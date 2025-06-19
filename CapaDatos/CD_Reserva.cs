using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Linq;

namespace CapaDatos
{
    public class CD_Reserva : CD_TemplateM<Reserva>
    {
        //Se sobreescriben los metodos heredados de la clase plantilla
        protected override string NombreSPRegistrar() => "InsertarReserva";
        protected override string NombreSPEditar() => "ActualizarReserva";
        protected override string NombreSPEliminar() => "LiberarReserva";
        protected override string NombreSPListar() => "ListarReservas";
        protected override string NombreSPBuscar() => "BuscarReserva";
        protected override void AgregarParametrosRegistrar(SqlCommand cmd, Reserva obj)
        {
            //Se agregan los parametros para registrar una reserva
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id_Auto", obj.oAuto.Id_Auto);
            cmd.Parameters.AddWithValue("Id_Pago", obj.oPago.Id_Pago);
            cmd.Parameters.AddWithValue("Id_Cliente", obj.oCliente.Id_Cliente);
            cmd.Parameters.AddWithValue("Id_Usuario", obj.oUsuario.Id_Usuario);
            cmd.Parameters.AddWithValue("Fecha_Inicio", obj.Fecha_Inicio);
            cmd.Parameters.AddWithValue("Fecha_Fin", obj.Fecha_Fin);
            cmd.Parameters.AddWithValue("Estado", obj.Estado);
            cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        }
        protected override void AgregarParametrosEditar(SqlCommand cmd, Reserva obj)
        {
            //Se agregan los parametros para editar una reserva
            cmd.Parameters.AddWithValue("Id_Reserva", obj.Id_Reserva);
            cmd.Parameters.AddWithValue("Id_Auto", obj.oAuto.Id_Auto);
            cmd.Parameters.AddWithValue("Id_Pago", obj.oPago.Id_Pago);
            cmd.Parameters.AddWithValue("Id_Cliente", obj.oCliente.Id_Cliente);
            cmd.Parameters.AddWithValue("Fecha_Inicio", obj.Fecha_Inicio);
            cmd.Parameters.AddWithValue("Fecha_Fin", obj.Fecha_Fin);
            cmd.Parameters.AddWithValue("Estado", obj.Estado);
            cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        }
        protected override void AgregarParametrosEliminar(SqlCommand cmd, Reserva obj)
        {
            //Se agregan los parametros para liberar una reserva
            cmd.Parameters.AddWithValue("Id_Reserva", obj.Id_Reserva);
            cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        }
        protected override void AgregarParametrosBuscar(SqlCommand cmd, string obj)
        {
            //Se agregan los parametros para buscar una reserva
            cmd.Parameters.AddWithValue("@Id_Reserva", obj);
        }
        protected override Reserva Mapear(SqlDataReader reader)
        {
            //Se agregan los parametros de lectura para una reserva
            return new Reserva
            {
                Id_Reserva = Convert.ToInt32(reader["Id_Reserva"]),
                oAuto = new Autos()
                {
                    Id_Auto = Convert.ToInt32(reader["Id_Auto"]),
                },
                oPago = new Pago()
                {
                    Id_Pago = Convert.ToInt32(reader["Id_Pago"])
                },
                oCliente = new Cliente()
                {
                    Id_Cliente = Convert.ToInt32(reader["Id_Cliente"])
                },
                Fecha_Inicio = Convert.ToDateTime(reader["Fecha_Inicio"]),
                Fecha_Fin = Convert.ToDateTime(reader["Fecha_Fin"]),
                Estado = Convert.ToBoolean(reader["Estado"])

            };
        }

