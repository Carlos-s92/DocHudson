using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Reserva
    {
        public int Id_Reserva { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public Autos oAuto { get; set; }
        public Pago oPago { get; set; }
        public Cliente oCliente { get; set; }
        public bool Estado { get; set; }
    }
}
