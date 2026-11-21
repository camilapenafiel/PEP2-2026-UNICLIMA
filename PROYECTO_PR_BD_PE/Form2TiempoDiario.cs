using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using PROYECTO_PR_BD_PE.CapaDatos;
using PROYECTO_PR_BD_PE.CapaEntidades;
using PROYECTO_PR_BD_PE.CapaNegocio;

namespace PROYECTO_PR_BD_PE
{
    public partial class Form2TiempoDiario : Form
    {
        private Form menuprincipal;

        public Form2TiempoDiario(Form menu)
        {
            InitializeComponent();
            this.menuprincipal = menu;
        }

        // Este evento se dispara cuando el formulario se abre
        private void Form2TiempoDiario_Load(object sender, EventArgs e)
        {
            CargarClimaYPronostico();
        }

        private void CargarClimaYPronostico()
        {
            try
            {
                CD_Lectura cdLectura = new CD_Lectura();
                CN_Pronostico cnPronostico = new CN_Pronostico();
                int idEstacionCentral = 1;

                // 1. OBTENEMOS EL CLIMA REAL DE HOY (DÍA 1)
                Lectura climaHoy = cdLectura.ObtenerUltimaLectura(idEstacionCentral);
                DateTime fechaActual = DateTime.Now;
                CultureInfo culturaES = new CultureInfo("es-ES");

                // --- LLENADO DEL BLOQUE 1 (HOY) ---
                lblTituloDia1.Text = $"{culturaES.TextInfo.ToTitleCase(fechaActual.ToString("ddd d", culturaES))} | Día";
                lblTituloNoche1.Text = $"{culturaES.TextInfo.ToTitleCase(fechaActual.ToString("ddd d", culturaES))} | Noche";

                lblTempDia1.Text = $"{Math.Round(climaHoy.Temperatura, 1)}° C";

                // Protección para el Día 1 (Por si el sensor falla)
                double humedadHoy = Math.Max(0, Math.Min(100, (double)climaHoy.Humedad));
                lblHumedadDia1.Text = $"{Math.Round(humedadHoy, 0)}%";

                lblMaxMinDia1.Text = $"{Math.Round(climaHoy.TempMax, 1)}° / {Math.Round(climaHoy.TempMin, 1)}°";

                lblTempNoche1.Text = $"{Math.Round(climaHoy.Temperatura - 5, 1)}° C";

                // Protección para la Noche 1
                double humedadNocheHoy = Math.Max(0, Math.Min(100, (double)climaHoy.Humedad + 10));
                lblHumedadNoche1.Text = $"{Math.Round(humedadNocheHoy, 0)}%";

                lblMaxMinNoche1.Text = lblMaxMinDia1.Text;
                lblUVDia1.Text = "UV: 6";
                lblUVNoche1.Text = "UV: 0";

                // 2. PRONÓSTICO PARA LOS PRÓXIMOS 5 DÍAS
                List<DatosClimaHistorico> historial = cdLectura.ObtenerHistorialParaML(idEstacionCentral);

                if (historial.Count > 100)
                {
                    PrediccionClima pronostico = cnPronostico.GenerarPronostico(historial, 5);

                    if (pronostico.PronosticoTemperatura != null && pronostico.PronosticoTemperatura.Length >= 120)
                    {
                        // --- BLOQUE 2 (MAÑANA) ---
                        LlenarBloquePronostico(fechaActual.AddDays(1), 24, pronostico, culturaES,
                            lblTituloDia2, lblTituloNoche2, lblTempDia2, lblHumedadDia2, lblMaxMinDia2,
                            lblTempNoche2, lblHumedadNoche2, lblMaxMinNoche2, lblUVDia2, lblUVNoche2);

                        // --- BLOQUE 3 ---
                        LlenarBloquePronostico(fechaActual.AddDays(2), 48, pronostico, culturaES,
                            lblTituloDia3, lblTituloNoche3, lblTempDia3, lblHumedadDia3, lblMaxMinDia3,
                            lblTempNoche3, lblHumedadNoche3, lblMaxMinNoche3, lblUVDia3, lblUVNoche3);

                        // --- BLOQUE 4 ---
                        LlenarBloquePronostico(fechaActual.AddDays(3), 72, pronostico, culturaES,
                            lblTituloDia4, lblTituloNoche4, lblTempDia4, lblHumedadDia4, lblMaxMinDia4,
                            lblTempNoche4, lblHumedadNoche4, lblMaxMinNoche4, lblUVDia4, lblUVNoche4);

                        // --- BLOQUE 5 ---
                        LlenarBloquePronostico(fechaActual.AddDays(4), 96, pronostico, culturaES,
                            lblTituloDia5, lblTituloNoche5, lblTempDia5, lblHumedadDia5, lblMaxMinDia5,
                            lblTempNoche5, lblHumedadNoche5, lblMaxMinNoche5, lblUVDia5, lblUVNoche5);

                        // --- BLOQUE 6 ---
                        LlenarBloquePronostico(fechaActual.AddDays(5), 119, pronostico, culturaES,
                            lblTituloDia6, lblTituloNoche6, lblTempDia6, lblHumedadDia6, lblMaxMinDia6,
                            lblTempNoche6, lblHumedadNoche6, lblMaxMinNoche6, lblUVDia6, lblUVNoche6);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error cargando el pronóstico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Función auxiliar corregida para evitar porcentajes negativos o mayores a 100
        private void LlenarBloquePronostico(DateTime fecha, int indice, PrediccionClima pronostico, CultureInfo cultura,
            Label titDia, Label titNoche, Label tempDia, Label humDia, Label maxMinDia,
            Label tempNoche, Label humNoche, Label maxMinNoche, Label uvDia, Label uvNoche)
        {
            titDia.Text = $"{cultura.TextInfo.ToTitleCase(fecha.ToString("ddd d", cultura))} | Día";
            titNoche.Text = $"{cultura.TextInfo.ToTitleCase(fecha.ToString("ddd d", cultura))} | Noche";

            tempDia.Text = $"{Math.Round(pronostico.PronosticoTemperatura[indice], 1)}° C";

            // CORRECCIÓN: Restringimos la humedad/probabilidad del día entre 0 y 100
            double humedadDia = Math.Max(0, Math.Min(100, pronostico.PronosticoHumedad[indice]));
            humDia.Text = $"{Math.Round(humedadDia, 0)}%";

            maxMinDia.Text = $"{Math.Round(pronostico.PronosticoTemperatura[indice] + 3, 1)}° / {Math.Round(pronostico.PronosticoTemperatura[indice] - 4, 1)}°";

            tempNoche.Text = $"{Math.Round(pronostico.PronosticoTemperatura[indice] - 5, 1)}° C";

            // CORRECCIÓN: Restringimos la humedad/probabilidad de la noche entre 0 y 100
            double humedadNoche = Math.Max(0, Math.Min(100, pronostico.PronosticoHumedad[indice] + 10));
            humNoche.Text = $"{Math.Round(humedadNoche, 0)}%";

            maxMinNoche.Text = maxMinDia.Text;
            uvDia.Text = "UV: 6";
            uvNoche.Text = "UV: 0";
        }

        // TUS BOTONES ORIGINALES
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTempDia2_Click(object sender, EventArgs e)
        {

        }
    }
}