using System;
using System.Collections.Generic;
using System.Linq; // Muy importante para que funcione el buscador
using System.Windows.Forms;
using PROYECTO_PR_BD_PE.CapaEntidades;
using PROYECTO_PR_BD_PE.CapaNegocio;

namespace PROYECTO_PR_BD_PE
{
    public partial class Form7GestionUsuario : Form
    {
        private CN_Usuario negocioUsuario = new CN_Usuario();

        // AGREGADO: Lista en memoria para buscar rápido sin trabar el programa
        private List<Usuario> listaOriginalUsuarios;

        public Form7GestionUsuario()
        {
            InitializeComponent();
        }

        private void Form7GestionUsuario_Load(object sender, EventArgs e)
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Usuario normal");
            cmbRol.Items.Add("Administrador");

            txtIdUsuario.ReadOnly = true;
            txtNombreCompleto.ReadOnly = true;

            CargarListaUsuarios();
        }

        private void CargarListaUsuarios()
        {
            // AGREGADO: Guardamos la lista en memoria
            listaOriginalUsuarios = negocioUsuario.Obtener();
            dgvUsuarios.DataSource = listaOriginalUsuarios;

            if (dgvUsuarios.Columns["Contraseña"] != null)
            {
                dgvUsuarios.Columns["Contraseña"].Visible = false;
            }
        }

        // AGREGADO: Este es el método que no encontrabas. 
        // (Haz doble clic en tu txtBuscar en la vista de diseño para enlazarlo)
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filtro))
            {
                dgvUsuarios.DataSource = listaOriginalUsuarios;
            }
            else
            {
                // Busca coincidencias uniendo el Nombre y Apellido
                var listaFiltrada = listaOriginalUsuarios
                    .Where(u => (u.Nombre + " " + u.Apellido).ToLower().Contains(filtro))
                    .ToList();

                dgvUsuarios.DataSource = listaFiltrada;
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                txtIdUsuario.Text = fila.Cells["IdUsuario"].Value?.ToString() ?? "";
                txtNombreCompleto.Text = (fila.Cells["Nombre"].Value?.ToString() ?? "") + " " +
                                       (fila.Cells["Apellido"].Value?.ToString() ?? "");

                string rolActual = fila.Cells["Rol"].Value?.ToString() ?? "";
                cmbRol.SelectedItem = rolActual;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdUsuario.Text))
            {
                MessageBox.Show("Por favor, selecciona un usuario de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un rol válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(txtIdUsuario.Text);
            string nuevoRol = cmbRol.SelectedItem.ToString();

            bool resultado = negocioUsuario.CambiarRol(id, nuevoRol);

            if (resultado)
            {
                MessageBox.Show("Rol actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListaUsuarios();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtIdUsuario.Clear();
            txtNombreCompleto.Clear();
            cmbRol.SelectedIndex = -1;

            // AGREGADO: Limpiar también el buscador
            if (txtBuscar != null) txtBuscar.Clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarListaUsuarios();
        }

        private void btnAtrasGU_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            // 1. Validamos que haya una fila seleccionada en la tabla (ajusta "dgvUsuarios" al nombre de tu DataGridView)
            if (dgvUsuarios.SelectedRows.Count > 0 || dgvUsuarios.CurrentRow != null)
            {
                // Extraemos el ID del usuario de la celda correspondiente 
                // (Ajusta "id_usuario" al nombre exacto de la columna en tu DataGridView o usa el índice numérico)
                int idSeleccionado = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["idusuario"].Value);

                // 2. Medida de seguridad: Bloquear auto-eliminación
                if (idSeleccionado == SesionActual.IdUsuario)
                {
                    MessageBox.Show("Por seguridad, no puedes eliminar tu propia cuenta de administrador desde este panel. Usa 'Mi Perfil'.", "Acción denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Confirmación
                DialogResult advertencia = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar permanentemente a este usuario del sistema?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (advertencia == DialogResult.Yes)
                {
                    // 4. Ejecutar el borrado en la base de datos
                    CN_Usuario negocioUsuario = new CN_Usuario();
                    bool eliminado = negocioUsuario.Eliminar(idSeleccionado);

                    if (eliminado)
                    {
                        MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 5. Refrescar la tabla para ocultar al usuario borrado
                        // CargarDatos(); // Reemplaza esto con el método que usas para llenar tu DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el usuario. Verifica la conexión o dependencias.", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}