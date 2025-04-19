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
    public class CD_Cliente
    {
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select Id_Cliente, DNI, Nombre, p.Id_Provincia,p.Provincia, l.Id_Localidad,l.Localidad, d.Calle, d.Numero, Fecha_Nacimiento, Mail, Telefono, Estado from Cliente c");
                    query.AppendLine("inner join Direccion d on d.Id_Direccion = c.Id_Direccion");
                    query.AppendLine("inner join Localidad l on d.Id_Localidad = l.Id_Localidad and d.Id_Provincia = l.Id_Provincia");
                    query.AppendLine("inner join Provincia p on l.Id_Provincia = p.Id_Provincia");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);

                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]),
                                Dni = dr["DNI"].ToString(),
                                Nombre = dr["Nombre"].ToString(), 
                                domicilio = new Domicilio()
                                {
                                    Calle = dr["Calle"].ToString(),
                                    Numero = Convert.ToInt32(dr["Numero"]),
                                    oLocalidad = new Localidad()
                                    {
                                        Id_Localidad = Convert.ToInt32(dr["Id_Localidad"]),
                                        localidad = dr["Localidad"].ToString(),
                                        oProvincia = new Provincia()
                                        {
                                            Id_Provincia = Convert.ToInt32(dr["Id_Provincia"]),
                                            provincia = dr["Provincia"].ToString()
                                        }
                                    }
                                },
                                //Provincia = dr["Provincia"].ToString(),
                                //Localidad = dr["Localidad"].ToString(),
                                //Calle = dr["Calle"].ToString(),
                                //Numero = Convert.ToInt32(dr["Numero"]),
                                Fecha_Nacimiento = Convert.ToDateTime(dr["Fecha_Nacimiento"]),
                                Mail = dr["Mail"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Cliente>();
                }
            }
            return lista;
        }

        public Cliente ObtenerClientePorPago(int idPago)
        {
            Cliente cliente = null;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT c.Id_Cliente,c.Nombre,c.DNI");
                    query.AppendLine("FROM Cliente c");
                    query.AppendLine("INNER JOIN Reserva r ON r.Id_Cliente = c.Id_Cliente");
                    query.AppendLine("INNER JOIN Pago p ON p.Id_Pago = r.Id_Pago");
                    query.AppendLine("WHERE p.Id_Pago = @IdPago");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oconexion))
                    {
                        cmd.Parameters.AddWithValue("@IdPago", idPago);
                        cmd.CommandType = CommandType.Text;
                        oconexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                cliente = new Cliente()
                                {
                                    Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Dni = dr["DNI"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener cliente: " + ex.Message);
                }
            }
            return cliente;
        }

        public int Registrar(Cliente obj, out string Mensaje)
        {
            int IdClienteGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("InsertarCliente", oconexion);
                   
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                 
                    cmd.Parameters.AddWithValue("DNI", obj.Dni);
                    cmd.Parameters.AddWithValue("Fecha_Nacimiento", obj.Fecha_Nacimiento);
                    cmd.Parameters.AddWithValue("Provincia", obj.domicilio.oLocalidad.oProvincia.Id_Provincia);
                    cmd.Parameters.AddWithValue("Localidad", obj.domicilio.oLocalidad.Id_Localidad);
                    cmd.Parameters.AddWithValue("Calle", obj.domicilio.Calle);
                    cmd.Parameters.AddWithValue("Numero", obj.domicilio.Numero);
                    cmd.Parameters.AddWithValue("Mail", obj.Mail);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    IdClienteGenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                IdClienteGenerado = 0;
                Mensaje = ex.Message;
            }

            return IdClienteGenerado;

        }

        public bool Editar(Cliente obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {


                    SqlCommand cmd = new SqlCommand("ActualizarCliente", oconexion);
                    cmd.Parameters.AddWithValue("Id_Cliente", obj.Id_Cliente);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("DNI", obj.Dni);
                    cmd.Parameters.AddWithValue("Fecha_Nacimiento", obj.Fecha_Nacimiento);
                    cmd.Parameters.AddWithValue("Provincia", obj.domicilio.oLocalidad.oProvincia.Id_Provincia);
                    cmd.Parameters.AddWithValue("Localidad", obj.domicilio.oLocalidad.Id_Localidad);
                    cmd.Parameters.AddWithValue("Calle", obj.domicilio.Calle);
                    cmd.Parameters.AddWithValue("Numero", obj.domicilio.Numero);
                    cmd.Parameters.AddWithValue("Mail", obj.Mail);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
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

        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {


                    SqlCommand cmd = new SqlCommand("EliminarCliente", oconexion);
                    cmd.Parameters.AddWithValue("Id_Cliente", obj.Id_Cliente);
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
