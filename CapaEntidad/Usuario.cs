using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuarios
    {
        public int Id_Usuario { get; set; }

        public Perfiles oPerfil { get; set; }
        public string Usuario { get; set; }

        public string Contraseña { get; set; }

        public bool Estado { get; set; }

        public DateTime Fecha_Registro { get; set; }

    }
}
