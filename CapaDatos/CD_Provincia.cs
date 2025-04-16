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
                    query.AppendLine("SELECT Nombre FROM Provincia");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);

                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Provincia()
                            {

                                Nombre = dr["Nombre"].ToString(),
                                
                            });
                        }
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("no hay provincias");
                }
            }
            return lista;
        }
    }
}
