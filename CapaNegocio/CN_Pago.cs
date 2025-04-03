using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Pago
    {
        private CD_Pago objcd_Pago = new CD_Pago();

        public List<Pago> Listar()
        {
            return objcd_Pago.Listar();
        }

        public int Registrar(Pago obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oTipoPago.Id_TipoPago == 0)
            {
                Mensaje += "Es Necesario el Tipo de Pago\n";
            }
            if (obj.Total <= 0)
            {
                Mensaje += "Es Necesario el Total del Pago\n";
            }




            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Pago.Registrar(obj, out Mensaje);
            }

        }



        public bool Editar(Pago obj, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (obj.oTipoPago.Id_TipoPago == 0)
            {
                Mensaje += "Es Necesario el Tipo de Pago\n";
            }
            if (obj.Total <= 0)
            {
                Mensaje += "Es Necesario el Total del Pago\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Pago.Editar(obj, out Mensaje);
            }
        }


        public bool Eliminar(Pago obj, out string Mensaje)
        {
            return objcd_Pago.Eliminar(obj, out Mensaje);
        }
    }
}
