using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using PROYECTO_PR_BD_PE.CapaDatos;
using PROYECTO_PR_BD_PE.CapaEntidades;

// Importaciones necesarias para LiveCharts2
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;

namespace PROYECTO_PR_BD_PE
{
    public partial class Form4Metricas : Form
    {
        private Form menuprincipal;

        private CartesianChart chartDinamico;
        private List<DatosClimaHistorico> ultimosRegistros;

        public Form4Metricas(Form menu)
        {
            InitializeComponent();
            this.menuprincipal = menu;

            // Enlaza el evento de carga forzosamente para que inicie al abrir la ventana
            this.Load += Form4Metricas_Load;
        }

        private void Form4Metricas_Load(object sender, EventArgs e)
        {
            chartDinamico = new CartesianChart
            {
                Dock = DockStyle.Fill
            };

            panelGrafico.Controls.Add(chartDinamico);

            CargarDatosBD();
            ActualizarTextosUI(); // LLAMAMOS A LA FUNCIÓN QUE LLENA LOS TEXTOS (Presión, etc)
            ActualizarGrafica("Temperatura");
        }

        private void CargarDatosBD()
        {
            try
            {
                CD_Lectura cdLectura = new CD_Lectura();
                List<DatosClimaHistorico> historial = cdLectura.ObtenerHistorialParaML(1);

                if (historial != null && historial.Count > 0)
                {
                    // AQUÍ ESTÁ EL SALTO DE 12 EN 12 HORAS
                    var historialCada12h = new List<DatosClimaHistorico>();
                    for (int i = 0; i < historial.Count; i += 12)
                    {
                        historialCada12h.Add(historial[i]);
                    }

                    // Tomamos los últimos 15 registros de esa nueva lista filtrada
                    ultimosRegistros = historialCada12h.Skip(Math.Max(0, historialCada12h.Count - 15)).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos desde la base de datos: " + ex.Message);
            }
        }

        private void ActualizarTextosUI()
        {
            if (ultimosRegistros != null && ultimosRegistros.Count > 0)
            {
                // Obtenemos el registro más reciente para los textos fijos
                var ultimo = ultimosRegistros.Last();

                lblValorTemp.Text = $"{Math.Round(ultimo.Temperatura, 1)}° C";
                lblValorHumedad.Text = $"{Math.Round(ultimo.Humedad, 0)} %";

                // Estos valores quedan fijos a menos que los tengas en la base de datos
                lblValorUV.Text = "4";
                lblValorPresion.Text = "1013 hPa";
            }
        }

        private void ActualizarGrafica(string tipoMetrica)
        {
            if (ultimosRegistros == null || ultimosRegistros.Count == 0) return;

            double[] valores = new double[0];
            string titulo = "";
            SKColor colorLinea = SKColors.Blue;

            switch (tipoMetrica)
            {
                case "Temperatura":
                    valores = ultimosRegistros.Select(x => (double)x.Temperatura).ToArray();
                    titulo = "Sensación Térmica (°C)";
                    colorLinea = SKColors.OrangeRed;
                    break;
                case "Humedad":
                    valores = ultimosRegistros.Select(x => (double)x.Humedad).ToArray();
                    titulo = "Humedad (%)";
                    colorLinea = SKColors.DodgerBlue;
                    break;
                case "UV":
                    valores = ultimosRegistros.Select(x => 4.0).ToArray();
                    titulo = "Índice UV";
                    colorLinea = SKColors.Gold;
                    break;
                case "Presion":
                    valores = ultimosRegistros.Select(x => 1013.0).ToArray();
                    titulo = "Presión Atmosférica (hPa)";
                    colorLinea = SKColors.SlateGray;
                    break;
            }

            chartDinamico.Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = valores,
                    Name = titulo,
                    GeometrySize = 10,
                    Stroke = new SolidColorPaint(colorLinea) { StrokeThickness = 3 },
                    Fill = new SolidColorPaint(colorLinea.WithAlpha(50))
                }
            };

