
using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;


namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_usuario = new CD_Usuario();

        public List<Usuarios> Listar()
        {
            return objcd_usuario.Listar();
        }

        public int Registrar(Usuarios obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Usuario == "")
            {
                Mensaje += "Es Necesario el Nombre de Usuario del Usuario\n";
            }
            if (obj.Contraseña == "")
            {
                Mensaje += "Es Necesario la Contraseña del Usuario\n";
            }
            if (obj.Dni == "")
            {
                Mensaje += "Es Necesario el DNI del Usuario\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_usuario.Registrar(obj, out Mensaje);
            }

        }
        


        public int Editar(Usuarios obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Usuario == "")
            {
                Mensaje += "Es Necesario el Nombre del Usuario\n";
            }
            if (obj.Contraseña == "")
            {
                Mensaje += "Es Necesario la Clave del Usuario\n";
            }
            if (obj.Dni == "")
            {
                Mensaje += "Es Necesario el DNI del Usuario\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_usuario.Editar(obj, out Mensaje);
            }
        }


        public int Eliminar(Usuarios obj, out string Mensaje)
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);
        }
        
    } 
}

