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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea Cerrar la sesión?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.Close(); // Cierra el formulario y finaliza la sesión.
            }
        }


        public void Pintar()
        {
            this.menuMantenimiento.BackColor = Color.FromArgb(27, 43, 66);
            this.menuAutos.BackColor = Color.FromArgb(23, 24, 28);
            this.menuReserva.BackColor = Color.FromArgb(23, 24, 28);
            // Definimos conjuntos de tipos de formularios para cada menú
            var mantenimientoForms = new HashSet<Type>
    {
                //Si tenemos submenus
        //typeof(FrmCategoria),
        //typeof(FrmCupon),
        //typeof(FrmNegocio),
        //typeof(FrmProducto)
    };

            var autosForms = new HashSet<Type>
    {
        //typeof(FrmDetalleCompra),
        //typeof(FrmCompras)
    };

            var reservasForms = new HashSet<Type>
    {
        //typeof(FrmDetalleVenta),
        //typeof(FrmVentas)
    };

            // Inicializamos el color de fondo por defecto
            Color defaultColor = Color.FromArgb(23, 24, 28);
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
                else if (autosForms.Contains(form.GetType()))
                {
                    this.menuAutos.BackColor = selectedColor;
                    found = true;
                    break; // Salimos del bucle si encontramos un formulario de compras
                }
                else if (reservasForms.Contains(form.GetType()))
                {
                    this.menuReserva.BackColor = selectedColor;
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
                menuActivo.BackColor = Color.FromArgb(23, 24, 28);
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
            formulario.BackColor = Color.FromArgb(14, 15, 19); // Cambia el color de fondo.
            Contenedor.Controls.Add(formulario); // Añade el formulario al contenedor visual.
            Pintar();
            formulario.Show(); // Muestra el formulario.
        }

        private void menuInicio_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmInicio()); // Abre el formulario de inicio.
            this.lblIndicador.Text = "Inicio";
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmUsuario()); // Abre el formulario de inicio.
            this.lblIndicador.Text = "Usuarios";
        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmClientes()); // Abre el formulario de inicio.
            this.lblIndicador.Text = "Clientes";
        }

        private void menuPagos_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmPagos()); // Abre el formulario de inicio.
            this.lblIndicador.Text = "Pagos";
        }

        private void menuReportes_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmReporte()); // Abre el formulario de inicio.
            this.lblIndicador.Text = "Reporte de reservas";
        }

        private void Negocio_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmNegocio()); // Abre el formulario de inicio.
            this.lblIndicador.Text = "Gestion de Negocio";
        }

        private void Backup_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmBackup()); // Abre el formulario de inicio.
            this.lblIndicador.Text = "Gestion de Base Datos";
        }

        private void menuAutos_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmAutos()); // Abre el formulario de inicio.
            this.lblIndicador.Text = "Gestion de Autos";
        }

        private void menuRegistrarReserva_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmReserva()); // Abre el formulario de inicio.
            this.lblIndicador.Text = "Reservas";
        }

        private void menuVerReserva_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmDetalleReserva()); // Abre el formulario de inicio.
            this.lblIndicador.Text = "Detalle Reservas";
        }
    }
}
