using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace PROYECTO_PR_BD_PE
{
    public partial class Form9Reportes : Form
    {
        // Declaramos el visor por código para evitar bugs del diseñador
        private Microsoft.Reporting.WinForms.ReportViewer visorReporte;

        public Form9Reportes()
        {
            InitializeComponent();

            visorReporte = new Microsoft.Reporting.WinForms.ReportViewer();
            visorReporte.Location = new System.Drawing.Point(525, 140);
            visorReporte.Size = new System.Drawing.Size(610, 550);
            visorReporte.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(visorReporte);
            visorReporte.BringToFront();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (cmbTipoReporte.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el tipo de reporte en el filtro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaInicio = dtpInicio.Value.Date;
            DateTime fechaFin = dtpFin.Value.Date.AddDays(1).AddTicks(-1);

            string querySQL = "";
            string archivoRDLC = "";
            string nombreDataSetRDLC = "";

            switch (cmbTipoReporte.SelectedItem.ToString())
            {
                case "Histórico General":
                    querySQL = @"
                        SELECT 
                            CAST(m.fecha_hora AS DATE) AS Fecha,
                            AVG(CASE WHEN v.nombre = 'Temperatura' THEN m.valor END) AS TempPromedio,
                            AVG(CASE WHEN v.nombre = 'Humedad' THEN m.valor END) AS HumedadPromedio,
                            
                            CASE WHEN COALESCE(SUM(CASE WHEN v.nombre = 'Precipitacion' THEN m.valor END), 0) = 0 
                                 THEN 1 ELSE 0 END AS DiasSoleados, 
                                 
                            CASE WHEN COALESCE(SUM(CASE WHEN v.nombre = 'Precipitacion' THEN m.valor END), 0) > 0 
                                 THEN 1 ELSE 0 END AS DiasLluvia 
                                 
                        FROM dbo.mediciones m
                        INNER JOIN dbo.variables_meteorologicas v ON m.id_variable = v.id_variable
                        WHERE m.fecha_hora BETWEEN @Inicio AND @Fin
                        GROUP BY CAST(m.fecha_hora AS DATE)
                        ORDER BY CAST(m.fecha_hora AS DATE) ASC";
                    archivoRDLC = "RepHistorico.rdlc";
                    nombreDataSetRDLC = "DS_Historico";
                    break;

                case "Comparativo de Estaciones":
                    querySQL = @"
                        SELECT 
                            e.nombre AS NombreEstacion,
                            MAX(CASE WHEN v.nombre = 'Temperatura' THEN m.valor END) AS TempMaxima,
                            MIN(CASE WHEN v.nombre = 'Temperatura' THEN m.valor END) AS TempMinima,
                            SUM(CASE WHEN v.nombre = 'Precipitacion' THEN m.valor END) AS LluviaTotal
                        FROM dbo.estaciones_meteorologicas e
                        LEFT JOIN dbo.sensores s ON e.id_estacion = s.id_estacion
                        LEFT JOIN dbo.mediciones m ON s.id_sensor = m.id_sensor 
                            AND m.fecha_hora BETWEEN @Inicio AND @Fin
                        LEFT JOIN dbo.variables_meteorologicas v ON m.id_variable = v.id_variable
                        GROUP BY e.nombre";
                    archivoRDLC = "RepComparativo.rdlc";
                    nombreDataSetRDLC = "DS_Comparativo";
                    break;

                case "Alertas Climatológicas":
                    querySQL = @"
                        SELECT 
                            a.fecha_hora AS FechaAlerta,
                            e.nombre AS Estacion,
                            ta.nivel_severidad AS TipoAlerta,
                            a.mensaje AS ValorCritico
                        FROM dbo.alertas_meteorologicas a
                        INNER JOIN dbo.estaciones_meteorologicas e ON a.id_estacion = e.id_estacion
                        INNER JOIN dbo.tipos_alerta ta ON a.id_tipo_alerta = ta.id_tipo_alerta
                        WHERE a.fecha_hora BETWEEN @Inicio AND @Fin";
                    archivoRDLC = "RepAlertas.rdlc";
                    nombreDataSetRDLC = "DS_Alertas";
                    break;

                case "Tendencias Mensuales":
                    querySQL = @"
                        SELECT 
                            MONTH(m.fecha_hora) AS Mes,
                            YEAR(m.fecha_hora) AS Año,
                            AVG(CASE WHEN v.nombre = 'Temperatura' THEN m.valor END) AS TempPromedioMensual,
                            SUM(CASE WHEN v.nombre = 'Precipitacion' THEN m.valor END) AS TotalPrecipitacion
                        FROM dbo.mediciones m
                        INNER JOIN dbo.variables_meteorologicas v ON m.id_variable = v.id_variable
                        WHERE m.fecha_hora BETWEEN @Inicio AND @Fin
                        GROUP BY YEAR(m.fecha_hora), MONTH(m.fecha_hora)";
                    archivoRDLC = "RepTendencias.rdlc";
                    nombreDataSetRDLC = "DS_Tendencias";
                    break;

                case "Mantenimiento IoT":
                    querySQL = @"
                        SELECT 
                            e.nombre AS Estacion,
                            MAX(m.fecha_hora) AS UltimaConexion,
                            'Operativo' AS EstadoSensores
                        FROM dbo.estaciones_meteorologicas e
                        LEFT JOIN dbo.sensores s ON e.id_estacion = s.id_estacion
                        LEFT JOIN dbo.mediciones m ON s.id_sensor = m.id_sensor
                        GROUP BY e.nombre";
                    archivoRDLC = "RepMantenimiento.rdlc";
                    nombreDataSetRDLC = "DS_Mantenimiento";
                    break;
            }

            string cadenaConexion = @"Data Source=sql5113.site4now.net;Initial Catalog=db_acf741_uniclimadb;User Id=db_acf741_uniclimadb_admin;Password=135abg99N@;Encrypt=True;TrustServerCertificate=True;";
            DataTable dtResultados = new DataTable();

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand comando = new SqlCommand(querySQL, conexion))
                    {
                        comando.Parameters.AddWithValue("@Inicio", fechaInicio);
                        comando.Parameters.AddWithValue("@Fin", fechaFin);

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            conexion.Open();
                            adaptador.Fill(dtResultados);
                        }
                    }
                }

                visorReporte.LocalReport.ReportPath = archivoRDLC;
                visorReporte.LocalReport.DataSources.Clear();
                visorReporte.LocalReport.DataSources.Add(new ReportDataSource(nombreDataSetRDLC, dtResultados));
                visorReporte.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            // 1. Validar que ya exista un reporte generado en el visor
            if (string.IsNullOrEmpty(visorReporte.LocalReport.ReportPath))
            {
                MessageBox.Show("Primero debes generar un reporte antes de exportarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Abrir la ventana para que el usuario elija dónde guardar el archivo
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                sfd.Title = "Guardar reporte como Excel";

                // Sugerimos un nombre de archivo automático con la fecha de hoy
                string nombreReporte = cmbTipoReporte.SelectedItem != null ? cmbTipoReporte.SelectedItem.ToString().Replace(" ", "") : "Reporte";
                sfd.FileName = $"{nombreReporte}_{DateTime.Now:yyyyMMdd}";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // 3. Renderizar el reporte a formato Excel (EXCELOPENXML)
                    Microsoft.Reporting.WinForms.Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string extension;

                    byte[] bytes = visorReporte.LocalReport.Render(
                        "EXCELOPENXML", null, out mimeType, out encoding, out extension,
                        out streamids, out warnings);

                    // 4. Guardar los bytes renderizados en el disco duro
                    System.IO.File.WriteAllBytes(sfd.FileName, bytes);

                    MessageBox.Show("Reporte exportado exitosamente.", "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(visorReporte.LocalReport.ReportPath))
            {
                MessageBox.Show("Primero debes generar un reporte antes de exportarlo.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Archivo PDF (.pdf)|.pdf";
                sfd.Title = "Guardar reporte como PDF";

                string nombreReporte = cmbTipoReporte.SelectedItem != null
                    ? cmbTipoReporte.SelectedItem.ToString().Replace(" ", "")
                    : "Reporte";

                sfd.FileName = $"{nombreReporte}_{DateTime.Now:yyyyMMdd}";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Reporting.WinForms.Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string extension;

                    byte[] bytes = visorReporte.LocalReport.Render(
                        "PDF", null, out mimeType, out encoding, out extension,
                        out streamids, out warnings);

                    System.IO.File.WriteAllBytes(sfd.FileName, bytes);

                    MessageBox.Show("Reporte PDF exportado exitosamente.",
                        "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a PDF: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}