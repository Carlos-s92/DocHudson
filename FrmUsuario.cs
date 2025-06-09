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
using System.Windows.Controls;
using System.Windows.Forms;
using TestGit.Modales;

namespace TestGit
{
    public partial class FrmUsuario : Form
    {
        private Usuarios usuarioActual;
        public FrmUsuario()
        {
            InitializeComponent();
         
        }
        public FrmUsuario(Usuarios pUsuarios)
        {
            InitializeComponent();
            this.usuarioActual = pUsuarios;
        }


        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LimpiarCampos()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtDni.Texts = "";
            txtUsuario.Texts = "";
            txtClave.Texts = "";
            comboRol.SelectedIndex = 0;
            comboEstado.SelectedIndex = 0;
        }
        private bool Validaciones()
        {
            bool validaciones = true; // Variable que indica si las validaciones son correctas

            // Verifica que el nombre no esté vacío
            if (txtUsuario.Texts == "")
            {
                validaciones = false; // Marca como inválido si el nombre está vacío
            }
            // Verifica que el documento no esté vacío
            if (txtDni.Texts == "")
            {
                validaciones = false; // Marca como inválido si el documento está vacío
            }
            // Verifica que la contraseña no esté vacía
            if (txtClave.Texts == "")
            {
                validaciones = false; // Marca como inválido si la contraseña está vacía
            }

            return validaciones; // Retorna el resultado de las validaciones
        }

