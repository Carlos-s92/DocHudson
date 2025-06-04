using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objcd_cliente = new CD_Cliente();

        // Metodo para listar todos los clientes
        public List<Persona> Listar()
        {
            return objcd_cliente.Listar();
        }

        // Metodo para buscar un domicilio segun una persona

        public int BusquedaDomicilio(int persona)
        {
            int id = 0;

            id = new CD_Cliente().BusquedaDomicilio(persona);

            return id;
        }

        // Metodo para registrar un cliente
        public int Registrar(Persona obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Licencia == "")
            {
                Mensaje += "Es Necesario la licencia del Cliente\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es Necesario el Nombre del Cliente\n";
            }
            if (obj.Apellido == "")
            {
                Mensaje += "Es Necesario el apellido del Cliente\n";
            }
            if (obj.Telefono == "")
            {
                Mensaje += "Es Necesario el Telefono del Cliente\n";
            }
            if (obj.DNI == "")
            {
                Mensaje += "Es Necesario el DNI del Cliente\n";
            }
            if (obj.oDomicilio.oLocalidad.oProvincia.Id_Provincia == 0)
            {
                Mensaje += "Es Necesario la Provincia del Cliente\n";
            }
            if (obj.oDomicilio.oLocalidad.localidad == "")
            {
                Mensaje += "Es Necesario la Localidad del Cliente\n";
            }
            if (obj.oDomicilio.Calle == "")
            {
                Mensaje += "Es Necesario la Calle del Cliente\n";
            }
            if (obj.oDomicilio.Numero == 0)
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

            List<Persona> list = objcd_cliente.Listar();

            foreach (Persona item in list)
            {
                if (item.DNI == obj.DNI || item.Mail == obj.Mail)
                {
                    Mensaje += "El cliente ya existe";
                }
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
                Persona persona = new Persona()
                {
                    Licencia = obj.Licencia,
                    Estado = obj.Estado,
                    DNI = obj.DNI,
                    Mail = obj.Mail,
                    Nombre = obj.Nombre,
                    Apellido = obj.Apellido,
                    Telefono = obj.Telefono,
                    oDomicilio = obj.oDomicilio,
                    Fecha_Nacimiento = obj.Fecha_Nacimiento
                };
                return objcd_cliente.Registrar(obj, out Mensaje);
            }

        }

        // Metodo para traer un id de persona segun un documento
        public int BusquedaDni(string dni)
        {
            int id = 0;

            id = new CD_Persona().BusquedaDni(dni);

            return id;
        }

        // Metodo para editar un cliente
        public int Editar(Persona obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "Es Necesario el Nombre del Cliente\n";
            }
            if (obj.Apellido == "")
            {
                Mensaje += "Es Necesario el apellido del Cliente\n";
            }
            if (obj.Licencia == "")
            {
                Mensaje += "Es Necesario la licencia del Cliente\n";
            }

            if (obj.Telefono == "")
            {
                Mensaje += "Es Necesario el Telefono del Cliente\n";
            }
            if (obj.DNI == "")
            {
                Mensaje += "Es Necesario el DNI del Cliente\n";
            }
            if (obj.oDomicilio.oLocalidad.oProvincia.Id_Provincia == 0)
            {
                Mensaje += "Es Necesario la Provincia del Cliente\n";
            }
            if (obj.oDomicilio.oLocalidad.localidad == "")
            {
                Mensaje += "Es Necesario la Localidad del Cliente\n";
            }
            if (obj.oDomicilio.Calle == "")
            {
                Mensaje += "Es Necesario la Calle del Cliente\n";
            }
            if (obj.oDomicilio.Numero == 0)
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
                return 0;
            }
            else
            {
                Persona persona = new Persona()
                {
                    Id_Persona = obj.Id_Persona,
                    Licencia = obj.Licencia,
                    Estado = obj.Estado,
                    DNI = obj.DNI,
                    Mail = obj.Mail,
                    Nombre = obj.Nombre,
                    Apellido = obj.Apellido,
                    Telefono = obj.Telefono,
                    oDomicilio = obj.oDomicilio,
                    Fecha_Nacimiento = obj.Fecha_Nacimiento
                };
           
                return objcd_cliente.Editar(obj, out Mensaje);
            }
        }

        // Metodo para eliminar un cliente
        public int Eliminar(Persona obj, out string Mensaje)
        {
            return objcd_cliente.Eliminar(obj, out Mensaje);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Metodo para verificar si el mail es valido
        public bool MailValido(string email)//Método que verifica si el E-Mail es Válido, devuelve True en caso de ser verdadero
        {
            string regex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }

        public List<Persona> BuscarCliente(string texto)
        {
            return objcd_cliente.Buscar(texto);
        }

    }
}
