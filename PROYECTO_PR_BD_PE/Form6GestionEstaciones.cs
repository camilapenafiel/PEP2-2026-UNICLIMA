using PROYECTO_PR_BD_PE.CapaDatos;
using PROYECTO_PR_BD_PE.CapaEntidades;
using PROYECTO_PR_BD_PE.CapaNegocio;
using System;
using System.Windows.Forms;

namespace PROYECTO_PR_BD_PE
{
    public partial class Form6GestionEstaciones : Form
    {
        private CN_EstacionMeteorologica negocioEstacion = new CN_EstacionMeteorologica();
        private CN_Ubicacion negocioUbicacion = new CN_Ubicacion(); // Se usa CN_Ubicacion tal como figura en tu carpeta CapaNegocio

        public Form6GestionEstaciones()
        {
            InitializeComponent();
        }

        private void Form6GestionEstaciones_Load(object sender, EventArgs e)
        {
            // Opciones visuales para el estado
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Activa");
            cmbEstado.Items.Add("Mantenimiento");
            cmbEstado.SelectedIndex = 0;

            CargarUbicaciones();
            CargarEstaciones();
        }

        private void CargarUbicaciones()
        {
            // Llena el ComboBox desde la tabla ubicaciones de SQL Server
            cmbUbicacion.DataSource = negocioUbicacion.Obtener();
            cmbUbicacion.DisplayMember = "Ciudad";
            cmbUbicacion.ValueMember = "IdUbicacion";
        }

        private void CargarEstaciones()
        {
            // Operación OBTENER (SELECT)
            dgvEstaciones.DataSource = negocioEstacion.Obtener();

            // Ocultamos la columna del ID de ubicación numérico para mostrar únicamente el nombre
            if (dgvEstaciones.Columns["IdUbicacion"] != null)
            {
                dgvEstaciones.Columns["IdUbicacion"].Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreEstacion.Text))
            {
                MessageBox.Show("Por favor, ingresa el nombre de la estación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbUbicacion.SelectedValue == null)
            {
                MessageBox.Show("Selecciona una ubicación válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Operación CREAR (INSERT)
            EstacionMeteorologica nueva = new EstacionMeteorologica()
            {
                Nombre = txtNombreEstacion.Text.Trim(),
                IdUbicacion = Convert.ToInt32(cmbUbicacion.SelectedValue)
            };

            bool exito = negocioEstacion.Crear(nueva);

            if (exito)
            {
                MessageBox.Show("Estación meteorológica registrada con éxito.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarEstaciones();
            }
            else
            {
                MessageBox.Show("Error al guardar la estación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombreEstacion.Clear();
            txtModelo.Clear();
            if (cmbUbicacion.Items.Count > 0) cmbUbicacion.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
        }

        private void btnAtrasGE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}