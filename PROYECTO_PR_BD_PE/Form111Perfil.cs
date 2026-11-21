using System;
using System.Windows.Forms;
using PROYECTO_PR_BD_PE.CapaEntidades;
using PROYECTO_PR_BD_PE.CapaNegocio;
using PROYECTO_PR_BD_PE.Utils;

namespace PROYECTO_PR_BD_PE
{
    public partial class Form111Perfil : Form
    {
        private CN_Usuario negocioUsuario = new CN_Usuario();

        private Usuario usuarioActualCompleto = null;

        public Form111Perfil()
        {
            InitializeComponent();

            this.Load += Form111Perfil_Load;

        }

        private void Form111Perfil_Load(object sender, EventArgs e)
        {
            // Los campos sensibles comienzan vacíos.
            txtEmailAp.Clear();
            txtEmailNp.Clear();
            txtContraAp.Clear();
            txtContraNp.Clear();

            txtNombreP.ReadOnly = false;
            txtApellidoP.ReadOnly = false;
            txtNickP.ReadOnly = false;

            // Buscamos los datos del usuario que inició sesión.
            var listaUsuarios = negocioUsuario.Obtener();

            foreach (var usuario in listaUsuarios)
            {
                if (usuario.IdUsuario == SesionActual.IdUsuario)
                {
                    usuarioActualCompleto = usuario;
                    break;
                }
            }

            // Cargamos solamente los datos personales.
            if (usuarioActualCompleto != null)
            {
                txtNombreP.Text = usuarioActualCompleto.Nombre;
                txtApellidoP.Text = usuarioActualCompleto.Apellido;
                txtNickP.Text = usuarioActualCompleto.Nickname;
            }
            else
            {
                MessageBox.Show(
                    "No se pudieron cargar los datos del perfil.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnGuardarP_Click(object sender, EventArgs e)
        {
            if (usuarioActualCompleto == null)
            {
                MessageBox.Show("No se encontraron los datos del usuario.");
                return;
            }

            // 1. Validar datos personales
            if (string.IsNullOrWhiteSpace(txtNombreP.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoP.Text) ||
                string.IsNullOrWhiteSpace(txtNickP.Text))
            {
                MessageBox.Show("Nombre, apellido y nickname son obligatorios.");
                return;
            }

            // 2. Conservar los datos actuales
            string correoFinal = usuarioActualCompleto.Correo;
            string contrasenaFinal = usuarioActualCompleto.Contraseña;

            // 3. CAMBIO DE CORREO
            bool quiereCambiarCorreo =
                !string.IsNullOrWhiteSpace(txtEmailAp.Text) ||
                !string.IsNullOrWhiteSpace(txtEmailNp.Text);

            if (quiereCambiarCorreo)
            {
                if (string.IsNullOrWhiteSpace(txtEmailAp.Text) ||
                    string.IsNullOrWhiteSpace(txtEmailNp.Text))
                {
                    MessageBox.Show("Completa el correo actual y el nuevo correo.");
                    return;
                }

                if (!txtEmailAp.Text.Trim().Equals(
                    usuarioActualCompleto.Correo,
                    StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("El correo actual no coincide.");
                    return;
                }

                correoFinal = txtEmailNp.Text.Trim();



                if (negocioUsuario.ExisteCorreo(correoFinal, SesionActual.IdUsuario))
                {
                    MessageBox.Show(
     "Este correo electrónico ya está asociado a otra cuenta. Por favor, introduce uno diferente.",
     "Correo no disponible",
     MessageBoxButtons.OK,
     MessageBoxIcon.Warning
 );
                    return;
                }
            }

            // 4. CAMBIO DE CONTRASEÑA
            bool quiereCambiarContrasena =
                !string.IsNullOrEmpty(txtContraAp.Text) ||
                !string.IsNullOrEmpty(txtContraNp.Text);

            if (quiereCambiarContrasena)
            {
                if (string.IsNullOrEmpty(txtContraAp.Text) ||
                    string.IsNullOrEmpty(txtContraNp.Text))
                {
                    MessageBox.Show("Completa la contraseña actual y la nueva.");
                    return;
                }

                if (!PasswordHasher.VerifyPassword(
                    txtContraAp.Text,
                    usuarioActualCompleto.Contraseña))
                {
                    MessageBox.Show("La contraseña actual es incorrecta.");
                    return;
                }

                if (txtContraNp.Text.Length < 8 ||
    !System.Text.RegularExpressions.Regex.IsMatch(
        txtContraNp.Text, @"^(?=.*[A-Z])(?=.*\d).{8,}$"))
                {
                    MessageBox.Show(
                        "La nueva contraseña debe tener al menos 8 caracteres, una mayúscula y un número.");
                    return;
                }

                contrasenaFinal = PasswordHasher.HashPassword(txtContraNp.Text);
            }

            // 5. Preparar usuario actualizado
            Usuario usuarioActualizado = new Usuario()
            {
                IdUsuario = SesionActual.IdUsuario,
                Nombre = txtNombreP.Text.Trim(),
                Apellido = txtApellidoP.Text.Trim(),
                Nickname = txtNickP.Text.Trim(),
                Correo = correoFinal,
                Contraseña = contrasenaFinal
            };

            // 6. Guardar en SQL Server
            string mensaje;

            bool actualizado = negocioUsuario.ActualizarPerfil(
                usuarioActualizado,
                out mensaje
            );

            if (actualizado)
            {
                usuarioActualCompleto.Nombre = usuarioActualizado.Nombre;
                usuarioActualCompleto.Apellido = usuarioActualizado.Apellido;
                usuarioActualCompleto.Nickname = usuarioActualizado.Nickname;
                usuarioActualCompleto.Correo = usuarioActualizado.Correo;
                usuarioActualCompleto.Contraseña = usuarioActualizado.Contraseña;

                SesionActual.Nombre = usuarioActualizado.Nombre;
                SesionActual.Nickname = usuarioActualizado.Nickname;

                txtEmailAp.Clear();
                txtEmailNp.Clear();
                txtContraAp.Clear();
                txtContraNp.Clear();

                MessageBox.Show(
                    "¡Tu perfil se actualizó correctamente!",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarP_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
        "¿Estás seguro de que deseas eliminar tu cuenta? Esta acción no se puede deshacer.",
        "Confirmar eliminación",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
    );

            if (resultado != DialogResult.Yes)
            {
                return;
            }

            bool eliminado = negocioUsuario.Eliminar(SesionActual.IdUsuario);

            if (eliminado)
            {
                MessageBox.Show(
                    "Tu cuenta ha sido eliminada correctamente.",
                    "Cuenta eliminada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                SesionActual.IdUsuario = 0;
                SesionActual.Nombre = "";
                SesionActual.Nickname = "";
                SesionActual.Rol = "";

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo eliminar la cuenta. Inténtalo nuevamente.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }

        private void btnVolverP_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}