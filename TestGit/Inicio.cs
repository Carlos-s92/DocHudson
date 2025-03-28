using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGit
{
    public partial class Inicio : Form
    {
        // Variables estáticas para gestionar el usuario, el menú activo y el formulario activo.
        //private static Usuario user; // Variable para almacenar el usuario actual.
        public static IconMenuItem menuActivo = null; // Almacena el menú que está activo.
        private static Form formActivo = null; // Almacena el formulario activo.
        public Inicio()
        {
            InitializeComponent();
 
      
        }

        private void subMenuRCompras_Click(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea Cerrar la sesión?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.Close(); // Cierra el formulario y finaliza la sesión.
            }
        }


        public void pintar()
        {
            this.menuMantenimiento.BackColor = Color.FromArgb(38, 50, 56);
            this.menuCompras.BackColor = Color.FromArgb(38, 50, 56);
            this.menuVentas.BackColor = Color.FromArgb(38, 50, 56);
            // Definimos conjuntos de tipos de formularios para cada menú
            var mantenimientoForms = new HashSet<Type>
    {
                //Si tenemos submenus
        //typeof(FrmCategoria),
        //typeof(FrmCupon),
        //typeof(FrmNegocio),
        //typeof(FrmProducto)
    };

            var comprasForms = new HashSet<Type>
    {
        //typeof(FrmDetalleCompra),
        //typeof(FrmCompras)
    };

            var ventasForms = new HashSet<Type>
    {
        //typeof(FrmDetalleVenta),
        //typeof(FrmVentas)
    };

            // Inicializamos el color de fondo por defecto
            Color defaultColor = Color.FromArgb(38, 50, 56);
            Color selectedColor = Color.FromArgb(30, 30, 30);

            // Variable para determinar si encontramos un formulario específico
            bool found = false;

            foreach (Form form in Contenedor.Controls.OfType<Form>())
            {
                if (mantenimientoForms.Contains(form.GetType()))
                {
                    this.menuMantenimiento.BackColor = selectedColor;
                    found = true;
                    break; // Salimos del bucle si encontramos un formulario de mantenimiento
                }
                else if (comprasForms.Contains(form.GetType()))
                {
                    this.menuCompras.BackColor = selectedColor;
                    found = true;
                    break; // Salimos del bucle si encontramos un formulario de compras
                }
                else if (ventasForms.Contains(form.GetType()))
                {
                    this.menuVentas.BackColor = selectedColor;
                    found = true;
                    break; // Salimos del bucle si encontramos un formulario de ventas
                }
            }

            // Si no se encontró ningún formulario, aplicamos el color por defecto
            if (!found)
            {
                this.menuMantenimiento.BackColor = defaultColor;
            }
        }

        public void abrirFormulario(IconMenuItem menu, Form formulario)
        {
            Contenedor.Controls.Clear();
            // Restablece el color del menú activo si existe.
            if (menuActivo != null)
            {
                menuActivo.BackColor = Color.FromArgb(38, 50, 56);
            }

            // Cambia el color del menú seleccionado.
            menu.BackColor = Color.FromArgb(30, 30, 30);
            menuActivo = menu; // Asigna el nuevo menú como activo.

            // Cierra el formulario activo si ya hay uno abierto.
            if (formActivo != null)
            {
                formActivo.Close();
            }

            formActivo = formulario; // Asigna el nuevo formulario como activo.
            formulario.TopLevel = false; // Configura el formulario para que no sea de nivel superior.
            formulario.FormBorderStyle = FormBorderStyle.None; // Elimina los bordes del formulario.
            formulario.Dock = DockStyle.Fill; // Establece el formulario para que ocupe todo el contenedor.
            formulario.BackColor = Color.FromArgb(44, 53, 68); // Cambia el color de fondo.
            Contenedor.Controls.Add(formulario); // Añade el formulario al contenedor visual.
            pintar();
            formulario.Show(); // Muestra el formulario.
        }
    }
}
