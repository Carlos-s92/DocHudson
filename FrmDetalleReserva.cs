using CapaEntidad;
using CapaNegocio;
using System;
using System.IO;
using System.Windows.Forms;
using TestGit.Modales;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using TestGit.Class;

namespace TestGit
{
    public partial class FrmDetalleReserva : Form
    {
        private Reserva _reservaActual;
        public string doc { get; set; }
        public FrmDetalleReserva()
        {
            InitializeComponent();
            this.AcceptButton = btnBuscar;
        }

        private void btnLiberar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBusqueda.Texts, out int id)) return;

            // 1) Confirmar que la reserva existe
            var reserva = new CN_Reserva().BuscarReserva(id);
            if (reserva == null)
            {
                new VentanaEmergente("Error", "No existe esa reserva", "Error").ShowDialog();
                return;
            }

            // 2) Pedir confirmación al usuario
            var confirm = MessageBox.Show(
                "¿Seguro que desea liberar esta reserva?",
                "Confirmar",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (confirm != DialogResult.OK) return;

            // 3) Llamar al negocio para liberar
            string mensaje;
            bool ok = new CN_Reserva().LiberarReserva(id, out mensaje);
            if (ok)
            {
                MessageBox.Show("Reserva liberada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();   // tu método para resetear la UI
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {

            // Si el text box busqueda es distinto de vacio.
            if (txtBusqueda.Texts != "")
            {

                // Creo y muestro una ventana de confirmacion
                VentanaEmergente confirmacion = new VentanaEmergente("Informacion", "Desea liberar esta reserva?", "Interrogacion");
                confirmacion.ShowDialog();


                string mensaje = string.Empty;

                // Si la respuesta a la ventana emergente es un Si.
                if (confirmacion.DialogResult == DialogResult.Yes)
                {

                    //Procedo a liberar la reserva mediante la funcionalidad en la capa de negocio.
                    //Y almaceno el resultado de la operacion.
                    bool resultado = new CN_Reserva().LiberarReserva(Convert.ToInt32(txtBusqueda.Text), out mensaje);

                    // Si se ejecuto la operacion
                    if (resultado == true)
                    {
                        VentanaEmergente msg = new VentanaEmergente("Informacion", "Reserva Liberada con Éxito", "Informacion");
                        msg.ShowDialog();
                    }
                    else
                    {
                        VentanaEmergente msg = new VentanaEmergente("Error", "No se pudo liberar la reserva", "Error");
                        msg.ShowDialog();
                    }
                }
            }
            else
            {
                VentanaEmergente error = new VentanaEmergente("Error", "No selecciono ninguna reserva", "Error");
                error.ShowDialog();
            }

        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        public void LimpiarCampos()
        {
            this.txtAño.Texts = "";
            this.txtModelo.Texts = "";
            this.txtConsumo.Texts = "";
            this.txtMatricula.Texts = "";
            this.txtKilometros.Texts = "";
            this.txtMarca.Texts = "";

            this.txtDocumento.Texts = "";
            this.txtNombre.Texts = "";
            this.txtTelefono.Texts = "";
            this.txtLicencia.Texts = "";
            this.txtDomicilio.Texts = "";
            this.txtTotal.Texts = "";

            this.dtpFechaI.Value = System.DateTime.Now;
            this.dtpFechaF.Value = System.DateTime.Now;
        }

        private void BGenPDF_Click(object sender, EventArgs e)
        {
            if (_reservaActual == null)
            {
                MessageBox.Show("Primero debes buscar la reserva antes de generar el PDF");
                return;
            }
           // si es de tipo string
            // Cargar la plantilla HTML del PDF desde los recursos
            string Texto_Html = Properties.Resources.PlantillaReserva.ToString();
          
            Negocio oDatos = new CN_Negocio().obtenerDatos();

            // Reemplazar los marcadores en el HTML con los datos de la compra y del negocio
            Texto_Html = Texto_Html.Replace("@NombreEmpresa", oDatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@Cliente", txtNombre.Texts);
            Texto_Html = Texto_Html.Replace("@FechaActual", DateTime.Today.ToString("dd/MM/yyyy"));
            Texto_Html = Texto_Html.Replace("@Telefono", txtTelefono.Texts);
            Texto_Html = Texto_Html.Replace("@NumeroReserva", txtBusqueda.Texts);

            int dias = (dtpFechaF.Value.Date - dtpFechaI.Value.Date).Days;
            decimal total = _reservaActual.oPago.Total;
            decimal precioDia = dias > 0 ? total / dias : 0m;

            // Construir las filas de la tabla con los productos comprados
            Texto_Html = Texto_Html.Replace("@Marca", txtMarca.Texts);
            Texto_Html = Texto_Html.Replace("@Modelo", txtModelo.Texts);
            Texto_Html = Texto_Html.Replace("@Matricula", txtMatricula.Texts);
            Texto_Html = Texto_Html.Replace("@FechaInicio", dtpFechaI.Value.ToString("dd/MM/yyyy"));
            Texto_Html = Texto_Html.Replace("@FechaFin", dtpFechaF.Value.ToString("dd/MM/yyyy"));
            Texto_Html = Texto_Html.Replace("@Dias", dias.ToString());
            Texto_Html = Texto_Html.Replace("@PrecioDia", precioDia.ToString("0.##"));
            Texto_Html = Texto_Html.Replace("@Total", total.ToString("0.##"));

            // Mostrar un cuadro de diálogo para seleccionar la ubicación donde guardar el PDF
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Reserva_{0}.pdf", txtDocumento.Texts + DateTime.Today.ToString("ddMMyyyy"));
            savefile.Filter = "Pdf Files | *.pdf";

            // Si el usuario confirma la descarga
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                // Crear un nuevo archivo PDF
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    // Leer el HTML y agregarlo al documento PDF
                    using (StringReader sr = new StringReader(Texto_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    // Cerrar el documento y el stream
                    pdfDoc.Close();
                    stream.Close();
                    VentanaEmergente mensaje = new VentanaEmergente("Mensaje", "Pdf Generado", "Exito");
                    mensaje.ShowDialog();
                }
            }
        }

        private void FrmDetalleReserva_Load(object sender, EventArgs e)
        {
            //Establecer las fechas actuales al entrar.
            this.dtpFechaI.Value = System.DateTime.Now;
            this.dtpFechaF.Value = System.DateTime.Now;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBusqueda.Texts, out int id)) return;

            var oReserva = new CN_Reserva().BuscarReserva(id);
            _reservaActual = oReserva;

            if (oReserva == null)
            {
                new VentanaEmergente("Error", "Ese numero de reserva no existe", "Error").ShowDialog();
                return;
            }

            // Auto
            txtMatricula.Texts = oReserva.oAuto.Matricula;
            txtAño.Texts = oReserva.oAuto.Año.ToString();
            txtKilometros.Texts = oReserva.oAuto.Kilometros.ToString();
            txtConsumo.Texts = oReserva.oAuto.oModelo.Consumo.ToString();
            txtModelo.Texts = oReserva.oAuto.oModelo.modelo;
            txtMarca.Texts = oReserva.oAuto.oModelo.oMarca.marca;

            // Cliente / Persona
            txtDocumento.Texts = oReserva.oCliente.oPersona.DNI;
            txtNombre.Texts = $"{oReserva.oCliente.oPersona.Nombre} {oReserva.oCliente.oPersona.Apellido}";
            txtTelefono.Texts = oReserva.oCliente.oPersona.Telefono;
            txtLicencia.Texts = oReserva.oCliente.Licencia;
            txtDomicilio.Texts = $"{oReserva.oCliente.oPersona.oDomicilio.Calle} {oReserva.oCliente.oPersona.oDomicilio.Numero}, " +
                                  $"{oReserva.oCliente.oPersona.oDomicilio.oLocalidad.localidad}, " +
                                  $"{oReserva.oCliente.oPersona.oDomicilio.oLocalidad.oProvincia.provincia}";

            // Fechas Reserva
            dtpFechaI.Value = oReserva.Fecha_Inicio;
            dtpFechaF.Value = oReserva.Fecha_Fin;

            // Pago
            txtTotal.Texts = oReserva.oPago.Total.ToString("F2");
        }

        private void FrmDetalleReserva_Load_1(object sender, EventArgs e)
        {
            aplicarEfectoZoom();
        }

        private void aplicarEfectoZoom()
        {
            HoverZoomEffect.Apply(btnBuscar);
            HoverZoomEffect.Apply(btnLiberar);
            HoverZoomEffect.Apply(btnLimpiar);
            HoverZoomEffect.Apply(BGenPDF);
        }
    }
}
