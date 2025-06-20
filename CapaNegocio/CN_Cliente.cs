﻿using CapaDatos;
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
        public List<Cliente> Listar()
        {
            return objcd_cliente.Listar();
        }

        // Metodo para buscar un domicilio segun una persona

        public int BusquedaDomicilio(int persona)
        {
            int id = 0;

            id = new CD_Persona().BusquedaDomicilio(persona);

            return id;
        }

        // Metodo para registrar un cliente
        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Licencia == "")
            {
                Mensaje += "Es Necesario la licencia del Cliente\n";
            }
            if (obj.oPersona.Nombre == "")
            {
                Mensaje += "Es Necesario el Nombre del Cliente\n";
            }
            if (obj.oPersona.Apellido == "")
            {
                Mensaje += "Es Necesario el apellido del Cliente\n";
            }
            if (obj.oPersona.Telefono == "")
            {
                Mensaje += "Es Necesario el Telefono del Cliente\n";
            }
            if (obj.oPersona.DNI == "")
            {
                Mensaje += "Es Necesario el DNI del Cliente\n";
            }
            if (obj.oPersona.oDomicilio.oLocalidad.oProvincia.Id_Provincia == 0)
            {
                Mensaje += "Es Necesario la Provincia del Cliente\n";
            }
            if (obj.oPersona.oDomicilio.oLocalidad.localidad == "")
            {
                Mensaje += "Es Necesario la Localidad del Cliente\n";
            }
            if (obj.oPersona.oDomicilio.Calle == "")
            {
                Mensaje += "Es Necesario la Calle del Cliente\n";
            }
            if (obj.oPersona.oDomicilio.Numero == 0)
            {
                Mensaje += "Es Necesario el Numero de Calle del Cliente\n";
            }
            if (obj.oPersona.Mail == "")
            {
                Mensaje += "Es Necesario el Mail del Cliente\n";
            }
            ////////////////////////////////////////////////////////////
            if (!MailValido(obj.oPersona.Mail))//Llamada al método para verificar mail
            {
                Mensaje += "Verificar que el Mail sea Correcto\n";
            }

            List<Cliente> list = objcd_cliente.Listar();

            foreach (Cliente item in list)
            {
                if (item.oPersona.DNI == obj.oPersona.DNI)
                {
                    Mensaje += "El cliente ya existe con ese D.N.I";
                }
                if (item.oPersona.Mail == obj.oPersona.Mail)
                {
                    Mensaje += "El cliente ya existe con ese Mail";
                }
                if (item.Licencia == obj.Licencia)
                {
                    Mensaje += "El cliente ya existe con esa Licencia";
                }
            }


            DateTime fechaNacimiento = obj.oPersona.Fecha_Nacimiento;//Cálculo de Edad y Mensaje si es menor de edad
            int edad = DateTime.Now.Year - fechaNacimiento.Year;

            if (fechaNacimiento > DateTime.Now.AddYears(-edad))
            {
                edad--;
            }

            if (edad > 90)
            {
                Mensaje += "El Cliente debe tener menos de 90 años\n";
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
                    DNI = obj.oPersona.DNI,
                    Mail = obj.oPersona.Mail,
                    Nombre = obj.oPersona.Nombre,
                    Apellido = obj.oPersona.Apellido,
                    Telefono = obj.oPersona.Telefono,
                    oDomicilio = obj.oPersona.oDomicilio,
                    Fecha_Nacimiento = obj.oPersona.Fecha_Nacimiento
                };
                obj.oPersona.Id_Persona = new CD_Persona().Registrar(persona, out Mensaje);
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
        public int Editar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            //Se realizan validaciones necesarias para editar un cliente
            if (obj.oPersona.Nombre == "")
            {
                Mensaje += "Es Necesario el Nombre del Cliente\n";
            }
            if (obj.oPersona.Apellido == "")
            {
                Mensaje += "Es Necesario el apellido del Cliente\n";
            }
            if (obj.Licencia == "")
            {
                Mensaje += "Es Necesario la licencia del Cliente\n";
            }

            if (obj.oPersona.Telefono == "")
            {
                Mensaje += "Es Necesario el Telefono del Cliente\n";
            }
            if (obj.oPersona.DNI == "")
            {
                Mensaje += "Es Necesario el DNI del Cliente\n";
            }
            if (obj.oPersona.oDomicilio.oLocalidad.oProvincia.Id_Provincia == 0)
            {
                Mensaje += "Es Necesario la Provincia del Cliente\n";
            }
            if (obj.oPersona.oDomicilio.oLocalidad.localidad == "")
            {
                Mensaje += "Es Necesario la Localidad del Cliente\n";
            }
            if (obj.oPersona.oDomicilio.Calle == "")
            {
                Mensaje += "Es Necesario la Calle del Cliente\n";
            }
            if (obj.oPersona.oDomicilio.Numero == 0)
            {
                Mensaje += "Es Necesario el Numero de Calle del Cliente\n";
            }
            if (obj.oPersona.Mail == "")
            {
                Mensaje += "Es Necesario el Mail del Cliente\n";
            }
            ///////////////////////////////////////////////////////////
            if (!MailValido(obj.oPersona.Mail))//Llamada al método para verificar mail
            {
                Mensaje += "Verificar que el Mail sea Correcto\n";
            }

            DateTime fechaNacimiento = obj.oPersona.Fecha_Nacimiento;//Cálculo de Edad y Mensaje si es menor de edad
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
                    Id_Persona = obj.oPersona.Id_Persona,
                    DNI = obj.oPersona.DNI,
                    Mail = obj.oPersona.Mail,
                    Nombre = obj.oPersona.Nombre,
                    Apellido = obj.oPersona.Apellido,
                    Telefono = obj.oPersona.Telefono,
                    oDomicilio = obj.oPersona.oDomicilio,
                    Fecha_Nacimiento = obj.oPersona.Fecha_Nacimiento
                };
                obj.oPersona.Id_Persona = new CD_Persona().Editar(persona, out Mensaje);
                return objcd_cliente.Editar(obj, out Mensaje);
            }
        }

        // Metodo para eliminar un cliente
        public int Eliminar(Cliente obj, out string Mensaje)
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

        //Metodo para buscar un cliente por un texto
        public List<Cliente> BuscarCliente(string texto)
        {
            return objcd_cliente.Buscar(texto);
        }

    }
}
