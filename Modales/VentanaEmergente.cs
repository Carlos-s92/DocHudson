using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TestGit.Class;

namespace TestGit.Modales
{
    public partial class VentanaEmergente : Form
    {
        public VentanaEmergente(string titulo, string descripcion, string tipo)
        {
            InitializeComponent();

            //Suscripción a eventos paints (manualmente)
            this.Paint += VE_Paint;

            MostrarInformacionVE(descripcion, titulo); //Se muestra la información de la descripción y título de la ventana emergente.
            mostrarIMGTipo(tipo);                      //Se establece la imagen correcta según el tipo de mensaje.
            mostrarBotonesTipo(tipo);                  //Se muestran los botones correspondientes al tipo del mensaje.
        }

        //Funcionamiento de los distintos botones de la ventana emergente (VE)
        private void BCloseVE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BAceptarVE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BNoVE_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Hide();
        }

        private void BSIVE_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Hide();
        }

        private void MostrarInformacionVE(string descripcion, string titulo)
        {
            LInfoVE.Text = descripcion;
            LTituloVE.Text = titulo;
        }

        private void mostrarIMGTipo(string tipoIMG)
        {
            string basePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Resources\"));

            switch (tipoIMG)
            {
                case "Error":
                    IPBVE.ImageLocation = basePath + "IconoCerrarVE.png";
                    break;
                case "Interrogacion":
                    IPBVE.ImageLocation = basePath + "IconoInterrogacionVE.png";
                    break;
                case "Informacion":
                    IPBVE.ImageLocation = basePath + "IconoAlertaVE.png";
                    break;
                case "Exito":
                    IPBVE.ImageLocation = basePath + "IconoSuccessVE.png";
                    break;
            }
            IPBVE.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void mostrarBotonesTipo(string tipoBoton)
        {
            switch (tipoBoton)
            {
                case "Error":
                    BNoVE.Visible = false;
                    BSIVE.Visible = false;
                    break;
                case "Interrogacion":
                    BAceptarVE.Visible = false;
                    break;
                case "Informacion":
                    BNoVE.Visible = false;
                    BSIVE.Visible = false;
                    break;
                case "Exito":
                    BNoVE.Visible = false;
                    BSIVE.Visible = false;
                    break;
            }
        }

        private void VE_Paint(object sender, PaintEventArgs e)
        {
            BorderClass rounded = new BorderClass();
            rounded.AplicarBordeRedondeado(this, 1, e.Graphics, Color.Cyan, 1);
        }
    }
}
