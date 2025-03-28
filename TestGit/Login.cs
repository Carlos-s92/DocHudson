using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestGit.Modales;

namespace TestGit
{
    public partial class Login : Form
    {
        public Login()
        {

            InitializeComponent();
            this.btnSalir.Parent = pFondo;
            this.btnSalir.BackColor = Color.Transparent;
            btnSalir.FlatStyle = FlatStyle.Flat; // Hace que el botón sea plano
            btnSalir.FlatAppearance.BorderSize = 0; // Elimina el borde
            btnSalir.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 255, 0, 0); // Rojo semi-transparente al hacer clic
            btnSalir.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 255, 50, 50); // Rojo semi-transparente al pasar el mouse
            btnSalir.BackColor = Color.Transparent; // Fondo transparente
            btnSalir.ForeColor = Color.White; // Asegura que el texto se vea bien
            // Crear una instancia del control de usuario
            ucLogin loginControl = new ucLogin();
            loginControl.Dock = DockStyle.Fill; // Ocupa todo el panel
            this.btnSalir.Parent = pFondo;
            // Agregarlo al PanelLogin
            this.PanelLogin.Controls.Add(loginControl);

        }


        private void rjTextBox2__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_DragEnter(object sender, DragEventArgs e)
        {
            //this.BackColor = Color.Red;
        }

        private void btnSalir_MouseEnter(object sender, EventArgs e)
        {
            this.btnSalir.Parent = pFondo;
            this.btnSalir.BackColor = Color.Red;
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            this.btnSalir.Parent = pFondo;
            this.btnSalir.BackColor = Color.Transparent;
        }
    }
}
