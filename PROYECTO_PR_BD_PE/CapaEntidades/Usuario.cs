using System;
using System.Collections.Generic;
using System.Text;

namespace PROYECTO_PR_BD_PE.CapaEntidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Nickname { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Contraseña { get; set; }
        public string? PreguntaSeguridad { get; set; }
        public string? RespuestaSeguridad { get; set; }
        public string? Rol { get; set; }
    }
}