using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Modelo
    {
        public int Id_Modelo { get; set; }
        public Marca oMarca { get; set; } = new Marca();
        public string modelo { get; set; }
        public decimal Consumo { get; set; }
        public int Puertas { get; set; }
        public int Asientos { get; set; }
    }
}
