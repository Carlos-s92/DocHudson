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
        // Metodo para conectarse y listar en la base de datos
        public List<Cliente> Listar()
        {
            //Genera una lista de clientes vacia
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder();


                    // Forma la consulta SQL
                    query.AppendLine("Select Id_Cliente, Licencia, pe.DNI, pe.Id_Persona, pe.Nombre, pe.Apellido, p.Id_Provincia, p.Provincia, l.Id_Localidad,l.Localidad, d.Calle,d.Id_Domicilio, d.Numero, pe.Fecha_Nacimiento, pe.Mail, pe.Telefono, Estado from Cliente c");
                    query.AppendLine("inner join Persona pe on pe.Id_Persona = c.Id_Persona");
                    query.AppendLine("inner join Domicilio d on d.Id_Domicilio = pe.Id_Domicilio");
                    query.AppendLine("inner join Localidad l on d.Id_Localidad = l.Id_Localidad");
                    query.AppendLine("inner join Provincia p on l.Id_Provincia = p.Id_Provincia");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);

                    // Tipo de comando SQL
                    cmd.CommandType = CommandType.Text;

                    // Abre la conexion con la base de datos
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Añade a la lista de clientes, cada cliente que encuentre
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
                                        Id_Domicilio = Convert.ToInt32(dr["Id_Domicilio"]),
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
                    oconexion.Close();
                }
                catch (Exception ex)
                {
                    //Si encuentra un error genera una lista vacia de clientes
                    lista = new List<Cliente>();
                }
            }
            return lista;
        }

        // Metodo para conectarse con la base de datos y registrar un cliente

        public int Registrar(Cliente obj, out string Mensaje)
        {
            // Genere una variable local de id y mensaje
            int IdClienteGenerado = 0;
            Mensaje = string.Empty;

            try
            {

                // Metodo para registrar y retornar el id de la persona
                int persona = new CD_Persona().Registrar(obj.oPersona,out Mensaje);

                if(persona != 0) // Si la persona se registro exitosamente

                {
                    using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                    {

                        SqlCommand cmd = new SqlCommand("InsertarCliente", oconexion);


                        //Se añaden los parametros y sus respectivos valores para el procedimiento SQL
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

                        oconexion.Close();

                    }
                }

                

            }
            catch (Exception ex)
            {
                // Si no se registro, el id del cliente se inicializa en 0
                IdClienteGenerado = 0;
                Mensaje = ex.Message;
            }

            return IdClienteGenerado;

        }

        // Metodo para conectarse a la base de datos y editar un cliente
        public bool Editar(Cliente obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {

                // Metodo para editar la persona asociada al cliente
                int persona = new CD_Persona().Editar(obj.oPersona, out Mensaje);
                if (persona != 0){
                
        
                    using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                    {

                        SqlCommand cmd = new SqlCommand("ActualizarCliente", oconexion);

                        // Agrega los parametros necesarios para el procedimiento SQL
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
                        oconexion.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                // Si no se edito el usuario que devuelva falso
                Respuesta = false;
                Mensaje = ex.Message;
            }

            return Respuesta;

        }

        // Metodo para conectarse a una base de datos y eliminar el cliente
        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {


                    SqlCommand cmd = new SqlCommand("EliminarCliente", oconexion);

                    // Se agregan los parametros necesarios para el procedimiento SQL
                    cmd.Parameters.AddWithValue("Id_Cliente", obj.Id_Cliente);
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
                // En caso de error retorna falso
                Respuesta = false;
                Mensaje = ex.Message;
            }

            return Respuesta;

        }



    }
}
