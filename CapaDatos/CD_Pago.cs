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
    public class CD_Pago
    {
        public List<Pago> Listar()
        {
            List<Pago> lista = new List<Pago>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.Id_Pago, p.Id_Tipopago, tp.Descripcion, p.Total, p.Fecha_Pago, p.Estado");
                    query.AppendLine("FROM Pago p");
                    query.AppendLine("Inner join Tipo_Pago tp on tp.Id_Tipopago = p.Id_Tipopago");


                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oconexion))
                    {
                        cmd.CommandType = CommandType.Text;

                        oconexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Pago()
                                {
                                    Id_Pago = Convert.ToInt32(dr["Id_Pago"]),
                                    Total = Convert.ToDecimal(dr["Total"]),
                                    Fecha_Pago = Convert.ToDateTime(dr["Fecha_Pago"]),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    oTipoPago = new TipoPago()
                                    {
                                        Id_TipoPago = Convert.ToInt32(dr["Id_Tipopago"]),
                                        Descripcion = dr["Descripcion"].ToString()
                                    }
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Pago>(); // Asegura que no se retorne null
                }
            }
            return lista;
        }
        public int Registrar(Pago obj, out string Mensaje)
        {
            int IdPagoGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("InsertarPago", oconexion);
                    cmd.Parameters.AddWithValue("Id_Tipopago", obj.oTipoPago.Id_TipoPago);
                    cmd.Parameters.AddWithValue("Total", obj.Total);
                    cmd.Parameters.AddWithValue("Fecha_Pago", obj.Fecha_Pago);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    IdPagoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                IdPagoGenerado = 0;
                Mensaje = ex.Message;
            }

            return IdPagoGenerado;

        }

        public bool Editar(Pago obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("ActualizarPago", oconexion);
                    cmd.Parameters.AddWithValue("Id_Pago", obj.Id_Pago);
                    cmd.Parameters.AddWithValue("Id_Tipopago", obj.oTipoPago.Id_TipoPago);
                    cmd.Parameters.AddWithValue("Total", obj.Total);
                    cmd.Parameters.AddWithValue("Fecha_Pago", obj.Fecha_Pago);
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

        public bool Eliminar(Pago obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {


                    SqlCommand cmd = new SqlCommand("EliminarPago", oconexion);
                    cmd.Parameters.AddWithValue("Id_Pago", obj.Id_Pago);
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
