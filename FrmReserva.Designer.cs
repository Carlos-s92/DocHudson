namespace TestGit
{
    partial class FrmReserva
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
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txtIdAuto = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAuto = new CustomControls.RJControls.RJButton();
            this.btnCliente = new CustomControls.RJControls.RJButton();
            this.txtConsumo = new CustomControls.RJControls.RJTextBox();
            this.txtModelo = new CustomControls.RJControls.RJTextBox();
            this.txtKilometros = new CustomControls.RJControls.RJTextBox();
            this.txtMatricula = new CustomControls.RJControls.RJTextBox();
            this.txtAño = new CustomControls.RJControls.RJTextBox();
            this.BtnLimpiar2 = new CustomControls.RJControls.RJButton();
            this.BtnGuardar2 = new CustomControls.RJControls.RJButton();
            this.txtDomicilio = new CustomControls.RJControls.RJTextBox();
            this.txtMail = new CustomControls.RJControls.RJTextBox();
            this.txtTelefono = new CustomControls.RJControls.RJTextBox();
            this.txtDocumento = new CustomControls.RJControls.RJTextBox();
            this.txtNombre = new CustomControls.RJControls.RJTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFechaF
            // 
            this.dtpFechaF.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFechaF.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.dtpFechaF.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaF.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaF.Location = new System.Drawing.Point(918, 966);
            this.dtpFechaF.Margin = new System.Windows.Forms.Padding(6);
            this.dtpFechaF.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpFechaF.Name = "dtpFechaF";
            this.dtpFechaF.Size = new System.Drawing.Size(723, 52);
            this.dtpFechaF.TabIndex = 146;
            // 
            // dtpFechaI
            // 
            this.dtpFechaI.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFechaI.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.dtpFechaI.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaI.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaI.Location = new System.Drawing.Point(81, 966);
            this.dtpFechaI.Margin = new System.Windows.Forms.Padding(6);
            this.dtpFechaI.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpFechaI.Name = "dtpFechaI";
            this.dtpFechaI.Size = new System.Drawing.Size(723, 52);
            this.dtpFechaI.TabIndex = 145;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(820, 378);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(6);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(41, 29);
            this.txtIdCliente.TabIndex = 155;
            this.txtIdCliente.Text = "0";
            this.txtIdCliente.Visible = false;
            // 
            // txtIdAuto
            // 
            this.txtIdAuto.Location = new System.Drawing.Point(820, 825);
            this.txtIdAuto.Margin = new System.Windows.Forms.Padding(6);
            this.txtIdAuto.Name = "txtIdAuto";
            this.txtIdAuto.Size = new System.Drawing.Size(41, 29);
            this.txtIdAuto.TabIndex = 156;
            this.txtIdAuto.Text = "0";
            this.txtIdAuto.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TestGit.Properties.Resources.Comp_1_11;
            this.pictureBox2.Location = new System.Drawing.Point(-20, 873);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1822, 7);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 152;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TestGit.Properties.Resources.Comp_1_11;
            this.pictureBox1.Location = new System.Drawing.Point(-20, 426);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1822, 7);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 144;
            this.pictureBox1.TabStop = false;
            // 
            // btnAuto
            // 
            this.btnAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.btnAuto.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.btnAuto.BorderColor = System.Drawing.Color.DimGray;
            this.btnAuto.BorderRadius = 20;
            this.btnAuto.BorderSize = 2;
            this.btnAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAuto.FlatAppearance.BorderSize = 0;
            this.btnAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuto.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnAuto.Location = new System.Drawing.Point(898, 733);
            this.btnAuto.Margin = new System.Windows.Forms.Padding(4);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(818, 76);
            this.btnAuto.TabIndex = 154;
            this.btnAuto.Text = "+";
            this.btnAuto.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnAuto.UseVisualStyleBackColor = false;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.btnCliente.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.btnCliente.BorderColor = System.Drawing.Color.DimGray;
            this.btnCliente.BorderRadius = 20;
            this.btnCliente.BorderSize = 2;
            this.btnCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnCliente.Location = new System.Drawing.Point(876, 262);
            this.btnCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(818, 76);
            this.btnCliente.TabIndex = 153;
            this.btnCliente.Text = "+";
            this.btnCliente.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // txtConsumo
            // 
            this.txtConsumo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtConsumo.BorderColor = System.Drawing.Color.DimGray;
            this.txtConsumo.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtConsumo.BorderRadius = 10;
            this.txtConsumo.BorderSize = 2;
            this.txtConsumo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumo.ForeColor = System.Drawing.Color.White;
            this.txtConsumo.IsReadOnly = true;
            this.txtConsumo.Location = new System.Drawing.Point(82, 726);
            this.txtConsumo.Margin = new System.Windows.Forms.Padding(7);
            this.txtConsumo.Multiline = false;
            this.txtConsumo.Name = "txtConsumo";
            this.txtConsumo.Padding = new System.Windows.Forms.Padding(18, 13, 18, 13);
            this.txtConsumo.PasswordChar = false;
            this.txtConsumo.PlaceholderColor = System.Drawing.Color.White;
            this.txtConsumo.PlaceholderText = "Consumo";
            this.txtConsumo.ShortcutsEnabled = false;
            this.txtConsumo.Size = new System.Drawing.Size(726, 77);
            this.txtConsumo.TabIndex = 151;
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
            this.txtModelo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelo.ForeColor = System.Drawing.Color.White;
            this.txtModelo.IsReadOnly = true;
            this.txtModelo.Location = new System.Drawing.Point(898, 495);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(7);
            this.txtModelo.Multiline = false;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Padding = new System.Windows.Forms.Padding(18, 13, 18, 13);
            this.txtModelo.PasswordChar = false;
            this.txtModelo.PlaceholderColor = System.Drawing.Color.White;
            this.txtModelo.PlaceholderText = "Modelo";
            this.txtModelo.ShortcutsEnabled = false;
            this.txtModelo.Size = new System.Drawing.Size(818, 77);
            this.txtModelo.TabIndex = 149;
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
            this.txtKilometros.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKilometros.ForeColor = System.Drawing.Color.White;
            this.txtKilometros.IsReadOnly = true;
            this.txtKilometros.Location = new System.Drawing.Point(898, 609);
            this.txtKilometros.Margin = new System.Windows.Forms.Padding(7);
            this.txtKilometros.Multiline = false;
            this.txtKilometros.Name = "txtKilometros";
            this.txtKilometros.Padding = new System.Windows.Forms.Padding(18, 13, 18, 13);
            this.txtKilometros.PasswordChar = false;
            this.txtKilometros.PlaceholderColor = System.Drawing.Color.White;
            this.txtKilometros.PlaceholderText = "Kilometros";
            this.txtKilometros.ShortcutsEnabled = false;
            this.txtKilometros.Size = new System.Drawing.Size(818, 77);
            this.txtKilometros.TabIndex = 150;
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
            this.txtMatricula.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.ForeColor = System.Drawing.Color.White;
            this.txtMatricula.IsReadOnly = true;
            this.txtMatricula.Location = new System.Drawing.Point(82, 495);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(7);
            this.txtMatricula.Multiline = false;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Padding = new System.Windows.Forms.Padding(18, 13, 18, 13);
            this.txtMatricula.PasswordChar = false;
            this.txtMatricula.PlaceholderColor = System.Drawing.Color.White;
            this.txtMatricula.PlaceholderText = "Matricula";
            this.txtMatricula.ShortcutsEnabled = false;
            this.txtMatricula.Size = new System.Drawing.Size(726, 77);
            this.txtMatricula.TabIndex = 147;
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
            this.txtAño.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAño.ForeColor = System.Drawing.Color.White;
            this.txtAño.IsReadOnly = true;
            this.txtAño.Location = new System.Drawing.Point(82, 609);
            this.txtAño.Margin = new System.Windows.Forms.Padding(7);
            this.txtAño.Multiline = false;
            this.txtAño.Name = "txtAño";
            this.txtAño.Padding = new System.Windows.Forms.Padding(18, 13, 18, 13);
            this.txtAño.PasswordChar = false;
            this.txtAño.PlaceholderColor = System.Drawing.Color.White;
            this.txtAño.PlaceholderText = "Año";
            this.txtAño.ShortcutsEnabled = true;
            this.txtAño.Size = new System.Drawing.Size(726, 77);
            this.txtAño.TabIndex = 148;
            this.txtAño.Texts = "";
            this.txtAño.UnderlinedStyle = true;
            // 
            // BtnLimpiar2
            // 
            this.BtnLimpiar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.BtnLimpiar2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.BtnLimpiar2.BorderColor = System.Drawing.Color.DimGray;
            this.BtnLimpiar2.BorderRadius = 20;
            this.BtnLimpiar2.BorderSize = 2;
            this.BtnLimpiar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar2.FlatAppearance.BorderSize = 0;
            this.BtnLimpiar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.BtnLimpiar2.Location = new System.Drawing.Point(898, 1183);
            this.BtnLimpiar2.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLimpiar2.Name = "BtnLimpiar2";
            this.BtnLimpiar2.Size = new System.Drawing.Size(796, 76);
            this.BtnLimpiar2.TabIndex = 143;
            this.BtnLimpiar2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.BtnLimpiar2.UseVisualStyleBackColor = false;
            this.BtnLimpiar2.Click += new System.EventHandler(this.BtnLimpiar2_Click);
            // 
            // BtnGuardar2
            // 
            this.BtnGuardar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.BtnGuardar2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.BtnGuardar2.BorderColor = System.Drawing.Color.DimGray;
            this.BtnGuardar2.BorderRadius = 20;
            this.BtnGuardar2.BorderSize = 2;
            this.BtnGuardar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuardar2.FlatAppearance.BorderSize = 0;
            this.BtnGuardar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.BtnGuardar2.Location = new System.Drawing.Point(60, 1182);
            this.BtnGuardar2.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGuardar2.Name = "BtnGuardar2";
            this.BtnGuardar2.Size = new System.Drawing.Size(726, 76);
            this.BtnGuardar2.TabIndex = 142;
            this.BtnGuardar2.Text = "+";
            this.BtnGuardar2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.BtnGuardar2.UseVisualStyleBackColor = false;
            this.BtnGuardar2.Click += new System.EventHandler(this.BtnGuardar2_Click);
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtDomicilio.BorderColor = System.Drawing.Color.DimGray;
            this.txtDomicilio.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtDomicilio.BorderRadius = 10;
            this.txtDomicilio.BorderSize = 2;
            this.txtDomicilio.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomicilio.ForeColor = System.Drawing.Color.White;
            this.txtDomicilio.IsReadOnly = true;
            this.txtDomicilio.Location = new System.Drawing.Point(60, 255);
            this.txtDomicilio.Margin = new System.Windows.Forms.Padding(7);
            this.txtDomicilio.Multiline = false;
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Padding = new System.Windows.Forms.Padding(18, 13, 18, 13);
            this.txtDomicilio.PasswordChar = false;
            this.txtDomicilio.PlaceholderColor = System.Drawing.Color.White;
            this.txtDomicilio.PlaceholderText = "Domicilio";
            this.txtDomicilio.ShortcutsEnabled = false;
            this.txtDomicilio.Size = new System.Drawing.Size(726, 77);
            this.txtDomicilio.TabIndex = 136;
            this.txtDomicilio.Texts = "";
            this.txtDomicilio.UnderlinedStyle = true;
            // 
            // txtMail
            // 
            this.txtMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtMail.BorderColor = System.Drawing.Color.DimGray;
            this.txtMail.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtMail.BorderRadius = 10;
            this.txtMail.BorderSize = 2;
            this.txtMail.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.ForeColor = System.Drawing.Color.White;
            this.txtMail.IsReadOnly = true;
            this.txtMail.Location = new System.Drawing.Point(876, 24);
            this.txtMail.Margin = new System.Windows.Forms.Padding(7);
            this.txtMail.Multiline = false;
            this.txtMail.Name = "txtMail";
            this.txtMail.Padding = new System.Windows.Forms.Padding(18, 13, 18, 13);
            this.txtMail.PasswordChar = false;
            this.txtMail.PlaceholderColor = System.Drawing.Color.White;
            this.txtMail.PlaceholderText = "Mail";
            this.txtMail.ShortcutsEnabled = false;
            this.txtMail.Size = new System.Drawing.Size(818, 77);
            this.txtMail.TabIndex = 134;
            this.txtMail.Texts = "";
            this.txtMail.UnderlinedStyle = true;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtTelefono.BorderColor = System.Drawing.Color.DimGray;
            this.txtTelefono.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtTelefono.BorderRadius = 10;
            this.txtTelefono.BorderSize = 2;
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.ForeColor = System.Drawing.Color.White;
            this.txtTelefono.IsReadOnly = true;
            this.txtTelefono.Location = new System.Drawing.Point(876, 140);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(7);
            this.txtTelefono.Multiline = false;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Padding = new System.Windows.Forms.Padding(18, 13, 18, 13);
            this.txtTelefono.PasswordChar = false;
            this.txtTelefono.PlaceholderColor = System.Drawing.Color.White;
            this.txtTelefono.PlaceholderText = "Telefono";
            this.txtTelefono.ShortcutsEnabled = false;
            this.txtTelefono.Size = new System.Drawing.Size(818, 77);
            this.txtTelefono.TabIndex = 135;
            this.txtTelefono.Texts = "";
            this.txtTelefono.UnderlinedStyle = true;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtDocumento
            // 
            this.txtDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtDocumento.BorderColor = System.Drawing.Color.DimGray;
            this.txtDocumento.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtDocumento.BorderRadius = 10;
            this.txtDocumento.BorderSize = 2;
            this.txtDocumento.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.ForeColor = System.Drawing.Color.White;
            this.txtDocumento.IsReadOnly = true;
            this.txtDocumento.Location = new System.Drawing.Point(60, 24);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(7);
            this.txtDocumento.Multiline = false;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Padding = new System.Windows.Forms.Padding(18, 13, 18, 13);
            this.txtDocumento.PasswordChar = false;
            this.txtDocumento.PlaceholderColor = System.Drawing.Color.White;
            this.txtDocumento.PlaceholderText = "Documento";
            this.txtDocumento.ShortcutsEnabled = false;
            this.txtDocumento.Size = new System.Drawing.Size(726, 77);
            this.txtDocumento.TabIndex = 132;
            this.txtDocumento.Texts = "";
            this.txtDocumento.UnderlinedStyle = true;
            this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtNombre.BorderColor = System.Drawing.Color.DimGray;
            this.txtNombre.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtNombre.BorderRadius = 10;
            this.txtNombre.BorderSize = 2;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.IsReadOnly = true;
            this.txtNombre.Location = new System.Drawing.Point(60, 140);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(7);
            this.txtNombre.Multiline = false;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Padding = new System.Windows.Forms.Padding(18, 13, 18, 13);
            this.txtNombre.PasswordChar = false;
            this.txtNombre.PlaceholderColor = System.Drawing.Color.White;
            this.txtNombre.PlaceholderText = "Nombre Cliente";
            this.txtNombre.ShortcutsEnabled = true;
            this.txtNombre.Size = new System.Drawing.Size(726, 77);
            this.txtNombre.TabIndex = 133;
            this.txtNombre.Texts = "";
            this.txtNombre.UnderlinedStyle = true;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // FrmReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(1800, 1340);
            this.Controls.Add(this.txtIdAuto);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtConsumo);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.txtKilometros);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.txtAño);
            this.Controls.Add(this.dtpFechaF);
            this.Controls.Add(this.dtpFechaI);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnLimpiar2);
            this.Controls.Add(this.BtnGuardar2);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.txtNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmReserva";
            this.Text = "FrmReserva";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.RJControls.RJTextBox txtDomicilio;
        private CustomControls.RJControls.RJTextBox txtMail;
        private CustomControls.RJControls.RJTextBox txtTelefono;
        private CustomControls.RJControls.RJTextBox txtDocumento;
        private CustomControls.RJControls.RJTextBox txtNombre;
        private CustomControls.RJControls.RJButton BtnLimpiar2;
        private CustomControls.RJControls.RJButton BtnGuardar2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dtpFechaF;
        private System.Windows.Forms.DateTimePicker dtpFechaI;
        private CustomControls.RJControls.RJTextBox txtConsumo;
        private CustomControls.RJControls.RJTextBox txtModelo;
        private CustomControls.RJControls.RJTextBox txtKilometros;
        private CustomControls.RJControls.RJTextBox txtMatricula;
        private CustomControls.RJControls.RJTextBox txtAño;
        private System.Windows.Forms.PictureBox pictureBox2;
        private CustomControls.RJControls.RJButton btnCliente;
        private CustomControls.RJControls.RJButton btnAuto;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtIdAuto;
    }
}