using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Autos
    {
        public int Id_Auto { get; set; }
        public bool Estado { get; set; }
        public String Modelo { get; set; }

        public String Matricula { get; set; }       
        public decimal Kilometros { get; set; }
        public int Año { get; set; }
        public decimal Consumo { get; set; }

        public String Imagen { get; set; }

        public int Puertas { get; set; }

        public String Marca { get; set; }
        public int Asientos { get; set; }

        public DateTime Fecha_Registro { get; set; }
    }
}
