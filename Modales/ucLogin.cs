using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestGit.Class;

namespace TestGit.Modales
{
    public partial class ucLogin : UserControl
    {     
        // Definir un evento que será capturado por el formulario principal
        public ucLogin(){

            InitializeComponent();

            this.Paint += UcLogin_Paint; //Suscripción al evento paint (manualmente)
            this.Load += UcLogin_Load;

            //Se fuerza el redibujado de los textbox del userControl para verlos correctamente.
            CampoUsuario.Invalidate();      
            CampoContraseña.Invalidate();

            this.BackColor = Color.FromArgb(150, 36, 35, 58); // Fondo semitransparente}
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            Usuarios oUsuarios = new CN_Usuario().Listar().Where(u => u.Usuario == CampoUsuario.Texts && u.Contraseña == CampoContraseña.Texts && u.Estado == true).FirstOrDefault();

            if (oUsuarios != null)
            {
                OnLoginSuccess(oUsuarios);
            }
            else
            {
                VentanaEmergente VE = new VentanaEmergente("Credenciales incorrectas", "Intento fallido al iniciar sesión, vuelva a reintentarlo.", "Error");
                VE.ShowDialog();
            }
        }

        // Método para enviar el evento de login exitoso
        private void OnLoginSuccess(Usuarios pUsuario)
        {
            // Aquí se puede notificar al formulario principal o cambiar el estado de visibilidad
            if (this.ParentForm is Login mainForm)  // Verificamos que el formulario principal sea el adecuado
            {
             
                mainForm.HandleLoginSuccess(pUsuario); // Llamamos a un método en el formulario principal
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void LimpiarCampos()
        {
            this.CampoContraseña.Texts = "";
            this.CampoUsuario.Texts = "";
        }

        //Función para aplicar borde redondeado al userControl "ucLogin" (mediante una función AplicarBordeRedondeado de la clase BorderClass)
        private void UcLogin_Paint(object sender, PaintEventArgs e)
        {
            BorderClass rounded = new BorderClass();
            rounded.AplicarBordeRedondeado(this, 9, e.Graphics, Color.Cyan, 2);

            CampoUsuario.Invalidate();
            CampoContraseña.Invalidate();
        }

        //Función para ingresar automaticamente el usuario y contraseña único de momento.
        private void UcLogin_Load(object sender, EventArgs e)
        {
            CampoUsuario.Texts = "admin";
            CampoContraseña.Texts = "123";
        }
    }
}
