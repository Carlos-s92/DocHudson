using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Reserva
    {
        private CD_Reserva objcd_Reserva = new CD_Reserva();

        public List<Reserva> Listar()
        {
            return objcd_Reserva.Listar();
        }

        public int Registrar(Reserva obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Fecha_Inicio >= obj.Fecha_Fin )
            {
                Mensaje += "La fecha de fin no puede ser menor que la de inicio\n";
            }
            if (obj.Fecha_Inicio < System.DateTime.Today || obj.Fecha_Fin < System.DateTime.Today)
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
                return objcd_Reserva.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Reserva obj, out string Mensaje)
        {
            Mensaje = string.Empty;

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
                return false;
            }
            else
            {
                return objcd_Reserva.Editar(obj, out Mensaje);
            }
        }


        public bool Eliminar(int id_reserva, out string Mensaje)
        {
            return objcd_Reserva.Eliminar(id_reserva, out Mensaje);

        }

        public Reserva BuscarReserva(int id) => new CD_Reserva().Buscar(id);
    }
}
