using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using CustomControls.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestGit.Modales;

namespace TestGit
{
    public partial class FrmAutos : Form
    {

        private string nombreImagen = "";
        public FrmAutos()
        {
            InitializeComponent();

            BFondoPBAuto.Paint += BFondoPBAuto_Paint;
        }

        private bool Validaciones()
        {
            bool confirmacion = true;
    

            // Verifica que el campo de Documento no esté vacío.
            /*if (txtModelo.Texts == "")
            {
                confirmacion = false;
            }*/
            // Verifica que el campo de Dirección no esté vacío.
            if (txtMatricula.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el correo tenga formato válido.
            /*if (txtMarca.Texts == "")
            {
                confirmacion = false;
            }*/
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

        private void LimpiarCampos()
        {
            //this.txtModelo.Texts = "";
            //this.txtMarca.Texts = "";
            
            this.txtMatricula.Texts = "";
            this.txtAño.Texts = "";
            this.txtAsientos.Texts = "";
            this.txtPuertas.Texts = "";
            this.txtConsumo.Texts = "";
            this.txtKilometros.Texts = "";
            this.txtid.Text = "0";
            comboMarca.SelectedIndex = 0;
            comboModelo.SelectedIndex = 0;
            comboEstado.SelectedIndex = 0;
       
        }




        private void BtnGuardar2_Click(object sender, EventArgs e)
        {
            // Valida los campos antes de proceder.
            if (Validaciones())
            {
                string mensaje = string.Empty;

                VentanaEmergente confirmacion = new VentanaEmergente("Confirmacion","¿Seguro desea agregar el Auto?","Interrogacion");
                confirmacion.ShowDialog();
                
                // Si la respuesta es afirmativa, se crea o edita el Auto.
                if (confirmacion.DialogResult == DialogResult.Yes)
                {
                    confirmacion.Close();

                    Marca marca = new Marca()
                    {
                        Id_Marca = Convert.ToInt32(((OpcionesCombo)comboMarca.SelectedItem).Valor),
                    };

                    Modelo modelo = new Modelo()
                    {
                        Id_Modelo = Convert.ToInt32(((OpcionesCombo)comboModelo.SelectedItem).Valor),
                        oMarca = marca,
                        modelo = ((OpcionesCombo)comboModelo.SelectedItem).Texto,
                        Consumo = Convert.ToDecimal(txtConsumo.Texts),
                        Puertas = Convert.ToInt32(txtPuertas.Texts),
                        Asientos = Convert.ToInt32(txtAsientos.Texts),
                    };

                    Autos objAuto = new Autos()
                    {

                        Id_Auto = Convert.ToInt32(txtid.Text),
                        oModelo = modelo,
                        /*Modelo = txtModelo.Texts,
                        Marca = txtMarca.Texts,*/
                        Matricula = txtMatricula.Texts,
                        Kilometros = Convert.ToDecimal(txtKilometros.Texts),
                        /*Consumo = Convert.ToDecimal(txtConsumo.Texts),
                        Puertas = Convert.ToInt32(txtPuertas.Texts),
                        Asientos = Convert.ToInt32(txtAsientos.Texts),*/
                        Año = Convert.ToInt32(txtAño.Texts),
                        Imagen = nombreImagen,
                        Estado = Convert.ToInt32(((OpcionesCombo)comboEstado.SelectedItem).Valor) == 1 ? true : false
                    };

                    int idAutoGenerado = new CN_Auto().Registrar(objAuto, out mensaje);
                        if (idAutoGenerado != 0)
                        {
                            LimpiarCampos(); // Limpia los campos del formulario.
                            VentanaEmergente MsgError = new VentanaEmergente("Registro exitoso", "Auto registrado exitosamente", "Exito");
                            MsgError.ShowDialog();
                    }
                        else
                        {
                            VentanaEmergente MsgError = new VentanaEmergente("Error", mensaje, "Error");
                            MsgError.ShowDialog();
                        }
                }
                else
                {
                    confirmacion.Close();
                }
            }
            else
            {
                // Muestra un mensaje si no se completan todos los campos obligatorios.
                VentanaEmergente MsgError = new VentanaEmergente("Alerta", "Debe Completar todos los campos", "Informacion");
                MsgError.ShowDialog();
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

        private void BFotoProducto_Click(object sender, EventArgs e)
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


        private void FrmAutos_Load(object sender, EventArgs e)
        {
            // Inicializa el comboEstado con opciones para el estado del cliente (Activo, No Activo).
            comboEstado.Items.Add(new OpcionesCombo() { Valor = 1, Texto = "Activo" });
            comboEstado.Items.Add(new OpcionesCombo() { Valor = 0, Texto = "No Activo" });

            // Configura las propiedades de visualización del comboEstado.
            comboEstado.DisplayMember = "Texto";
            comboEstado.ValueMember = "Valor";
            comboEstado.SelectedIndex = 0;

            /////////// Muestra las Marcas en el comboMarca//////////////////////////////////////////////////
            List<Marca> listaMarcas = new CN_Marca().Listar();

            foreach (Marca item in listaMarcas)
            {
                comboMarca.Items.Add(new OpcionesCombo() { Valor = item.Id_Marca, Texto = item.marca });
            }
            //comboMarca.DataSource = listaMarcas;
            comboMarca.DisplayMember = "Texto";
            comboMarca.ValueMember = "Valor";
            comboMarca.SelectedIndex = 0;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void txtKilometros_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escribe solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPuertas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escribe solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAsientos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escribe solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtConsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escribe solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escribe solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Modelo> listaModelos = new CN_Modelo().Listar();

            string idMarca = ((OpcionesCombo)comboMarca.SelectedItem).Valor.ToString();

            var modelosFiltrados = listaModelos
                .Where(l => l.oMarca != null && l.oMarca.Id_Marca == Convert.ToInt32(idMarca))
                .Select(l => new OpcionesCombo
                {
                    Valor = l.Id_Modelo,
                    Texto = l.modelo
                })
                .ToList();
            
            comboModelo.DataSource = modelosFiltrados;
            comboModelo.DisplayMember = "Texto";
            comboModelo.ValueMember = "Valor";
        }

        private void BFondoPBAuto_Paint(object sender, PaintEventArgs e)
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
