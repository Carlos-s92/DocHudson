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
    public partial class userYearSelector : UserControl
    {
        private List<Button> botonesAnios;
        public userYearSelector()
        {
            InitializeComponent();

            botonesAnios = new List<Button>
            {
                BYear1x1, BYear2x1, BYear3x1, BYear4x1,
                BYear1x2, BYear2x2, BYear3x2, BYear4x2,
                BYear1x3, BYear2x3, BYear3x3, BYear4x3
            };
        }

        public event EventHandler<int> AnioSeleccionado;

        private void BAño_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && int.TryParse(btn.Text, out int anio))
            {
                AnioSeleccionado?.Invoke(this, anio);
            }
        }

        public void MostrarAnios(int anioBase)
        {
            for (int i = 0; i < botonesAnios.Count; i++)
            {
                botonesAnios[i].Text = (anioBase + i).ToString();
            }
        }
    }
}
