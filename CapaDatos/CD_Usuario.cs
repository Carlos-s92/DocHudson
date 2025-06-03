using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Usuario : CD_TemplateM<Usuarios>
    {
        protected override string NombreSPRegistrar() => "InsertarUsuario";
        protected override string NombreSPEditar() => "ActualizarUsuario";
        protected override string NombreSPEliminar() => "EliminarUsuario";
        protected override string NombreSPListar() => "ListarUsuarios";
        protected override string NombreSPBuscar() => "BuscarUsuarios";
        protected override void AgregarParametrosRegistrar(SqlCommand cmd, Usuarios obj)
        {
            cmd.Parameters.AddWithValue("Usuario", obj.Usuario);
            cmd.Parameters.AddWithValue("Contraseña", obj.Contraseña);
            cmd.Parameters.AddWithValue("DNI", obj.Dni);
            cmd.Parameters.AddWithValue("Id_Perfil", obj.oPerfil.Id_Perfil);
            cmd.Parameters.AddWithValue("Estado", obj.Estado);
            cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        }
        protected override void AgregarParametrosEditar(SqlCommand cmd, Usuarios obj)
        {
            cmd.Parameters.AddWithValue("IdUsuario", obj.Id_Usuario);
            cmd.Parameters.AddWithValue("Usuario", obj.Usuario);
            cmd.Parameters.AddWithValue("Contraseña", obj.Contraseña);
            cmd.Parameters.AddWithValue("DNI", obj.Dni);
            cmd.Parameters.AddWithValue("Id_Perfil", obj.oPerfil.Id_Perfil);
            cmd.Parameters.AddWithValue("Estado", obj.Estado);
            cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        }
        protected override void AgregarParametrosEliminar(SqlCommand cmd, Usuarios obj)
        {
            cmd.Parameters.AddWithValue("Id_Usuario", obj.Id_Usuario);
            cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        }
        protected override void AgregarParametrosBuscar(SqlCommand cmd, string obj)
        {
            cmd.Parameters.AddWithValue("@Texto", obj);
        }
        protected override Usuarios Mapear(SqlDataReader reader)
        {
            return new Usuarios
            {
                Id_Usuario = Convert.ToInt32(reader["Id_Usuario"]),
                Usuario = reader["Usuario"].ToString(),
                Contraseña = reader["Contraseña"].ToString(),
                Dni = reader["DNI"].ToString(),
                Estado = Convert.ToBoolean(reader["Estado"]),
                oPerfil = new Perfiles()
                {
                    Id_Perfil = Convert.ToInt32(reader["Id_Perfil"]),
                    Descripcion = reader["Descripcion"].ToString()
                }
            };
        }
    }
}