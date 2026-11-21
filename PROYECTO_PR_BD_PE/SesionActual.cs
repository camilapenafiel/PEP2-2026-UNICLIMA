using System;
using System.Collections.Generic;
using System.Text;

namespace PROYECTO_PR_BD_PE
{
    public static class SesionActual
    {
        public static int IdUsuario { get; set; }
        public static string Nombre { get; set; } = "";

        public static string Nickname { get; set; } = "";
        public static string Rol { get; set; } = ""; // "Administrador" o "Usuario normal"
    }
}