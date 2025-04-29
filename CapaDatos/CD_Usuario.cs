using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace CapaDatos
{
    public class CD_Usuario
    {
        public List<Usuarios> Listar()
        {
            List<Usuarios> lista = new List<Usuarios>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT u.Id_Usuario, u.Usuario, u.Contraseña, per.DNI, u.Estado, p.Id_Perfil, p.Descripcion");
                    query.AppendLine("FROM Usuarios u");
                    query.AppendLine("INNER JOIN Persona per ON per.Id_Persona = u.Id_Persona");
                    query.AppendLine("INNER JOIN Perfiles p ON p.Id_Perfil = u.Id_Perfil");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oconexion))
                    {
                        cmd.CommandType = CommandType.Text;

                        oconexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Usuarios()
                                {
                                    Id_Usuario = Convert.ToInt32(dr["Id_Usuario"]),
                                    Usuario = dr["Usuario"].ToString(),
                                    Contraseña = dr["Contraseña"].ToString(),
                                    Dni = dr["DNI"].ToString(),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    oPerfil = new Perfiles()
                                    {
                                        Id_Perfil = Convert.ToInt32(dr["Id_Perfil"]),
                                        Descripcion = dr["Descripcion"].ToString()
                                    }
                                });
                            }
                        }
                        oconexion.Close();
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Usuarios>(); // Asegura que no se retorne null
                }
            }
            return lista;
        }

       


        public int Registrar(Usuarios obj, out string Mensaje)
        {
            int IdUsuarioGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("InsertarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Usuario", obj.Usuario);
                    cmd.Parameters.AddWithValue("Contraseña", obj.Contraseña);
                    cmd.Parameters.AddWithValue("DNI", obj.Dni);
                    cmd.Parameters.AddWithValue("Id_Perfil", obj.oPerfil.Id_Perfil);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    IdUsuarioGenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                    oconexion.Close();
                }

            }
            catch (Exception ex)
            {
                IdUsuarioGenerado = 0;
                Mensaje = ex.Message;
            }

            return IdUsuarioGenerado;

        }

        public bool Editar(Usuarios obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("ActualizarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.Id_Usuario);
                    cmd.Parameters.AddWithValue("Usuario", obj.Usuario);
                    cmd.Parameters.AddWithValue("Contraseña", obj.Contraseña);
                    cmd.Parameters.AddWithValue("DNI", obj.Dni);
                    cmd.Parameters.AddWithValue("Id_Perfil", obj.oPerfil.Id_Perfil);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                    oconexion.Close();
                }

            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }

            return Respuesta;

        }

        public bool Eliminar(Usuarios obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {


                    SqlCommand cmd = new SqlCommand("EliminarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Id_Usuario", obj.Id_Usuario);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                    oconexion.Close();
                }

            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }

            return Respuesta;

        }
    }
}
