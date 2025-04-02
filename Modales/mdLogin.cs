using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGit.Modales
{
    public partial class mdLogin : Form
    {
        public mdLogin()
        {
            InitializeComponent();

            // Configura la opacidad al 50% (0.5 = 50% de transparencia)
            this.Opacity = 0.8;

            // Opcional: Elimina TransparencyKey para evitar errores de renderizado.
            this.BackColor = Color.FromArgb(36, 35, 58); // Color de fondo
        }
    }
}

