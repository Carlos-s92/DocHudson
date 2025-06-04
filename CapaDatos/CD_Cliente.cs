using CapaEntidad;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace CapaDatos
{
    public class CD_Cliente : CD_TemplateM<Persona>
    {
        protected override string NombreSPRegistrar() => "InsertarPersona";
        protected override string NombreSPEditar() => "ActualizarPersona";
        protected override string NombreSPEliminar() => "EliminarPersona";
        protected override string NombreSPListar() => "ListarPersonas";
        protected override string NombreSPBuscar() => "BuscarClientes";
        protected override void AgregarParametrosRegistrar(SqlCommand cmd, Persona obj)
        {
            cmd.Parameters.AddWithValue("DNI", obj.DNI);
            cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
            cmd.Parameters.AddWithValue("Apellido", obj.Apellido);
            cmd.Parameters.AddWithValue("Mail", obj.Mail);
            cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
            cmd.Parameters.AddWithValue("Id_Domicilio", obj.oDomicilio.Id_Domicilio);
            cmd.Parameters.AddWithValue("Fecha_Nacimiento", obj.Fecha_Nacimiento);
            cmd.Parameters.AddWithValue("Licencia", obj.Licencia);
            cmd.Parameters.AddWithValue("Estado", obj.Estado);
            cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        }
        protected override void AgregarParametrosEditar(SqlCommand cmd, Persona obj)
        {
            cmd.Parameters.AddWithValue("Id_Persona", obj.Id_Persona);
            cmd.Parameters.AddWithValue("DNI", obj.DNI);
            cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
            cmd.Parameters.AddWithValue("Apellido", obj.Apellido);
            cmd.Parameters.AddWithValue("Mail", obj.Mail);
            cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
            cmd.Parameters.AddWithValue("Id_Domicilio", obj.oDomicilio.Id_Domicilio);
            cmd.Parameters.AddWithValue("Fecha_Nacimiento", obj.Fecha_Nacimiento);
            cmd.Parameters.AddWithValue("Licencia", obj.Licencia);
            cmd.Parameters.AddWithValue("Estado", obj.Estado);
            cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        }
        protected override void AgregarParametrosEliminar(SqlCommand cmd, Persona obj)
        {
            cmd.Parameters.AddWithValue("Id_Persona", obj.Id_Persona);
            cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        }
        protected override void AgregarParametrosBuscar(SqlCommand cmd, string obj)
        {
            cmd.Parameters.AddWithValue("@Texto", obj);
        }
        protected override Persona Mapear(SqlDataReader reader)
        {
            return new Persona
            {
                Id_Persona = Convert.ToInt32(reader["Id_Persona"]),
                DNI = reader["DNI"].ToString(),
                Nombre = reader["Nombre"].ToString(),
                Apellido = reader["Apellido"].ToString(),
                Mail = reader["Mail"].ToString(),
                Telefono = reader["Telefono"].ToString(),
                Licencia = reader["Licencia"].ToString(),
                Estado = Convert.ToBoolean(reader["Estado"]),
                Fecha_Nacimiento = Convert.ToDateTime(reader["Fecha_Nacimiento"]),
                oDomicilio = new Domicilio
                {
                    Id_Domicilio = Convert.ToInt32(reader["Id_Domicilio"]),
                    Calle = reader["Calle"].ToString(),
                    Numero = Convert.ToInt32(reader["Numero"]),
                    oLocalidad = new Localidad
                    {
                        Id_Localidad = Convert.ToInt32(reader["Id_Localidad"]),
                        localidad = reader["Localidad"].ToString(),
                        oProvincia = new Provincia
                        {
                            Id_Provincia = Convert.ToInt32(reader["Id_Provincia"]),
                            provincia = reader["Provincia"].ToString()
                        }
                    }
                }
            };
        }

        public int BusquedaDomicilio(int persona)
        {
            int obj = 0;
            using (var oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
             
                    using (var cmd = new SqlCommand(NombreSPRegistrar(), conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Id_Persona", persona);
                        
                        oConexion.Open();
                        obj = cmd.ExecuteNonQuery();
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
    }
}