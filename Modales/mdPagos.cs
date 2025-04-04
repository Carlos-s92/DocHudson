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
    public partial class mdPagos : Form
    {
        public mdPagos()
        {
            InitializeComponent();
        }

        private void mdPagos_Load(object sender, EventArgs e)
        {
            this.btnTarjeta.Checked = true;
        }

        private void btnTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (this.btnTarjeta.Checked)
            {
                this.txtTarjeta.Visible = true;
                this.txtCambio.Visible = false;
                this.txtPaga.Visible = false;
            }
        }

        private void btnEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.btnEfectivo.Checked)
            {
                this.txtCambio.Visible = true;
                this.txtPaga.Visible = true;
                this.txtTarjeta.Visible = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public bool Validaciones()
        {
            bool resultado = true;

            if (this.btnEfectivo.Checked == true) {
                if (this.txtPaga.Texts == "" || Convert.ToDecimal(this.txtPaga.Texts) < Convert.ToDecimal(this.txtMonto.Texts))
                {
                    resultado = false;
                }

            }
            else
            {
                if (this.txtTarjeta.Texts == "")
                {
                    resultado = false;
                }
            }

            return resultado;

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                try
                {

                }
                catch (Exception ex) { 
                
                }
            }
            else
            {
                MessageBox.Show("Debe completar todas los campos","Alerta",MessageBoxButtons.OK);
            }
        }
    }
}
