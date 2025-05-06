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
using TestGit.Modales;

namespace TestGit
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Abre un modal para seleccionar un cliente.
            using (var modal = new mdRecuerdo())
            {
                var result = modal.ShowDialog(); // Muestra el diálogo modal.

            }
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            aplicarEfectoZoom();
        }

        private void aplicarEfectoZoom()
        {
            HoverZoomEffect.Apply(Btn1);
            HoverZoomEffect.Apply(Btn2);
            HoverZoomEffect.Apply(Btn3);
            HoverZoomEffect.Apply(Btn4);
            HoverZoomEffect.Apply(Btn5);
            HoverZoomEffect.Apply(Btn6);
        }
    }
}
