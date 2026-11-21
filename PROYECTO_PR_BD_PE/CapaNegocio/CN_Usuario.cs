using System.Collections.Generic;
using PROYECTO_PR_BD_PE.CapaDatos;
using PROYECTO_PR_BD_PE.CapaEntidades;

namespace PROYECTO_PR_BD_PE.CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objDatos = new CD_Usuario();

        public List<Usuario> Obtener()
        {
            return objDatos.ObtenerUsuarios();
        }

        public bool Crear(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;

            // 1. Validar campos vacíos
            if (string.IsNullOrWhiteSpace(obj.Nombre) ||
                string.IsNullOrWhiteSpace(obj.Apellido) ||
                string.IsNullOrWhiteSpace(obj.Correo) ||
                string.IsNullOrWhiteSpace(obj.Contraseña) ||
                string.IsNullOrWhiteSpace(obj.Nickname) ||
                string.IsNullOrWhiteSpace(obj.PreguntaSeguridad) ||
                string.IsNullOrWhiteSpace(obj.RespuestaSeguridad))
            {
                mensaje = "Todos los campos son obligatorios.";
                return false;
            }

            // 2. Validar si el correo o el nickname ya existen usando el método de datos
            if (objDatos.ExisteCorreoONickname(obj.Correo, obj.Nickname))
            {
                mensaje = "El correo electrónico o el nickname ya están registrados. Por favor, use otros.";
                return false;
            }

            // 3. Si todo está bien, se crea el usuario
            bool respuesta = objDatos.CrearUsuario(obj);
            if (!respuesta)
            {
                mensaje = "Ocurrió un error al intentar registrar el usuario.";
            }
            return respuesta;
        }

        public Usuario ObtenerPorCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
            {
                return null;
            }

            return objDatos.ObtenerPorCorreo(correo);
        }

        // NUEVO MÉTODO PARA ACTUALIZAR CONTRASEÑA
        public bool ActualizarContrasena(int idUsuario, string nuevaContrasenaHash)
        {
            if (idUsuario <= 0 || string.IsNullOrWhiteSpace(nuevaContrasenaHash))
            {
                return false;
            }

            return objDatos.ActualizarContrasena(idUsuario, nuevaContrasenaHash);
        }
        public bool ExisteCorreo(string correo, int idExcluir)
        {
            if (string.IsNullOrWhiteSpace(correo))
                return false;

            return objDatos.ExisteCorreo(correo, idExcluir);
        }

        // NUEVO MÉTODO PARA ACTUALIZAR DATOS DEL PERFIL
        public bool ActualizarPerfil(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.IdUsuario <= 0 ||
                      string.IsNullOrWhiteSpace(obj.Nombre) ||
                      string.IsNullOrWhiteSpace(obj.Apellido) ||
                      string.IsNullOrWhiteSpace(obj.Correo) ||
                      string.IsNullOrWhiteSpace(obj.Contraseña))
            {
                mensaje = "Nombre, apellido, correo y contraseña son obligatorios.";
                return false;
            }

            // ==========================================
            // AQUÍ ES EXACTAMENTE DONDE DEBES LLAMARLO:
            // ==========================================
            if (objDatos.ExisteCorreoONickname(obj.Correo, obj.Nickname, obj.IdUsuario))
            {
                mensaje = "El correo electrónico o nickname ya está en uso por otra cuenta. Elige otro.";
                return false;
            }

            // Si pasa la validación anterior, procede a guardar en la base de datos
            bool respuesta = objDatos.ActualizarPerfil(obj);
            if (!respuesta)
            {
                mensaje = "No se pudo actualizar el perfil en la base de datos.";
            }
            return respuesta;
        }
        public bool CambiarRol(int idUsuario, string nuevoRol)
        {
            return objDatos.CambiarRol(idUsuario, nuevoRol);
        }

        public bool Eliminar(int idUsuario)
        {
            if (idUsuario <= 0)

                return false;

            return objDatos.EliminarUsuario(idUsuario);
        }
    }
}