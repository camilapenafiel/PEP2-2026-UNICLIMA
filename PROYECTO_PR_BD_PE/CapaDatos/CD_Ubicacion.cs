using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient; // Aquí usamos la librería nueva
using PROYECTO_PR_BD_PE.CapaEntidades; // Importamos tu carpeta de entidades

namespace PROYECTO_PR_BD_PE.CapaDatos
{
    public class CD_Ubicacion
    {
        // Instanciamos tu clase de conexión
        private Conexion conexion = new Conexion();

        // METODO 1: OBTENER (SELECT)
        public List<Ubicacion> ObtenerUbicaciones()
        {
            List<Ubicacion> lista = new List<Ubicacion>();

            using (SqlConnection oConexion = conexion.LeerCadena())
            {
                string query = "SELECT id_ubicacion, ciudad, coordenadas FROM ubicaciones";
                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Ubicacion()
                            {
                                IdUbicacion = Convert.ToInt32(dr["id_ubicacion"]),
                                Ciudad = dr["ciudad"].ToString(),
                                Coordenadas = dr["coordenadas"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Si algo falla, devuelve una lista vacía
                    lista = new List<Ubicacion>();
                }
            }
            return lista;
        }

        // METODO 2: CREAR (INSERT)
        public bool CrearUbicacion(Ubicacion obj)
        {
            bool respuesta = false;

            using (SqlConnection oConexion = conexion.LeerCadena())
            {
                string query = "INSERT INTO ubicaciones (ciudad, coordenadas) VALUES (@ciudad, @coordenadas)";
                SqlCommand cmd = new SqlCommand(query, oConexion);

                // Pasamos los parámetros de forma segura
                cmd.Parameters.AddWithValue("@ciudad", obj.Ciudad);
                cmd.Parameters.AddWithValue("@coordenadas", obj.Coordenadas);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        respuesta = true;
                    }
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
    }
}