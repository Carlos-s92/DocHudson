using CapaEntidad;
using CapaNegocio;
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
using TestGit.Modales;

namespace TestGit
{
    public partial class Inicio : Form
    {

        // Variables estáticas para gestionar el usuario, el menú activo y el formulario activo.
        //private static Usuario user; // Variable para almacenar el usuario actual.
        public static IconMenuItem menuActivo = null; // Almacena el menú que está activo.
        private static Form formActivo = null; // Almacena el formulario activo.
        private Usuarios user;
        public Inicio()
        {
            InitializeComponent();
        }
        public Inicio(Usuarios pUsuario)
        {
            InitializeComponent();
            this.user = pUsuario;
            this.nombreUser.Text = this.user.Usuario;
            this.lblRol.Text = this.user.oPerfil.Descripcion;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            VentanaEmergente VE = new VentanaEmergente("Cerrar Sesion", "¿Está seguro que desea cerrar sesión?", "Interrogacion");
            VE.ShowDialog(); //Mostramos el mensaje personalizado.

            if (VE.DialogResult == DialogResult.Yes)
            {
                VE.Close(); //Cerramos el mensaje personalizado una vez evaluado el "DialogResult"
                this.Close(); // Cerramos el formulario "Inicio"
            }
            else
            {
                VE.Close(); //Cerramos el mensaje personalizado una vez evaluado el "DialogResult"
            }
        }


        public void Pintar()
        {
            this.menuMantenimiento.BackColor = Color.FromArgb(23, 24, 28);
            this.menuAutos.BackColor = Color.FromArgb(23, 24, 28);
            this.menuReserva.BackColor = Color.FromArgb(23, 24, 28);
            // Definimos conjuntos de tipos de formularios para cada menú
            var mantenimientoForms = new HashSet<Type>
            {
                typeof(FrmNegocio),
                typeof(FrmBackup)
            };

            var autosForms = new HashSet<Type>
            {
                typeof(FrmCatalogo),
                typeof(FrmAutos)
            };

            var reservasForms = new HashSet<Type>
            {
                typeof(FrmReserva),
                typeof(FrmDetalleReserva)
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
            abrirFormulario((IconMenuItem)sender, new FrmUsuario(this.user)); // Abre el formulario de inicio.
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
           
        }

        private void menuRegistrarReserva_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmReserva(this.user)); // Abre el formulario de inicio.
            this.lblIndicador.Text = "Reservas";
        }

        private void menuVerReserva_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmDetalleReserva()); // Abre el formulario de inicio.
            this.lblIndicador.Text = "Detalle Reservas";
        }

        private void menuGraficos_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmGraficos()); // Abre el formulario de inicio.
            this.lblIndicador.Text = "Graficos";
        }

        private void menuGestionAuto_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmAutos()); // Abre el formulario de inicio.
            this.lblIndicador.Text = "Gestion de Autos";
        }

        private void menuCatalogo_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmCatalogo()); // Abre el formulario de inicio.
            this.lblIndicador.Text = "Catalogo";
        }

        public void Reservas(Autos pAuto)
        {
            abrirFormulario(menuReserva, new FrmReserva(pAuto,this.user));
            this.lblIndicador.Text = "Reservas";
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

            DateTime fecha = DateTime.Now;

            bool resultado = new CN_Backup().Backup(fecha);
            if (resultado == true)
            {
                MessageBox.Show("Se esta realizando una copia de seguridad automatica, aguarde", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


            if(user.oPerfil.Descripcion == "Encargado")
            {
                this.menuMantenimiento.Visible = false;
                this.menuUsuarios.Visible = false;
                this.menuGraficos.Visible = false;

            }


        }
    }
}
