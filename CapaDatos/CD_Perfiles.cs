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
    public class CD_Perfiles
    {
        public List<Perfiles> Listar()
        {
            List<Perfiles> lista = new List<Perfiles>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.Id_Perfil, p.Descripcion FROM Perfiles p");
             
            

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oconexion))
                    {
                        cmd.CommandType = CommandType.Text;

                        oconexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Perfiles()
                                {
                                    Id_Perfil = Convert.ToInt32(dr["Id_Perfil"]),
                                    Descripcion = dr["Descripcion"].ToString()
                                });
                            }
                        }
                        oconexion.Close();
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Perfiles>(); // Asegura que no se retorne null
                }
            }
            return lista;
        }
    }
}
