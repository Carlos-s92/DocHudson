using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Tipopago
    {
        private CD_Tipopago objcd_Tipopago = new CD_Tipopago();

        public List<TipoPago> Listar()
        {
            return objcd_Tipopago.Listar();
        }

        public int Registrar(TipoPago obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "Es Necesario la Descripcion del Tipopago\n";
            }
       


            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Tipopago.Registrar(obj, out Mensaje);
            }

        }



        public bool Editar(TipoPago obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "Es Necesario la Descripcion del Tipopago\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Tipopago.Editar(obj, out Mensaje);
            }
        }


        public bool Eliminar(TipoPago obj, out string Mensaje)
        {
            return objcd_Tipopago.Eliminar(obj, out Mensaje);
        }
    }
}
