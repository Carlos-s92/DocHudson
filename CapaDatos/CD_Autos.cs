using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace CapaDatos
{
    public class CD_Autos
    {

        public List<Autos> Listar()
        {
            List<Autos> lista = new List<Autos>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT a.Id_Auto, a.Modelo, a.Marca, a.Matricula, a.Kilometros, a.Año, a.Consumo, a.Puertas, a.Asientos, a.Imagen, a.Estado");
                    query.AppendLine("FROM Autos a");
                

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oconexion))
                    {
                        cmd.CommandType = CommandType.Text;

                        oconexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Autos()
                                {
                                    Id_Auto = Convert.ToInt32(dr["Id_Auto"]),
                                    Modelo = dr["Modelo"].ToString(),
                                    Marca = dr["Marca"].ToString(),
                                    Matricula = dr["Matricula"].ToString(),
                                    Kilometros = Convert.ToDecimal(dr["Kilometros"]),
                                    Año = Convert.ToInt32(dr["Año"]),
                                    Consumo = Convert.ToDecimal(dr["Consumo"]),
                                    Puertas = Convert.ToInt32(dr["Puertas"]),
                                    Asientos = Convert.ToInt32(dr["Asientos"]),
                                    Imagen = dr["Imagen"].ToString(),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                        
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Autos>(); // Asegura que no se retorne null
                }
            }
            return lista;
        }


        public int Registrar(Autos obj, out string Mensaje)
        {
            int IdAutoGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {



                    SqlCommand cmd = new SqlCommand("InsertarAuto", oconexion);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("Modelo", obj.Modelo);
                    cmd.Parameters.AddWithValue("Matricula", obj.Matricula);
                    cmd.Parameters.AddWithValue("Kilometros", obj.Kilometros);
                    cmd.Parameters.AddWithValue("Año", obj.Año);
                    cmd.Parameters.AddWithValue("Consumo", obj.Consumo);
                    cmd.Parameters.AddWithValue("Imagen", obj.Imagen);
                    cmd.Parameters.AddWithValue("Puerta", obj.Puertas);
                    cmd.Parameters.AddWithValue("Marca", obj.Marca);
                    cmd.Parameters.AddWithValue("Asientos", obj.Asientos);
                    cmd.Parameters.Add("IdAutoResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    IdAutoGenerado = Convert.ToInt32(cmd.Parameters["IdAutoResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                IdAutoGenerado = 0;
                Mensaje = ex.Message;
            }

            return IdAutoGenerado;

        }

        public bool Editar(Autos obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("ActualizarAuto", oconexion);
                    cmd.Parameters.AddWithValue("Id_Auto", obj.Id_Auto);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("Modelo", obj.Modelo);
                    cmd.Parameters.AddWithValue("Matricula", obj.Matricula);
                    cmd.Parameters.AddWithValue("Kilometros", obj.Kilometros);
                    cmd.Parameters.AddWithValue("Año", obj.Año);
                    cmd.Parameters.AddWithValue("Consumo", obj.Consumo);
                    cmd.Parameters.AddWithValue("Imagen", obj.Imagen);
                    cmd.Parameters.AddWithValue("Puerta", obj.Puertas);
                    cmd.Parameters.AddWithValue("Marca", obj.Marca);
                    cmd.Parameters.AddWithValue("Asientos", obj.Asientos);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }

            return Respuesta;

        }

        public bool Eliminar(Autos obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {


                    SqlCommand cmd = new SqlCommand("EliminarAuto", oconexion);
                    cmd.Parameters.AddWithValue("Id_Auto", obj.Id_Auto);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

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
