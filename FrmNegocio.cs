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
using System.Windows.Interop;
using System.Windows.Media.TextFormatting;
using TestGit.Modales;

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
                    picLogo.Image = Image.FromFile(sourceFilePath);
                    picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

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
                VentanaEmergente confirmacion = new VentanaEmergente("Confirmacion", "¿Seguro desea cambiar los datos?", "Interrogacion");
                confirmacion.ShowDialog();
                if (confirmacion.DialogResult == DialogResult.Yes)
                {
                    confirmacion.Close();
                    // Crear un objeto Negocio con los datos ingresados por el usuario
                    Negocio obj = new Negocio()
                    {
                        Nombre = txtNombre.Texts,
                        Imagen = txtImagen.Texts,
                        Direccion = txtDireccion.Texts
                    };

                    // Intentar guardar los datos en la base de datos a través de la capa de negocio
                    bool respuesta = new CN_Negocio().guardarDatos(obj, out mensaje);

                    // Mostrar mensajes según el resultado de la operación
                    if (respuesta)
                    {
                        VentanaEmergente msg = new VentanaEmergente("Mensaje", "Los cambios fueron guardados", "Informacion");
                        msg.ShowDialog();
                    }
                    else
                    {
                        VentanaEmergente msg = new VentanaEmergente("Mensaje", "No se guardaron los cambios", "Error");
                        msg.ShowDialog();
                    }
                }
                else
                {
                    confirmacion.Close();
                }
            }
            else
            {
                // Mostrar un mensaje de advertencia si algún campo está incompleto
                VentanaEmergente msg = new VentanaEmergente("Alerta", "Debe completar todos los campos", "Informacion");
                msg.ShowDialog();
            }
        }

        private void FrmNegocio_Load(object sender, EventArgs e)
        {
            Negocio obj = new CN_Negocio().obtenerDatos();
            txtNombre.Texts = obj.Nombre;
            txtDireccion.Texts = obj.Direccion;

            if(obj.Imagen != null)
            {

                string uploadsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
                string imagePath = Path.Combine(uploadsPath, obj.Imagen);

                if (File.Exists(imagePath))
                {
                    picLogo.Image = Image.FromFile(imagePath);
                    picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    VentanaEmergente msg = new VentanaEmergente("Error", "La imagen no se encontró.", "Error");
                    msg.ShowDialog();
                }
            }

        }
    }
}
