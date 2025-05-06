using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestGit.Class;

namespace TestGit
{
    public partial class FrmReporte : Form
    {
        public FrmReporte()
        {
            InitializeComponent();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            aplicarEfectoZoom();
        }

        private void aplicarEfectoZoom()
        {
            HoverZoomEffect.Apply(BtnGuardar2);
            HoverZoomEffect.Apply(BLimpiar);
        }
    }
}
