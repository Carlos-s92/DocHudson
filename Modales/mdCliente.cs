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

namespace TestGit.Modales
{
    public partial class mdCliente : Form
    {
        public Cliente _Cliente = new Cliente();

        public mdCliente()
        {
            InitializeComponent();
        }

        private void mdCliente_Load(object sender, EventArgs e)
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

            // Muestra los clientes en el DataGridView.
            List<Cliente> listaClientes = new CN_Cliente().Listar().Where(p => p.Estado == true).ToList();

            foreach (Cliente item in listaClientes)
            {
                DateTime fechaNacimiento = item.oPersona.Fecha_Nacimiento;
                int edad = DateTime.Now.Year - fechaNacimiento.Year;
                if (fechaNacimiento > DateTime.Now.AddYears(-edad))
                {
                    edad--;
                }

                dgvData.Rows.Add(new object[] {
                                "", // Columna para el icono de selección
                                item.Id_Cliente,
                                item.oPersona.DNI,
                                item.oPersona.Nombre,
                                edad,
                                item.oPersona.Fecha_Nacimiento,
                                item.oPersona.Mail,
                                item.oPersona.oDomicilio.oLocalidad.oProvincia.provincia + " " + item.oPersona.oDomicilio.oLocalidad.localidad + " " + item.oPersona.oDomicilio.Calle + " " + item.oPersona.oDomicilio.Numero,
                                item.oPersona.Telefono,
                                item.Estado == true ? 1 : 0, // Estado como valor
                                item.Estado == true ? "Activo" : "No Activo", // Estado como texto
                                item.oPersona.oDomicilio.oLocalidad.oProvincia.Id_Provincia,
                                item.oPersona.oDomicilio.oLocalidad.Id_Localidad,
                                item.oPersona.oDomicilio.Calle,
                                item.oPersona.oDomicilio.Numero
                            });
            }
        }

        private void rjButton3_Click(object sender, EventArgs e)
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

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;

            if (iRow >= 0 && iColumn > 0)
            {
                _Cliente = new Cliente()
                {
                    Id_Cliente = Convert.ToInt32(dgvData.Rows[iRow].Cells["IdCliente"].Value.ToString()),
             

                    oPersona = new Persona()
                    {
                        DNI = dgvData.Rows[iRow].Cells["Documento"].Value.ToString(),
                        Nombre = dgvData.Rows[iRow].Cells["NombreCompleto"].Value.ToString(),
                        Mail = dgvData.Rows[iRow].Cells["Mail"].Value.ToString(),
                        Telefono = dgvData.Rows[iRow].Cells["Telefono"].Value.ToString(),

                        oDomicilio = new Domicilio()
                        {
                            Calle = dgvData.Rows[iRow].Cells["Calle"].Value.ToString(),
                            Numero = Convert.ToInt32(dgvData.Rows[iRow].Cells["Numero"].Value.ToString()),
                            oLocalidad = new Localidad()
                            {
                                Id_Localidad = Convert.ToInt32(dgvData.Rows[iRow].Cells["Localidad"].Value),
                                oProvincia = new Provincia()
                                {
                                    Id_Provincia = Convert.ToInt32(dgvData.Rows[iRow].Cells["Provincia"].Value)
                                }
                            }
                        }
                    }
                    

                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
