using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Perfiles
    {

        private CD_Perfiles objcd_perfiles = new CD_Perfiles();

        public List<Perfiles> Listar()
        {
            return objcd_perfiles.Listar();
        }

    }
}
