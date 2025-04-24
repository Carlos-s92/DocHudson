using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Modelo
    {
        private CD_Modelo objcd_modelo = new CD_Modelo();

        public List<Modelo> Listar()
        {
            return objcd_modelo.Listar();
        }
    }
}