        protected Reserva MapearExtendido(SqlDataReader reader)
        {
            //Se agregan los parametros de lectura para leer una reserva completa
            return new Reserva
            {
                Id_Reserva = reader.GetInt32(reader.GetOrdinal("Id_Reserva")),
                Fecha_Inicio = reader.GetDateTime(reader.GetOrdinal("Fecha_Inicio")),
                Fecha_Fin = reader.GetDateTime(reader.GetOrdinal("Fecha_Fin")),

                // Auto
                oAuto = new Autos
                {
                    Id_Auto = reader.GetInt32(reader.GetOrdinal("Id_Auto")),
                    Matricula = reader["Matricula"].ToString(),
                    Kilometros = reader.GetDecimal(reader.GetOrdinal("Kilometros")),
                    Año = reader.GetInt32(reader.GetOrdinal("Año")),
                    Imagen = reader["Imagen"].ToString(),
                    Reservado = reader.GetBoolean(reader.GetOrdinal("Reservado")),
                    Estado = reader.GetBoolean(reader.GetOrdinal("EstadoAuto")),
                    oModelo = new Modelo
                    {
                        Id_Modelo = reader.GetInt32(reader.GetOrdinal("Id_Modelo")),
                        modelo = reader["NombreModelo"].ToString(),
                        Consumo = reader.GetDecimal(reader.GetOrdinal("Consumo")),
                        Puertas = reader.GetInt32(reader.GetOrdinal("Puertas")),
                        Asientos = reader.GetInt32(reader.GetOrdinal("Asientos")),
                        oMarca = new Marca
                        {
                            Id_Marca = reader.GetInt32(reader.GetOrdinal("Id_Marca")),
                            marca = reader["NombreMarca"].ToString()
                        }
                    }
                },

                // Cliente
                oCliente = new Cliente
                {
                    Id_Cliente = reader.GetInt32(reader.GetOrdinal("Id_Cliente")),
                    Licencia = reader["Licencia"].ToString(),
                    Estado = reader.GetBoolean(reader.GetOrdinal("EstadoCliente")),
                    oPersona = new Persona
                    {
                        Id_Persona = reader.GetInt32(reader.GetOrdinal("Id_Persona")),
                        DNI = reader["DNI"].ToString(),
                        Nombre = reader["NombrePersona"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Fecha_Nacimiento = reader.GetDateTime(reader.GetOrdinal("Fecha_Nacimiento")),
                        Mail = reader["Mail"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        oDomicilio = new Domicilio
                        {
                            Id_Domicilio = reader.GetInt32(reader.GetOrdinal("Id_Domicilio")),
                            Calle = reader["Calle"].ToString(),
                            Numero = reader.GetInt32(reader.GetOrdinal("Numero")),
                            oLocalidad = new Localidad
                            {
                                Id_Localidad = reader.GetInt32(reader.GetOrdinal("Id_Localidad")),
                                localidad = reader["Localidad"].ToString(),
                                oProvincia = new Provincia
                                {
                                    Id_Provincia = reader.GetInt32(reader.GetOrdinal("Id_Provincia")),
                                    provincia = reader["Provincia"].ToString()
                                }
                            }
                        }
                    }
                },

                // Pago
                oPago = new Pago
                {
                    Id_Pago = reader.GetInt32(reader.GetOrdinal("Id_Pago")),
                    Total = Convert.ToDecimal(reader["Total"]),
                    Fecha_Pago = reader.GetDateTime(reader.GetOrdinal("Fecha_Pago")),
                    Estado = reader.GetBoolean(reader.GetOrdinal("EstadoPago"))
                }
            };
        }

        //Metodo para liberar una reserva por un id
        public int LiberarReserva(int id_reserva, out string Mensaje)
        {
            Reserva reserva = new Reserva() { Id_Reserva = id_reserva};
            return Eliminar(reserva, out Mensaje);
        }

        //Metodo para buscar una reserva segun un id
        public Reserva BuscarReserva(int obj)
        {
            Reserva reserva = Buscar(obj);
            return reserva;
        }

        //Metodo para buscar una reserva
        public Reserva Buscar(int obj)
        {
            List<Reserva> lista = new List<Reserva>();

            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("BuscarReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Reserva", obj);
                cn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(MapearExtendido(reader));
                    }
                }
            }
            return lista.FirstOrDefault();
        }

    }
}
