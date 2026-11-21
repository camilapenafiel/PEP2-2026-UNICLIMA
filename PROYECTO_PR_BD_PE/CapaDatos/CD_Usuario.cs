using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using PROYECTO_PR_BD_PE.CapaEntidades;

namespace PROYECTO_PR_BD_PE.CapaDatos
{
    public class CD_Usuario
    {
        private Conexion conexion = new Conexion();

        // 1. OBTENER (SELECT)
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oConexion = conexion.LeerCadena())
            {
                string query = "SELECT id_usuario, nombre, apellido, nickname, fecha_nacimiento, correo, telefono, contraseña, pregunta_seguridad, respuesta_seguridad, rol FROM usuarios";
                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["id_usuario"]),
                                Nombre = dr["nombre"].ToString(),
                                Apellido = dr["apellido"].ToString(),
                                Nickname = dr["nickname"]?.ToString() ?? "",
                                FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]),
                                Correo = dr["correo"].ToString(),
                                Telefono = dr["telefono"]?.ToString() ?? "",
                                Contraseña = dr["contraseña"].ToString(),
                                PreguntaSeguridad = dr["pregunta_seguridad"]?.ToString() ?? "",
                                RespuestaSeguridad = dr["respuesta_seguridad"]?.ToString() ?? "",
                                Rol = dr["rol"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error al cargar datos: " + ex.Message, "Fallo en la BD");
                    lista = new List<Usuario>();
                }
            }
            return lista;
        }

        // 2. CREAR (INSERT)
        public bool CrearUsuario(Usuario obj)
        {
            bool respuesta = false;

            using (SqlConnection oConexion = conexion.LeerCadena())
            {
                string query = "INSERT INTO usuarios (nombre, apellido, nickname, fecha_nacimiento, correo, telefono, contraseña, pregunta_seguridad, respuesta_seguridad, rol) " +
                               "VALUES (@nombre, @apellido, @nickname, @fecha_nacimiento, @correo, @telefono, @contraseña, @pregunta_seguridad, @respuesta_seguridad, @rol)";
                SqlCommand cmd = new SqlCommand(query, oConexion);

                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@apellido", obj.Apellido);
                cmd.Parameters.AddWithValue("@nickname", (object)obj.Nickname ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", obj.FechaNacimiento);
                cmd.Parameters.AddWithValue("@correo", obj.Correo);
                cmd.Parameters.AddWithValue("@telefono", (object)obj.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@contraseña", obj.Contraseña);
                cmd.Parameters.AddWithValue("@pregunta_seguridad", (object)obj.PreguntaSeguridad ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@respuesta_seguridad", (object)obj.RespuestaSeguridad ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@rol", obj.Rol);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Detalle técnico de SQL: " + ex.Message, "Error en Base de Datos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    respuesta = false;
                }
            }
            return respuesta;
        }

        // 3. NUEVO: OBTENER POR CORREO PARA LOGIN SEGURO Y RECUPERACIÓN
        public Usuario ObtenerPorCorreo(string correo)
        {
            Usuario obj = null;

            using (SqlConnection oConexion = conexion.LeerCadena())
            {
                // Se agregaron fecha_nacimiento, pregunta_seguridad y respuesta_seguridad a la consulta
                string query = "SELECT id_usuario, nombre, apellido, nickname, correo, fecha_nacimiento, pregunta_seguridad, respuesta_seguridad, contraseña, rol FROM usuarios WHERE correo = @correo";
                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj = new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["id_usuario"]),
                                Nombre = dr["nombre"].ToString() + " " + dr["apellido"].ToString(),
                                Nickname = dr["nickname"].ToString() ?? "",
                                Correo = dr["correo"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]),
                                PreguntaSeguridad = dr["pregunta_seguridad"]?.ToString() ?? "",
                                RespuestaSeguridad = dr["respuesta_seguridad"]?.ToString() ?? "",
                                Contraseña = dr["contraseña"].ToString(),
                                Rol = dr["rol"].ToString()
                            };
                        }
                    }
                }
                catch (Exception)
                {
                    obj = null;
                }
            }
            return obj;
        }

        // 4. ACTUALIZAR ROL (UPDATE)
        public bool CambiarRol(int idUsuario, string nuevoRol)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = conexion.LeerCadena())
            {
                string query = "UPDATE usuarios SET rol = @rol WHERE id_usuario = @id_usuario";
                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.Parameters.AddWithValue("@rol", nuevoRol);
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
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

        // 5. ELIMINAR (DELETE)
        public bool EliminarUsuario(int idUsuario)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = conexion.LeerCadena())
            {
                string query = "DELETE FROM usuarios WHERE id_usuario = @id_usuario";
                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
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

        // 6. NUEVO: ACTUALIZAR CONTRASEÑA
        public bool ActualizarContrasena(int idUsuario, string nuevaContrasenaHash)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = conexion.LeerCadena())
            {
                string query = "UPDATE usuarios SET contraseña = @contraseña WHERE id_usuario = @id_usuario";
                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.Parameters.AddWithValue("@contraseña", nuevaContrasenaHash);
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
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

        // 7. NUEVO: ACTUALIZAR DATOS DEL PERFIL
        public bool ActualizarPerfil(Usuario obj)
        {
            bool respuesta = false;

            using (SqlConnection oConexion = conexion.LeerCadena())
            {
                string query = "UPDATE usuarios SET nombre = @nombre, apellido = @apellido, nickname = @nickname, correo = @correo, contraseña = @contraseña WHERE id_usuario = @id_usuario";

                SqlCommand cmd = new SqlCommand(query, oConexion);

                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@apellido", string.IsNullOrWhiteSpace(obj.Apellido) ? DBNull.Value : (object)obj.Apellido);
                cmd.Parameters.AddWithValue("@nickname", string.IsNullOrWhiteSpace(obj.Nickname) ? DBNull.Value : (object)obj.Nickname);
                cmd.Parameters.AddWithValue("@correo", obj.Correo);
                cmd.Parameters.AddWithValue("@contraseña", obj.Contraseña);
                cmd.Parameters.AddWithValue("@id_usuario", obj.IdUsuario);

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

        // 8. NUEVO: VERIFICAR SI EL CORREO EXISTE O NICKNAME DUPLICADO


        //8. correo mio existente
        // Este método busca si el correo o nickname ya existen, pero IGNORA tu propio ID para que no choque contigo mismo
        public bool ExisteCorreoONickname(string correo, string nickname, int idExcluir = 0)
        {
            bool existe = false;
            using (SqlConnection oConexion = conexion.LeerCadena())
            {
                string query = "SELECT COUNT(1) FROM usuarios WHERE (correo = @correo OR (nickname != '' AND nickname = @nickname)) AND id_usuario != @idExcluir";
                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@nickname", string.IsNullOrEmpty(nickname) ? "" : nickname);
                cmd.Parameters.AddWithValue("@idExcluir", idExcluir);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConexion.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    existe = count > 0;
                }
                catch (Exception)
                {
                    existe = false;
                }
            }
            return existe;
        }

        public bool ExisteCorreo(string correo, int idExcluir)
        {
            bool existe = false;

            using (SqlConnection oConexion = conexion.LeerCadena())
            {
                string query = "SELECT COUNT(1) FROM usuarios WHERE correo = @correo AND id_usuario != @idExcluir";

                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@idExcluir", idExcluir);

                try
                {
                    oConexion.Open();
                    int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                    existe = cantidad > 0;
                }
                catch (Exception)
                {
                    existe = false;
                }
            }

            return existe;
        }
    }

}