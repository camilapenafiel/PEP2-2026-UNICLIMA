using System;
using System.Windows.Forms;
using System.Text.RegularExpressions; // Necesario para la validación de contraseña
using Microsoft.Data.SqlClient;       // Necesario para la consulta del teléfono
using PROYECTO_PR_BD_PE.CapaEntidades;
using PROYECTO_PR_BD_PE.CapaNegocio;
using PROYECTO_PR_BD_PE.Utils;

namespace PROYECTO_PR_BD_PE
{
    public partial class Form5UsuariosRegistro : Form
    {
        private CN_Usuario negocioUsuario = new CN_Usuario();

        public Form5UsuariosRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrarme_Click(object sender, EventArgs e)
        {
            // Validaciones de campos vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                string.IsNullOrWhiteSpace(txtNickname.Text) ||
                string.IsNullOrWhiteSpace(cmbPreguntaSeguridad.Text) ||
                string.IsNullOrWhiteSpace(txtRespuestaSeguridad.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. VALIDACIÓN DE CONTRASEÑA (Mínimo 8 caracteres, 1 mayúscula, 1 número)
            string contrasena = txtContrasena.Text;
            if (!Regex.IsMatch(contrasena, @"^(?=.*[A-Z])(?=.*\d).{8,}$"))
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres, incluir una letra mayúscula y un número.", "Seguridad de la contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detiene el registro
            }

            // 2. VALIDACIÓN DE TELÉFONO DUPLICADO
            string telefono = txtTelefono.Text.Trim();
            if (!string.IsNullOrWhiteSpace(telefono)) // Solo valida en BD si el usuario escribió un teléfono
            {
                string cadenaConexion = @"Data Source=sql5113.site4now.net;Initial Catalog=db_acf741_uniclimadb;User Id=db_acf741_uniclimadb_admin;Password=135abg99N@;Encrypt=True;TrustServerCertificate=True;";

                try
                {
                    using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                    {
                        conexion.Open();
                        string queryCheck = "SELECT COUNT(1) FROM dbo.Usuarios WHERE telefono = @Telefono";
                        using (SqlCommand cmdCheck = new SqlCommand(queryCheck, conexion))
                        {
                            cmdCheck.Parameters.AddWithValue("@Telefono", telefono);
                            int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());

                            if (existe > 0)
                            {
                                MessageBox.Show("Este número de teléfono ya está registrado en otra cuenta. Intente con uno diferente.", "Teléfono duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; // Detiene el registro
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar el teléfono: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 3. GENERAR HASH Y GUARDAR EL USUARIO
            string hashParaGuardar = PasswordHasher.HashPassword(contrasena);

            // Crear el objeto entidad asignando todos los campos
            Usuario nuevoUsuario = new Usuario()
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Nickname = txtNickname.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value.Date,
                Correo = txtCorreo.Text.Trim(),
                Telefono = string.IsNullOrWhiteSpace(telefono) ? null : telefono,
                Contraseña = hashParaGuardar,
                PreguntaSeguridad = cmbPreguntaSeguridad.Text.Trim(),
                RespuestaSeguridad = txtRespuestaSeguridad.Text.Trim(),
                Rol = "usuario normal"
            };

            string mensajeError;
            bool registrado = negocioUsuario.Crear(nuevoUsuario, out mensajeError);

            if (registrado)
            {
                MessageBox.Show("¡Cuenta registrada con éxito! Ya puedes iniciar sesión.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                // Mostramos el mensaje exacto (ej. si el correo o el nickname ya existen)
                MessageBox.Show(mensajeError, "Aviso de Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }
    }
}