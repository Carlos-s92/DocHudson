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

        public Persona oPersona { get; set; }

        public string Licencia { get; set; }

        public bool Estado { get; set; }
    }
}
