using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestGit.Modales
{
    public partial class mdCliente : Form
    {
        // Constantes WinAPI
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Cliente _Cliente = new Cliente();

        public mdCliente()
        {
            InitializeComponent();

            // Suscribe el evento al formulario o a tu panel superior
            this.MouseDown += Form_MouseDown;
        }
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void mdCliente_Load(object sender, EventArgs e)
        {
            // Muestra los clientes en el DataGridView.
            List<Cliente> listaClientes = new CN_Cliente().Listar();

            foreach (Cliente item in listaClientes)
            {

                //Se calcula el valor de la edad

                DateTime fechaNacimiento = item.oPersona.Fecha_Nacimiento;
                int edad = DateTime.Now.Year - fechaNacimiento.Year;
                if (fechaNacimiento > DateTime.Now.AddYears(-edad))
                {
                    edad--;
                }
                //Añade cada cliente a una fila del datagridview
                dgvData.Rows.Add(new object[]
                {
            "",                                      // Columna de selección (icono)
            item.Id_Cliente,                        // Id
            item.oPersona.DNI,                      // DNI
            $"{item.oPersona.Nombre} {item.oPersona.Apellido}",  // Nombre completo
            edad,                                   // Edad calculada
            item.oPersona.Fecha_Nacimiento,         // Fecha de nacimiento
            item.oPersona.Mail,                     // Email
            // Dirección concatenada: Provincia, Localidad, Calle y Número
            $"{item.oPersona.oDomicilio.oLocalidad.oProvincia.provincia} " +
            $"{item.oPersona.oDomicilio.oLocalidad.localidad} " +
            $"{item.oPersona.oDomicilio.Calle} " +
            $"{item.oPersona.oDomicilio.Numero}",
            item.oPersona.Telefono,                 // Teléfono
            item.Estado ? 1 : 0,                    // Valor numérico de estado
            item.Estado ? "Activo" : "No Activo",   // Texto de estado
            // Valores ocultos para reprocesar el formulario si editas
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

        //private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyData == Keys.Enter) // Si el usuario presiona la tecla Enter.
        //    {
        //        // Obtiene el nombre de la columna seleccionada para la búsqueda.
        //        string columnaFiltro = ((OpcionesCombo)comboBusqueda.SelectedItem).Valor.ToString();

        //        // Verifica si hay filas en el DataGridView.
        //        if (dgvData.Rows.Count > 0)
        //        {
        //            // Filtra las filas del DataGridView según el texto de búsqueda.
        //            foreach (DataGridViewRow row in dgvData.Rows)
        //            {
        //                if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Texts.Trim().ToUpper()))
        //                {
        //                    row.Visible = true; // Muestra la fila si coincide.
        //                }
        //                else
        //                {
        //                    row.Visible = false; // Oculta la fila si no coincide.
        //                }
        //            }
        //        }
        //    }
        //}

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // 1) Obtiene el texto de búsqueda
            string criterio = txtBusqueda.Texts.Trim();

            // 2) Llama a la capa de negocio que a su vez invoca al SP BuscarClientes
            var resultados = new CN_Cliente().BuscarCliente(criterio);

            // 3) Limpia el grid
            dgvData.Rows.Clear();

            // 4) Itera sobre cada Cliente devuelto
            foreach (var item in resultados)
            {
                // Calcula la edad a partir de la fecha de nacimiento
                var fechaNacimiento = item.oPersona.Fecha_Nacimiento;
                int edad = DateTime.Now.Year - fechaNacimiento.Year;
                if (fechaNacimiento.Date > DateTime.Now.AddYears(-edad))
                    edad--;

                // 5) Agrega la fila al grid
                dgvData.Rows.Add(new object[]
                {
            "",                                      // Columna de selección (icono)
            item.Id_Cliente,                        // Id
            item.oPersona.DNI,                      // DNI
            $"{item.oPersona.Nombre} {item.oPersona.Apellido}",  // Nombre completo
            edad,                                   // Edad calculada
            item.oPersona.Fecha_Nacimiento,         // Fecha de nacimiento
            item.oPersona.Mail,                     // Email
            // Dirección concatenada: Provincia, Localidad, Calle y Número
            $"{item.oPersona.oDomicilio.oLocalidad.oProvincia.provincia} " +
            $"{item.oPersona.oDomicilio.oLocalidad.localidad} " +
            $"{item.oPersona.oDomicilio.Calle} " +
            $"{item.oPersona.oDomicilio.Numero}",
            item.oPersona.Telefono,                 // Teléfono
            item.Estado ? 1 : 0,                    // Valor numérico de estado
            item.Estado ? "Activo" : "No Activo",   // Texto de estado
            // Valores ocultos para reprocesar el formulario si editas
            item.oPersona.oDomicilio.oLocalidad.oProvincia.Id_Provincia,
            item.oPersona.oDomicilio.oLocalidad.Id_Localidad,
            item.oPersona.oDomicilio.Calle,
            item.oPersona.oDomicilio.Numero
                });
            }
        }
    }
}
