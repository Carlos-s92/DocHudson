using CapaEntidad;
using CapaNegocio;
using CustomControls.RJControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TestGit.Modales;

namespace TestGit
{
    public partial class FrmCatalogo : Form
    {
        // Constantes WinAPI
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Autos _Auto = new Autos();
        public FrmCatalogo()
        {
            InitializeComponent();

            // Suscribe el evento al formulario o a tu panel superior
            this.MouseDown += Form_MouseDown;
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmCatalogo_Load(object sender, EventArgs e)//////////////////REVISAR MODELO Y MARCA//////////////////////////////////
        {
            flowLayoutPanel1.Controls.Clear();

            List<Autos> autos = new CN_Auto().Listar();

            foreach (Autos item in autos)
            {
                TarjetaAuto auto = new TarjetaAuto(item.Id_Auto,item.oModelo.modelo, item.oModelo.oMarca.marca, item.oModelo.Consumo, item.oModelo.Puertas, item.oModelo.Asientos, item.Kilometros, item.Reservado, item.Estado, item.Matricula, item.Año, item.Imagen);
                flowLayoutPanel1 .Controls.Add(auto);
            }

            if (this.Owner is Inicio)
            {
                btnSalir.Visible = true; // o btnCancelar.Enabled = true;
            }
            else
            {
                btnSalir.Visible = false;
            }

        }
        public void HandleLoginSuccess()
        {
            this.flowLayoutPanel1.Controls.Clear();
            List<Autos> autos = new CN_Auto().Listar();

            foreach (Autos item in autos)
            {
                TarjetaAuto auto = new TarjetaAuto(item.Id_Auto, item.oModelo.modelo, item.oModelo.oMarca.marca, item.oModelo.Consumo, item.oModelo.Puertas, item.oModelo.Asientos, item.Kilometros, item.Reservado, item.Estado, item.Matricula,item.Año, item.Imagen);
                flowLayoutPanel1.Controls.Add(auto);

            }
        }

        public void Envio(Autos pAuto)
        {
            if(this.ParentForm is Inicio mainform)
            {

                mainform.Reservas(pAuto);
            }
            else
            {
                _Auto = pAuto;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            // 1) Obtiene el texto de búsqueda
            string criterio = txtBusqueda.Texts.Trim();

            // 2) Llama a la capa de negocio que a su vez invoca al SP BuscarClientes
            var resultados = new CN_Auto().BuscarAuto(criterio);

            foreach (Autos item in resultados)
            {
                TarjetaAuto auto = new TarjetaAuto(item.Id_Auto, item.oModelo.modelo, item.oModelo.oMarca.marca, item.oModelo.Consumo, item.oModelo.Puertas, item.oModelo.Asientos, item.Kilometros, item.Reservado, item.Estado, item.Matricula, item.Año, item.Imagen);
                flowLayoutPanel1.Controls.Add(auto);
            }
        }

        private void btnBuscar_Click(object sender, DragEventArgs e)
        {

        }

        private void BBordeFormCatalogo_Paint(object sender, PaintEventArgs e)
        {
            RJButton butt = sender as RJButton;
            if (butt != null)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(butt.ClientRectangle,
                Color.Blue,
                Color.Purple,
                LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, butt.ClientRectangle);
                }
            }
        }
    }
}
