using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Provincia
    {
        public List<Provincia> Listar()
        {
            List<Provincia> lista = new List<Provincia>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT Id_Provincia, Provincia FROM Provincia");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);

                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Provincia()
                            {
                                Id_Provincia = Convert.ToInt32(dr["Id_Provincia"]),
                                provincia = dr["Provincia"].ToString(),
                                
                            });
                        }
                        
                    }
                    oconexion.Close();
                }
                catch (Exception ex) 
                {
                    lista = new List<Provincia>();
                }
            }
            return lista;
        }
    }
}
