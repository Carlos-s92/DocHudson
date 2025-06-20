using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using CustomControls.RJControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TestGit.Modales;
using TestGit.Properties;

namespace TestGit
{
    public partial class FrmClientes : Form
    {

        private bool cargandoDatos = false; //Variable global para frenar la carga de datos en el combobox

        //Constructor del formulario
        public FrmClientes()
        {
            InitializeComponent();
        }

        //Evento de carga del formulario
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
            // Configura las propiedades de visualización del comboBusqueda.
            comboBusqueda.DisplayMember = "Texto";
            comboBusqueda.ValueMember = "Valor";
            comboBusqueda.SelectedIndex = 0;


            /////////// Muestra las provincias en el comboProvincia//////////////////////////////////////////////////
            List<Provincia> listaProvincias = new CN_Provincia().Listar();
            foreach (Provincia item in listaProvincias)
            {
                comboProvincia.Items.Add(new OpcionesCombo() { Valor = item.Id_Provincia, Texto = item.provincia });
            }
            // Configura las propiedades de visualización del comboProvincia.
            comboProvincia.DisplayMember = "Texto";
            comboProvincia.ValueMember = "Valor";
            comboProvincia.SelectedIndex = 0;


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
                dgvData.Rows.Add(new object[] {
                                "", // Columna para el icono de selección
                                item.Id_Cliente,
                                item.oPersona.DNI,
                                item.Licencia,
                                item.oPersona.Nombre,
                                item.oPersona.Apellido,
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
                                item.oPersona.oDomicilio.Numero,
                                item.oPersona.Id_Persona,
                                item.oPersona.oDomicilio.Id_Domicilio
                            });
            }
        }

        //Metodo para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            this.txtNombre.Texts = "";
            this.txtLicencia.Texts = "";
            this.txtApellido.Texts = "";
            this.txtDocumento.Texts = "";
            this.txtCalle.Texts = "";
            this.txtNumero.Texts = "";
            this.BtnGuardar2.Text = "Registrar Cliente";
            this.comboLocalidad.SelectedIndex = 0;
            this.comboProvincia.SelectedIndex = 0;

            this.txtTelefono.Texts = "";
            this.txtMail.Texts = "";
            this.txtid.Text = "0";
            this.txtPersona.Text = "0";
            this.txtDomicilio.Text = "0";
            txtindice.Text = "-1";
            comboEstado.SelectedIndex = 0;
            comboProvincia.SelectedIndex = 5;
            rjdtpFecha.Value = System.DateTime.Now;
        }

        //Evento para realizar el registro del cliente
        private void BtnGuardar2_Click(object sender, EventArgs e)
        {
            // Valida los campos antes de proceder.
            if (Validaciones())
            {
                VentanaEmergente confirmacion;

                string mensaje = string.Empty;

                // Confirma si se va a agregar o editar un cliente.
                if (Convert.ToInt32(txtid.Text) == 0)
                {
                    confirmacion = new VentanaEmergente("Confirmacion", "¿Seguro desea agregar el Cliente?", "Interrogacion");
                    confirmacion.ShowDialog();
                }
                else
                {
                    confirmacion = new VentanaEmergente("Confirmacion", "¿Seguro desea editar el Cliente?", "Interrogacion");
                    confirmacion.ShowDialog();
                }

                // Si la respuesta es afirmativa, se crea o edita el cliente.
                if (confirmacion.DialogResult == DialogResult.Yes)
                {
                    confirmacion.Close();

                    //Se crean las instancias de Provincia, Localidad, Domicilio, Persona y Cliente
                    Provincia provincia = new Provincia()
                    {
                        Id_Provincia = Convert.ToInt32(((OpcionesCombo)comboProvincia.SelectedItem).Valor),
                        provincia = ((OpcionesCombo)comboProvincia.SelectedItem).Texto
                    };

                    Localidad localidad = new Localidad()
                    {
                        Id_Localidad = Convert.ToInt32(((OpcionesCombo)comboLocalidad.SelectedItem).Valor),
                        oProvincia = provincia,
                        localidad = ((OpcionesCombo)comboLocalidad.SelectedItem).Texto
                    };


                    Domicilio domicilio = new Domicilio()
                    {
                        Id_Domicilio = Convert.ToInt32(txtDomicilio.Text),
                        Calle = txtCalle.Texts,
                        Numero = Convert.ToInt32(txtNumero.Texts),
                        oLocalidad = localidad,
                    };

                    Persona persona = new Persona()
                    {
                        Id_Persona = Convert.ToInt32(txtPersona.Text),
                        DNI = txtDocumento.Texts,
                        Nombre = txtNombre.Texts,
                        Apellido = txtApellido.Texts,
                        oDomicilio = domicilio,
                        Mail = txtMail.Texts,
                        Telefono = txtTelefono.Texts,
                        Fecha_Nacimiento = rjdtpFecha.Value,
                    };


                    Cliente objCliente = new Cliente()
                    {
                        Id_Cliente = Convert.ToInt32(txtid.Text),
                        oPersona = persona,
                        Licencia = txtLicencia.Texts,

                        Estado = Convert.ToInt32(((OpcionesCombo)comboEstado.SelectedItem).Valor) == 1 ? true : false
                    };

                    // Se calcula la edad del cliente
                    DateTime fechaNacimiento = rjdtpFecha.Value;
                    int edad = DateTime.Now.Year - fechaNacimiento.Year;
                    if (fechaNacimiento > DateTime.Now.AddYears(-edad))
                    {
                        edad--;
                    }

                    // Si es un nuevo cliente, se registra en la base de datos.
                    if (objCliente.Id_Cliente == 0)
                    {

                        int idClienteGenerado = new CN_Cliente().Registrar(objCliente, out mensaje); //Se registra el cliente y retorna el id del mismo
                        int idPersona = new CN_Cliente().BusquedaDni(txtDocumento.Texts); // Se busca el id de la persona segun el documento
                        int idDomicilio = new CN_Cliente().BusquedaDomicilio(idPersona); //Se busca el domicilio segun la persona



                        if (idClienteGenerado != 0) //Si el cliente se genero correctamente
                        {
                            // Agrega el nuevo cliente al DataGridView.
                            dgvData.Rows.Add(new object[] {
                                "", // Columna para el icono de selección
                                idClienteGenerado,
                                txtDocumento.Texts,
                                txtLicencia.Texts,
                                txtNombre.Texts,
                                txtApellido.Texts,
                                edad,
                                rjdtpFecha.Value,
                                txtMail.Texts,
                                ((OpcionesCombo)comboProvincia.SelectedItem).Texto.ToString() + " " + ((OpcionesCombo)comboLocalidad.SelectedItem).Texto.ToString() + " " + txtCalle.Texts + " " + txtNumero.Texts,
                                txtTelefono.Texts,
                                ((OpcionesCombo)comboEstado.SelectedItem).Valor.ToString(),
                                ((OpcionesCombo)comboEstado.SelectedItem).Texto.ToString(),
                                ((OpcionesCombo)comboProvincia.SelectedItem).Valor.ToString(), //
                                ((OpcionesCombo)comboLocalidad.SelectedItem).Valor.ToString(), //
                                txtCalle.Texts,
                                txtNumero.Texts,
                                idPersona,
                                idDomicilio
                            });

                            LimpiarCampos(); // Limpia los campos del formulario.

                            // Se muestra la ventana emergente que indica que el cliente se registro con exito
                            VentanaEmergente Succeso = new VentanaEmergente("Exito", "Cliente registrado exitosamente", "Informacion");
                            Succeso.ShowDialog();
                        }
                        else
                        {
                            // Se muestra la ventana emergente de error
                            VentanaEmergente Error = new VentanaEmergente("Error", mensaje, "Error");
                            Error.ShowDialog();
                        }
                    }
                    else
                    {
                        // Si se está editando, actualiza la información del cliente.
                        int resultado = new CN_Cliente().Editar(objCliente, out mensaje);
                        if (resultado != 0)
                        {
                            //Se modifican las columnas de ese cliente
                            DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtindice.Text)];
                            row.Cells["IdCliente"].Value = txtid.Text;
                            row.Cells["Documento"].Value = txtDocumento.Texts;
                            row.Cells["Licencia"].Value = txtLicencia.Texts;
                            row.Cells["Nombre"].Value = txtNombre.Texts;
                            row.Cells["Apellido"].Value = txtApellido.Texts;
                            row.Cells["Edad"].Value = edad;
                            row.Cells["Fecha_Nacimiento"].Value = rjdtpFecha.Value;
                            row.Cells["Mail"].Value = txtMail.Texts;
                            row.Cells["Domicilio"].Value = ((OpcionesCombo)comboProvincia.SelectedItem).Texto.ToString() + " " + ((OpcionesCombo)comboLocalidad.SelectedItem).Texto.ToString() + " " + txtCalle.Texts + " " + txtNumero.Texts;
                            row.Cells["Telefono"].Value = txtTelefono.Texts;
                            row.Cells["EstadoValor"].Value = ((OpcionesCombo)comboEstado.SelectedItem).Valor.ToString();
                            row.Cells["Estado"].Value = ((OpcionesCombo)comboEstado.SelectedItem).Texto.ToString();
                            row.Cells["Provincia"].Value = ((OpcionesCombo)comboProvincia.SelectedItem).Valor.ToString();
                            row.Cells["Localidad"].Value = ((OpcionesCombo)comboLocalidad.SelectedItem).Valor.ToString(); ;
                            row.Cells["Calle"].Value = txtCalle.Texts;
                            row.Cells["Numero"].Value = txtNumero.Texts;
                            row.Cells["Persona"].Value = txtPersona.Text;
                            row.Cells["IdDomicilio"].Value = txtDomicilio.Text;

                            LimpiarCampos(); // Limpia los campos del formulario.

                            // Se muestra la ventana emergente que indica que el cliente se modificó con exito
                            VentanaEmergente Succeso = new VentanaEmergente("Exito", "Cliente modificado exitosamente", "Informacion");
                            Succeso.ShowDialog();
                        }
                        else
                        {
                            //Se muestra la ventana emergente del error
                            VentanaEmergente Error = new VentanaEmergente("Error", mensaje, "Error");
                            Error.ShowDialog();
                        }
                    }
                }
                else
                {
                    //Se cierra la ventana emergente
                    confirmacion.Close();
                }
            }
            else
            {
                // Muestra un mensaje si no se completan todos los campos obligatorios.
                VentanaEmergente Alerta = new VentanaEmergente("Alerta", "Debe Completar todos los campos", "Informacion");
                Alerta.ShowDialog();
            }
        }

        private bool Validaciones()
        {
            bool confirmacion = true;

            // Verifica que el campo de Documento no esté vacío.
            if (txtDocumento.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el campo de calle y numero no esté vacío.
            if (txtCalle.Texts == "" || txtNumero.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el correo no este vacio.
            if (txtMail.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el campo de Nombre no esté vacío.
            if (txtNombre.Texts == "")
            {
                confirmacion = false;
            }

            // Verifica que el apellido no este vacio
            if (txtApellido.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que la licencia no este vacia
            if (txtLicencia.Texts == "")
            {
                confirmacion = false;
            }
            // Verifica que el campo de Teléfono no esté vacío.
            if (txtTelefono.Texts == "")
            {
                confirmacion = false;
            }


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
                VentanaEmergente pregunta = new VentanaEmergente("Mensaje", "¿Desea eliminar al cliente?", "Interrogacion");
                pregunta.ShowDialog();
    
                // Confirma si desea eliminar el cliente
                if (pregunta.DialogResult == DialogResult.Yes)
                {
                    pregunta.Close();
                    string mensaje = string.Empty;
                    Cliente objCliente = new Cliente()
                    {
                        Id_Cliente = Convert.ToInt32(txtid.Text),
                    };

                    // Llama al método de eliminación en la base de datos.
                    int respuesta = new CN_Cliente().Eliminar(objCliente, out mensaje);
                    if (respuesta != 0)
                    {
                        // Cambia el estado del cliente en el DataGridView a "No Activo".
                        dgvData.Rows[Convert.ToInt32(txtindice.Text)].Cells["EstadoValor"].Value = 0;
                        dgvData.Rows[Convert.ToInt32(txtindice.Text)].Cells["Estado"].Value = "No Activo";
                        LimpiarCampos(); // Limpia los campos del formulario.

                        // Se muestra la ventana emergente que indica que el cliente se elimino con exito
                        VentanaEmergente Succeso = new VentanaEmergente("Exito", "Cliente eliminado exitosamente", "Informacion");
                        Succeso.ShowDialog();
                    }
                    else
                    {
                        // Muestra la ventana emergente si sucede un error
                        VentanaEmergente Alerta = new VentanaEmergente("Alerta", mensaje, "Informacion");
                        Alerta.ShowDialog();
                    }
                }
                else
                {
                    // Cierra la ventana emergente si el usuario cancela
                    pregunta.Close();
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
            this.BtnGuardar2.Text = "Editar Cliente";

            // Verifica si se ha hecho clic en la columna de selección.
            if (dgvData.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                // Obtiene el indice del cliente desde el datagridview
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    cargandoDatos = true; //Cambia el estado de la variable para evitar la carga de datos en los combobox


                    // Carga los datos del cliente seleccionado en los campos del formulario.
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvData.Rows[indice].Cells["IdCliente"].Value.ToString();
                    txtDocumento.Texts = dgvData.Rows[indice].Cells["Documento"].Value.ToString();
                    txtLicencia.Texts = dgvData.Rows[indice].Cells["Licencia"].Value.ToString();
                    txtNombre.Texts = dgvData.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtApellido.Texts = dgvData.Rows[indice].Cells["Apellido"].Value.ToString();
                    rjdtpFecha.Value = Convert.ToDateTime(dgvData.Rows[indice].Cells["Fecha_Nacimiento"].Value);
                    txtMail.Texts = dgvData.Rows[indice].Cells["Mail"].Value.ToString();
                   


                    // Provincia
                    int idProvincia = Convert.ToInt32(dgvData.Rows[indice].Cells["Provincia"].Value);
                    int idLocalidad = Convert.ToInt32(dgvData.Rows[indice].Cells["Localidad"].Value);
                    


                    // Seleccionar la provincia (buscando por valor)
                    foreach (OpcionesCombo item in comboProvincia.Items)
                    {
                        if ((int)item.Valor == idProvincia)
                        {
                            comboProvincia.SelectedItem = item;
                            break;
                        }
                    }


                    txtCalle.Texts = dgvData.Rows[indice].Cells["Calle"].Value.ToString();
                    txtNumero.Texts = dgvData.Rows[indice].Cells["Numero"].Value.ToString();
                    txtPersona.Text = dgvData.Rows[indice].Cells["Persona"].Value.ToString();
                    txtDomicilio.Text = dgvData.Rows[indice].Cells["IdDomicilio"].Value.ToString();

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


                    CargarLocalidades(idProvincia, idLocalidad); //Metodo para cargar las localidades segun la provincia
                    cargandoDatos = false;


                }
            }
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Cargar imagen
                Image checkImage = Resources.checkCell;

                // Calcular posición centrada
                int x = e.CellBounds.Left + (e.CellBounds.Width - checkImage.Width) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - checkImage.Height) / 2;

                // Dibujar la imagen
                e.Graphics.DrawImage(checkImage, new Rectangle(x, y, checkImage.Width, checkImage.Height));
                e.Handled = true;
            }
        }

        /////////////////////////////////////////
        // Metodo para cargar las localidades segun la provincia
        private void CargarLocalidades(object provinciaId, int? idLocalidadSeleccionada = null)
        {
            List<Localidad> listaLocalidades = new CN_Localidad().Listar();

            var localidadesFiltradas = listaLocalidades
                .Where(l => l.oProvincia != null && l.oProvincia.Id_Provincia == Convert.ToInt32(provinciaId))
                .Select(l => new OpcionesCombo
                {
                    Valor = l.Id_Localidad,
                    Texto = l.localidad
                })
                .ToList();

            comboLocalidad.DataSource = localidadesFiltradas;
            comboLocalidad.DisplayMember = "Texto";
            comboLocalidad.ValueMember = "Valor";

            // Si viene un id específico para seleccionar, lo asignamos
            if (idLocalidadSeleccionada.HasValue)
            {
                comboLocalidad.SelectedValue = idLocalidadSeleccionada.Value;
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // Limitar longitud a 50 caracteres
            RJTextBox txt = sender as RJTextBox;
            if (txt != null && txt.Texts.Length >= 50 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // Limitar longitud a 50 caracteres
            RJTextBox txt = sender as RJTextBox;
            if (txt != null && txt.Texts.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLicencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // Limitar longitud a 100 caracteres
            RJTextBox txt = sender as RJTextBox;
            if (txt != null && txt.Texts.Length >= 100 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // Limitar longitud a 50 caracteres
            RJTextBox txt = sender as RJTextBox;
            if (txt != null && txt.Texts.Length >= 50 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool esLetra = char.IsLetter(e.KeyChar);
            bool esControl = char.IsControl(e.KeyChar);
            string acentos = "áéíóúÁÉÍÓÚñÑ";
            bool esEspacio = e.KeyChar == ' ';

            if (!esLetra && !acentos.Contains(e.KeyChar) && !esControl && !esEspacio)
            {
                e.Handled = true;
            }
            // Limitar longitud a 150 caracteres
            RJTextBox txt = sender as RJTextBox;
            if (txt != null && txt.Texts.Length >= 150 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool esLetra = char.IsLetter(e.KeyChar);
            bool esControl = char.IsControl(e.KeyChar);
            string acentos = "áéíóúÁÉÍÓÚñÑ";
            bool esEspacio = e.KeyChar == ' ';

            if (!esLetra && !acentos.Contains(e.KeyChar) && !esControl && !esEspacio)
            {
                e.Handled = true;
            }
            // Limitar longitud a 150 caracteres
            RJTextBox txt = sender as RJTextBox;
            if (txt != null && txt.Texts.Length >= 150 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool esLetra = char.IsLetter(e.KeyChar);
            bool esControl = char.IsControl(e.KeyChar);
            string acentos = "áéíóúÁÉÍÓÚñÑ";
            bool esEspacio = e.KeyChar == ' ';

            if (!esLetra && !acentos.Contains(e.KeyChar) && !esControl && !esEspacio)
            {
                e.Handled = true;
            }
            // (Acá también podrías limitar la longitud si tuvieras un tamaño en la base para "calle")
            // Limitar longitud a 150 caracteres
            RJTextBox txt = sender as RJTextBox;
            if (txt != null && txt.Texts.Length >= 100 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void txtMail_Leave(object sender, EventArgs e)
        {
            RJTextBox txt = sender as RJTextBox;
  
            if(txt.Texts != "")
            {
                // Limitar longitud a 150
                if (txt.Texts.Length > 150)
                {
                    MessageBox.Show("El correo no puede superar los 150 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt.Texts = txt.Texts.Substring(0, 150);
                }

                // Validar formato de correo
                if (!System.Text.RegularExpressions.Regex.IsMatch(txt.Texts, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Ingrese un correo electrónico válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt.Focus();
                }
            }


        }


        private void comboProvincia_SelectedIndexChanged(object sender, EventArgs e)//Muestra las localidades de la provincia seleccionada
        {

            if (cargandoDatos) return;

            if (comboProvincia.SelectedItem is OpcionesCombo opcionSeleccionada)
            {
                CargarLocalidades(opcionSeleccionada.Valor);
            }
        }

        private void txtDomicilio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}