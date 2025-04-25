using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Reflection;

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

                    query.AppendLine("Select Id_Cliente, Licencia, pe.DNI, pe.Nombre, pe.Apellido, p.Id_Provincia,p.Provincia, l.Id_Localidad,l.Localidad, d.Calle, d.Numero, pe.Fecha_Nacimiento, pe.Mail, pe.Telefono, Estado from Cliente c");
                    query.AppendLine("inner join Persona pe on pe.Id_Persona = c.Id_Persona");
                    query.AppendLine("inner join Direccion d on d.Id_Direccion = pe.Id_Direccion");
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
                                Licencia = dr["Licencia"].ToString(),

                                oPersona = new Persona() 
                                {
                                    Id_Persona = Convert.ToInt32(dr["Id_Persona"]),
                                    DNI = dr["DNI"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    Apellido = dr["Apellido"].ToString(),
                                    Fecha_Nacimiento = Convert.ToDateTime(dr["Fecha_Nacimiento"]),
                                    Mail = dr["Mail"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    oDomicilio = new Domicilio()
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
                                },


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


        public int Registrar(Cliente obj, out string Mensaje)
        {
            int IdClienteGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                int persona = new CD_Persona().Registrar(obj.oPersona,out Mensaje);

                if(persona != 0)
                {
                    using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                    {

                        SqlCommand cmd = new SqlCommand("InsertarCliente", oconexion);

                        cmd.Parameters.AddWithValue("Id_Persona", persona);
                        cmd.Parameters.AddWithValue("Licencia", obj.Licencia);
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
                int persona = new CD_Persona().Editar(obj.oPersona, out Mensaje);

                if (persona != 0){
                
        
                    using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                    {


                        SqlCommand cmd = new SqlCommand("ActualizarCliente", oconexion);
                        cmd.Parameters.AddWithValue("Id_Cliente", obj.Id_Cliente);
                        cmd.Parameters.AddWithValue("Id_Persona", persona);
                        cmd.Parameters.AddWithValue("Licencia", obj.Licencia);
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
