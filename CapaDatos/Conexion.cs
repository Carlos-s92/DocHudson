using System;
using System.Configuration;

namespace CapaDatos
{
    public class Conexion
    {
        //Se crea la cadena de conexion a la base de datos
        public static String cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ToString();
    }
}
