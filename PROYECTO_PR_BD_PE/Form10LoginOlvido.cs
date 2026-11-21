using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_PR_BD_PE.CapaEntidades;
using PROYECTO_PR_BD_PE.CapaNegocio;
using PROYECTO_PR_BD_PE.Utils;

namespace PROYECTO_PR_BD_PE
{
    public partial class Form10LoginOlvido : Form
    {
        private CN_Usuario negocioUsuario = new CN_Usuario();
        private Usuario usuarioEncontrado = null;

        public Form10LoginOlvido()
        {
            InitializeComponent();
        }

        private void txtCorreoOlvido_Leave(object sender, EventArgs e)
        {
            string correo = txtCorreoOlvido.Text.Trim();
            if (!string.IsNullOrWhiteSpace(correo))
            {
                usuarioEncontrado = negocioUsuario.ObtenerPorCorreo(correo);

                if (usuarioEncontrado != null && !string.IsNullOrEmpty(usuarioEncontrado.PreguntaSeguridad))
                {
                    lblPreguntaOlvido.Text = usuarioEncontrado.PreguntaSeguridad;
                }
                else
                {
                    lblPreguntaOlvido.Text = "------PREGUNTA DE SEGURIDAD------";
                }
            }
        }

        private void btnConfirmarOlvido_Click(object sender, EventArgs e)
        {
            if (usuarioEncontrado == null)
            {
                MessageBox.Show("El correo ingresado no está registrado en el sistema.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNuevaContrasena.Text) || txtNuevaContrasena.Text != txtNuevaContrasena2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden o están vacías.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpFechaOlvido.Value.Date != usuarioEncontrado.FechaNacimiento.Date)
            {
                MessageBox.Show("La fecha de nacimiento no coincide con nuestros registros.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!txtRespuestaOlvido.Text.Trim().Equals(usuarioEncontrado.RespuestaSeguridad, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("La respuesta de seguridad es incorrecta.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nuevoHash = PasswordHasher.HashPassword(txtNuevaContrasena.Text.Trim());
            bool actualizado = negocioUsuario.ActualizarContrasena(usuarioEncontrado.IdUsuario, nuevoHash);

            if (actualizado)
            {
                MessageBox.Show("Tu contraseña ha sido actualizada correctamente. Ya puedes iniciar sesión.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al actualizar la contraseña en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarOlvido_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}