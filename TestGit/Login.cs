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
        private ucLogin loginControl = new ucLogin();
        public Login()
        {

            InitializeComponent();
          
            loginControl.Dock = DockStyle.Fill;

            // Agregarlo al PanelLogin
            this.PanelLogin.Controls.Add(loginControl);


            this.btnSalir.Parent = pFondo;
            this.btnSalir.BackColor = Color.Transparent;
            btnSalir.FlatStyle = FlatStyle.Flat; // Hace que el botón sea plano
            btnSalir.FlatAppearance.BorderSize = 0; // Elimina el borde
            btnSalir.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 255, 0, 0); // Rojo semi-transparente al hacer clic
            btnSalir.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 255, 50, 50); // Rojo semi-transparente al pasar el mouse
            btnSalir.BackColor = Color.Transparent; // Fondo transparente
            btnSalir.ForeColor = Color.White; // Asegura que el texto se vea bien


        }
        public void HandleLoginSuccess()
        {
            // Aquí realizamos la transición a otro formulario (por ejemplo, Inicio)
            Inicio inicio = new Inicio();
            inicio.FormClosing += frm_closing; // Asocia el evento para cuando el formulario Inicio se cierre.
            inicio.Show();  // Muestra el nuevo formulario
            this.Hide();  // Esconde el formulario principal
        }
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            this.loginControl.LimpiarCampos();
            this.Show(); // Muestra de nuevo el formulario Login.
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
