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

        public Persona _Cliente = new Persona();

        public mdCliente()
        {
            InitializeComponent();

            // Suscribe el evento al formulario o a tu panel superior
            this.MouseDown += Form_MouseDown;
            this.AcceptButton = btnBuscar;
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
            List<Persona> listaClientes = new CN_Cliente().Listar();

            foreach (Persona item in listaClientes)
            {

                //Se calcula el valor de la edad

                DateTime fechaNacimiento = item.Fecha_Nacimiento;
                int edad = DateTime.Now.Year - fechaNacimiento.Year;
                if (fechaNacimiento > DateTime.Now.AddYears(-edad))
                {
                    edad--;
                }
                //Añade cada cliente a una fila del datagridview
                dgvData.Rows.Add(new object[]
                {
            "",                                      // Columna de selección (icono)
            item.Id_Persona,                        // Id
            item.DNI,                      // DNI
            $"{item.Nombre} {item.Apellido}",  // Nombre completo
            edad,                                   // Edad calculada
            item.Fecha_Nacimiento,         // Fecha de nacimiento
            item.Mail,                     // Email
            // Dirección concatenada: Provincia, Localidad, Calle y Número
            $"{item.oDomicilio.oLocalidad.oProvincia.provincia} " +
            $"{item.oDomicilio.oLocalidad.localidad} " +
            $"{item.oDomicilio.Calle} " +
            $"{item.oDomicilio.Numero}",
            item.Telefono,                 // Teléfono
            item.Estado ? 1 : 0,                    // Valor numérico de estado
            item.Estado ? "Activo" : "No Activo",   // Texto de estado
            // Valores ocultos para reprocesar el formulario si editas
            item.oDomicilio.oLocalidad.oProvincia.Id_Provincia,
            item.oDomicilio.oLocalidad.Id_Localidad,
            item.oDomicilio.Calle,
            item.oDomicilio.Numero
                });
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpia el campo de búsqueda y muestra todas las filas del DataGridView.
            txtBusqueda.Texts = "";
            btnBuscar_Click(sender, e);
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Evita el “ding” del sistema
                e.Handled = true;
                e.SuppressKeyPress = true;

                // Llama al método de búsqueda (igual que btnBuscar_Click)
                btnBuscar.PerformClick();
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;

            if (iRow >= 0 && iColumn > 0)
            {
                _Cliente = new Persona()
                {
                    Id_Persona = Convert.ToInt32(dgvData.Rows[iRow].Cells["IdCliente"].Value.ToString()),
             

                   
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
                var fechaNacimiento = item.Fecha_Nacimiento;
                int edad = DateTime.Now.Year - fechaNacimiento.Year;
                if (fechaNacimiento.Date > DateTime.Now.AddYears(-edad))
                    edad--;

                // 5) Agrega la fila al grid
                dgvData.Rows.Add(new object[]
                {
                    "",                                      // Columna de selección (icono)
                    item.Id_Persona,                        // Id
                    item.DNI,                      // DNI
                    $"{item.Nombre} {item.Apellido}",  // Nombre completo
                    edad,                                   // Edad calculada
                    item.Fecha_Nacimiento,         // Fecha de nacimiento
                    item.Mail,                     // Email
                    // Dirección concatenada: Provincia, Localidad, Calle y Número
                    $"{item.oDomicilio.oLocalidad.oProvincia.provincia} " +
                    $"{item.oDomicilio.oLocalidad.localidad} " +
                    $"{item.oDomicilio.Calle} " +
                    $"{item.oDomicilio.Numero}",
                    item.Telefono,                 // Teléfono
                    item.Estado ? 1 : 0,                    // Valor numérico de estado
                    item.Estado ? "Activo" : "No Activo",   // Texto de estado
                    // Valores ocultos para reprocesar el formulario si editas
                    item.oDomicilio.oLocalidad.oProvincia.Id_Provincia,
                    item.oDomicilio.oLocalidad.Id_Localidad,
                    item.oDomicilio.Calle,
                    item.oDomicilio.Numero
                });
            }
        }
    }
}
