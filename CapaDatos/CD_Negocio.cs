using CapaEntidad;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace CapaDatos
{
    public class CD_Negocio
    {
        public Negocio obtenerDatos()
        {
            Negocio obj = new Negocio();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    string query = "select Id_Negocio,Nombre,Imagen from Negocio where Id_Negocio = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Negocio()
                            {
                                Id_Negocio = int.Parse(dr["Id_Negocio"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                Imagen = dr["Imagen"].ToString()
                            };
                        }
                    }
                    conexion.Close();
                }
            }
            catch
            {
                obj = new Negocio();
            }

            return obj;
        }


        public bool guardarDatos(Negocio obj, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update Negocio set Nombre = @Nombre,");
                    query.AppendLine("Imagen = @Imagen,");
                    query.AppendLine("where Id_Negocio = 1");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Imagen", obj.Imagen);


                    cmd.CommandType = CommandType.Text;


                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo actualizar los datos";
                        respuesta = false;
                    }

                    conexion.Close();

                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
