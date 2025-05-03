using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Auto
    {
        private CD_Autos objcd_Autos = new CD_Autos();

        public List<Autos> Listar()
        {
            return objcd_Autos.Listar();
        }

        public int Registrar(Autos obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Matricula == "")
            {
                Mensaje += "Es Necesario la Matricula del Auto\n";
            }
            ////////////////////////////////////////////////////////////
            if (obj.oModelo.modelo == "")
            {
                Mensaje += "Es Necesario el Modelo del Auto\n";
            }
            if (obj.oModelo.oMarca.marca == "")
            {
                Mensaje += "Es Necesario la Marca del Auto\n";
            }
            ////////////////////////////////////////////////////////////
            if (obj.Kilometros == 0)
            {
                Mensaje += "Es Necesario los Kilometros del Auto\n";
            }
            if (obj.Año <= 1886)
            {
                Mensaje += "Es Necesario un Año Correcto del Auto\n";
            }
            ////////////////////--VER ESTO--////////////////////////////////////////
            /*if (obj.Consumo == 0)
            {
                Mensaje += "Es Necesario un Consumo del Auto\n";
            }
            if (obj.Puertas == 0)
            {
                Mensaje += "Es Necesario la Cantidad de Puertas del Auto\n";
            }
            if (obj.Asientos == 0)
            {
                Mensaje += "Es Necesario la Cantidad de Asientos del Auto\n";
            }*/
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Autos.Registrar(obj, out Mensaje);
            }

        }

        public bool Editar(Autos obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Matricula == "")
            {
                Mensaje += "Es Necesario la Matricula del Auto\n";
            }
            ////////////////////////////////////////////////////////////
            if (obj.oModelo.modelo == "")
            {
                Mensaje += "Es Necesario el Modelo del Auto\n";
            }
            if (obj.oModelo.oMarca.marca == "")
            {
                Mensaje += "Es Necesario la Marca del Auto\n";
            }
            ////////////////////////////////////////////////////////////
            if (obj.Kilometros == 0)
            {
                Mensaje += "Es Necesario los Kilometros del Auto\n";
            }
            if (obj.Año <= 1886)
            {
                Mensaje += "Es Necesario un Año Correcto del Auto\n";
            }
            ////////////////////--VER ESTO--////////////////////////////////////////
            /*if (obj.Consumo == 0)
            {
                Mensaje += "Es Necesario un Consumo del Auto\n";
            }
            if (obj.Puertas == 0)
            {
                Mensaje += "Es Necesario la Cantidad de Puertas del Auto\n";
            }
            if (obj.Asientos == 0)
            {
                Mensaje += "Es Necesario la Cantidad de Asientos del Auto\n";
            }*/
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Autos.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(Autos obj, out string Mensaje)
        {
            return objcd_Autos.Eliminar(obj, out Mensaje);
        }

        public List<Autos> BuscarAuto(string texto)
        {
            return new CD_Autos().Buscar(texto);
        }
    }
}
