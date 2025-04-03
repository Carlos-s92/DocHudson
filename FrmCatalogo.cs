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
    public partial class FrmCatalogo : Form
    {
        public FrmCatalogo()
        {
            InitializeComponent();

            mostrarAutito();
        }

        private void mostrarAutito()
        {
            TarjetaAuto autito = new TarjetaAuto();
            TarjetaAuto autito1 = new TarjetaAuto();
            TarjetaAuto autito2 = new TarjetaAuto();
            TarjetaAuto autito3 = new TarjetaAuto();

            flowLayoutPanel1.Controls.Add(autito);
            flowLayoutPanel1.Controls.Add(autito1);
            flowLayoutPanel1.Controls.Add(autito2);
            flowLayoutPanel1.Controls.Add(autito3);
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
    }
}
