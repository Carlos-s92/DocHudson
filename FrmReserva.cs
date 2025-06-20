using CapaEntidad;
using CapaNegocio;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TestGit.Modales;

namespace TestGit
{
    public partial class FrmReserva : Form
    {
        Usuarios user = new Usuarios();
        Autos oAuto = new Autos();
        // Constructor mínimo: sólo usuario
        public FrmReserva(Usuarios user)
            : this(null, user)   // llama al otro constructor
        {
            // Aquí no hace falta nada; todo lo hace el otro ctor
        }
        // Constructor “completo”: puede venir oAuto = null
        public FrmReserva(Autos oAuto, Usuarios user)
        {
            InitializeComponent();

            // Inicialización común a ambos escenarios
            dtpFechaI.MinDate = new DateTime(1753, 1, 1);
            dtpFechaI.MaxDate = new DateTime(9998, 12, 31);
            dtpFechaF.MinDate = new DateTime(1753, 1, 1);
            dtpFechaF.MaxDate = new DateTime(9998, 12, 31);
            dtpFechaI.Value = DateTime.Today;
            dtpFechaF.Value = DateTime.Today.AddDays(1);

            // Guarda referencias
            this.user = user;
            this.oAuto = oAuto;

            // Si me pasaron un auto, precargo sus datos en los controles
            if (oAuto != null)
            {
                txtMatricula.Texts = oAuto.Matricula;
                txtAño.Texts = oAuto.Año.ToString();
                txtKilometros.Texts = oAuto.Kilometros.ToString();
                txtConsumo.Texts = oAuto.oModelo.Consumo.ToString();
                txtModelo.Texts = oAuto.oModelo.modelo;
                txtIdAuto.Text = oAuto.Id_Auto.ToString();
            }
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

             
                            oReserva.Estado = true;
                            oReserva.Fecha_Inicio = dtpFechaI.Value;
                            oReserva.Fecha_Fin = dtpFechaF.Value;
                          
                            oReserva.oPago = new Pago()
                            {
                                Id_Pago = modal.Id_Pago
                            };
                        
                            int id = new CN_Reserva().Registrar(oReserva,out Mensaje);

                            if(id > 0)
                            {
                                VentanaEmergente msg = new VentanaEmergente("Exito", "Reserva Generada con Exito:" + " " + id, "Informacion");
                                msg.ShowDialog();
                            }
                            else
                            {
                                new VentanaEmergente("Error", Mensaje, "Error").ShowDialog();
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
            else
            {
                VentanaEmergente msg = new VentanaEmergente("Error", "Debe seleccionar los elementos necesarios para la reserva", "Error");
                msg.ShowDialog();
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
            this.dtpFechaI.Value = System.DateTime.Now;
            this.dtpFechaF.Value = System.DateTime.Now;
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
                    txtDocumento.Texts = modal._Cliente.oPersona.DNI.ToString();
                    txtNombre.Texts = modal._Cliente.oPersona.Nombre.ToString();
                    txtMail.Texts = modal._Cliente.oPersona.Mail.ToString();
                    txtTelefono.Texts = modal._Cliente.oPersona.Telefono.ToString();

                    string domicilio = modal._Cliente.oPersona.oDomicilio.oLocalidad.oProvincia.provincia + " " + modal._Cliente.oPersona.oDomicilio.oLocalidad.localidad + " " + modal._Cliente.oPersona.oDomicilio.Calle + " " + modal._Cliente.oPersona.oDomicilio.Numero.ToString();

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
                    //////////////////////VER CONSUMO Y MODELO//////////////////////////////////////////////////////////////////////////////////////////
                    this.txtConsumo.Texts = modal._Auto.oModelo.Consumo.ToString();
                    this.txtModelo.Texts = modal._Auto.oModelo.modelo.ToString();
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
