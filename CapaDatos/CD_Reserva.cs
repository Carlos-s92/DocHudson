using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Reserva
    {

        public List<Reserva> Listar()
        {
            List<Reserva> lista = new List<Reserva>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT r.Id_Reserva, r.Id_Auto, r.Id_Pago, r.Id_Cliente, r.Fecha_Inicio, r.Fecha_Fin, r.Estado");
                    query.AppendLine("FROM Reservas r");
                    

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oconexion))
                    {
                        cmd.CommandType = CommandType.Text;

                        oconexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Reserva()
                                {
                                    Id_Reserva = Convert.ToInt32(dr["Id_Reserva"]),
                                    oAuto = new Autos()
                                    {
                                        Id_Auto = Convert.ToInt32(dr["Id_Auto"]),
                                    },
                                    oPago = new Pago()
                                    {
                                        Id_Pago =Convert.ToInt32(dr["Id_Pago"]) 
                                    },
                                    oCliente = new Cliente()
                                    {
                                        Id_Cliente = Convert.ToInt32(dr["Id_Cliente"])
                                    },
                                    Fecha_Inicio = Convert.ToDateTime(dr["Fecha_Inicio"]),
                                    Fecha_Fin = Convert.ToDateTime(dr["Fecha_Fin"]),
                                    Estado = Convert.ToBoolean(dr["Estado"])
                           
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Reserva>(); // Asegura que no se retorne null
                }
            }
            return lista;
        }

        public int Registrar(Reserva obj, out string Mensaje)
        {
            int IdReservaGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {


                    SqlCommand cmd = new SqlCommand("InsertarReserva", oconexion);
                    cmd.Parameters.AddWithValue("Id_Auto", obj.oAuto.Id_Auto);
                    cmd.Parameters.AddWithValue("Id_Pago", obj.oPago.Id_Pago);
                    cmd.Parameters.AddWithValue("Id_Cliente", obj.oCliente.Id_Cliente);
                    cmd.Parameters.AddWithValue("Fecha_Inicio", obj.Fecha_Inicio);
                    cmd.Parameters.AddWithValue("Fecha_Fin", obj.Fecha_Fin);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    IdReservaGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                IdReservaGenerado = 0;
                Mensaje = ex.Message;
            }

            return IdReservaGenerado;

        }

        public bool Editar(Reserva obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
       

                    SqlCommand cmd = new SqlCommand("ActualizarReserva", oconexion);
                    cmd.Parameters.AddWithValue("Id_Reserva", obj.Id_Reserva);
                    cmd.Parameters.AddWithValue("Id_Auto", obj.oAuto.Id_Auto);
                    cmd.Parameters.AddWithValue("Id_Pago", obj.oPago.Id_Pago);
                    cmd.Parameters.AddWithValue("Id_Cliente", obj.oCliente.Id_Cliente);
                    cmd.Parameters.AddWithValue("Fecha_Inicio", obj.Fecha_Inicio);
                    cmd.Parameters.AddWithValue("Fecha_Fin", obj.Fecha_Fin);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
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

        public bool Eliminar(Reserva obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {


                    SqlCommand cmd = new SqlCommand("EliminarReserva", oconexion);
                    cmd.Parameters.AddWithValue("Id_Reserva", obj.Id_Reserva);
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
