using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Domicilio
    {
        public int Id_Domicilio { get; set; }
        public Localidad oLocalidad { get; set; }
        public int Numero { get; set; }
        public string Calle { get; set; }
    }
}