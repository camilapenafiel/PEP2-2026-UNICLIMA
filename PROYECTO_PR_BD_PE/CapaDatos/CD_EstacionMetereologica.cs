using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using PROYECTO_PR_BD_PE.CapaEntidades;

namespace PROYECTO_PR_BD_PE.CapaDatos
{
    public class CD_EstacionMeteorologica
    {
        private Conexion conexion = new Conexion();

        // 1. OBTENER (SELECT con INNER JOIN para traer el nombre del Campus)
        public List<EstacionMeteorologica> ObtenerEstaciones()
        {
            List<EstacionMeteorologica> lista = new List<EstacionMeteorologica>();

            using (SqlConnection oConexion = conexion.LeerCadena())
            {
                string query = @"SELECT e.id_estacion, e.nombre, e.id_ubicacion, u.ciudad AS campus 
                                 FROM estaciones_meteorologicas e
                                 INNER JOIN ubicaciones u ON e.id_ubicacion = u.id_ubicacion";

                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new EstacionMeteorologica()
                            {
                                IdEstacion = Convert.ToInt32(dr["id_estacion"]),
                                Nombre = dr["nombre"].ToString(),
                                IdUbicacion = Convert.ToInt32(dr["id_ubicacion"]),
                                Campus = dr["campus"].ToString()
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<EstacionMeteorologica>();
                }
            }
            return lista;
        }

        // 2. CREAR (INSERT)
        public bool CrearEstacion(EstacionMeteorologica obj)
        {
            bool respuesta = false;

            using (SqlConnection oConexion = conexion.LeerCadena())
            {
                string query = "INSERT INTO estaciones_meteorologicas (nombre, id_ubicacion) VALUES (@nombre, @id_ubicacion)";
                SqlCommand cmd = new SqlCommand(query, oConexion);

                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@id_ubicacion", obj.IdUbicacion);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
    }
}