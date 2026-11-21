using System.Collections.Generic;
using PROYECTO_PR_BD_PE.CapaDatos;
using PROYECTO_PR_BD_PE.CapaEntidades;

namespace PROYECTO_PR_BD_PE.CapaNegocio
{
    public class CN_Ubicacion
    {
        // Instanciamos tu capa de datos para poder usar sus métodos
        private CD_Ubicacion objDatos = new CD_Ubicacion();

        // METODO 1: OBTENER (Solo pide la lista a la capa de datos y la pasa hacia arriba)
        public List<Ubicacion> Obtener()
        {
            return objDatos.ObtenerUbicaciones();
        }

        // METODO 2: CREAR (Aquí aplicamos la validación)
        public bool Crear(Ubicacion obj)
        {
            // Regla de negocio: La ciudad no puede estar vacía o llena de espacios
            if (string.IsNullOrWhiteSpace(obj.Ciudad))
            {
                return false; // Rechaza el guardado
            }

            // Si pasa la validación, lo mandamos a la capa de datos para que haga el INSERT
            return objDatos.CrearUbicacion(obj);
        }
    }
}