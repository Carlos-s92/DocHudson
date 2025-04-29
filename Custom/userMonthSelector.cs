using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGit.Custom
{
    public partial class userMonthSelector : UserControl
    {
        public userMonthSelector()
        {
            InitializeComponent();
        }

        public event EventHandler<int> MesSeleccionado;

        private void BEne_Click(object sender, EventArgs e)
        {
            MesSeleccionado?.Invoke(this, 1); //Enero.
        }

        private void BFeb_Click(object sender, EventArgs e)
        {
            MesSeleccionado?.Invoke(this, 2); //Febrero.
        }

        private void BMar_Click(object sender, EventArgs e)
        {
            MesSeleccionado?.Invoke(this, 3); //Marzo.
        }

        private void BAbr_Click(object sender, EventArgs e)
        {
            MesSeleccionado?.Invoke(this, 4); //Abril.
        }

        private void BMay_Click(object sender, EventArgs e)
        {
            MesSeleccionado?.Invoke(this, 5); //Mayo.
        }

        private void BJun_Click(object sender, EventArgs e)
        {
            MesSeleccionado?.Invoke(this, 6); //Junio.
        }

        private void BJul_Click(object sender, EventArgs e)
        {
            MesSeleccionado?.Invoke(this, 7); //Julio.
        }

        private void BAgo_Click(object sender, EventArgs e)
        {
            MesSeleccionado?.Invoke(this, 8); //Agosto.
        }

        private void BSep_Click(object sender, EventArgs e)
        {
            MesSeleccionado?.Invoke(this, 9); //Septiembre.
        }

        private void BOct_Click(object sender, EventArgs e)
        {
            MesSeleccionado?.Invoke(this, 10); //Octubre.
        }

        private void BNov_Click(object sender, EventArgs e)
        {
            MesSeleccionado?.Invoke(this, 11); //Noviembre.
        }

        private void BDic_Click(object sender, EventArgs e)
        {
            MesSeleccionado?.Invoke(this, 12); //Diciembre.
        }
    }
}
