using CapaEntidad;
using CapaNegocio;
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

namespace TestGit.Modales
{
    public partial class mdPagos : Form
    {
        public int Id_Pago = 0;
        public mdPagos()
        {
            InitializeComponent();
        }

        private void mdPagos_Load(object sender, EventArgs e)
        {
            this.btnTarjeta.Checked = true;

            aplicarEfectoZoom();
        }

        private void aplicarEfectoZoom()
        {
            HoverZoomEffect.Apply(btnCancelar);
            HoverZoomEffect.Apply(btnConfirmar);
            HoverZoomEffect.Apply(btnEfectivo);
            HoverZoomEffect.Apply(btnTarjeta);
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
                string Mensaje = string.Empty;
                try
                {

                    Pago oPago = new Pago();

                    oPago.Total = Convert.ToDecimal(txtMonto.Texts);
                    if (btnEfectivo.Checked)
                    {
                        oPago.oTipoPago = new TipoPago()
                        {
                            Id_TipoPago = 2
                        };
                    }
                    else
                    {
                        oPago.oTipoPago = new TipoPago()
                        {
                            Id_TipoPago = 1
                        };
                    }
                    oPago.Fecha_Pago = System.DateTime.Now;
                    oPago.Estado = true;
                    int id = new CN_Pago().Registrar(oPago,out Mensaje);
                    Id_Pago = id;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex) {
                   
                    Mensaje = ex.Message;
                    MessageBox.Show(Mensaje, "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos","Alerta",MessageBoxButtons.OK);
            }
        }
    }
}
