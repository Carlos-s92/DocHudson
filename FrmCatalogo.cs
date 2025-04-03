using CapaEntidad;
using CapaNegocio;
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
        public FrmCatalogo()
        {
            InitializeComponent();

            mostrarAutito();
        }

        private void mostrarAutito()
        {

        }
        private void comboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rjButton3_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

        private void FrmCatalogo_Load(object sender, EventArgs e)
        {
            List<Autos> autos = new CN_Auto().Listar();

            foreach(Autos item in autos)
            {

                TarjetaAuto auto = new TarjetaAuto(item.Id_Auto,item.Modelo, item.Marca, item.Consumo, item.Puertas, item.Asientos, item.Kilometros, item.Reservado, item.Estado, item.Matricula, item.Año, item.Imagen);
                flowLayoutPanel1 .Controls.Add(auto);

            }

        }
        public void HandleLoginSuccess()
        {
            this.flowLayoutPanel1.Controls.Clear();
            List<Autos> autos = new CN_Auto().Listar();

            foreach (Autos item in autos)
            {
                TarjetaAuto auto = new TarjetaAuto(item.Id_Auto, item.Modelo, item.Marca, item.Consumo, item.Puertas, item.Asientos, item.Kilometros, item.Reservado, item.Estado, item.Matricula,item.Año, item.Imagen);
                flowLayoutPanel1.Controls.Add(auto);

            }
        }
    }
}
