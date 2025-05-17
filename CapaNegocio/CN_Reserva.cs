using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Reserva
    {
        private CD_Reserva objcd_Reserva = new CD_Reserva();
        private readonly CD_Autos objcd_Autos = new CD_Autos();

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
            Mensaje = string.Empty;

            // 1) Desactivar la reserva
            bool okRes = objcd_Reserva.Eliminar(id_reserva, out Mensaje);
            if (!okRes)
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

        public Reserva BuscarReserva(int id) => new CD_Reserva().Buscar(id);
    }
}
