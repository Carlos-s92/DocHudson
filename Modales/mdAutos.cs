using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGit.Modales
{
    public partial class mdAutos : Form
    {
        private string nombreImagen = "";
        private bool estado;
        public mdAutos()
        {
            InitializeComponent();
        }
        public mdAutos(int id, Autos pAuto)
        {
            InitializeComponent();
            this.txtId.Text = id.ToString();
            this.txtModelo.Texts = pAuto.Modelo;
            this.txtMarca.Texts = pAuto.Marca;
            this.txtConsumo.Texts = pAuto.Consumo.ToString();
            this.txtKilometros.Texts = pAuto.Kilometros.ToString();
            this.txtMatricula.Texts = pAuto.Matricula.ToString();
            this.txtPuertas.Texts = pAuto.Puertas.ToString();
            this.txtAsientos.Texts = pAuto.Asientos.ToString();
            this.txtAño.Texts = pAuto.Año.ToString();
            this.estado = pAuto.Estado;
            this.nombreImagen = pAuto.Imagen;

            string uploadsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
            string imagePath = Path.Combine(uploadsPath, nombreImagen);

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
        private bool Validaciones()
        {
            bool confirmacion = true;


            // Verifica que el campo de Documento no esté vacío.
            if (txtModelo.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el campo de Dirección no esté vacío.
            if (txtMatricula.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el correo tenga formato válido.
            if (txtMarca.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el campo de Nombre no esté vacío.
            if (txtAño.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el campo de Teléfono no esté vacío.
            if (txtAsientos.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el campo de Nombre no esté vacío.
            if (txtConsumo.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el campo de Teléfono no esté vacío.
            if (txtPuertas.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el campo de Teléfono no esté vacío.
            if (txtKilometros.Texts == "")
            {
                confirmacion = false;
            }


            // Retorna el resultado de las validaciones.
            return confirmacion;
        }
        private void BtnGuardar2_Click(object sender, EventArgs e)
        {
            // Valida los campos antes de proceder.
            if (Validaciones())
            {
                DialogResult confirmacion;

                string mensaje = string.Empty;


                confirmacion = MessageBox.Show("¿Seguro desea editar el Auto?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



                // Si la respuesta es afirmativa, se crea o edita el Auto.
                if (confirmacion == DialogResult.Yes)
                {
                    Autos objAuto = new Autos()
                    {
                        Id_Auto = Convert.ToInt32(txtId.Text),
                        Modelo = txtModelo.Texts,
                        Marca = txtMarca.Texts,
                        Matricula = txtMatricula.Texts,
                        Kilometros = Convert.ToDecimal(txtKilometros.Texts),
                        Consumo = Convert.ToDecimal(txtConsumo.Texts),
                        Puertas = Convert.ToInt32(txtPuertas.Texts),
                        Asientos = Convert.ToInt32(txtAsientos.Texts),
                        Año = Convert.ToInt32(txtAño.Texts),
                        Imagen = nombreImagen,
                        Estado = Convert.ToInt32(((OpcionesCombo)comboEstado.SelectedItem).Valor) == 1 ? true : false
                    };

                    bool idAutoGenerado = new CN_Auto().Editar(objAuto, out mensaje);
                    if (idAutoGenerado == true)
                    {
                        LimpiarCampos(); // Limpia los campos del formulario.
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
            else
            {
                // Muestra un mensaje si no se completan todos los campos obligatorios.
                MessageBox.Show("Debe Completar todos los campos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LimpiarCampos()
        {
            this.txtModelo.Texts = "";
            this.txtMarca.Texts = "";
            this.txtMatricula.Texts = "";
            this.txtAño.Texts = "";
            this.txtAsientos.Texts = "";
            this.txtPuertas.Texts = "";
            this.txtConsumo.Texts = "";
            this.txtKilometros.Texts = "";
            this.txtId.Text = "0";

            comboEstado.SelectedIndex = 0;

        }

        private void BtnLimpiar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mdAutos_Load(object sender, EventArgs e)
        {
            // Inicializa el comboEstado con opciones para el estado del cliente (Activo, No Activo).
            comboEstado.Items.Add(new OpcionesCombo() { Valor = 1, Texto = "Activo" });
            comboEstado.Items.Add(new OpcionesCombo() { Valor = 0, Texto = "No Activo" });

            // Configura las propiedades de visualización del comboEstado.
            comboEstado.DisplayMember = "Texto";
            comboEstado.ValueMember = "Valor";
            if (this.estado == true)
            {
                this.comboEstado.SelectedIndex = 0;
            }
            else
            {
                this.comboEstado.SelectedIndex = 1;
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:";
                openFileDialog.Filter = "Archivos de imagen | *.jpg;*.jpeg;*.png";
                openFileDialog.Title = "Seleccione una imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourceFilePath = openFileDialog.FileName;
                    txtImagen.Texts = sourceFilePath;

                    // Genera un nombre único para la imagen
                    nombreImagen = Guid.NewGuid().ToString() + Path.GetExtension(sourceFilePath);

                    // Definir la carpeta 'uploads' dentro del directorio base del proyecto
                    string uploadsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");

                    // Asegurarse de que la carpeta existe
                    Directory.CreateDirectory(uploadsPath);

                    // Construir la ruta final de la imagen
                    string destinationPath = Path.Combine(uploadsPath, nombreImagen);

                    Debug.WriteLine(destinationPath);

                    // Copiar la imagen al directorio de destino
                    File.Copy(sourceFilePath, destinationPath, true);

                    // Mostrar la imagen en el PictureBox
                    pictureBox1.Image = Image.FromFile(sourceFilePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

        }
    }
}
