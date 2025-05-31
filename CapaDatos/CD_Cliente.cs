using CapaEntidad;
using System;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Cliente : CD_TemplateM<Cliente>
    {
        protected override string NombreSPRegistrar() => "InsertarCliente";
        protected override string NombreSPEditar() => "ActualizarCliente";
        protected override string NombreSPEliminar() => "EliminarCliente";
        protected override string NombreSPListar() => "ListarClientes";
        protected override string NombreSPBuscar() => "BuscarClientes";
        protected override void AgregarParametrosRegistrar(SqlCommand cmd, Cliente obj)
        {
            cmd.Parameters.AddWithValue("Id_Persona", obj.oPersona.Id_Persona);
            cmd.Parameters.AddWithValue("Licencia", obj.Licencia);
            cmd.Parameters.AddWithValue("Estado", obj.Estado);
            cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        }
        protected override void AgregarParametrosEditar(SqlCommand cmd, Cliente obj)
        {
            cmd.Parameters.AddWithValue("Id_Cliente", obj.Id_Cliente);
            cmd.Parameters.AddWithValue("Id_Persona", obj.oPersona.Id_Persona);
            cmd.Parameters.AddWithValue("Licencia", obj.Licencia);
            cmd.Parameters.AddWithValue("Estado", obj.Estado);
            cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        }
        protected override void AgregarParametrosEliminar(SqlCommand cmd, Cliente obj)
        {
            cmd.Parameters.AddWithValue("Id_Cliente", obj.Id_Cliente);
            cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        }
        protected override void AgregarParametrosBuscar(SqlCommand cmd, string obj)
        {
            cmd.Parameters.AddWithValue("@Texto", obj);
        }
        protected override Cliente Mapear(SqlDataReader reader)
        {
            return new Cliente
            {
                Id_Cliente = Convert.ToInt32(reader["Id_Cliente"]),
                Licencia = reader["Licencia"].ToString(),
                oPersona = new Persona()
                {
                    Id_Persona = Convert.ToInt32(reader["Id_Persona"]),
                    DNI = reader["DNI"].ToString(),
                    Nombre = reader["Nombre"].ToString(),
                    Apellido = reader["Apellido"].ToString(),
                    Fecha_Nacimiento = Convert.ToDateTime(reader["Fecha_Nacimiento"]),
                    Mail = reader["Mail"].ToString(),
                    Telefono = reader["Telefono"].ToString(),
                    oDomicilio = new Domicilio()
                    {
                        Id_Domicilio = Convert.ToInt32(reader["Id_Domicilio"]),
                        Calle = reader["Calle"].ToString(),
                        Numero = Convert.ToInt32(reader["Numero"]),
                        oLocalidad = new Localidad()
                        {
                            Id_Localidad = Convert.ToInt32(reader["Id_Localidad"]),
                            localidad = reader["Localidad"].ToString(),
                            oProvincia = new Provincia()
                            {
                                Id_Provincia = Convert.ToInt32(reader["Id_Provincia"]),
                                provincia = reader["Provincia"].ToString()
                            }
                        }
                    },
                },
                Estado = Convert.ToBoolean(reader["Estado"]),
            };
        }
    }
}