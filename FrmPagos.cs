using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
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
    public partial class FrmPagos : Form
    {
        public FrmPagos()
        {
            InitializeComponent();
        }

        private void FrmPagos_Load(object sender, EventArgs e)
        {
            // Configura el comboBusqueda para filtrar los resultados en el DataGridView.
            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    comboBusqueda.Items.Add(new OpcionesCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            comboBusqueda.DisplayMember = "Texto";
            comboBusqueda.ValueMember = "Valor";
            comboBusqueda.SelectedIndex = 0;
            // Muestra los Pagos en el DataGridView.
            List<Pago> listaPagos = new CN_Pago().Listar();

            foreach (Pago item in listaPagos)
            {
                Cliente cliente = new CN_Cliente().ClientePorPago(item.Id_Pago);

                dgvData.Rows.Add(new object[] {
                                "", // Columna para el icono de selección
                                item.Id_Pago,
                                item.Total,
                                cliente.Dni,
                                cliente.Nombre,
                                item.Estado == true ? 1 : 0, // Estado como valor
                                item.Estado == true ? "Activo" : "No Activo", // Estado como texto
                   
                });
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            // Limpia el campo de búsqueda y muestra todas las filas del DataGridView.
            txtBusqueda.Texts = "";
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true; // Muestra todas las filas.
            }
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) // Si el usuario presiona la tecla Enter.
            {
                // Obtiene el nombre de la columna seleccionada para la búsqueda.
                string columnaFiltro = ((OpcionesCombo)comboBusqueda.SelectedItem).Valor.ToString();

                // Verifica si hay filas en el DataGridView.
                if (dgvData.Rows.Count > 0)
                {
                    // Filtra las filas del DataGridView según el texto de búsqueda.
                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Texts.Trim().ToUpper()))
                        {
                            row.Visible = true; // Muestra la fila si coincide.
                        }
                        else
                        {
                            row.Visible = false; // Oculta la fila si no coincide.
                        }
                    }
                }
            }
        }
    }
}
