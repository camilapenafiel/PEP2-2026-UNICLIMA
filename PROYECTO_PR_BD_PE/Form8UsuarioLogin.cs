using System;
using System.Windows.Forms;
using PROYECTO_PR_BD_PE.CapaEntidades;
using PROYECTO_PR_BD_PE.CapaNegocio;
using PROYECTO_PR_BD_PE.Utils;

namespace PROYECTO_PR_BD_PE
{
    public partial class Form8UsuarioLogin : Form
    {
        private CN_Usuario negocioUsuario = new CN_Usuario();

        public Form8UsuarioLogin()
        {
            InitializeComponent();
        }

        private void btnIngresarLogin_Click(object sender, EventArgs e)
        {
            string correo = txtCorreoLogin.Text.Trim();
            string pass = txtContrasenaLogin.Text;

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Por favor, ingrese el correo y la contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usuario = negocioUsuario.ObtenerPorCorreo(correo);

            if (usuario != null && PasswordHasher.VerifyPassword(pass, usuario.Contraseña))
            {
                // Guardar datos en la sesión global (Paso 3 integrado)
                SesionActual.IdUsuario = usuario.IdUsuario;
                SesionActual.Nombre = usuario.Nombre;
                SesionActual.Nickname = string.IsNullOrWhiteSpace(usuario.Nickname) ? usuario.Nombre : usuario.Nickname;
                SesionActual.Rol = usuario.Rol;

                MessageBox.Show($"Bienvenido, {usuario.Nombre}\nRol: {usuario.Rol}", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasenaLogin.Clear();
                txtContrasenaLogin.Focus();
            }
        }

        private void btsSalirLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            Form5UsuariosRegistro registro = new Form5UsuariosRegistro();
            registro.ShowDialog();

            this.Show();
        }

        private void lnkOlvidaste_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            Form10LoginOlvido contrasena = new Form10LoginOlvido();
            contrasena.ShowDialog();

            this.Show();
        }

        private void txtContrasenaLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}