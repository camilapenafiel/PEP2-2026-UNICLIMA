using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace PROYECTO_PR_BD_PE.CapaDatos
{
    public class Conexion
    {
        // Conexión apuntando al servidor en la nube (SmarterASP.NET)
        private string CadenaConexion = @"Data Source=sql5113.site4now.net;Initial Catalog=db_acf741_uniclimadb;User Id=db_acf741_uniclimadb_admin;Password=135abg99N@;Encrypt=True;TrustServerCertificate=True;";

        public SqlConnection LeerCadena()
        {
            return new SqlConnection(CadenaConexion);
        }
    }
}