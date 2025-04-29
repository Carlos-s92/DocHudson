using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TestGit.Modales;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Drawing.Drawing2D;
using CustomControls.RJControls;

namespace TestGit
{
    public partial class FrmDetalleReserva : Form
    {
        public string doc { get; set; }
        public FrmDetalleReserva()
        {
            InitializeComponent();
        }

        private void txtBusqueda__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjButton2_Click(object sender, EventArgs e)
        {

        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) // Si el usuario presiona la tecla Enter.
            {
                
                Reserva oReserva = new CN_Reserva().Listar().Where(p => p.Id_Reserva == Convert.ToInt32(txtBusqueda.Texts)).FirstOrDefault();

                if (oReserva != null)
                {
                    Cliente oCliente = new CN_Cliente().Listar().Where(p => p.Id_Cliente == oReserva.oCliente.Id_Cliente).FirstOrDefault();
                    Autos oAuto = new CN_Auto().Listar().Where(p => p.Id_Auto == oReserva.oAuto.Id_Auto).FirstOrDefault();
                    Pago oPago = new CN_Pago().Listar().Where(p => p.Id_Pago == oReserva.oPago.Id_Pago).FirstOrDefault();

                    this.txtAño.Texts = oAuto.Año.ToString();

                    ///////////////////// VER MODELO, CONSUMO y MARCA //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    this.txtModelo.Texts = oAuto.oModelo.modelo.ToString();
                    this.txtConsumo.Texts = oAuto.oModelo.Consumo.ToString();
                    this.txtMatricula.Texts = oAuto.Matricula.ToString();
                    this.txtKilometros.Texts = oAuto.Kilometros.ToString();
                    this.txtMarca.Texts = oAuto.oModelo.Consumo.ToString();

                    this.txtDocumento.Texts = oCliente.oPersona.DNI.ToString();
                    this.txtNombre.Texts = oCliente.oPersona.Nombre.ToString();
                    this.txtTelefono.Texts = oCliente.oPersona.Telefono.ToString();
                    this.txtLicencia.Texts = oCliente.oPersona.Mail.ToString();
                    this.txtDomicilio.Texts = oCliente.oPersona.oDomicilio.oLocalidad.oProvincia.provincia + " " + oCliente.oPersona.oDomicilio.oLocalidad.localidad + " " + oCliente.oPersona.oDomicilio.Calle + " " + oCliente.oPersona.oDomicilio.Numero.ToString();

                    this.dtpFechaI.Value = oReserva.Fecha_Inicio;
                    this.dtpFechaF.Value = oReserva.Fecha_Fin;

                    this.txtTotal.Texts = oPago.Total.ToString(); 


                }
                else
                {
                    VentanaEmergente mensaje = new VentanaEmergente("Error", "Ese numero de reserva no existe","Error");
                    mensaje.ShowDialog();
                }
            }
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
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
            // Verifica si hay una compra seleccionada antes de intentar generar el PDF
            if (txtDocumento.Texts == "")
            {
                VentanaEmergente mensaje = new VentanaEmergente("Mensaje", "No se encontraron resultados", "Informacion");
                mensaje.ShowDialog();
                return;
            }
           // si es de tipo string
            // Cargar la plantilla HTML del PDF desde los recursos
            string Texto_Html = Properties.Resources.PlantillaReserva.ToString();
          
            Negocio oDatos = new CN_Negocio().obtenerDatos();

            // Reemplazar los marcadores en el HTML con los datos de la compra y del negocio
            Texto_Html = Texto_Html.Replace("@NombreEmpresa", oDatos.Nombre.ToUpper());
            


            Texto_Html = Texto_Html.Replace("@Cliente", txtNombre.Texts);
            Texto_Html = Texto_Html.Replace("@FechaActual", System.DateTime.Today.ToString());
            Texto_Html = Texto_Html.Replace("@Telefono", txtTelefono.Texts);
            Texto_Html = Texto_Html.Replace("@NumeroReserva", txtDocumento.Texts);

            int dias = this.dtpFechaI.Value.Day - this.dtpFechaF.Value.Day;

            // Construir las filas de la tabla con los productos comprados
            Texto_Html = Texto_Html.Replace("@Marca", txtMarca.Texts);
            Texto_Html = Texto_Html.Replace("@Modelo", txtModelo.Texts);
            Texto_Html = Texto_Html.Replace("@Matricula", txtMatricula.Texts);
            Texto_Html = Texto_Html.Replace("@FechaInicio", dtpFechaI.Value.ToString());
            Texto_Html = Texto_Html.Replace("@FechaFin", dtpFechaF.Value.ToString());
            Texto_Html = Texto_Html.Replace("@Dias", dias.ToString());
            Texto_Html = Texto_Html.Replace("@PrecioDia", "2500");
            Texto_Html = Texto_Html.Replace("@Total", txtTotal.Texts);
            Texto_Html = Texto_Html.Replace("@Total2", txtTotal.Texts);

            // Mostrar un cuadro de diálogo para seleccionar la ubicación donde guardar el PDF
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Reserva_{0}.pdf", txtDocumento.Texts);
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
    }
}
