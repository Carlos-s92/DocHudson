﻿using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Reserva
    {
        //Atributos de la clase reserva
        private CD_Reserva objcd_Reserva = new CD_Reserva();
        private readonly CD_Autos objcd_Autos = new CD_Autos();

        //Metodo para listar reservas
        public List<Reserva> Listar()
        {
            return objcd_Reserva.Listar();
        }

        public int Registrar(Reserva obj, out string mensaje)
        {
            mensaje = string.Empty;

            // 1) Validaciones de negocio
            if (obj.Fecha_Inicio >= obj.Fecha_Fin)
                mensaje += "La fecha de fin no puede ser menor o igual que la de inicio.\n";
            if (obj.Fecha_Inicio < System.DateTime.Today)
                mensaje += "La fecha de inicio/fin no puede ser menor que la fecha actual.\n";
            if (obj.oCliente.Id_Cliente == 0)
                mensaje += "Es necesario un Cliente para reservar.\n";
            if (obj.oAuto.Id_Auto == 0)
                mensaje += "Es necesario un Auto para reservar.\n";
            if (obj.oPago.Id_Pago == 0)
                mensaje += "Es necesario un Pago para reservar.\n";

            if (!string.IsNullOrEmpty(mensaje))
            {
                // Si fallan las validaciones, devolvemos 0 y el mensaje acumulado
                return 0;
            }

            // 2) Insertar la reserva en la BD (SP InsertarReserva)
            int idReserva = objcd_Reserva.Registrar(obj,out string msgRes);

            if (idReserva == 0)
            {
                // SP devolvió error
                mensaje = msgRes;
                return 0;
            }

            // 3) Marcar el auto como reservado (SP CambiarEstadoAuto)
            bool okAuto = objcd_Autos.CambiarEstado(
                obj.oAuto.Id_Auto,
                true,       // reservado = true
                out string msgAuto
            );

            if (!okAuto)
            {
                // Si no pudimos reservar el auto, revertimos la inserción de la reserva
                objcd_Reserva.LiberarReserva(idReserva, out _);
                mensaje = $"Reserva creada (ID={idReserva}), pero no se pudo marcar el auto: {msgAuto}";
                return 0;
            }

            // 4) Todo OK
            mensaje = $"Reserva registrada correctamente. ID: {idReserva}";
            return idReserva;
        }

        //Metodo para editar una reserva
        public int Editar(Reserva obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            //Se verifican que todos los campos esten correctos
            if (obj.Fecha_Inicio <= obj.Fecha_Fin)
            {
                Mensaje += "La fecha de fin no puede ser menor que la de inicio\n";
            }
            if (obj.Fecha_Inicio < System.DateTime.Now || obj.Fecha_Fin < System.DateTime.Now)
            {
                Mensaje += "La fecha de inicio/fin no puede ser menor que actual\n";
            }
            if (obj.oCliente.Id_Cliente == 0)
            {
                Mensaje += "Es Necesario un Cliente para Reservar\n";
            }
            if (obj.oAuto.Id_Auto == 0)
            {
                Mensaje += "Es Necesario un Auto para Reservar\n";
            }
            if (obj.oPago.Id_Pago == 0)
            {
                Mensaje += "Es Necesario un Pago para Reservar\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Reserva.Editar(obj, out Mensaje);
            }
        }

        //Metodo para liberar una reserva
        public bool LiberarReserva(int id_reserva, out string Mensaje)
        {
            Mensaje = string.Empty;

            // 1) Desactivar la reserva
            int okRes = objcd_Reserva.LiberarReserva(id_reserva, out Mensaje);
            if (okRes == 0)
            {
                Mensaje = "Reserva: " + Mensaje;
                return false;
            }

            // 2) Recuperar el Id_Auto de esa reserva
            var reserva = BuscarReserva(id_reserva);
            if (reserva == null)
            {
                Mensaje = "Reserva eliminada, pero no se encontró detalle de auto.";
                return false;
            }

            // 3) Cambiar estado del auto a 'no reservado'
            bool okAuto = objcd_Autos.CambiarEstado(reserva.oAuto.Id_Auto, false, out string msgAuto);
            if (!okAuto)
            {
                Mensaje = "Reserva cancelada, pero error liberando auto: " + msgAuto;
                return false;
            }

            // Todo OK
            return true;
        }
        //Metodo para buscar una reserva por el id
        public Reserva BuscarReserva(int id) => new CD_Reserva().BuscarReserva(id);
    }
}
