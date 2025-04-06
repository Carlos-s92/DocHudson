using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestGit.Modales;

namespace TestGit
{
    public partial class FrmReserva : Form
    {
        Autos oAuto = new Autos();
        public FrmReserva()
        {
            InitializeComponent();
        }
        public FrmReserva(Autos oAuto)
        {
            InitializeComponent();
            this.oAuto = oAuto;

            this.txtAño.Texts = oAuto.Año.ToString();
            this.txtConsumo.Texts = oAuto.Consumo.ToString();
            this.txtIdAuto.Text = oAuto.Id_Auto.ToString();
            this.txtKilometros.Texts = oAuto.Kilometros.ToString();
            this.txtMatricula.Texts = oAuto.Matricula;
            this.txtModelo.Texts = oAuto.Modelo.ToString();

        }

        public bool Validaciones()
        {
            bool validaciones = true;

            if(txtIdAuto.Text == "0")
            {
                validaciones = false;
            }
            if(txtIdCliente.Text == "0")
            {
                validaciones = false;
            }
            if(dtpFechaI.Value >= dtpFechaF.Value)
            {
                validaciones = false;
            }

            return validaciones;
        }


        private void BtnGuardar2_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                using (var modal = new mdPagos())
                {
                    var result = modal.ShowDialog(); // Muestra el diálogo modal.

                    if (result == DialogResult.OK) // Si se selecciona un Cliente, llena los campos de Cliente y precio.
                    {
                        String Mensaje = string.Empty;
                        if(modal.Id_Pago != 0)
                        {
                            Reserva oReserva = new Reserva();

                            oReserva.oCliente.Id_Cliente= Convert.ToInt32(txtIdCliente.Text);
                            oReserva.oAuto.Id_Auto = Convert.ToInt32(txtIdAuto.Text);
                            oReserva.Estado = true;
                            oReserva.Fecha_Fin = dtpFechaF.Value;
                            oReserva.Fecha_Inicio = dtpFechaI.Value;
                            oReserva.oPago.Id_Pago = modal.Id_Pago;

                            int id = new CN_Reserva().Registrar(oReserva,out Mensaje);

                            if(id != 0)
                            {
                                MessageBox.Show("Reserva Generada con Exito:" + " " + id,"Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("La Reserva no pudo ser Generada","Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar la reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }



        }

        private void BtnLimpiar2_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        public void LimpiarCampos()
        {
            this.txtIdAuto.Text = "0";
            this.txtIdCliente.Text = "0";
            this.txtAño.Texts = "";
            this.txtConsumo.Texts = "";
            this.txtLicencia.Texts = "";
            this.txtDocumento.Texts = "";
            this.txtDomicilio.Texts = "";
            this.txtKilometros.Texts = "";
            this.txtMatricula.Texts = "";
            this.txtModelo.Texts = "";
            this.txtNombre.Texts = "";
            this.txtTelefono.Texts = "";
            this.dtpFechaI.Value = System.DateTime.Now;
            this.dtpFechaF.Value = System.DateTime.Now;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            // Abre un modal para seleccionar un Cliente.
            using (var modal = new mdCliente())
            {
                var result = modal.ShowDialog(); // Muestra el diálogo modal.

                if (result == DialogResult.OK) // Si se selecciona un Cliente, llena los campos de Cliente y precio.
                {
                    txtIdCliente.Text = modal._Cliente.Id_Cliente.ToString();
                    txtDocumento.Texts = modal._Cliente.Dni.ToString();
                    txtNombre.Texts = modal._Cliente.Nombre.ToString();
                    txtLicencia.Texts = modal._Cliente.Licencia.ToString();
                    txtTelefono.Texts = modal._Cliente.Telefono.ToString();

                    string domicilio = modal._Cliente.Provincia + " " + modal._Cliente.Localidad + " " + modal._Cliente.Calle + " " + modal._Cliente.Numero.ToString();

                    txtDomicilio.Texts = domicilio;
                }
                else
                {
                    btnCliente.Select(); // Si no se selecciona Cliente, el foco vuelve al campo de código del Cliente.
                }
            }
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            // Abre un modal para seleccionar un Cliente.
            using (var modal = new FrmCatalogo())
            {
                var result = modal.ShowDialog(this); // Muestra el diálogo modal.

                if (result == DialogResult.OK) // Si se selecciona un Cliente, llena los campos de Cliente y precio.
                {
                    this.txtAño.Texts = modal._Auto.Año.ToString();
                    this.txtConsumo.Texts = modal._Auto.Consumo.ToString();
                    this.txtModelo.Texts = modal._Auto.Modelo.ToString();
                    this.txtIdAuto.Text = modal._Auto.Id_Auto.ToString();
                    this.txtKilometros.Texts = modal._Auto.Kilometros.ToString();
                    this.txtMatricula.Texts = modal._Auto.Matricula;
                }
                else
                {
                    btnAuto.Select();
                }
            }

        }
    }
}
