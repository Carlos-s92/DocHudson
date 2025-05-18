using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

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
                        oconexion.Close();
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Reserva>(); // Asegura que no se retorne null
                }
            }
            return lista;
        }

        public Reserva Buscar(int id)
        {
            Reserva r = null;
            using (var cn = new SqlConnection(Conexion.cadena))
            using (var cmd = new SqlCommand("BuscarReserva", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Reserva", id);
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        // Construyo Reserva
                        r = new Reserva
                        {
                            Id_Reserva = dr.GetInt32(dr.GetOrdinal("Id_Reserva")),
                            Fecha_Inicio = dr.GetDateTime(dr.GetOrdinal("Fecha_Inicio")),
                            Fecha_Fin = dr.GetDateTime(dr.GetOrdinal("Fecha_Fin")),

                            // Auto
                            oAuto = new Autos
                            {
                                Id_Auto = dr.GetInt32(dr.GetOrdinal("Id_Auto")),
                                Matricula = dr["Matricula"].ToString(),
                                Kilometros = dr.GetDecimal(dr.GetOrdinal("Kilometros")),
                                Año = dr.GetInt32(dr.GetOrdinal("Año")),
                                Imagen = dr["Imagen"].ToString(),
                                Reservado = dr.GetBoolean(dr.GetOrdinal("Reservado")),
                                Estado = dr.GetBoolean(dr.GetOrdinal("EstadoAuto")),
                                oModelo = new Modelo
                                {
                                    Id_Modelo = dr.GetInt32(dr.GetOrdinal("Id_Modelo")),
                                    modelo = dr["NombreModelo"].ToString(),
                                    Consumo = dr.GetDecimal(dr.GetOrdinal("Consumo")),
                                    Puertas = dr.GetInt32(dr.GetOrdinal("Puertas")),
                                    Asientos = dr.GetInt32(dr.GetOrdinal("Asientos")),
                                    oMarca = new Marca
                                    {
                                        Id_Marca = dr.GetInt32(dr.GetOrdinal("Id_Marca")),
                                        marca = dr["NombreMarca"].ToString()
                                    }
                                }
                            },

                            // Cliente
                            oCliente = new Cliente
                            {
                                Id_Cliente = dr.GetInt32(dr.GetOrdinal("Id_Cliente")),
                                Licencia = dr["Licencia"].ToString(),
                                Estado = dr.GetBoolean(dr.GetOrdinal("EstadoCliente")),
                                oPersona = new Persona
                                {
                                    Id_Persona = dr.GetInt32(dr.GetOrdinal("Id_Persona")),
                                    DNI = dr["DNI"].ToString(),
                                    Nombre = dr["NombrePersona"].ToString(),
                                    Apellido = dr["Apellido"].ToString(),
                                    Fecha_Nacimiento = dr.GetDateTime(dr.GetOrdinal("Fecha_Nacimiento")),
                                    Mail = dr["Mail"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    oDomicilio = new Domicilio
                                    {
                                        Id_Domicilio = dr.GetInt32(dr.GetOrdinal("Id_Domicilio")),
                                        Calle = dr["Calle"].ToString(),
                                        Numero = dr.GetInt32(dr.GetOrdinal("Numero")),
                                        oLocalidad = new Localidad
                                        {
                                            Id_Localidad = dr.GetInt32(dr.GetOrdinal("Id_Localidad")),
                                            localidad = dr["Localidad"].ToString(),
                                            oProvincia = new Provincia
                                            {
                                                Id_Provincia = dr.GetInt32(dr.GetOrdinal("Id_Provincia")),
                                                provincia = dr["Provincia"].ToString()
                                            }
                                        }
                                    }
                                }
                            },

                            // Pago
                            oPago = new Pago
                            {
                                Id_Pago = dr.GetInt32(dr.GetOrdinal("Id_Pago")),
                                Total = Convert.ToDecimal(dr["Total"]),
                                Fecha_Pago = dr.GetDateTime(dr.GetOrdinal("Fecha_Pago")),
                                Estado = dr.GetBoolean(dr.GetOrdinal("EstadoPago"))
                            }
                        };
                    }
                }
                cn.Close();
            }
            return r;
        }


        public int Registrar(int idAuto, int idPago, int idCliente, int idUsuario,
                        DateTime fechaInicio, DateTime fechaFin, bool estado,
                        out string mensaje)
        {
            int idRes = 0;
            mensaje = string.Empty;

            using (var cn = new SqlConnection(Conexion.cadena))
            using (var cmd = new SqlCommand("InsertarReserva", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Auto", idAuto);
                cmd.Parameters.AddWithValue("@Id_Pago", idPago);
                cmd.Parameters.AddWithValue("@Id_Cliente", idCliente);
                cmd.Parameters.AddWithValue("@Id_Usuario", idUsuario);
                cmd.Parameters.AddWithValue("@Fecha_Inicio", fechaInicio);
                cmd.Parameters.AddWithValue("@Fecha_Fin", fechaFin);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cn.Open();
                cmd.ExecuteNonQuery();

                idRes = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);
                mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                cn.Close();
            }
            return idRes;
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

        public bool LiberarReserva(int id_reserva, out string Mensaje)

        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try { 
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("LiberarReserva", oconexion);
                    cmd.Parameters.AddWithValue("Id_Reserva", id_reserva);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                    oconexion.Close();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }
    }
}
