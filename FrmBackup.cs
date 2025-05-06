using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestGit.Class;
using TestGit.Modales;

namespace TestGit
{
    public partial class FrmBackup : Form
    {
        public FrmBackup()
        {
            InitializeComponent();
        }

        private void BtnGuardar2_Click(object sender, EventArgs e)
        {
            string mensaje = new CN_Backup().Backup();
            if (mensaje.Contains("Copia"))
            {
                VentanaEmergente respuesta = new VentanaEmergente("Aviso", mensaje, "Exito");
                respuesta.ShowDialog();
            }
            else
            {
                VentanaEmergente respuesta = new VentanaEmergente("Aviso", mensaje, "Informacion");
                respuesta.ShowDialog();
            }
        }

        private void BtnLimpiar2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.FileName = "Files | *.Archivo;*.BAK";

            if (open.ShowDialog() == DialogResult.OK)
            {

                string ruta = open.FileName;
                this.txtDireccion2.Texts = ruta;

                string mensaje = new CN_Backup().Restore(ruta);
                VentanaEmergente respuesta = new VentanaEmergente("Aviso", mensaje, "Informacion");
                respuesta.ShowDialog();

            }
        }

        private void FrmBackup_Load(object sender, EventArgs e)
        {
            aplicarEfectoZoom();
        }

        private void aplicarEfectoZoom()
        {
            HoverZoomEffect.Apply(BtnGuardar2);
            HoverZoomEffect.Apply(BtnLimpiar2);
        }
    }
}
