using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Localidad
    {
        public int Id_Localidad { get; set; }
        public Provincia oProvincia { get; set; }
        public string localidad { get; set; }
    }
}