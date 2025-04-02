using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pago
    {
        public int Id_Pago { get; set; }
        public Decimal Total { get; set; }

        public TipoPago oTipoPago { get; set; }
        public DateTime Fecha_Pago { get; set; }
        public bool Estado { get; set; }
    }
}
