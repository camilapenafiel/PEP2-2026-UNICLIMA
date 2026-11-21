using System.Collections.Generic;
using PROYECTO_PR_BD_PE.CapaDatos;
using PROYECTO_PR_BD_PE.CapaEntidades;

namespace PROYECTO_PR_BD_PE.CapaNegocio
{
    public class CN_EstacionMeteorologica
    {
        private CD_EstacionMeteorologica objDatos = new CD_EstacionMeteorologica();

        public List<EstacionMeteorologica> Obtener()
        {
            return objDatos.ObtenerEstaciones();
        }

        public bool Crear(EstacionMeteorologica obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Nombre) || obj.IdUbicacion <= 0)
            {
                return false;
            }

            return objDatos.CrearEstacion(obj);
        }
    }
}