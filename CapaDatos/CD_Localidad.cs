using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace CapaDatos
{
    public class CD_Localidad
    {
        public List<Localidad> Listar()
        {
            List<Localidad> lista = new List<Localidad>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT Id_Localidad, Id_Provincia, localidad FROM Localidad");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oconexion))
                    {
                        cmd.CommandType = CommandType.Text;

                        oconexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                /*int idLoc = Convert.ToInt32(dr["Id_Localidad"]);
                                if ( == idLoc)
                                {

                                }*/
                                lista.Add(new Localidad()
                                {
                                    Id_Localidad = Convert.ToInt32(dr["Id_Localidad"]),
                                    oProvincia = new Provincia()
                                    {
                                        Id_Provincia = Convert.ToInt32(dr["Id_Provincia"]),
                                    },
                                    localidad = dr["localidad"].ToString(),
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Localidad>(); // Asegura que no se retorne null
                }
            }
            return lista;
        }

    }
}
