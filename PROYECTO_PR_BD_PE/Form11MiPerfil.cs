using System;
using System.Windows.Forms;
using PROYECTO_PR_BD_PE.CapaEntidades;
using PROYECTO_PR_BD_PE.CapaNegocio;
using PROYECTO_PR_BD_PE.Utils;

namespace PROYECTO_PR_BD_PE
{
    public partial class Form11MiPerfil : Form
    {
        private CN_Usuario negocioUsuario = new CN_Usuario();
        private Usuario usuarioActualCompleto = null;

        public Form11MiPerfil()
        {
            InitializeComponent();
        }

        private void Form11MiPerfil_Load(object sender, EventArgs e)
        {
            txtNombreApellido.ReadOnly = true;
            txtNickname.ReadOnly = true;
            txtActualizarCorreo.ReadOnly = true;
            txtContrasenaPerfil.ReadOnly = true;
            txtApellidoPerfil.ReadOnly = true;

            var listaUsuarios = negocioUsuario.Obtener();
            foreach (var u in listaUsuarios)
            {
                if (u.IdUsuario == SesionActual.IdUsuario)
                {
                    usuarioActualCompleto = u;
                    break;
                }
            }

            if (usuarioActualCompleto != null)
            {
                txtNombreApellido.Text = usuarioActualCompleto.Nombre;
                txtNickname.Text = usuarioActualCompleto.Apellido; // Ojo aquí si tu apellido va en txtApellidoPerfil
                txtNickname.Text = usuarioActualCompleto.Nickname;
                txtActualizarCorreo.Text = usuarioActualCompleto.Correo;
                txtContrasenaPerfil.Text = "";
                txtApellidoPerfil.Text = usuarioActualCompleto.Apellido;
            }
        }

        private void btnActualizarNombre_Click(object sender, EventArgs e)
        {
            txtNombreApellido.ReadOnly = false;
            txtNombreApellido.Focus();
            txtApellidoPerfil.ReadOnly = false;
            txtApellidoPerfil.Focus();
        }

        private void btnActualizarNickname_Click(object sender, EventArgs e)
        {
            txtNickname.ReadOnly = false;
            txtNickname.Focus();
        }

        private void btnActualizarCorreo_Click(object sender, EventArgs e)
        {
            txtActualizarCorreo.ReadOnly = false;
            txtActualizarCorreo.Focus();
        }

        private void btnActualizarContrasena_Click(object sender, EventArgs e)
        {
            txtContrasenaPerfil.ReadOnly = false;
            txtContrasenaPerfil.Focus();
        }

        private void btnCancelarPerfil_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmarPerfil_Click(object sender, EventArgs e)
        {
            if (usuarioActualCompleto == null) return;

            if (string.IsNullOrWhiteSpace(txtNombreApellido.Text) || string.IsNullOrWhiteSpace(txtActualizarCorreo.Text))
            {
                MessageBox.Show("El nombre y el correo no pueden estar vacíos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usuarioActualizado = new Usuario()
            {
                IdUsuario = SesionActual.IdUsuario,
                Nombre = txtNombreApellido.Text.Trim(),
                Apellido = txtApellidoPerfil.Text.Trim(),
                Nickname = txtNickname.Text.Trim(),
                Correo = txtActualizarCorreo.Text.Trim()
            };

            if (!string.IsNullOrWhiteSpace(txtContrasenaPerfil.Text))
            {
                usuarioActualizado.Contraseña = PasswordHasher.HashPassword(txtContrasenaPerfil.Text.Trim());
            }
            else
            {
                usuarioActualizado.Contraseña = usuarioActualCompleto.Contraseña;
            }

            // CORRECCIÓN AQUÍ: Pasamos el parámetro 'out string mensaje' que tu Capa de Negocio exige obligatoriamente
            string mensajeError = "";
            bool actualizado = negocioUsuario.ActualizarPerfil(usuarioActualizado, out mensajeError);

            if (actualizado)
            {
                SesionActual.Nombre = usuarioActualizado.Nombre;
                SesionActual.Nickname = usuarioActualizado.Nickname;
                MessageBox.Show("Tu perfil se ha actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(string.IsNullOrEmpty(mensajeError) ? "No se pudo actualizar el perfil. Verifica los datos." : mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            DialogResult advertencia = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar tu cuenta de forma permanente?\n\nEsta acción borrará todos tus datos y no se puede deshacer.",
                "Peligro: Eliminar Cuenta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (advertencia == DialogResult.Yes)
            {
                // Verificamos si el método de eliminar de tu capa de negocio usa IdUsuario o requiere otro parámetro
                bool eliminado = negocioUsuario.Eliminar(SesionActual.IdUsuario);

                if (eliminado)
                {
                    MessageBox.Show("Tu cuenta ha sido eliminada exitosamente. Esperamos verte pronto.", "Despedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SesionActual.IdUsuario = 0;
                    SesionActual.Nombre = "";
                    SesionActual.Nickname = "";
                    SesionActual.Rol = "";

                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la cuenta. Verifica la conexión a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}