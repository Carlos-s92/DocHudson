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
    public class CD_Modelo
    {
        public List<Modelo> Listar()
        {
            List<Modelo> lista = new List<Modelo>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT Id_Modelo, Id_Marca, modelo, Consumo, Puertas, Asientos FROM Modelo");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oconexion))
                    {
                        cmd.CommandType = CommandType.Text;

                        oconexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Modelo()
                                {

                                    Id_Modelo = Convert.ToInt32(dr["Id_Modelo"]),
                                    oMarca = new Marca()
                                    {
                                        Id_Marca = Convert.ToInt32(dr["Id_Marca"]),
                                    },
                                    modelo = dr["modelo"].ToString(),
                                    Consumo = Convert.ToDecimal(dr["Consumo"]),
                                    Puertas = Convert.ToInt32(dr["Puertas"]),
                                    Asientos = Convert.ToInt32(dr["Asientos"]),
                                });
                            }
                        }
                        oconexion.Close();
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Modelo>(); // Asegura que no se retorne null
                }
            }
            return lista;
        }
    }
}
