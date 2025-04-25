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
    public class CD_Domicilio
    {

        public int Registrar(Domicilio domicilio)
        {
            int id = 0;
            string Mensaje = string.Empty;
            try
            {
            
                    using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                    {

                        SqlCommand cmd = new SqlCommand("InsertarDomicilio", oconexion);

                        cmd.Parameters.AddWithValue("Calle", domicilio.Calle);
                        cmd.Parameters.AddWithValue("Numero", domicilio.Numero);
                        cmd.Parameters.AddWithValue("Id_Localidad", domicilio.oLocalidad.Id_Localidad);
                        cmd.Parameters.Add("IdResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;

                        oconexion.Open();

                        cmd.ExecuteNonQuery();

                        id = Convert.ToInt32(cmd.Parameters["IdResultado"].Value);
                        Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                    }
                



            }
            catch (Exception ex)
            {
                id = 0;
                Mensaje = ex.Message;
            }


            return id;

        }


    }
}
