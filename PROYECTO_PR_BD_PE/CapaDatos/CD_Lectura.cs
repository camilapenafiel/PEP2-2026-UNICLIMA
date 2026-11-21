using System;
using System.Collections.Generic; // Agregado para usar List<>
using Microsoft.Data.SqlClient;
using PROYECTO_PR_BD_PE.CapaEntidades;

namespace PROYECTO_PR_BD_PE.CapaDatos
{
    public class CD_Lectura
    {
        // ---------------------------------------------------------
        // MÉTODO ORIGINAL (Intacto)
        // ---------------------------------------------------------
        public Lectura ObtenerUltimaLectura(int idEstacion)
        {
            Lectura objetoLectura = new Lectura();
            Conexion objConexion = new Conexion();

            using (SqlConnection conexion = objConexion.LeerCadena())
            {
                try
                {
                    string query = @"
                        SELECT 
                            (SELECT TOP 1 m.valor 
                             FROM mediciones m INNER JOIN sensores s ON m.id_sensor = s.id_sensor 
                             WHERE s.id_estacion = @idEstacion AND m.id_variable = 1 
                             ORDER BY m.fecha_hora DESC) AS TemperaturaActual,
                             
                            (SELECT TOP 1 m.valor 
                             FROM mediciones m INNER JOIN sensores s ON m.id_sensor = s.id_sensor 
                             WHERE s.id_estacion = @idEstacion AND m.id_variable = 2 
                             ORDER BY m.fecha_hora DESC) AS HumedadActual,
                             
                            (SELECT MAX(m.valor) 
                             FROM mediciones m INNER JOIN sensores s ON m.id_sensor = s.id_sensor 
                             WHERE s.id_estacion = @idEstacion AND m.id_variable = 1 AND CAST(m.fecha_hora AS DATE) = CAST(GETDATE() AS DATE)) AS TempMax,
                             
                            (SELECT MIN(m.valor) 
                             FROM mediciones m INNER JOIN sensores s ON m.id_sensor = s.id_sensor 
                             WHERE s.id_estacion = @idEstacion AND m.id_variable = 1 AND CAST(m.fecha_hora AS DATE) = CAST(GETDATE() AS DATE)) AS TempMin
                    ";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@idEstacion", idEstacion);

                    conexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            if (dr["TemperaturaActual"] != DBNull.Value)
                                objetoLectura.Temperatura = Convert.ToDecimal(dr["TemperaturaActual"]);

                            if (dr["HumedadActual"] != DBNull.Value)
                                objetoLectura.Humedad = Convert.ToDecimal(dr["HumedadActual"]);

                            if (dr["TempMax"] != DBNull.Value)
                                objetoLectura.TempMax = Convert.ToDecimal(dr["TempMax"]);
                            else
                                objetoLectura.TempMax = objetoLectura.Temperatura;

                            if (dr["TempMin"] != DBNull.Value)
                                objetoLectura.TempMin = Convert.ToDecimal(dr["TempMin"]);
                            else
                                objetoLectura.TempMin = objetoLectura.Temperatura;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en CD_Lectura: " + ex.Message);
                }
            }
            return objetoLectura;
        }

        // ---------------------------------------------------------
        // NUEVO MÉTODO PARA MACHINE LEARNING (ML.NET)
        // ---------------------------------------------------------
        public List<DatosClimaHistorico> ObtenerHistorialParaML(int idEstacion)
        {
            List<DatosClimaHistorico> historial = new List<DatosClimaHistorico>();
            Conexion objConexion = new Conexion(); // Usamos tu clase de conexión

            using (SqlConnection conexion = objConexion.LeerCadena())
            {
                try
                {
                    // Hacemos un INNER JOIN igual que en tu método original
                    string query = @"
                        SELECT 
                            DATEADD(hour, DATEDIFF(hour, 0, m.fecha_hora), 0) AS FechaHora,
                            MAX(CASE WHEN m.id_variable = 1 THEN m.valor END) AS Temperatura,
                            MAX(CASE WHEN m.id_variable = 2 THEN m.valor END) AS Humedad
                        FROM dbo.mediciones m
                        INNER JOIN dbo.sensores s ON m.id_sensor = s.id_sensor
                        WHERE s.id_estacion = @idEstacion
                        GROUP BY DATEADD(hour, DATEDIFF(hour, 0, m.fecha_hora), 0)
                        ORDER BY FechaHora ASC";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@idEstacion", idEstacion);

                    conexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            historial.Add(new DatosClimaHistorico()
                            {
                                FechaHora = Convert.ToDateTime(dr["FechaHora"]),
                                // ML.NET prefiere floats, así que convertimos los decimales a float (Single)
                                Temperatura = dr["Temperatura"] != DBNull.Value ? Convert.ToSingle(dr["Temperatura"]) : 0f,
                                Humedad = dr["Humedad"] != DBNull.Value ? Convert.ToSingle(dr["Humedad"]) : 0f
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener historial ML: " + ex.Message);
                }
            }
            return historial;
        }
    }
}