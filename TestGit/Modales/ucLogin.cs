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
        public ucLogin()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(150, 36, 35, 58); // Fondo semitransparente
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CampoUsuario.Text == "admin" && CampoContraseña.Text == "1234")
            {
                MessageBox.Show("¡Login exitoso!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Visible = false; // Ocultar el control después del login
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
