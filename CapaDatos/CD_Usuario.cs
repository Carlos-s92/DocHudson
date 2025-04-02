using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;


namespace CapaDatos
{
    public class CD_Usuario
    {
        public List<Usuarios> Listar()
        {
            List<Usuarios> lista = new List<Usuarios>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT u.IdUsuario, u.Documento, u.NombreCompleto, u.Correo, u.Clave, u.Estado, r.IdRol, r.Descripcion");
                    query.AppendLine("FROM usuario u");
                    query.AppendLine("INNER JOIN Rol r ON r.IdRol = u.IdRol");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oconexion))
                    {
                        cmd.CommandType = CommandType.Text;

                        oconexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Usuarios()
                                {
                                    Id_Usuario = Convert.ToInt32(dr["IdUsuario"]),
                                    Usuario = dr["Correo"].ToString(),
                                    Contraseña = dr["Clave"].ToString(),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    oPerfil = new Perfiles()
                                    {
                                        Id_Perfil = Convert.ToInt32(dr["IdRol"]),
                                        Descripcion = dr["Descripcion"].ToString()
                                    }
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Usuarios>(); // Asegura que no se retorne null
                }
            }
            return lista;
        }
    }
}
