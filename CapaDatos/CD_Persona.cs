using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Persona
    {
        public List<Persona> Listar()
        {
            var lista = new List<Persona>();
            using (var oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("SELECT p.Id_Persona, p.DNI, p.Nombre, p.Apellido, p.Mail, p.Telefono,");
                    sb.AppendLine("       p.Id_Domicilio, p.Fecha_Nacimiento,");
                    sb.AppendLine("       d.Calle, d.Numero, d.Id_Localidad,");
                    sb.AppendLine("       l.Localidad, l.Id_Provincia,");
                    sb.AppendLine("       pr.Provincia");
                    sb.AppendLine("FROM Persona p");
                    sb.AppendLine("INNER JOIN Dirección d ON d.Id_Domicilio = p.Id_Domicilio");
                    sb.AppendLine("INNER JOIN Localidad l ON l.Id_Localidad = d.Id_Localidad");
                    sb.AppendLine("INNER JOIN Provincia pr ON pr.Id_Provincia = l.Id_Provincia");

                    using (var cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Persona
                                {
                                    Id_Persona = Convert.ToInt32(dr["Id_Persona"]),
                                    DNI = dr["DNI"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    Apellido = dr["Apellido"].ToString(),
                                    Mail = dr["Mail"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Fecha_Nacimiento = Convert.ToDateTime(dr["Fecha_Nacimiento"]),
                                    oDomicilio = new Domicilio
                                    {
                                        Id_Domicilio = Convert.ToInt32(dr["Id_Domicilio"]),
                                        Calle = dr["Calle"].ToString(),
                                        Numero = Convert.ToInt32(dr["Numero"]),
                                        oLocalidad = new Localidad
                                        {
                                            Id_Localidad = Convert.ToInt32(dr["Id_Localidad"]),
                                            localidad = dr["Localidad"].ToString(),
                                            oProvincia = new Provincia
                                            {
                                                Id_Provincia = Convert.ToInt32(dr["Id_Provincia"]),
                                                provincia = dr["Provincia"].ToString()
                                            }
                                        }
                                    }
                                });
                            }

                          

                        }
                        oConexion.Close();

                    }
                }
                catch
                {
                    lista = new List<Persona>();
                }
            }
            return lista;
        }

        public int Registrar(Persona obj, out string Mensaje)
        {
            int idGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    obj.oDomicilio.Id_Domicilio = new CD_Domicilio().Registrar(obj.oDomicilio);


                    SqlCommand cmd = new SqlCommand("InsertarPersona", oconexion);

               
                    cmd.Parameters.AddWithValue("DNI", obj.DNI);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("Mail", obj.Mail);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Id_Domicilio", obj.oDomicilio.Id_Domicilio);
                    cmd.Parameters.AddWithValue("Fecha_Nacimiento", obj.Fecha_Nacimiento);

                    cmd.Parameters.Add("IdResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idGenerado = Convert.ToInt32(cmd.Parameters["IdResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].ToString();

                    oconexion.Close();

                }
            }
            catch (Exception ex)
            {
                idGenerado = 0;
                Mensaje = ex.Message;
            }
            return idGenerado;
        }


        //public Persona Buscar(int id)
        //{
        //    Persona obj = null;
        //    using (var oConexion = new SqlConnection(Conexion.cadena))
        //    {
        //        try
        //        {
        //            var sb = new StringBuilder();
        //            sb.AppendLine("SELECT p.Id_Persona, p.DNI, p.Nombre, p.Apellido, p.Mail, p.Telefono,");
        //            sb.AppendLine("       p.Id_Domicilio, p.Fecha_Nacimiento,");
        //            sb.AppendLine("       d.Calle, d.Numero, d.Id_Localidad,");
        //            sb.AppendLine("       l.Localidad, l.Id_Provincia,");
        //            sb.AppendLine("       pr.Provincia");
        //            sb.AppendLine("FROM Persona p");
        //            sb.AppendLine("INNER JOIN Domicilio d ON d.Id_Domicilio = p.Id_Domicilio");
        //            sb.AppendLine("INNER JOIN Localidad l ON l.Id_Localidad = d.Id_Localidad");
        //            sb.AppendLine("INNER JOIN Provincia pr ON pr.Id_Provincia = l.Id_Provincia");
        //            sb.AppendLine("WHERE p.Id_Persona = @Id");

        //            using (var cmd = new SqlCommand(sb.ToString(), oConexion))
        //            {
        //                cmd.Parameters.AddWithValue("Id", id);
        //                cmd.CommandType = CommandType.Text;
        //                oConexion.Open();
        //                using (var dr = cmd.ExecuteReader())
        //                {
        //                    if (dr.Read())
        //                    {
        //                        obj = new Persona
        //                        {
        //                            Id_Persona = Convert.ToInt32(dr["Id_Persona"]),
        //                            DNI = dr["DNI"].ToString(),
        //                            Nombre = dr["Nombre"].ToString(),
        //                            Apellido = dr["Apellido"].ToString(),
        //                            Mail = dr["Mail"].ToString(),
        //                            Telefono = dr["Telefono"].ToString(),
        //                            Fecha_Nacimiento = Convert.ToDateTime(dr["Fecha_Nacimiento"]),
        //                            oDomicilio = new Domicilio
        //                            {
        //                                Id_Domicilio = Convert.ToInt32(dr["Id_Domicilio"]),
        //                                Calle = dr["Calle"].ToString(),
        //                                Numero = Convert.ToInt32(dr["Numero"]),
        //                                oLocalidad = new Localidad
        //                                {
        //                                    Id_Localidad = Convert.ToInt32(dr["Id_Localidad"]),
        //                                    localidad = dr["Localidad"].ToString(),
        //                                    oProvincia = new Provincia
        //                                    {
        //                                        Id_Provincia = Convert.ToInt32(dr["Id_Provincia"]),
        //                                        provincia = dr["Provincia"].ToString()
        //                                    }
        //                                }
        //                            }
        //                        };
        //                    }
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            obj = null;
        //        }
        //    }
        //    return obj;
        //}


        public int BusquedaDni(string dni)
        {
            int obj = 0;
            using (var oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("SELECT p.DNI FROM Persona p WHERE p.DNI = @dni");

                    using (var cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("dni", dni);
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                obj = Convert.ToInt32(dr["Id_Persona"]);
                               
                            }
                        }
                        oConexion.Close();
                    }
                }
                catch
                {
                    obj = 0;
                }
            }
            return obj;
        }

        public int BusquedaDomicilio(int persona)
        {
            int obj = 0;
            using (var oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("SELECT d.Id_Domicilio FROM Persona p \r\ninner join Domicilio d on d.Id_Domicilio = p.Id_Domicilio\r\nwhere p.Id_Persona = @Id");

                    using (var cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("Id", persona);
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                obj = Convert.ToInt32(dr["Id_Domicilio"]);

                            }
                        }
                        oConexion.Close();
                    }
                }
                catch
                {
                    obj = 0;
                }
            }
            return obj;
        }


        public int Editar(Persona obj, out string Mensaje)
        {
            int id = 0;
            int respuesta = 0;
            Mensaje = string.Empty;
            try
            {

                id = new CD_Domicilio().EditarDomicilio(obj.oDomicilio);
                using (var oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("ActualizarPersona", oConexion);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Id_Persona", obj.Id_Persona);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("DNI", obj.DNI);
                    cmd.Parameters.AddWithValue("Mail", obj.Mail);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Id_Domicilio", id);
                    cmd.Parameters.AddWithValue("Fecha_Nacimiento", obj.Fecha_Nacimiento);

                    cmd.Parameters.Add("IdResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToInt32(cmd.Parameters["IdResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].ToString();

                    oConexion.Close();

                }
            }
            catch (Exception ex)
            {
                respuesta = 0;
                Mensaje = ex.Message;
            }
            return respuesta;
        }
    }
}

