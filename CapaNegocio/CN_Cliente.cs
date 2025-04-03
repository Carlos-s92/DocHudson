using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objcd_cliente = new CD_Cliente();

        public List<Cliente> Listar()
        {
            return objcd_cliente.Listar();
        }
        public Cliente ClientePorPago(int idPago)
        {
            return objcd_cliente.ObtenerClientePorPago(idPago);
        }

        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "Es Necesario el Nombre del Cliente\n";
            }
            if (obj.Telefono == "")
            {
                Mensaje += "Es Necesario el Telefono del Cliente\n";
            }
            if (obj.Dni == "")
            {
                Mensaje += "Es Necesario el DNI del Cliente\n";
            }
            if (obj.Provincia == "")
            {
                Mensaje += "Es Necesario la Provincia del Cliente\n";
            }
            if (obj.Localidad == "")
            {
                Mensaje += "Es Necesario la Localidad del Cliente\n";
            }
            if (obj.Calle == "")
            {
                Mensaje += "Es Necesario la Calle del Cliente\n";
            }
            if (obj.Numero == 0)
            {
                Mensaje += "Es Necesario el Numero de Calle del Cliente\n";
            }
            if (obj.Licencia == "")
            {
                Mensaje += "Es Necesario la Licencia del Cliente\n";
            }


            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_cliente.Registrar(obj, out Mensaje);
            }

        }



        public bool Editar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "Es Necesario el Nombre del Cliente\n";
            }

            if (obj.Telefono == "")
            {
                Mensaje += "Es Necesario el Telefono del Cliente\n";
            }
            if (obj.Dni == "")
            {
                Mensaje += "Es Necesario el DNI del Cliente\n";
            }
            if (obj.Provincia == "")
            {
                Mensaje += "Es Necesario la Provincia del Cliente\n";
            }
            if (obj.Localidad == "")
            {
                Mensaje += "Es Necesario la Localidad del Cliente\n";
            }
            if (obj.Calle == "")
            {
                Mensaje += "Es Necesario la Calle del Cliente\n";
            }
            if (obj.Numero == 0)
            {
                Mensaje += "Es Necesario el Numero de Calle del Cliente\n";
            }
            if (obj.Licencia == "")
            {
                Mensaje += "Es Necesario la Licencia del Cliente\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_cliente.Editar(obj, out Mensaje);
            }
        }


        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            return objcd_cliente.Eliminar(obj, out Mensaje);
        }
    }
}
