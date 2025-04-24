using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Marca
    {
        private CD_Marca objcd_marca = new CD_Marca();

        public List<Marca> Listar()
        {
            return objcd_marca.Listar();
        }
    }
}
