namespace TestGit
{
    partial class FrmDetalleReserva
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpFechaF = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaI = new System.Windows.Forms.DateTimePicker();
            this.txtTotal = new CustomControls.RJControls.RJTextBox();
            this.txtMarca = new CustomControls.RJControls.RJTextBox();
            this.BGenPDF = new CustomControls.RJControls.RJButton();
            this.btnLiberar = new CustomControls.RJControls.RJButton();
            this.btnLimpiar = new CustomControls.RJControls.RJButton();
            this.btnBuscar = new CustomControls.RJControls.RJButton();
            this.txtBusqueda = new CustomControls.RJControls.RJTextBox();
            this.txtConsumo = new CustomControls.RJControls.RJTextBox();
            this.txtModelo = new CustomControls.RJControls.RJTextBox();
            this.txtKilometros = new CustomControls.RJControls.RJTextBox();
            this.txtMatricula = new CustomControls.RJControls.RJTextBox();
            this.txtAño = new CustomControls.RJControls.RJTextBox();
            this.txtDomicilio = new CustomControls.RJControls.RJTextBox();
            this.txtLicencia = new CustomControls.RJControls.RJTextBox();
            this.txtTelefono = new CustomControls.RJControls.RJTextBox();
            this.txtDocumento = new CustomControls.RJControls.RJTextBox();
            this.txtNombre = new CustomControls.RJControls.RJTextBox();
            this.SuspendLayout();
            // 
            // dtpFechaF
            // 
            this.dtpFechaF.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFechaF.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.dtpFechaF.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaF.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaF.Location = new System.Drawing.Point(483, 532);
            this.dtpFechaF.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpFechaF.Name = "dtpFechaF";
            this.dtpFechaF.Size = new System.Drawing.Size(446, 33);
            this.dtpFechaF.TabIndex = 161;
            // 
            // dtpFechaI
            // 
            this.dtpFechaI.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFechaI.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.dtpFechaI.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaI.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaI.Location = new System.Drawing.Point(38, 532);
            this.dtpFechaI.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpFechaI.Name = "dtpFechaI";
            this.dtpFechaI.Size = new System.Drawing.Size(396, 33);
            this.dtpFechaI.TabIndex = 160;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtTotal.BorderColor = System.Drawing.Color.DimGray;
            this.txtTotal.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtTotal.BorderRadius = 10;
            this.txtTotal.BorderSize = 2;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtTotal.ForeColor = System.Drawing.Color.White;
            this.txtTotal.IsReadOnly = true;
            this.txtTotal.Location = new System.Drawing.Point(166, 578);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.Multiline = false;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtTotal.PasswordChar = false;
            this.txtTotal.PlaceholderColor = System.Drawing.Color.White;
            this.txtTotal.PlaceholderText = "Total";
            this.txtTotal.ShortcutsEnabled = false;
            this.txtTotal.Size = new System.Drawing.Size(96, 36);
            this.txtTotal.TabIndex = 173;
            this.txtTotal.Texts = "";
            this.txtTotal.UnderlinedStyle = true;
            this.txtTotal.Visible = false;
            // 
            // txtMarca
            // 
            this.txtMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtMarca.BorderColor = System.Drawing.Color.DimGray;
            this.txtMarca.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtMarca.BorderRadius = 10;
            this.txtMarca.BorderSize = 2;
            this.txtMarca.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtMarca.ForeColor = System.Drawing.Color.White;
            this.txtMarca.IsReadOnly = false;
            this.txtMarca.Location = new System.Drawing.Point(483, 438);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(4);
            this.txtMarca.Multiline = false;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtMarca.PasswordChar = false;
            this.txtMarca.PlaceholderColor = System.Drawing.Color.White;
            this.txtMarca.PlaceholderText = "Marca";
            this.txtMarca.ShortcutsEnabled = false;
            this.txtMarca.Size = new System.Drawing.Size(446, 36);
            this.txtMarca.TabIndex = 172;
            this.txtMarca.Texts = "";
            this.txtMarca.UnderlinedStyle = true;
            // 
            // BGenPDF
            // 
            this.BGenPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BGenPDF.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BGenPDF.BorderColor = System.Drawing.Color.DimGray;
            this.BGenPDF.BorderRadius = 20;
            this.BGenPDF.BorderSize = 2;
            this.BGenPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGenPDF.FlatAppearance.BorderSize = 0;
            this.BGenPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGenPDF.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGenPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.BGenPDF.Location = new System.Drawing.Point(840, 620);
            this.BGenPDF.Margin = new System.Windows.Forms.Padding(2);
            this.BGenPDF.Name = "BGenPDF";
            this.BGenPDF.Size = new System.Drawing.Size(89, 48);
            this.BGenPDF.TabIndex = 171;
            this.BGenPDF.Text = "PDF";
            this.BGenPDF.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.BGenPDF.UseVisualStyleBackColor = false;
            this.BGenPDF.Click += new System.EventHandler(this.BGenPDF_Click);
            // 
            // btnLiberar
            // 
            this.btnLiberar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnLiberar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnLiberar.BorderColor = System.Drawing.Color.DimGray;
            this.btnLiberar.BorderRadius = 20;
            this.btnLiberar.BorderSize = 2;
            this.btnLiberar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLiberar.FlatAppearance.BorderSize = 0;
            this.btnLiberar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiberar.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiberar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnLiberar.Location = new System.Drawing.Point(543, 620);
            this.btnLiberar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.Size = new System.Drawing.Size(196, 48);
            this.btnLiberar.TabIndex = 170;
            this.btnLiberar.Text = "Liberar reserva";
            this.btnLiberar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnLiberar.UseVisualStyleBackColor = false;
            this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnLimpiar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnLimpiar.BorderColor = System.Drawing.Color.DimGray;
            this.btnLimpiar.BorderRadius = 20;
            this.btnLimpiar.BorderSize = 2;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnLimpiar.Location = new System.Drawing.Point(111, 620);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(196, 48);
            this.btnLimpiar.TabIndex = 169;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnBuscar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnBuscar.BorderColor = System.Drawing.Color.DimGray;
            this.btnBuscar.BorderRadius = 20;
            this.btnBuscar.BorderSize = 2;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnBuscar.Location = new System.Drawing.Point(568, 24);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(196, 48);
            this.btnBuscar.TabIndex = 168;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtBusqueda.BorderColor = System.Drawing.Color.DimGray;
            this.txtBusqueda.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtBusqueda.BorderRadius = 10;
            this.txtBusqueda.BorderSize = 2;
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.ForeColor = System.Drawing.Color.White;
            this.txtBusqueda.IsReadOnly = false;
            this.txtBusqueda.Location = new System.Drawing.Point(38, 27);
            this.txtBusqueda.Margin = new System.Windows.Forms.Padding(4);
            this.txtBusqueda.Multiline = false;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtBusqueda.PasswordChar = false;
            this.txtBusqueda.PlaceholderColor = System.Drawing.Color.White;
            this.txtBusqueda.PlaceholderText = "Busqueda...";
            this.txtBusqueda.ShortcutsEnabled = false;
            this.txtBusqueda.Size = new System.Drawing.Size(453, 45);
            this.txtBusqueda.TabIndex = 167;
            this.txtBusqueda.Texts = "";
            this.txtBusqueda.UnderlinedStyle = true;
            // 
            // txtConsumo
            // 
            this.txtConsumo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtConsumo.BorderColor = System.Drawing.Color.DimGray;
            this.txtConsumo.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtConsumo.BorderRadius = 10;
            this.txtConsumo.BorderSize = 2;
            this.txtConsumo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtConsumo.ForeColor = System.Drawing.Color.White;
            this.txtConsumo.IsReadOnly = false;
            this.txtConsumo.Location = new System.Drawing.Point(38, 438);
            this.txtConsumo.Margin = new System.Windows.Forms.Padding(4);
            this.txtConsumo.Multiline = false;
            this.txtConsumo.Name = "txtConsumo";
            this.txtConsumo.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtConsumo.PasswordChar = false;
            this.txtConsumo.PlaceholderColor = System.Drawing.Color.White;
            this.txtConsumo.PlaceholderText = "Consumo";
            this.txtConsumo.ShortcutsEnabled = false;
            this.txtConsumo.Size = new System.Drawing.Size(396, 36);
            this.txtConsumo.TabIndex = 166;
            this.txtConsumo.Texts = "";
            this.txtConsumo.UnderlinedStyle = true;
            // 
            // txtModelo
            // 
            this.txtModelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtModelo.BorderColor = System.Drawing.Color.DimGray;
            this.txtModelo.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtModelo.BorderRadius = 10;
            this.txtModelo.BorderSize = 2;
            this.txtModelo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtModelo.ForeColor = System.Drawing.Color.White;
            this.txtModelo.IsReadOnly = false;
            this.txtModelo.Location = new System.Drawing.Point(483, 313);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(4);
            this.txtModelo.Multiline = false;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtModelo.PasswordChar = false;
            this.txtModelo.PlaceholderColor = System.Drawing.Color.White;
            this.txtModelo.PlaceholderText = "Modelo";
            this.txtModelo.ShortcutsEnabled = false;
            this.txtModelo.Size = new System.Drawing.Size(446, 36);
            this.txtModelo.TabIndex = 164;
            this.txtModelo.Texts = "";
            this.txtModelo.UnderlinedStyle = true;
            // 
            // txtKilometros
            // 
            this.txtKilometros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtKilometros.BorderColor = System.Drawing.Color.DimGray;
            this.txtKilometros.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtKilometros.BorderRadius = 10;
            this.txtKilometros.BorderSize = 2;
            this.txtKilometros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtKilometros.ForeColor = System.Drawing.Color.White;
            this.txtKilometros.IsReadOnly = false;
            this.txtKilometros.Location = new System.Drawing.Point(483, 375);
            this.txtKilometros.Margin = new System.Windows.Forms.Padding(4);
            this.txtKilometros.Multiline = false;
            this.txtKilometros.Name = "txtKilometros";
            this.txtKilometros.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtKilometros.PasswordChar = false;
            this.txtKilometros.PlaceholderColor = System.Drawing.Color.White;
            this.txtKilometros.PlaceholderText = "Kilometros";
            this.txtKilometros.ShortcutsEnabled = false;
            this.txtKilometros.Size = new System.Drawing.Size(446, 36);
            this.txtKilometros.TabIndex = 165;
            this.txtKilometros.Texts = "";
            this.txtKilometros.UnderlinedStyle = true;
            // 
            // txtMatricula
            // 
            this.txtMatricula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtMatricula.BorderColor = System.Drawing.Color.DimGray;
            this.txtMatricula.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtMatricula.BorderRadius = 10;
            this.txtMatricula.BorderSize = 2;
            this.txtMatricula.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtMatricula.ForeColor = System.Drawing.Color.White;
            this.txtMatricula.IsReadOnly = false;
            this.txtMatricula.Location = new System.Drawing.Point(38, 313);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatricula.Multiline = false;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtMatricula.PasswordChar = false;
            this.txtMatricula.PlaceholderColor = System.Drawing.Color.White;
            this.txtMatricula.PlaceholderText = "Matricula";
            this.txtMatricula.ShortcutsEnabled = false;
            this.txtMatricula.Size = new System.Drawing.Size(396, 36);
            this.txtMatricula.TabIndex = 162;
            this.txtMatricula.Texts = "";
            this.txtMatricula.UnderlinedStyle = true;
            // 
            // txtAño
            // 
            this.txtAño.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtAño.BorderColor = System.Drawing.Color.DimGray;
            this.txtAño.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtAño.BorderRadius = 10;
            this.txtAño.BorderSize = 2;
            this.txtAño.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtAño.ForeColor = System.Drawing.Color.White;
            this.txtAño.IsReadOnly = false;
            this.txtAño.Location = new System.Drawing.Point(38, 375);
            this.txtAño.Margin = new System.Windows.Forms.Padding(4);
            this.txtAño.Multiline = false;
            this.txtAño.Name = "txtAño";
            this.txtAño.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtAño.PasswordChar = false;
            this.txtAño.PlaceholderColor = System.Drawing.Color.White;
            this.txtAño.PlaceholderText = "Año";
            this.txtAño.ShortcutsEnabled = true;
            this.txtAño.Size = new System.Drawing.Size(396, 36);
            this.txtAño.TabIndex = 163;
            this.txtAño.Texts = "";
            this.txtAño.UnderlinedStyle = true;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtDomicilio.BorderColor = System.Drawing.Color.DimGray;
            this.txtDomicilio.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtDomicilio.BorderRadius = 10;
            this.txtDomicilio.BorderSize = 2;
            this.txtDomicilio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtDomicilio.ForeColor = System.Drawing.Color.White;
            this.txtDomicilio.IsReadOnly = false;
            this.txtDomicilio.Location = new System.Drawing.Point(38, 239);
            this.txtDomicilio.Margin = new System.Windows.Forms.Padding(4);
            this.txtDomicilio.Multiline = false;
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDomicilio.PasswordChar = false;
            this.txtDomicilio.PlaceholderColor = System.Drawing.Color.White;
            this.txtDomicilio.PlaceholderText = "Calle, Numero";
            this.txtDomicilio.ShortcutsEnabled = false;
            this.txtDomicilio.Size = new System.Drawing.Size(396, 36);
            this.txtDomicilio.TabIndex = 159;
            this.txtDomicilio.Texts = "";
            this.txtDomicilio.UnderlinedStyle = true;
            // 
            // txtLicencia
            // 
            this.txtLicencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtLicencia.BorderColor = System.Drawing.Color.DimGray;
            this.txtLicencia.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtLicencia.BorderRadius = 10;
            this.txtLicencia.BorderSize = 2;
            this.txtLicencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtLicencia.ForeColor = System.Drawing.Color.White;
            this.txtLicencia.IsReadOnly = false;
            this.txtLicencia.Location = new System.Drawing.Point(483, 114);
            this.txtLicencia.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicencia.Multiline = false;
            this.txtLicencia.Name = "txtLicencia";
            this.txtLicencia.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtLicencia.PasswordChar = false;
            this.txtLicencia.PlaceholderColor = System.Drawing.Color.White;
            this.txtLicencia.PlaceholderText = "Licencia de Conducir";
            this.txtLicencia.ShortcutsEnabled = false;
            this.txtLicencia.Size = new System.Drawing.Size(446, 36);
            this.txtLicencia.TabIndex = 157;
            this.txtLicencia.Texts = "";
            this.txtLicencia.UnderlinedStyle = true;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtTelefono.BorderColor = System.Drawing.Color.DimGray;
            this.txtTelefono.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtTelefono.BorderRadius = 10;
            this.txtTelefono.BorderSize = 2;
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtTelefono.ForeColor = System.Drawing.Color.White;
            this.txtTelefono.IsReadOnly = false;
            this.txtTelefono.Location = new System.Drawing.Point(483, 177);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Multiline = false;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtTelefono.PasswordChar = false;
            this.txtTelefono.PlaceholderColor = System.Drawing.Color.White;
            this.txtTelefono.PlaceholderText = "Telefono";
            this.txtTelefono.ShortcutsEnabled = false;
            this.txtTelefono.Size = new System.Drawing.Size(446, 36);
            this.txtTelefono.TabIndex = 158;
            this.txtTelefono.Texts = "";
            this.txtTelefono.UnderlinedStyle = true;
            // 
            // txtDocumento
            // 
            this.txtDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtDocumento.BorderColor = System.Drawing.Color.DimGray;
            this.txtDocumento.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtDocumento.BorderRadius = 10;
            this.txtDocumento.BorderSize = 2;
            this.txtDocumento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtDocumento.ForeColor = System.Drawing.Color.White;
            this.txtDocumento.IsReadOnly = false;
            this.txtDocumento.Location = new System.Drawing.Point(38, 114);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.txtDocumento.Multiline = false;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDocumento.PasswordChar = false;
            this.txtDocumento.PlaceholderColor = System.Drawing.Color.White;
            this.txtDocumento.PlaceholderText = "Documento";
            this.txtDocumento.ShortcutsEnabled = false;
            this.txtDocumento.Size = new System.Drawing.Size(396, 36);
            this.txtDocumento.TabIndex = 155;
            this.txtDocumento.Texts = "";
            this.txtDocumento.UnderlinedStyle = true;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtNombre.BorderColor = System.Drawing.Color.DimGray;
            this.txtNombre.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtNombre.BorderRadius = 10;
            this.txtNombre.BorderSize = 2;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.IsReadOnly = false;
            this.txtNombre.Location = new System.Drawing.Point(38, 177);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Multiline = false;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtNombre.PasswordChar = false;
            this.txtNombre.PlaceholderColor = System.Drawing.Color.White;
            this.txtNombre.PlaceholderText = "Nombre Cliente";
            this.txtNombre.ShortcutsEnabled = true;
            this.txtNombre.Size = new System.Drawing.Size(396, 36);
            this.txtNombre.TabIndex = 156;
            this.txtNombre.Texts = "";
            this.txtNombre.UnderlinedStyle = true;
            // 
            // FrmDetalleReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(982, 726);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.BGenPDF);
            this.Controls.Add(this.btnLiberar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.txtConsumo);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.txtKilometros);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.txtAño);
            this.Controls.Add(this.dtpFechaF);
            this.Controls.Add(this.dtpFechaI);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.txtLicencia);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.txtNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDetalleReserva";
            this.Text = "FrmDetalleReserva";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.RJControls.RJTextBox txtConsumo;
        private CustomControls.RJControls.RJTextBox txtModelo;
        private CustomControls.RJControls.RJTextBox txtKilometros;
        private CustomControls.RJControls.RJTextBox txtMatricula;
        private CustomControls.RJControls.RJTextBox txtAño;
        private System.Windows.Forms.DateTimePicker dtpFechaF;
        private System.Windows.Forms.DateTimePicker dtpFechaI;
        private CustomControls.RJControls.RJTextBox txtDomicilio;
        private CustomControls.RJControls.RJTextBox txtLicencia;
        private CustomControls.RJControls.RJTextBox txtTelefono;
        private CustomControls.RJControls.RJTextBox txtDocumento;
        private CustomControls.RJControls.RJTextBox txtNombre;
        private CustomControls.RJControls.RJButton btnBuscar;
        private CustomControls.RJControls.RJTextBox txtBusqueda;
        private CustomControls.RJControls.RJButton btnLimpiar;
        private CustomControls.RJControls.RJButton btnLiberar;
        private CustomControls.RJControls.RJButton BGenPDF;
        private CustomControls.RJControls.RJTextBox txtMarca;
        private CustomControls.RJControls.RJTextBox txtTotal;
    }
}