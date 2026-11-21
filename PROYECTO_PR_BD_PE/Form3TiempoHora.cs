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
    public partial class Form3TiempoHora : Form
    {
        private Form menuprincipal;

        // TU CONSTRUCTOR ORIGINAL QUE RECIBE EL MENÚ
        public Form3TiempoHora(Form menu)
        {
            InitializeComponent();
            this.menuprincipal = menu;
        }

        // EVENTO QUE SE EJECUTA AL ABRIR LA VENTANA
        private void Form3TiempoHora_Load(object sender, EventArgs e)
        {
            CargarPronosticoPorHora();
        }

        // LÓGICA DE MACHINE LEARNING Y 5 BLOQUES
        private void CargarPronosticoPorHora()
        {
            try
            {
                CD_Lectura cdLectura = new CD_Lectura();
                CN_Pronostico cnPronostico = new CN_Pronostico();
                int idEstacionCentral = 1;

                List<DatosClimaHistorico> historial = cdLectura.ObtenerHistorialParaML(idEstacionCentral);
                DateTime fechaActual = DateTime.Now;
                CultureInfo culturaES = new CultureInfo("es-ES");

                if (historial.Count > 100)
                {
                    PrediccionClima pronostico = cnPronostico.GenerarPronostico(historial, 1);

                    if (pronostico.PronosticoTemperatura != null && pronostico.PronosticoTemperatura.Length >= 6)
                    {
                        // Bloque 1 (Próxima hora: índice 0)
                        LlenarBloqueHora(fechaActual.AddHours(1), 0, pronostico, culturaES,
                            lblFecha1, lblHora1, lblTemp1, lblHumedad1, lblMaxMin1, lblUV1, lblPresion1);

                        // Bloque 2 (En 2 horas: índice 1)
                        LlenarBloqueHora(fechaActual.AddHours(2), 1, pronostico, culturaES,
                            lblFecha2, lblHora2, lblTemp2, lblHumedad2, lblMaxMin2, lblUV2, lblPresion2);

                        // Bloque 3 (En 3 horas: índice 2)
                        LlenarBloqueHora(fechaActual.AddHours(3), 2, pronostico, culturaES,
                            lblFecha3, lblHora3, lblTemp3, lblHumedad3, lblMaxMin3, lblUV3, lblPresion3);

                        // Bloque 4 (En 4 horas: índice 3)
                        LlenarBloqueHora(fechaActual.AddHours(4), 3, pronostico, culturaES,
                            lblFecha4, lblHora4, lblTemp4, lblHumedad4, lblMaxMin4, lblUV4, lblPresion4);

                        // Bloque 5 (En 5 horas: índice 4)
                        LlenarBloqueHora(fechaActual.AddHours(5), 4, pronostico, culturaES,
                            lblFecha5, lblHora5, lblTemp5, lblHumedad5, lblMaxMin5, lblUV5, lblPresion5);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el pronóstico por hora: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // FUNCIÓN AUXILIAR PARA LLENAR TEXTOS Y APLICAR PROTECCIÓN (CLAMPING)
        private void LlenarBloqueHora(DateTime fechaHora, int indice, PrediccionClima pronostico, CultureInfo cultura,
            Label lblFecha, Label lblHora, Label lblTemp, Label lblHumedad, Label lblMaxMin, Label lblUV, Label lblPresion)
        {
            lblFecha.Text = cultura.TextInfo.ToTitleCase(fechaHora.ToString("dddd, dd 'de' MMMM", cultura));
            lblHora.Text = fechaHora.ToString("h tt", cultura).ToUpper();
            lblTemp.Text = $"{Math.Round(pronostico.PronosticoTemperatura[indice], 1)}° C";

            // Clamping para evitar lluvia negativa
            double humedad = Math.Max(0, Math.Min(100, pronostico.PronosticoHumedad[indice]));
            lblHumedad.Text = $"{Math.Round(humedad, 0)}%";

            lblMaxMin.Text = $"Max: {Math.Round(pronostico.PronosticoTemperatura[indice] + 2, 1)}° / Min: {Math.Round(pronostico.PronosticoTemperatura[indice] - 2, 1)}°";
            lblUV.Text = (fechaHora.Hour >= 18 || fechaHora.Hour <= 5) ? "Rayos UV: Nulo" : "Rayos UV: Alto";
            lblPresion.Text = "Presión: 1013 hPa";
        }

        // TUS EVENTOS ORIGINALES
        private void label7_Click(object sender, EventArgs e)
        {

        }

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