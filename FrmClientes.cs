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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGit
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }
        private void FrmClientes_Load(object sender, EventArgs e)
        {
            // Inicializa el comboEstado con opciones para el estado del cliente (Activo, No Activo).
            comboEstado.Items.Add(new OpcionesCombo() { Valor = 1, Texto = "Activo" });
            comboEstado.Items.Add(new OpcionesCombo() { Valor = 0, Texto = "No Activo" });

            // Configura las propiedades de visualización del comboEstado.
            comboEstado.DisplayMember = "Texto";
            comboEstado.ValueMember = "Valor";
            comboEstado.SelectedIndex = 0;

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

            /////////// Muestra las provincias en el comboProvincia//////////////////////////////////////////////////
            List<Provincia> listaProvincias = new CN_Provincia().Listar();
            foreach (Provincia item in listaProvincias)
            {
                comboProvincia.Items.Add(new OpcionesCombo() { Valor = item.Id_Provincia, Texto = item.provincia });
            }
            comboProvincia.DisplayMember = "Texto";
            comboProvincia.ValueMember = "Valor";
            comboProvincia.SelectedIndex = 5;

            // Muestra los clientes en el DataGridView.
            List<Cliente> listaClientes = new CN_Cliente().Listar();

            foreach (Cliente item in listaClientes)
            {
                DateTime fechaNacimiento = item.Fecha_Nacimiento;
                int edad = DateTime.Now.Year - fechaNacimiento.Year;
                if (fechaNacimiento > DateTime.Now.AddYears(-edad))
                {
                    edad--;
                }

                dgvData.Rows.Add(new object[] {
                                "", // Columna para el icono de selección
                                item.Id_Cliente,
                                item.Dni,
                                item.Nombre,
                                edad,
                                item.Fecha_Nacimiento,
                                item.Mail,
                                item.domicilio.oLocalidad.oProvincia.provincia + " " + item.domicilio.oLocalidad.localidad + " " + item.domicilio.Calle + " " + item.domicilio.Numero,
                                item.Telefono,
                                item.Estado == true ? 1 : 0, // Estado como valor
                                item.Estado == true ? "Activo" : "No Activo", // Estado como texto
                                item.domicilio.oLocalidad.oProvincia.Id_Provincia,
                                item.domicilio.oLocalidad.Id_Localidad,
                                item.domicilio.Calle,
                                item.domicilio.Numero
                            });
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjButton5_Click(object sender, EventArgs e)
        {

        }

        private void rjButton4_Click(object sender, EventArgs e)
        {

        }

        private void LimpiarCampos()
        {
            this.txtNombre.Texts = "";
            this.txtDocumento.Texts = "";
            this.txtCalle.Texts = "";
            this.txtNumero.Texts = "";
            this.txtLocalidad.Texts = "";
            this.txtProvincia.Texts = "";
            this.txtTelefono.Texts = "";
            this.txtMail.Texts = "";
            this.txtid.Text = "0";
            txtindice.Text = "-1";
            comboEstado.SelectedIndex = 0;
            comboProvincia.SelectedIndex = 5;
            dtpFecha.Value = System.DateTime.Now;
        }

        private void BtnGuardar2_Click(object sender, EventArgs e)
        {
            // Valida los campos antes de proceder.
            if (Validaciones())
            {
                DialogResult confirmacion;

                string mensaje = string.Empty;

                // Confirma si se va a agregar o editar un cliente.
                if (Convert.ToInt32(txtid.Text) == 0)
                {
                    confirmacion = MessageBox.Show("¿Seguro desea agregar el Cliente?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    confirmacion = MessageBox.Show("¿Seguro desea editar el Cliente?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                // Si la respuesta es afirmativa, se crea o edita el cliente.
                if (confirmacion == DialogResult.Yes)
                {
                    Cliente objCliente = new Cliente()
                    {
                        Id_Cliente = Convert.ToInt32(txtid.Text),
                        Dni = txtDocumento.Texts,
                        Nombre = txtNombre.Texts,

                        domicilio = new Domicilio()
                        {
                            Calle = txtCalle.Texts,
                            Numero = Convert.ToInt32(txtNumero.Texts),
                            oLocalidad = new Localidad()
                            {
                                localidad = txtLocalidad.Texts,
                                oProvincia = new Provincia()
                                {
                                    Id_Provincia = Convert.ToInt32(((OpcionesCombo)comboProvincia.SelectedItem).Valor),
                                }
                                
                            }
                        },
                        // ^
                        // |
                        //Creo que para solucionarlo hay que aplicar el caos de arriba

                        //Provincia = comboProvincia.Text,
                        //Localidad = txtLocalidad.Texts,
                        //Calle = txtCalle.Texts,
                        //Numero = Convert.ToInt32(txtNumero.Texts),
                        Mail = txtMail.Texts,
                        Telefono = txtTelefono.Texts,
                        Fecha_Nacimiento = dtpFecha.Value,
                        Estado = Convert.ToInt32(((OpcionesCombo)comboEstado.SelectedItem).Valor) == 1 ? true : false
                    };
                    DateTime fechaNacimiento = dtpFecha.Value;
                    int edad = DateTime.Now.Year - fechaNacimiento.Year;
                    if (fechaNacimiento > DateTime.Now.AddYears(-edad))
                    {
                        edad--;
                    }

                    // Si es un nuevo cliente, se registra en la base de datos.
                    if (objCliente.Id_Cliente == 0)
                    {
                        int idClienteGenerado = new CN_Cliente().Registrar(objCliente, out mensaje);
                        if (idClienteGenerado != 0)
                        {
                            

                            // Agrega el nuevo cliente al DataGridView.
                            dgvData.Rows.Add(new object[] {
                                "", // Columna para el icono de selección
                                idClienteGenerado,
                                txtDocumento.Texts,
                                txtNombre.Texts,
                                edad,
                                dtpFecha.Value,
                                txtMail.Texts,
                                comboProvincia.Text + " " + txtLocalidad.Texts + " " + txtCalle.Texts + " " + txtNumero.Texts,
                                txtTelefono.Texts,
                                ((OpcionesCombo)comboEstado.SelectedItem).Valor.ToString(),
                                ((OpcionesCombo)comboEstado.SelectedItem).Texto.ToString(),
                                comboProvincia.Text, 
                                txtLocalidad.Texts,
                                txtCalle.Texts,
                                txtNumero.Texts
                            });
                            LimpiarCampos(); // Limpia los campos del formulario.
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Si se está editando, actualiza la información del cliente.
                        bool resultado = new CN_Cliente().Editar(objCliente, out mensaje);
                        if (resultado == true)
                        {
                            DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtindice.Text)];
                            row.Cells["IdCliente"].Value = txtid.Text;
                            row.Cells["Documento"].Value = txtDocumento.Texts;
                            row.Cells["NombreCompleto"].Value = txtNombre.Texts;
                            row.Cells["Edad"].Value = edad;
                            row.Cells["Fecha_Nacimiento"].Value = dtpFecha.Value;
                            row.Cells["Mail"].Value = txtMail.Texts;
                            row.Cells["Domicilio"].Value = comboProvincia.Text + " " + txtLocalidad.Texts + " " + txtCalle.Texts + " " + txtNumero.Texts;
                            row.Cells["Telefono"].Value = txtTelefono.Texts;
                            row.Cells["EstadoValor"].Value = ((OpcionesCombo)comboEstado.SelectedItem).Valor.ToString();
                            row.Cells["Estado"].Value = ((OpcionesCombo)comboEstado.SelectedItem).Texto.ToString();
                            row.Cells["Provincia"].Value = ((OpcionesCombo)comboProvincia.SelectedItem).Valor.ToString();
                            row.Cells["Localidad"].Value = txtLocalidad.Texts;
                            row.Cells["Calle"].Value = txtCalle.Texts;
                            row.Cells["Numero"].Value = txtNumero.Texts;
                            LimpiarCampos(); // Limpia los campos del formulario.
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                // Muestra un mensaje si no se completan todos los campos obligatorios.
                MessageBox.Show("Debe Completar todos los campos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool Validaciones()
        {
            bool confirmacion = true;
            /*DateTime fechaNacimiento = dtpFecha.Value;
            int edad = DateTime.Now.Year - fechaNacimiento.Year;

            if (fechaNacimiento > DateTime.Now.AddYears(-edad))
            {
                edad--;
            }*/

            // Verifica que el campo de Documento no esté vacío.
            if (txtDocumento.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el campo de Dirección no esté vacío.
            if (txtCalle.Texts == "" || comboProvincia.Text == "" || txtLocalidad.Texts == "" || txtNumero.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el correo tenga formato válido.
            if (txtMail.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el campo de Nombre no esté vacío.
            if (txtNombre.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el campo de Teléfono no esté vacío.
            if (txtTelefono.Texts == "")
            {
                confirmacion = false;
            }
            /*if ( edad < 18)
            {
                confirmacion = false;
            }*/

            // Retorna el resultado de las validaciones.
            return confirmacion;
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

        private void BtnLimpiar2_Click(object sender, EventArgs e)
        {
            // Verifica si se ha seleccionado un cliente para eliminar.
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                // Pregunta al usuario si desea eliminar el cliente.
                if (MessageBox.Show("¿Desea eliminar el Cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Cliente objCliente = new Cliente()
                    {
                        Id_Cliente = Convert.ToInt32(txtid.Text),
                    };

                    // Llama al método de eliminación en la base de datos.
                    bool respuesta = new CN_Cliente().Eliminar(objCliente, out mensaje);
                    if (respuesta)
                    {
                        // Cambia el estado del cliente en el DataGridView a "No Activo".
                        dgvData.Rows[Convert.ToInt32(txtindice.Text)].Cells["EstadoValor"].Value = 0;
                        dgvData.Rows[Convert.ToInt32(txtindice.Text)].Cells["Estado"].Value = "No Activo";
                        LimpiarCampos(); // Limpia los campos del formulario.
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
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
            // Verifica si se ha hecho clic en la columna de selección.
            if (dgvData.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    // Carga los datos del cliente seleccionado en los campos del formulario.
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvData.Rows[indice].Cells["IdCliente"].Value.ToString();
                    txtDocumento.Texts = dgvData.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombre.Texts = dgvData.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    dtpFecha.Value = Convert.ToDateTime(dgvData.Rows[indice].Cells["Fecha_Nacimiento"].Value);
                    txtMail.Texts = dgvData.Rows[indice].Cells["Mail"].Value.ToString();

                    comboProvincia.Text = dgvData.Rows[indice].Cells["Provincia"].Value.ToString();
                    txtLocalidad.Texts = dgvData.Rows[indice].Cells["Localidad"].Value.ToString();
                    txtCalle.Texts = dgvData.Rows[indice].Cells["Calle"].Value.ToString();
                    txtNumero.Texts = dgvData.Rows[indice].Cells["Numero"].Value.ToString();

                    txtTelefono.Texts = dgvData.Rows[indice].Cells["Telefono"].Value.ToString();
                    // Selecciona el estado correspondiente en el comboEstado.
                    foreach (OpcionesCombo oc in comboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indiceCombo = comboEstado.Items.IndexOf(oc);
                            comboEstado.SelectedIndex = indiceCombo; // Selecciona el estado en el combo.
                            break;
                        }
                    }
                    // Selecciona el estado correspondiente en el comboEstado.
                    foreach (OpcionesCombo oc in comboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indiceCombo = comboEstado.Items.IndexOf(oc);
                            comboEstado.SelectedIndex = indiceCombo; // Selecciona el estado en el combo.
                            break;
                        }
                    }
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escribe solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escribe solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escribe solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Letras
            bool esLetra = char.IsLetter(e.KeyChar);

            // Caracteres de control como borrar
            bool esControl = char.IsControl(e.KeyChar);

            // Acentos y Ñ
            string acentos = "áéíóúÁÉÍÓÚñÑ";

            // Tecla espacio
            bool esEspacio = e.KeyChar == ' ';

            if (!esLetra && !acentos.Contains(e.KeyChar) && !esControl && !esEspacio)
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Letras
            bool esLetra = char.IsLetter(e.KeyChar);

            // Caracteres de control como borrar
            bool esControl = char.IsControl(e.KeyChar);

            // Acentos y Ñ
            string acentos = "áéíóúÁÉÍÓÚñÑ";

            // Tecla espacio
            bool esEspacio = e.KeyChar == ' ';

            if (!esLetra && !acentos.Contains(e.KeyChar) && !esControl && !esEspacio)
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        


    }
}
