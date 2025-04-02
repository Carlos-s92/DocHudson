using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGit.Modales
{
    public partial class mdRecuerdo : Form
    {
        public mdRecuerdo()
        {
            InitializeComponent();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            playSimpleSound();
        }

        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\GamBr\Documents\GitHub\DocHudson\TestGit\Resources\Musica.wav");
            simpleSound.PlaySync(); // Espera hasta que termine el sonido
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
