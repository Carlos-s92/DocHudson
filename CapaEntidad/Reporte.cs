using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Reporte
    {

        public int Id_Reserva { get; set; }
        public DateTime Fecha_Registro { get; set; }

        public Decimal Monto { get; set; }
        public String Usuario { get; set; }
        public String Dni { get; set; }
        public string NombreCliente { get; set; }
        public int Id_Auto { get; set; }
        public string Modelo { get; set; }
    }
}
