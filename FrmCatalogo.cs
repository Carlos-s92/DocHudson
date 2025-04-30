using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestGit.Modales;

namespace TestGit
{
    public partial class FrmCatalogo : Form
    {

        public Autos _Auto = new Autos();
        public FrmCatalogo()
        {
            InitializeComponent();

            txtBusqueda.KeyDown += TxtBusqueda_KeyDown;
        }

        private void TxtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            List <TarjetaAuto> lista = new List<TarjetaAuto>();

            if (e.KeyData == Keys.Enter) // Si el usuario presiona la tecla Enter.
            {
                foreach (TarjetaAuto control in flowLayoutPanel1.Controls)
                {
                    lista.Add(control);
                }

                if (comboBusqueda.SelectedIndex == 0)
                {
                    buscarSinFiltroCampo(lista, txtBusqueda.Texts);
                }
                else
                {
                    buscarConFiltroCampo(lista, txtBusqueda.Texts, comboBusqueda.SelectedItem.ToString());
                }
            }
        }

        private void buscarSinFiltroCampo(List<TarjetaAuto> lista, string texto)
        {
            foreach (TarjetaAuto control in lista)
            {
                if (control.Modelo.Contains(texto)  ||
                control.Marca.Contains(texto)       ||
                control.Consumo.Contains(texto)     ||
                control.KM.Contains(texto)          ||
                control.Asientos.Contains(texto)    ||
                control.Puertas.Contains(texto)     ||
                control.FechaInicio.Contains(texto) ||
                control.FechaFin.Contains(texto))
                {
                    control.Visible = true;
                }
                else
                {
                    control.Visible = false;
                }
            }
        }

    private void buscarConFiltroCampo(List<TarjetaAuto> lista, string texto, string campo)
    {
        foreach (TarjetaAuto control in lista)
        {

            PropertyInfo propiedad = control.GetType().GetProperty(campo);

            if (propiedad != null)
            {
                object valor = propiedad.GetValue(control);

                if (valor != null && valor.ToString().ToLower().Contains(texto.ToLower()))
                {
                    control.Visible = true;
                }
                else
                {
                   control.Visible = false;
                }
            }
            else
            {
                control.Visible = false;
            }
        }
    }


    private void comboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtBusqueda.Texts = ""; //Limpia el campo busqueda.
            comboBusqueda.SelectedIndex = 0;
            foreach (TarjetaAuto control in flowLayoutPanel1.Controls)
            {
                control.Visible = true; //cambiamos la visibilidad a "true" para cada control del panel "FlowLayourPanel1".
            }
        }

        private void FrmCatalogo_Load(object sender, EventArgs e)//////////////////REVISAR MODELO Y MARCA//////////////////////////////////
        {
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

            comboBusqueda.SelectedIndex = 0;
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
    }
}
