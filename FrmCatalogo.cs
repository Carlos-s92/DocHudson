using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestGit.Modales;

namespace TestGit
{
    public partial class FrmCatalogo : Form
    {

        public Autos _Auto = new Autos();
        public FrmCatalogo()
        {
            InitializeComponent();

        }

        private void comboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rjButton3_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmCatalogo_Load(object sender, EventArgs e)//////////////////REVISAR MODELO Y MARCA//////////////////////////////////
        {
            List<Autos> autos = new CN_Auto().Listar();


            foreach (Autos item in autos)
            {

                TarjetaAuto auto = new TarjetaAuto(item.Id_Auto,item.oModelo.modelo, item.oModelo.oMarca.marca, item.oModelo.Consumo, item.oModelo.Puertas, item.oModelo.Asientos, item.Kilometros, item.Reservado, item.Estado, item.Matricula, item.Año, item.Imagen);
                flowLayoutPanel1 .Controls.Add(auto);
                

            }
           

            if (this.Owner is Inicio)
            {
                btnSalir.Visible = true; // o btnCancelar.Enabled = true;
            }
            else
            {
                btnSalir.Visible = false;
            }

        }
        public void HandleLoginSuccess()
        {
            this.flowLayoutPanel1.Controls.Clear();
            List<Autos> autos = new CN_Auto().Listar();

            foreach (Autos item in autos)
            {
                TarjetaAuto auto = new TarjetaAuto(item.Id_Auto, item.oModelo.modelo, item.oModelo.oMarca.marca, item.oModelo.Consumo, item.oModelo.Puertas, item.oModelo.Asientos, item.Kilometros, item.Reservado, item.Estado, item.Matricula,item.Año, item.Imagen);
                flowLayoutPanel1.Controls.Add(auto);

            }
        }



        public void Envio(Autos pAuto)
        {
            if(this.ParentForm is Inicio mainform)
            {

                mainform.Reservas(pAuto);
            }
            else
            {
                _Auto = pAuto;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}
