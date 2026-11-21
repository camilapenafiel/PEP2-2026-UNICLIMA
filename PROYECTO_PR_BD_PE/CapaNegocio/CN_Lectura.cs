using PROYECTO_PR_BD_PE.CapaDatos;
using PROYECTO_PR_BD_PE.CapaEntidades;

namespace PROYECTO_PR_BD_PE.CapaNegocio
{
    public class CN_Lectura
    {
        private CD_Lectura objDatos = new CD_Lectura();

        public Lectura ObtenerUltimaLectura(int idEstacion)
        {
            return objDatos.ObtenerUltimaLectura(idEstacion);
        }
    }
}