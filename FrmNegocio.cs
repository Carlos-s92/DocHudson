using CapaEntidad;
using CapaNegocio;
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
using System.Windows.Media.TextFormatting;

namespace TestGit
{
    public partial class FrmNegocio : Form
    {
        private string nombreImagen = "";
        public FrmNegocio()
        {
            InitializeComponent();
        }


        private void rjButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:";
            openFileDialog.Filter = "Archivos de imagen (.jpg;.jpeg;.png)|.jpg;.jpeg;.png";
            openFileDialog.Title = "Seleccione una imagen";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourceFilePath = openFileDialog.FileName;
                txtImagen.Texts = sourceFilePath;
                
                // Genera un nombre único para la imagen
                nombreImagen = Guid.NewGuid().ToString() + Path.GetExtension(sourceFilePath);

                // Ruta de destino en tu proyecto (por ejemplo, en una carpeta 'uploads' en la misma ruta de ejecución)
                //string destinationPath = Path.Combine(Application.StartupPath, "uploads", nombreImagen);
                string destinationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"....\uploads" + nombreImagen);
                Debug.WriteLine(destinationPath);
                // Asegúrate de que la carpeta de destino existe

                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                // Copia la imagen a la carpeta de destino
                File.Copy(sourceFilePath, destinationPath, true);
            }

            //string imagePath = Path.Combine(Application.StartupPath, "uploads", photoFilePath);
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"....\uploads" + nombreImagen);
            picLogo.Image = Image.FromFile(imagePath);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;

        }
        private bool Validaciones()
        {
            bool validacion = true;

            // Validar que el campo de nombre no esté vacío
            if (txtNombre.Texts == "")
            {
                validacion = false;
            }
            // Validar que el campo de RUC no esté vacío
            if (txtImagen.Texts == "")
            {
                validacion = false;
            }
            // Validar que el campo de dirección no esté vacío
            if (txtDireccion.Texts == "")
            {
                validacion = false;
            }

            return validacion;  // Retornar true si todos los campos están completos, false en caso contrario
        }
        private void rjButton1_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            // Verificar que todos los campos estén completos antes de proceder
            if (Validaciones())
            {
                // Solicitar confirmación del usuario antes de realizar cambios
                DialogResult confirmacion = MessageBox.Show("¿Seguro desea cambiar los datos?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    // Crear un objeto Negocio con los datos ingresados por el usuario
                    Negocio obj = new Negocio()
                    {
                        Nombre = txtNombre.Texts,
                        Imagen = txtImagen.Text,
                        Direccion = txtDireccion.Texts
                    };

                    // Intentar guardar los datos en la base de datos a través de la capa de negocio
                    bool respuesta = new CN_Negocio().guardarDatos(obj, out mensaje);

                    // Mostrar mensajes según el resultado de la operación
                    if (respuesta)
                    {
                        MessageBox.Show("Los cambios fueron guardados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se guardaron los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Mostrar un mensaje de advertencia si algún campo está incompleto
                MessageBox.Show("Debe Completar todos los campos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmNegocio_Load(object sender, EventArgs e)
        {
            Negocio obj = new CN_Negocio().obtenerDatos();
            txtNombre.Texts = obj.Nombre;
            txtDireccion.Texts = obj.Direccion;
            if (obj.Imagen != null)
            {
                //string imagePath = Path.Combine(Application.StartupPath, "uploads", photoFilePath);
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"....\uploads" + obj.Imagen);
                picLogo.Image = Image.FromFile(imagePath);
                picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
