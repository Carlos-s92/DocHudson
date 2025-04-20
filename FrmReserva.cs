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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestGit.Modales;

namespace TestGit
{
    public partial class FrmReserva : Form
    {
        Usuarios user = new Usuarios();
        Autos oAuto = new Autos();
        public FrmReserva(Usuarios user)
        {
            InitializeComponent();
            this.user = user;
        }
        public FrmReserva(Autos oAuto, Usuarios user)
        {
            InitializeComponent();
            this.oAuto = oAuto;
            this.user = user;
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
            if(asd.Value >= dtpFechaFsadsad.Value)
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
                            oReserva.oCliente = new Cliente()
                            {
                                Id_Cliente = Convert.ToInt32(txtIdCliente.Text)
                            };
                            oReserva.oAuto = new Autos()
                            {
                                Id_Auto = Convert.ToInt32(txtIdAuto.Text)
                            };
                            oReserva.oUsuario = new Usuarios()
                            {
                                Id_Usuario = this.user.Id_Usuario
                            };

                            //oReserva.oCliente.Id_Cliente= Convert.ToInt32(txtIdCliente.Text);
                            //oReserva.oAuto.Id_Auto = Convert.ToInt32(txtIdAuto.Text);
                            oReserva.Estado = true;
                            oReserva.Fecha_Inicio = asd.Value;
                            oReserva.Fecha_Fin = dtpFechaFsadsad.Value;
                          
                            oReserva.oPago = new Pago()
                            {
                                Id_Pago = modal.Id_Pago
                            };
                        
                            int id = new CN_Reserva().Registrar(oReserva,out Mensaje);

                            if(id != 0)
                            {
                                VentanaEmergente msg = new VentanaEmergente("Exito", "Reserva Generada con Exito:" + " " + id, "Informacion");
                                msg.ShowDialog();
                            }
                            else
                            {
                                VentanaEmergente msg = new VentanaEmergente("Error", "La Reserva no pudo ser Generada", "Error");
                                msg.ShowDialog();
                            }

                        }
                        else
                        {
                            VentanaEmergente msg = new VentanaEmergente("Error", "No se pudo registrar la reserva", "Error");
                            msg.ShowDialog();
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
            this.txtMail.Texts = "";
            this.txtDocumento.Texts = "";
            this.txtDomicilio.Texts = "";
            this.txtKilometros.Texts = "";
            this.txtMatricula.Texts = "";
            this.txtModelo.Texts = "";
            this.txtNombre.Texts = "";
            this.txtTelefono.Texts = "";
            this.asd.Value = System.DateTime.Now;
            this.dtpFechaFsadsad.Value = System.DateTime.Now;
        }

        private void rjButton1_Click(object sender, EventArgs e)//Botón para agregar Cliente
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
                    txtMail.Texts = modal._Cliente.Mail.ToString();
                    txtTelefono.Texts = modal._Cliente.Telefono.ToString();

                    string domicilio = modal._Cliente.domicilio.oLocalidad.oProvincia.provincia + " " + modal._Cliente.domicilio.oLocalidad.localidad + " " + modal._Cliente.domicilio.Calle + " " + modal._Cliente.domicilio.Numero.ToString();

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

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escribe solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escribe solo Letras
            if (Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z\s\b]"))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escribe solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
