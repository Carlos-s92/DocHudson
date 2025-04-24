namespace TestGit
{
    partial class FrmAutos
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
            this.comboEstado = new System.Windows.Forms.ComboBox();
            this.BtnGuardar2 = new CustomControls.RJControls.RJButton();
            this.txtConsumo = new CustomControls.RJControls.RJTextBox();
            this.txtModelo = new CustomControls.RJControls.RJTextBox();
            this.txtKilometros = new CustomControls.RJControls.RJTextBox();
            this.txtMatricula = new CustomControls.RJControls.RJTextBox();
            this.txtAño = new CustomControls.RJControls.RJTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rjButton1 = new CustomControls.RJControls.RJButton();
            this.txtMarca = new CustomControls.RJControls.RJTextBox();
            this.txtPuertas = new CustomControls.RJControls.RJTextBox();
            this.txtAsientos = new CustomControls.RJControls.RJTextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtImagen = new CustomControls.RJControls.RJTextBox();
            this.comboMarca = new System.Windows.Forms.ComboBox();
            this.comboModelo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboEstado
            // 
            this.comboEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.comboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboEstado.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEstado.ForeColor = System.Drawing.Color.White;
            this.comboEstado.FormattingEnabled = true;
            this.comboEstado.Location = new System.Drawing.Point(732, 243);
            this.comboEstado.Margin = new System.Windows.Forms.Padding(5);
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(667, 53);
            this.comboEstado.TabIndex = 145;
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
            this.BtnGuardar2.Location = new System.Drawing.Point(443, 960);
            this.BtnGuardar2.Name = "BtnGuardar2";
            this.BtnGuardar2.Size = new System.Drawing.Size(594, 63);
            this.BtnGuardar2.TabIndex = 140;
            this.BtnGuardar2.Text = "+";
            this.BtnGuardar2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.BtnGuardar2.UseVisualStyleBackColor = false;
            this.BtnGuardar2.Click += new System.EventHandler(this.BtnGuardar2_Click);
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
            this.txtConsumo.IsReadOnly = false;
            this.txtConsumo.Location = new System.Drawing.Point(65, 232);
            this.txtConsumo.Margin = new System.Windows.Forms.Padding(6);
            this.txtConsumo.Multiline = false;
            this.txtConsumo.Name = "txtConsumo";
            this.txtConsumo.Padding = new System.Windows.Forms.Padding(15, 11, 15, 11);
            this.txtConsumo.PasswordChar = false;
            this.txtConsumo.PlaceholderColor = System.Drawing.Color.White;
            this.txtConsumo.PlaceholderText = "Consumo";
            this.txtConsumo.ShortcutsEnabled = false;
            this.txtConsumo.Size = new System.Drawing.Size(594, 68);
            this.txtConsumo.TabIndex = 137;
            this.txtConsumo.Texts = "";
            this.txtConsumo.UnderlinedStyle = true;
            this.txtConsumo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsumo_KeyPress);
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
            this.txtModelo.IsReadOnly = false;
            this.txtModelo.Location = new System.Drawing.Point(750, 722);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(6);
            this.txtModelo.Multiline = false;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Padding = new System.Windows.Forms.Padding(15, 11, 15, 11);
            this.txtModelo.PasswordChar = false;
            this.txtModelo.PlaceholderColor = System.Drawing.Color.White;
            this.txtModelo.PlaceholderText = "Modelo";
            this.txtModelo.ShortcutsEnabled = false;
            this.txtModelo.Size = new System.Drawing.Size(669, 68);
            this.txtModelo.TabIndex = 134;
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
            this.txtKilometros.IsReadOnly = false;
            this.txtKilometros.Location = new System.Drawing.Point(732, 135);
            this.txtKilometros.Margin = new System.Windows.Forms.Padding(6);
            this.txtKilometros.Multiline = false;
            this.txtKilometros.Name = "txtKilometros";
            this.txtKilometros.Padding = new System.Windows.Forms.Padding(15, 11, 15, 11);
            this.txtKilometros.PasswordChar = false;
            this.txtKilometros.PlaceholderColor = System.Drawing.Color.White;
            this.txtKilometros.PlaceholderText = "Kilometros";
            this.txtKilometros.ShortcutsEnabled = false;
            this.txtKilometros.Size = new System.Drawing.Size(669, 68);
            this.txtKilometros.TabIndex = 135;
            this.txtKilometros.Texts = "";
            this.txtKilometros.UnderlinedStyle = true;
            this.txtKilometros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKilometros_KeyPress);
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
            this.txtMatricula.IsReadOnly = false;
            this.txtMatricula.Location = new System.Drawing.Point(65, 40);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(6);
            this.txtMatricula.Multiline = false;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Padding = new System.Windows.Forms.Padding(15, 11, 15, 11);
            this.txtMatricula.PasswordChar = false;
            this.txtMatricula.PlaceholderColor = System.Drawing.Color.White;
            this.txtMatricula.PlaceholderText = "Matricula";
            this.txtMatricula.ShortcutsEnabled = false;
            this.txtMatricula.Size = new System.Drawing.Size(594, 68);
            this.txtMatricula.TabIndex = 132;
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
            this.txtAño.IsReadOnly = false;
            this.txtAño.Location = new System.Drawing.Point(65, 135);
            this.txtAño.Margin = new System.Windows.Forms.Padding(6);
            this.txtAño.Multiline = false;
            this.txtAño.Name = "txtAño";
            this.txtAño.Padding = new System.Windows.Forms.Padding(15, 11, 15, 11);
            this.txtAño.PasswordChar = false;
            this.txtAño.PlaceholderColor = System.Drawing.Color.White;
            this.txtAño.PlaceholderText = "Año";
            this.txtAño.ShortcutsEnabled = true;
            this.txtAño.Size = new System.Drawing.Size(594, 68);
            this.txtAño.TabIndex = 133;
            this.txtAño.Texts = "";
            this.txtAño.UnderlinedStyle = true;
            this.txtAño.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAño_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.pictureBox1.Location = new System.Drawing.Point(108, 475);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(495, 375);
            this.pictureBox1.TabIndex = 146;
            this.pictureBox1.TabStop = false;
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.rjButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.rjButton1.BorderColor = System.Drawing.Color.DimGray;
            this.rjButton1.BorderRadius = 20;
            this.rjButton1.BorderSize = 2;
            this.rjButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.rjButton1.Location = new System.Drawing.Point(761, 622);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(594, 63);
            this.rjButton1.TabIndex = 147;
            this.rjButton1.Text = "Agregar Imagen";
            this.rjButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.BFotoProducto_Click);
            // 
            // txtMarca
            // 
            this.txtMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtMarca.BorderColor = System.Drawing.Color.DimGray;
            this.txtMarca.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtMarca.BorderRadius = 10;
            this.txtMarca.BorderSize = 2;
            this.txtMarca.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarca.ForeColor = System.Drawing.Color.White;
            this.txtMarca.IsReadOnly = false;
            this.txtMarca.Location = new System.Drawing.Point(774, 802);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(6);
            this.txtMarca.Multiline = false;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Padding = new System.Windows.Forms.Padding(15, 11, 15, 11);
            this.txtMarca.PasswordChar = false;
            this.txtMarca.PlaceholderColor = System.Drawing.Color.White;
            this.txtMarca.PlaceholderText = "Marca";
            this.txtMarca.ShortcutsEnabled = false;
            this.txtMarca.Size = new System.Drawing.Size(594, 68);
            this.txtMarca.TabIndex = 148;
            this.txtMarca.Texts = "";
            this.txtMarca.UnderlinedStyle = true;
            // 
            // txtPuertas
            // 
            this.txtPuertas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtPuertas.BorderColor = System.Drawing.Color.DimGray;
            this.txtPuertas.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtPuertas.BorderRadius = 10;
            this.txtPuertas.BorderSize = 2;
            this.txtPuertas.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPuertas.ForeColor = System.Drawing.Color.White;
            this.txtPuertas.IsReadOnly = false;
            this.txtPuertas.Location = new System.Drawing.Point(732, 334);
            this.txtPuertas.Margin = new System.Windows.Forms.Padding(6);
            this.txtPuertas.Multiline = false;
            this.txtPuertas.Name = "txtPuertas";
            this.txtPuertas.Padding = new System.Windows.Forms.Padding(15, 11, 15, 11);
            this.txtPuertas.PasswordChar = false;
            this.txtPuertas.PlaceholderColor = System.Drawing.Color.White;
            this.txtPuertas.PlaceholderText = "Puertas";
            this.txtPuertas.ShortcutsEnabled = false;
            this.txtPuertas.Size = new System.Drawing.Size(304, 68);
            this.txtPuertas.TabIndex = 149;
            this.txtPuertas.Texts = "";
            this.txtPuertas.UnderlinedStyle = true;
            this.txtPuertas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPuertas_KeyPress);
            // 
            // txtAsientos
            // 
            this.txtAsientos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtAsientos.BorderColor = System.Drawing.Color.DimGray;
            this.txtAsientos.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtAsientos.BorderRadius = 10;
            this.txtAsientos.BorderSize = 2;
            this.txtAsientos.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsientos.ForeColor = System.Drawing.Color.White;
            this.txtAsientos.IsReadOnly = false;
            this.txtAsientos.Location = new System.Drawing.Point(1082, 334);
            this.txtAsientos.Margin = new System.Windows.Forms.Padding(6);
            this.txtAsientos.Multiline = false;
            this.txtAsientos.Name = "txtAsientos";
            this.txtAsientos.Padding = new System.Windows.Forms.Padding(15, 11, 15, 11);
            this.txtAsientos.PasswordChar = false;
            this.txtAsientos.PlaceholderColor = System.Drawing.Color.White;
            this.txtAsientos.PlaceholderText = "Asientos";
            this.txtAsientos.ShortcutsEnabled = false;
            this.txtAsientos.Size = new System.Drawing.Size(319, 68);
            this.txtAsientos.TabIndex = 150;
            this.txtAsientos.Texts = "";
            this.txtAsientos.UnderlinedStyle = true;
            this.txtAsientos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAsientos_KeyPress);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(1411, 78);
            this.txtid.Margin = new System.Windows.Forms.Padding(5);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(34, 26);
            this.txtid.TabIndex = 151;
            this.txtid.Text = "0";
            this.txtid.Visible = false;
            // 
            // txtImagen
            // 
            this.txtImagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtImagen.BorderColor = System.Drawing.Color.DimGray;
            this.txtImagen.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtImagen.BorderRadius = 10;
            this.txtImagen.BorderSize = 2;
            this.txtImagen.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImagen.ForeColor = System.Drawing.Color.White;
            this.txtImagen.IsReadOnly = false;
            this.txtImagen.Location = new System.Drawing.Point(750, 526);
            this.txtImagen.Margin = new System.Windows.Forms.Padding(6);
            this.txtImagen.Multiline = false;
            this.txtImagen.Name = "txtImagen";
            this.txtImagen.Padding = new System.Windows.Forms.Padding(15, 11, 15, 11);
            this.txtImagen.PasswordChar = false;
            this.txtImagen.PlaceholderColor = System.Drawing.Color.White;
            this.txtImagen.PlaceholderText = "";
            this.txtImagen.ShortcutsEnabled = false;
            this.txtImagen.Size = new System.Drawing.Size(594, 68);
            this.txtImagen.TabIndex = 152;
            this.txtImagen.Texts = "";
            this.txtImagen.UnderlinedStyle = true;
            this.txtImagen.Visible = false;
            // 
            // comboMarca
            // 
            this.comboMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.comboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMarca.DropDownWidth = 350;
            this.comboMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboMarca.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMarca.ForeColor = System.Drawing.Color.White;
            this.comboMarca.FormattingEnabled = true;
            this.comboMarca.Location = new System.Drawing.Point(733, 40);
            this.comboMarca.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboMarca.Name = "comboMarca";
            this.comboMarca.Size = new System.Drawing.Size(304, 53);
            this.comboMarca.TabIndex = 153;
            this.comboMarca.Tag = "";
            this.comboMarca.SelectedIndexChanged += new System.EventHandler(this.comboMarca_SelectedIndexChanged);
            // 
            // comboModelo
            // 
            this.comboModelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.comboModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboModelo.DropDownWidth = 350;
            this.comboModelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboModelo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboModelo.ForeColor = System.Drawing.Color.White;
            this.comboModelo.FormattingEnabled = true;
            this.comboModelo.Location = new System.Drawing.Point(1080, 40);
            this.comboModelo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboModelo.Name = "comboModelo";
            this.comboModelo.Size = new System.Drawing.Size(319, 53);
            this.comboModelo.TabIndex = 154;
            this.comboModelo.Tag = "";
            // 
            // FrmAutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(1473, 1117);
            this.Controls.Add(this.comboModelo);
            this.Controls.Add(this.comboMarca);
            this.Controls.Add(this.txtImagen);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.txtAsientos);
            this.Controls.Add(this.txtPuertas);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboEstado);
            this.Controls.Add(this.BtnGuardar2);
            this.Controls.Add(this.txtConsumo);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.txtKilometros);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.txtAño);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmAutos";
            this.Text = "FrmAutos";
            this.Load += new System.EventHandler(this.FrmAutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.RJControls.RJTextBox txtConsumo;
        private CustomControls.RJControls.RJTextBox txtModelo;
        private CustomControls.RJControls.RJTextBox txtKilometros;
        private CustomControls.RJControls.RJTextBox txtMatricula;
        private CustomControls.RJControls.RJTextBox txtAño;
        private CustomControls.RJControls.RJButton BtnGuardar2;
        private System.Windows.Forms.ComboBox comboEstado;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJButton rjButton1;
        private CustomControls.RJControls.RJTextBox txtMarca;
        private CustomControls.RJControls.RJTextBox txtPuertas;
        private CustomControls.RJControls.RJTextBox txtAsientos;
        private System.Windows.Forms.TextBox txtid;
        private CustomControls.RJControls.RJTextBox txtImagen;
        private System.Windows.Forms.ComboBox comboMarca;
        private System.Windows.Forms.ComboBox comboModelo;
    }
}