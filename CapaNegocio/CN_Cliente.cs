using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (obj.Mail == "")
            {
                Mensaje += "Es Necesario el Mail del Cliente\n";
            }
            ////////////////////////////////////////////////////////////
            if (!MailValido(obj.Mail))//Llamada al método para verificar mail
            {
                Mensaje += "Verificar que el Mail sea Correcto\n";
            }

            DateTime fechaNacimiento = obj.Fecha_Nacimiento;//Cálculo de Edad y Mensaje si es menor de edad
            int edad = DateTime.Now.Year - fechaNacimiento.Year;

            if (fechaNacimiento > DateTime.Now.AddYears(-edad))
            {
                edad--;
            }

            if (edad < 18)
            {
                Mensaje += "El Cliente debe tener 18 años o más para Alquilar un Auto\n";
            }
            /////////////////////////////////////////////////////////////

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
            if (obj.Mail == "")
            {
                Mensaje += "Es Necesario el Mail del Cliente\n";
            }
            ///////////////////////////////////////////////////////////
            if (!MailValido(obj.Mail))//Llamada al método para verificar mail
            {
                Mensaje += "Verificar que el Mail sea Correcto\n";
            }

            DateTime fechaNacimiento = obj.Fecha_Nacimiento;//Cálculo de Edad y Mensaje si es menor de edad
            int edad = DateTime.Now.Year - fechaNacimiento.Year;

            if (fechaNacimiento > DateTime.Now.AddYears(-edad))
            {
                edad--;
            }

            if (edad < 18)
            {
                Mensaje += "El Cliente debe tener 18 años o más para Alquilar un Auto\n";
            }
            ///////////////////////////////////////////////////////////
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

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool MailValido(string email)//Método que verifica si el E-Mail es Válido, devuelve True en caso de ser verdadero
        {
            string regex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }
    }
}
