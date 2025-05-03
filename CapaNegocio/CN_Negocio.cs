using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Negocio
    {
        private CD_Negocio objcd_Negocio = new CD_Negocio();

        public Negocio obtenerDatos()
        {
            return objcd_Negocio.obtenerDatos();
        }

        public bool guardarDatos(Negocio obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "Es Necesario el nombre del Negocio\n";
            }
            if (obj.Imagen == "")
            {
                Mensaje += "Es Necesario una Imagen de Negocio\n";
            }
            if (obj.Domicilio == "")
            {
                Mensaje += "Es Necesario el domicilio del Negocio\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Negocio.guardarDatos(obj, out Mensaje);
            }

        }

    }
}
