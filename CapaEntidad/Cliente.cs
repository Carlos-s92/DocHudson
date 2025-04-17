using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cliente
    {
        public int Id_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public Domicilio domicilio { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public bool Estado { get; set; }
    }
}
