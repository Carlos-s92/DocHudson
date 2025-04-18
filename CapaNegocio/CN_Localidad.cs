using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Localidad
    {
        private CD_Localidad objcd_localidad = new CD_Localidad();

        public List<Localidad> Listar()
        {
            return objcd_localidad.Listar();
        }

    }
}
