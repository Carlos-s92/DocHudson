using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGit.Modales
{
    public partial class TarjetaAuto : UserControl
    {


        public Autos oAuto = new Autos();

       
        public TarjetaAuto()
        {
            InitializeComponent();
        }
        public TarjetaAuto(int id,string modelo, string marca, decimal consumo, int puertas, int asientos, decimal kilometros, bool reservado, bool estado, string matricula, int año, string imagen)
        {
            //oAuto.oModelo = new Modelo();
            //oAuto.oModelo.oMarca = new Marca();
            InitializeComponent();
            this.iconButton1.BackColor = Color.FromArgb(14, 15, 19);
            this.iconButton2.BackColor = Color.FromArgb(14, 15, 19);
            ///////////VER MARCA, MODELO, CONSUMO, PUERTAS, ASIENTOS//////////////////////////////////////////////////////////////////////////////////////////////////////////
            oAuto.oModelo.oMarca.marca = marca;
            oAuto.oModelo.modelo = modelo;
            oAuto.oModelo.Consumo = consumo;
            oAuto.Kilometros = kilometros;
            oAuto.oModelo.Puertas = puertas;
            oAuto.oModelo.Asientos = asientos;
            oAuto.Estado = estado;
            oAuto.Id_Auto = id;
            oAuto.Reservado = reservado;
            oAuto.Matricula = matricula;
            oAuto.Año = Convert.ToInt32(año);
            oAuto.Imagen = imagen;


            if (oAuto.Estado != true){
                this.BackColor = Color.Red;
           }
          

            if (reservado != true)
            {
                this.lblFechaF.Visible = false;
                this.lblFechaI.Visible = false;
                this.lbl7.Visible = false;
                this.lbl8.Visible = false;
            }
            else
            {
                this.btnReserva.BackColor = Color.Red;
                this.btnReserva.Text = "Reservado";
                this.btnReserva.Click += label9_Click(); 
            }


            this.lbl1.Text = modelo;
            this.lbl2.Text = marca;
            this.lbl3.Text = consumo.ToString();
            this.lbl4.Text = kilometros.ToString();
            this.lbl5.Text = asientos.ToString();
            this.lbl6.Text = puertas.ToString();
            this.txtId.Text = id.ToString();

            string uploadsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
            string imagePath = Path.Combine(uploadsPath, oAuto.Imagen);

            if (File.Exists(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                MessageBox.Show("La imagen no se encontró.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private EventHandler label9_Click()
        {
            throw new NotImplementedException();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            using (var modal = new mdAutos(Convert.ToInt32(txtId.Text), oAuto))
            {
                var result = modal.ShowDialog(); // Muestra el diálogo modal.

                if (result == DialogResult.OK) // Si se selecciona un producto, llena los campos de producto y precio.
                {
                    Edicion();
                }
            }
        }
        private void Edicion()
        {
            // Aquí se puede notificar al formulario principal o cambiar el estado de visibilidad
            if (this.ParentForm is FrmCatalogo mainForm)  // Verificamos que el formulario principal sea el adecuado
            {

                mainForm.HandleLoginSuccess(); // Llamamos a un método en el formulario principal
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("Desea eliminar el auto?","Alerta",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if(confirmacion == DialogResult.Yes)
            {
                bool Resultado = new CN_Auto().Eliminar(oAuto, out string Mensaje);

                if (Resultado) {
                    Edicion();
                }
                else
                {
                    MessageBox.Show(Mensaje,"Error",MessageBoxButtons.OK);
                }
            }
        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            Envio(oAuto);
        }

        private void Envio(Autos pAuto)
        {
            // Aquí se puede notificar al formulario principal o cambiar el estado de visibilidad
            if (this.ParentForm is FrmCatalogo mainForm)  // Verificamos que el formulario principal sea el adecuado
            {

                mainForm.Envio(pAuto); // Llamamos a un método en el formulario principal
            }
        }
    }
}
