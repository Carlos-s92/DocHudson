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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.comboMarca = new System.Windows.Forms.ComboBox();
            this.comboModelo = new System.Windows.Forms.ComboBox();
            this.txtImagen = new CustomControls.RJControls.RJTextBox();
            this.txtAsientos = new CustomControls.RJControls.RJTextBox();
            this.txtPuertas = new CustomControls.RJControls.RJTextBox();
            this.rjButton1 = new CustomControls.RJControls.RJButton();
            this.BtnGuardar2 = new CustomControls.RJControls.RJButton();
            this.txtConsumo = new CustomControls.RJControls.RJTextBox();
            this.txtKilometros = new CustomControls.RJControls.RJTextBox();
            this.txtMatricula = new CustomControls.RJControls.RJTextBox();
            this.txtAño = new CustomControls.RJControls.RJTextBox();
            this.BFondoPBAuto = new CustomControls.RJControls.RJButton();
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
            this.comboEstado.Location = new System.Drawing.Point(488, 158);
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(446, 38);
            this.comboEstado.TabIndex = 145;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.pictureBox1.Location = new System.Drawing.Point(72, 309);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 244);
            this.pictureBox1.TabIndex = 146;
            this.pictureBox1.TabStop = false;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(941, 51);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(24, 20);
            this.txtid.TabIndex = 151;
            this.txtid.Text = "0";
            this.txtid.Visible = false;
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
            this.comboMarca.Location = new System.Drawing.Point(489, 26);
            this.comboMarca.Name = "comboMarca";
            this.comboMarca.Size = new System.Drawing.Size(204, 38);
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
            this.comboModelo.Location = new System.Drawing.Point(720, 26);
            this.comboModelo.Name = "comboModelo";
            this.comboModelo.Size = new System.Drawing.Size(214, 38);
            this.comboModelo.TabIndex = 154;
            this.comboModelo.Tag = "";
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
            this.txtImagen.Location = new System.Drawing.Point(500, 342);
            this.txtImagen.Margin = new System.Windows.Forms.Padding(4);
            this.txtImagen.Multiline = false;
            this.txtImagen.Name = "txtImagen";
            this.txtImagen.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtImagen.PasswordChar = false;
            this.txtImagen.PlaceholderColor = System.Drawing.Color.White;
            this.txtImagen.PlaceholderText = "";
            this.txtImagen.ShortcutsEnabled = false;
            this.txtImagen.Size = new System.Drawing.Size(434, 45);
            this.txtImagen.TabIndex = 152;
            this.txtImagen.Texts = "";
            this.txtImagen.UnderlinedStyle = true;
            this.txtImagen.Visible = false;
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
            this.txtAsientos.Location = new System.Drawing.Point(721, 217);
            this.txtAsientos.Margin = new System.Windows.Forms.Padding(4);
            this.txtAsientos.Multiline = false;
            this.txtAsientos.Name = "txtAsientos";
            this.txtAsientos.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtAsientos.PasswordChar = false;
            this.txtAsientos.PlaceholderColor = System.Drawing.Color.White;
            this.txtAsientos.PlaceholderText = "Asientos";
            this.txtAsientos.ShortcutsEnabled = false;
            this.txtAsientos.Size = new System.Drawing.Size(213, 45);
            this.txtAsientos.TabIndex = 150;
            this.txtAsientos.Texts = "";
            this.txtAsientos.UnderlinedStyle = true;
            this.txtAsientos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAsientos_KeyPress);
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
            this.txtPuertas.Location = new System.Drawing.Point(488, 217);
            this.txtPuertas.Margin = new System.Windows.Forms.Padding(4);
            this.txtPuertas.Multiline = false;
            this.txtPuertas.Name = "txtPuertas";
            this.txtPuertas.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPuertas.PasswordChar = false;
            this.txtPuertas.PlaceholderColor = System.Drawing.Color.White;
            this.txtPuertas.PlaceholderText = "Puertas";
            this.txtPuertas.ShortcutsEnabled = false;
            this.txtPuertas.Size = new System.Drawing.Size(203, 45);
            this.txtPuertas.TabIndex = 149;
            this.txtPuertas.Texts = "";
            this.txtPuertas.UnderlinedStyle = true;
            this.txtPuertas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPuertas_KeyPress);
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
            this.rjButton1.Location = new System.Drawing.Point(507, 404);
            this.rjButton1.Margin = new System.Windows.Forms.Padding(2);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(427, 41);
            this.rjButton1.TabIndex = 147;
            this.rjButton1.Text = "Agregar Imagen";
            this.rjButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.BFotoProducto_Click);
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
            this.BtnGuardar2.Location = new System.Drawing.Point(523, 484);
            this.BtnGuardar2.Margin = new System.Windows.Forms.Padding(2);
            this.BtnGuardar2.Name = "BtnGuardar2";
            this.BtnGuardar2.Size = new System.Drawing.Size(396, 41);
            this.BtnGuardar2.TabIndex = 140;
            this.BtnGuardar2.Text = "Registrar Auto";
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
            this.txtConsumo.Location = new System.Drawing.Point(43, 151);
            this.txtConsumo.Margin = new System.Windows.Forms.Padding(4);
            this.txtConsumo.Multiline = false;
            this.txtConsumo.Name = "txtConsumo";
            this.txtConsumo.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtConsumo.PasswordChar = false;
            this.txtConsumo.PlaceholderColor = System.Drawing.Color.White;
            this.txtConsumo.PlaceholderText = "Consumo";
            this.txtConsumo.ShortcutsEnabled = false;
            this.txtConsumo.Size = new System.Drawing.Size(396, 45);
            this.txtConsumo.TabIndex = 137;
            this.txtConsumo.Texts = "";
            this.txtConsumo.UnderlinedStyle = true;
            this.txtConsumo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsumo_KeyPress);
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
            this.txtKilometros.Location = new System.Drawing.Point(488, 88);
            this.txtKilometros.Margin = new System.Windows.Forms.Padding(4);
            this.txtKilometros.Multiline = false;
            this.txtKilometros.Name = "txtKilometros";
            this.txtKilometros.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtKilometros.PasswordChar = false;
            this.txtKilometros.PlaceholderColor = System.Drawing.Color.White;
            this.txtKilometros.PlaceholderText = "Kilometros";
            this.txtKilometros.ShortcutsEnabled = false;
            this.txtKilometros.Size = new System.Drawing.Size(446, 45);
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
            this.txtMatricula.Location = new System.Drawing.Point(43, 26);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatricula.Multiline = false;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtMatricula.PasswordChar = false;
            this.txtMatricula.PlaceholderColor = System.Drawing.Color.White;
            this.txtMatricula.PlaceholderText = "Matricula";
            this.txtMatricula.ShortcutsEnabled = false;
            this.txtMatricula.Size = new System.Drawing.Size(396, 45);
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
            this.txtAño.Location = new System.Drawing.Point(43, 88);
            this.txtAño.Margin = new System.Windows.Forms.Padding(4);
            this.txtAño.Multiline = false;
            this.txtAño.Name = "txtAño";
            this.txtAño.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtAño.PasswordChar = false;
            this.txtAño.PlaceholderColor = System.Drawing.Color.White;
            this.txtAño.PlaceholderText = "Año";
            this.txtAño.ShortcutsEnabled = true;
            this.txtAño.Size = new System.Drawing.Size(396, 45);
            this.txtAño.TabIndex = 133;
            this.txtAño.Texts = "";
            this.txtAño.UnderlinedStyle = true;
            this.txtAño.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAño_KeyPress);
            // 
            // BFondoPBAuto
            // 
            this.BFondoPBAuto.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BFondoPBAuto.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BFondoPBAuto.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BFondoPBAuto.BorderRadius = 3;
            this.BFondoPBAuto.BorderSize = 0;
            this.BFondoPBAuto.Enabled = false;
            this.BFondoPBAuto.FlatAppearance.BorderSize = 0;
            this.BFondoPBAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BFondoPBAuto.ForeColor = System.Drawing.Color.White;
            this.BFondoPBAuto.Location = new System.Drawing.Point(69, 306);
            this.BFondoPBAuto.Name = "BFondoPBAuto";
            this.BFondoPBAuto.Size = new System.Drawing.Size(335, 249);
            this.BFondoPBAuto.TabIndex = 155;
            this.BFondoPBAuto.TextColor = System.Drawing.Color.White;
            this.BFondoPBAuto.UseVisualStyleBackColor = false;
            // 
            // FrmAutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(952, 579);
            this.Controls.Add(this.comboModelo);
            this.Controls.Add(this.comboMarca);
            this.Controls.Add(this.txtImagen);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.txtAsientos);
            this.Controls.Add(this.txtPuertas);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboEstado);
            this.Controls.Add(this.BtnGuardar2);
            this.Controls.Add(this.txtConsumo);
            this.Controls.Add(this.txtKilometros);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.txtAño);
            this.Controls.Add(this.BFondoPBAuto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAutos";
            this.Text = "FrmAutos";
            this.Load += new System.EventHandler(this.FrmAutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.RJControls.RJTextBox txtConsumo;
        private CustomControls.RJControls.RJTextBox txtKilometros;
        private CustomControls.RJControls.RJTextBox txtMatricula;
        private CustomControls.RJControls.RJTextBox txtAño;
        private CustomControls.RJControls.RJButton BtnGuardar2;
        private System.Windows.Forms.ComboBox comboEstado;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJButton rjButton1;
        private CustomControls.RJControls.RJTextBox txtPuertas;
        private CustomControls.RJControls.RJTextBox txtAsientos;
        private System.Windows.Forms.TextBox txtid;
        private CustomControls.RJControls.RJTextBox txtImagen;
        private System.Windows.Forms.ComboBox comboMarca;
        private System.Windows.Forms.ComboBox comboModelo;
        private CustomControls.RJControls.RJButton BFondoPBAuto;
    }
}