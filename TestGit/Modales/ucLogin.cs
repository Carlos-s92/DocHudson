using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGit.Modales
{
    public partial class ucLogin : UserControl
    {     
        // Definir un evento que será capturado por el formulario principal
        public event EventHandler LoginExitoso;
       
        public ucLogin(){

                InitializeComponent();
                this.BackColor = Color.FromArgb(150, 36, 35, 58); // Fondo semitransparente}
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CampoUsuario.Texts == "admin" && CampoContraseña.Texts == "1234")
            {
                MessageBox.Show("¡Login exitoso!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OnLoginSuccess();  // Este método lo manejaremos en el formulario principal
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Método para enviar el evento de login exitoso
        private void OnLoginSuccess()
        {
            // Aquí se puede notificar al formulario principal o cambiar el estado de visibilidad
            if (this.ParentForm is Login mainForm)  // Verificamos que el formulario principal sea el adecuado
            {
                mainForm.HandleLoginSuccess(); // Llamamos a un método en el formulario principal
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
    }
}