        private void BtnGuardar2_Click(object sender, EventArgs e)
        {
            if (Validaciones()) // Llama a la función de validación
            {
                string mensaje = string.Empty; // Variable para almacenar mensajes de error
                VentanaEmergente confirmacion;

                if (((OpcionesCombo)comboRol.SelectedItem).Texto == "Gerente" && ((OpcionesCombo)comboEstado.SelectedItem).Texto == "No Activo")
                {
                    VentanaEmergente msg = new VentanaEmergente("Error","No se puede desactivar al gerente","Error");
                    msg.ShowDialog();
                    return;
                }



                // Determina si es un nuevo usuario o una edición
                if (Convert.ToInt32(txtid.Text) == 0)
                {
                    confirmacion = new VentanaEmergente("Confirmacion", "¿Seguro desea agregar el usuario?", "Interrogacion");
                    confirmacion.ShowDialog();
                }
                else
                {
                    confirmacion = new VentanaEmergente("Confirmacion", "¿Seguro desea editar el usuario?", "Interrogacion");
                    confirmacion.ShowDialog();
                }

                if (confirmacion.DialogResult == DialogResult.Yes) // Confirma la acción del usuario
                {
                    // Crea un nuevo objeto Usuario con los datos ingresados
                    Usuarios objUsuario = new Usuarios()
                    {
                        Id_Usuario = Convert.ToInt32(txtid.Text), // Asigna el ID del usuario
                        Dni = txtDni.Texts, // Asigna el documento
                        Usuario = txtUsuario.Texts, // Asigna el nombre completo
                        Contraseña = txtClave.Texts, // Asigna la contraseña
                        oPerfil = new Perfiles() { Id_Perfil = Convert.ToInt32(((OpcionesCombo)comboRol.SelectedItem).Valor) }, // Asigna el rol
                        Estado = Convert.ToInt32(((OpcionesCombo)comboEstado.SelectedItem).Valor) == 1 // Asigna el estado
                    };

                    // Verifica si es un nuevo usuario
                    if (objUsuario.Id_Usuario == 0)
                    {
                        // Intenta registrar el nuevo usuario
                        int idUsuarioGenerado = new CN_Usuario().Registrar(objUsuario, out mensaje);
                        if (idUsuarioGenerado != 0) // Verifica si se generó un ID
                        {
                            // Agrega el nuevo usuario al DataGridView
                            dgvData.Rows.Add(new object[] {
                            "",
                            idUsuarioGenerado,
                            txtDni.Texts,
                            txtUsuario.Texts,
                            txtClave.Texts,
                            ((OpcionesCombo)comboRol.SelectedItem).Valor.ToString(),
                            ((OpcionesCombo)comboRol.SelectedItem).Texto.ToString(),
                            ((OpcionesCombo)comboEstado.SelectedItem).Valor.ToString(),
                            ((OpcionesCombo)comboEstado.SelectedItem).Texto.ToString()
                        });
                            LimpiarCampos(); // Limpia los campos del formulario
                        }
                        else
                        {
                            VentanaEmergente error = new VentanaEmergente("Error", mensaje, "Error");
                            error.ShowDialog();
                        }
                    }
                    else // Si es un usuario existente
                    {
                        // Intenta editar el usuario existente
                        int resultado = new CN_Usuario().Editar(objUsuario, out mensaje);
                        if (resultado != 0) // Verifica si la edición fue exitosa
                        {
                            // Actualiza la fila correspondiente en el DataGridView
                            DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtindice.Text)];
                            row.Cells["IdUsuario"].Value = txtid.Text;
                            row.Cells["Dni"].Value = txtDni.Texts;
                            row.Cells["Usuario"].Value = txtUsuario.Texts;
                            row.Cells["Clave"].Value = txtClave.Texts;
                            row.Cells["IdRol"].Value = ((OpcionesCombo)comboRol.SelectedItem).Valor.ToString();
                            row.Cells["Rol"].Value = ((OpcionesCombo)comboRol.SelectedItem).Texto.ToString();
                            row.Cells["EstadoValor"].Value = ((OpcionesCombo)comboEstado.SelectedItem).Valor.ToString();
                            row.Cells["Estado"].Value = ((OpcionesCombo)comboEstado.SelectedItem).Texto.ToString();
                            LimpiarCampos(); // Limpia los campos del formulario
                        }
                        else
                        {
                            VentanaEmergente error = new VentanaEmergente("Error", mensaje, "Error");
                            error.ShowDialog();
                        }
                    }
                }
            }
            else
            {
                VentanaEmergente msg = new VentanaEmergente("Alerta", "Debe completar todos los campos", "Informacion");
                msg.ShowDialog();
            }
        }

        private void BtnEliminar2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0 && Convert.ToInt32(txtid.Text) != usuarioActual.Id_Usuario) // Verifica que haya un usuario seleccionado
            {

                if (((OpcionesCombo)comboRol.SelectedItem).Texto == "Gerente")
                {
                    VentanaEmergente msg = new VentanaEmergente("Error", "No se puede eliminar el gerente", "Error");
                    msg.ShowDialog();
                    return;
                }



                if (MessageBox.Show("¿Desea eliminar el usuario?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty; // Variable para almacenar mensajes de error
                    Usuarios objUsuario = new Usuarios()
                    {
                        Id_Usuario = Convert.ToInt32(txtid.Text), // Asigna el ID del usuario a eliminar
                    };

                    // Intenta eliminar el usuario
                    int respuesta = new CN_Usuario().Eliminar(objUsuario, out mensaje);
                    if (respuesta != 0)
                    {
                        // Actualiza el estado del usuario en el DataGridView
                        dgvData.Rows[Convert.ToInt32(txtindice.Text)].Cells["EstadoValor"].Value = 0;
                        dgvData.Rows[Convert.ToInt32(txtindice.Text)].Cells["Estado"].Value = "No Activo";
                        LimpiarCampos(); // Limpia los campos del formulario
                    }
                    else
                    {
                        VentanaEmergente msg = new VentanaEmergente("Error", mensaje, "Error");
                        msg.ShowDialog();
                    }
                }
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnseleccionar") // Verifica si se hizo clic en la columna "btnseleccionar"
            {
                int indice = e.RowIndex; // Obtiene el índice de la fila

                if (indice >= 0) // Verifica que el índice sea válido
                {
                    // Rellena los campos del formulario con los datos del usuario seleccionado
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvData.Rows[indice].Cells["IdUsuario"].Value.ToString();
                    txtDni.Texts = dgvData.Rows[indice].Cells["Documento"].Value.ToString();
                    txtUsuario.Texts = dgvData.Rows[indice].Cells["Usuario"].Value.ToString();
                    txtClave.Texts = dgvData.Rows[indice].Cells["Clave"].Value.ToString();

                    // Establece el rol seleccionado en el comboRol
                    foreach (OpcionesCombo oc in comboRol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indiceCombo = comboRol.Items.IndexOf(oc); // Obtiene el índice del rol
                            comboRol.SelectedIndex = indiceCombo; // Establece el rol seleccionado
                            break;
                        }
                    }

                    // Establece el estado seleccionado en el comboEstado
                    foreach (OpcionesCombo oc in comboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indiceCombo = comboEstado.Items.IndexOf(oc); // Obtiene el índice del estado
                            comboEstado.SelectedIndex = indiceCombo; // Establece el estado seleccionado
                            break;
                        }
                    }
                }
            }
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            // Inicializa los elementos del comboEstado
            comboEstado.Items.Add(new OpcionesCombo() { Valor = 1, Texto = "Activo" });
            comboEstado.Items.Add(new OpcionesCombo() { Valor = 0, Texto = "No Activo" });

            comboEstado.DisplayMember = "Texto"; // Establece el texto visible
            comboEstado.ValueMember = "Valor"; // Establece el valor asociado
            comboEstado.SelectedIndex = 0; // Selecciona el primer ítem

            // Carga los roles disponibles
            List<Perfiles> listaRol = new CN_Perfiles().Listar();
            foreach (Perfiles item in listaRol)
            {
                comboRol.Items.Add(new OpcionesCombo() { Valor = item.Id_Perfil, Texto = item.Descripcion });
            }
            comboRol.DisplayMember = "Texto"; // Establece el texto visible
            comboRol.ValueMember = "Valor"; // Establece el valor asociado
            comboRol.SelectedIndex = 0; // Selecciona el primer ítem

            // Carga las opciones de búsqueda
            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    comboBusqueda.Items.Add(new OpcionesCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            comboBusqueda.DisplayMember = "Texto"; // Establece el texto visible
            comboBusqueda.ValueMember = "Valor"; // Establece el valor asociado
            comboBusqueda.SelectedIndex = 0; // Selecciona el primer ítem

            // Muestra los usuarios en el DataGridView
            List<Usuarios> listaUsuarios = new CN_Usuario().Listar();
            foreach (Usuarios item in listaUsuarios)
            {
                dgvData.Rows.Add(new object[] {
                "",
                item.Id_Usuario,
                item.Dni,
                item.Usuario,
                item.Contraseña,
                item.oPerfil.Id_Perfil,
                item.oPerfil.Descripcion,
                item.Estado == true ? 1 : 0,
                item.Estado == true ? "Activo": "No Activo"
            });
            }
            comboRol.DisplayMember = "Texto"; // Establece el texto visible
            comboRol.ValueMember = "Valor"; // Establece el valor asociado
            comboRol.SelectedIndex = 0; // Selecciona el primer ítem
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            txtBusqueda.Texts = ""; // Limpia el campo de búsqueda
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true; // Muestra todas las filas
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

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escribe solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
