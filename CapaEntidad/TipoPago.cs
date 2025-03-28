using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TipoPago
    {
        public int Id_TipoPago { get; set; }

        public String Descripcion { get; set; }
        public DateTime Fecha_Registro { get; set; }
    }
}