            chartDinamico.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = ultimosRegistros.Select(x => x.FechaHora.ToString("dd/MMM HH:mm")).ToArray(),
                    LabelsRotation = 45
                }
            };

            // Actualizamos el resumen estadístico y de probabilidad según la métrica activa
            if (lblEstadisticaClima != null)
            {
                lblEstadisticaClima.Text = GenerarResumenEstadistico(valores, tipoMetrica);
            }
        }

        private string GenerarResumenEstadistico(double[] datos, string tipoMetrica)
        {
            List<double> lista = datos?
                .Where(d => !double.IsNaN(d) && !double.IsInfinity(d))
                .ToList() ?? new List<double>();

            if (lista.Count == 0)
            {
                return "Aún no hay suficientes registros recientes para mostrar este resumen.";
            }

            int n = lista.Count;
            double promedio = lista.Average();
            double minimo = lista.Min();
            double maximo = lista.Max();

            // Desviación estándar muestral (s) usando n - 1 cuando hay más de 1 dato
            double desviacion = 0;
            if (n > 1)
            {
                double sumaCuadrados = lista.Sum(x => Math.Pow(x - promedio, 2));
                desviacion = Math.Sqrt(sumaCuadrados / (n - 1));
            }

            double limInferior = promedio - desviacion;
            double limSuperior = promedio + desviacion;
            CultureInfo cultura = new CultureInfo("es-ES");

            if (tipoMetrica == "Humedad")
            {
                double umbralHumedad = 70.0;
                double probHumedadAlta = (lista.Count(x => x >= umbralHumedad) * 100.0) / n;

                double infRed = Math.Max(0, Math.Round(limInferior, 0));
                double supRed = Math.Min(100, Math.Round(limSuperior, 0));
                double promRed = Math.Round(promedio, 0);
                double minRed = Math.Round(minimo, 0);
                double maxRed = Math.Round(maximo, 0);
                double probRed = Math.Round(probHumedadAlta, 0);

                return $"La mayoría de los registros recientes de humedad estuvieron entre {infRed.ToString(cultura)}% y {supRed.ToString(cultura)}%.\n" +
        $"Valor habitual: {promRed.ToString(cultura)}% (mín. {minRed.ToString(cultura)}% / máx. {maxRed.ToString(cultura)}%) · " +
        $"Posibilidad de humedad alta (70% o más): {probRed.ToString(cultura)}%.";
            }

            if (tipoMetrica == "UV")
            {
                double promRed = Math.Round(promedio, 1);
                return $"En los registros mostrados, el índice UV se mantuvo en {promRed.ToString("0.0", cultura)} (sin variación en esta serie).";
            }

            if (tipoMetrica == "Presion")
            {
                double promRed = Math.Round(promedio, 0);
                return $"En los registros mostrados, la presión atmosférica se mantuvo en {promRed.ToString(cultura)} hPa (sin variación en esta serie).";
            }

            // Por defecto: Temperatura ("Sensación Térmica") con umbral de calor alto en 28° C
            double umbralCalor = 28.0;
            double probCalorAlto = (lista.Count(x => x >= umbralCalor) * 100.0) / n;

            double infTemp = Math.Round(limInferior, 1);
            double supTemp = Math.Round(limSuperior, 1);
            double promTemp = Math.Round(promedio, 1);
            double minTemp = Math.Round(minimo, 1);
            double maxTemp = Math.Round(maximo, 1);
            double probCalorRed = Math.Round(probCalorAlto, 0);

            return $"La mayoría de los registros recientes de temperatura estuvieron entre {infTemp.ToString("0.0", cultura)}° C y {supTemp.ToString("0.0", cultura)}° C.\n" +
       $"Valor habitual: {promTemp.ToString("0.0", cultura)}° C (mín. {minTemp.ToString("0.0", cultura)}° C / máx. {maxTemp.ToString("0.0", cultura)}° C) · " +
       $"Posibilidad de calor alto (28° C o más): {probCalorRed.ToString(cultura)}%.";
        }

        // --- EVENTOS LISTOS PARA ASOCIAR CON EL RAYITO ---

        public void btnVerGraficaTemp_Click(object sender, EventArgs e)
        {
            ActualizarGrafica("Temperatura");
        }

        public void btnVerGraficaHumedad_Click(object sender, EventArgs e)
        {
            ActualizarGrafica("Humedad");
        }

        public void btnVerGraficaUV_Click(object sender, EventArgs e)
        {
            ActualizarGrafica("UV");
        }

        public void btnVerGraficaPresion_Click(object sender, EventArgs e)
        {
            ActualizarGrafica("Presion");
        }

        // --- TUS BOTONES ORIGINALES ---
        private void button1_Click(object sender, EventArgs e)
        {
            menuprincipal.StartPosition = FormStartPosition.Manual;
            menuprincipal.Location = this.Location;
            menuprincipal.Size = this.Size;
            menuprincipal.WindowState = this.WindowState;
            menuprincipal.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}