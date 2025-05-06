namespace TestGit.Modales
{
    partial class mdPagos
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
            this.mdPagos2 = new CustomControls.RJControls.RJTextBox();
            this.btnTarjeta = new System.Windows.Forms.RadioButton();
            this.btnEfectivo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMonto = new CustomControls.RJControls.RJTextBox();
            this.txtPaga = new CustomControls.RJControls.RJTextBox();
            this.txtCambio = new CustomControls.RJControls.RJTextBox();
            this.txtTarjeta = new CustomControls.RJControls.RJTextBox();
            this.btnConfirmar = new CustomControls.RJControls.RJButton();
            this.btnCancelar = new CustomControls.RJControls.RJButton();
            this.rjButton2 = new CustomControls.RJControls.RJButton();
            this.SuspendLayout();
            // 
            // mdPagos2
            // 
            this.mdPagos2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.mdPagos2.BorderColor = System.Drawing.Color.DimGray;
            this.mdPagos2.BorderFocusColor = System.Drawing.Color.HotPink;
            this.mdPagos2.BorderRadius = 0;
            this.mdPagos2.BorderSize = 2;
            this.mdPagos2.CausesValidation = false;
            this.mdPagos2.Enabled = false;
            this.mdPagos2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdPagos2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mdPagos2.IsReadOnly = true;
            this.mdPagos2.Location = new System.Drawing.Point(3, 3);
            this.mdPagos2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mdPagos2.Multiline = true;
            this.mdPagos2.Name = "mdPagos2";
            this.mdPagos2.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.mdPagos2.PasswordChar = false;
            this.mdPagos2.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.mdPagos2.PlaceholderText = "";
            this.mdPagos2.ShortcutsEnabled = true;
            this.mdPagos2.Size = new System.Drawing.Size(671, 324);
            this.mdPagos2.TabIndex = 0;
            this.mdPagos2.Texts = "";
            this.mdPagos2.UnderlinedStyle = false;
            // 
            // btnTarjeta
            // 
            this.btnTarjeta.AutoSize = true;
            this.btnTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.btnTarjeta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarjeta.ForeColor = System.Drawing.Color.White;
            this.btnTarjeta.Location = new System.Drawing.Point(54, 109);
            this.btnTarjeta.Name = "btnTarjeta";
            this.btnTarjeta.Size = new System.Drawing.Size(87, 25);
            this.btnTarjeta.TabIndex = 1;
            this.btnTarjeta.TabStop = true;
            this.btnTarjeta.Text = "Tarjetas";
            this.btnTarjeta.UseVisualStyleBackColor = false;
            this.btnTarjeta.CheckedChanged += new System.EventHandler(this.btnTarjeta_CheckedChanged);
            // 
            // btnEfectivo
            // 
            this.btnEfectivo.AutoSize = true;
            this.btnEfectivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.btnEfectivo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEfectivo.ForeColor = System.Drawing.Color.White;
            this.btnEfectivo.Location = new System.Drawing.Point(54, 151);
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.Size = new System.Drawing.Size(90, 25);
            this.btnEfectivo.TabIndex = 2;
            this.btnEfectivo.TabStop = true;
            this.btnEfectivo.Text = "Efectivo";
            this.btnEfectivo.UseVisualStyleBackColor = false;
            this.btnEfectivo.CheckedChanged += new System.EventHandler(this.btnEfectivo_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(40, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Metodo de Pago";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtMonto.BorderColor = System.Drawing.Color.RoyalBlue;
            this.txtMonto.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtMonto.BorderRadius = 0;
            this.txtMonto.BorderSize = 2;
            this.txtMonto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMonto.IsReadOnly = false;
            this.txtMonto.Location = new System.Drawing.Point(279, 67);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMonto.Multiline = false;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtMonto.PasswordChar = false;
            this.txtMonto.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtMonto.PlaceholderText = "MONTO";
            this.txtMonto.ShortcutsEnabled = false;
            this.txtMonto.Size = new System.Drawing.Size(304, 36);
            this.txtMonto.TabIndex = 4;
            this.txtMonto.Texts = "";
            this.txtMonto.UnderlinedStyle = true;
            // 
            // txtPaga
            // 
            this.txtPaga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtPaga.BorderColor = System.Drawing.Color.RoyalBlue;
            this.txtPaga.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtPaga.BorderRadius = 0;
            this.txtPaga.BorderSize = 2;
            this.txtPaga.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaga.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPaga.IsReadOnly = false;
            this.txtPaga.Location = new System.Drawing.Point(281, 124);
            this.txtPaga.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPaga.Multiline = false;
            this.txtPaga.Name = "txtPaga";
            this.txtPaga.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPaga.PasswordChar = false;
            this.txtPaga.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPaga.PlaceholderText = "Paga con";
            this.txtPaga.ShortcutsEnabled = false;
            this.txtPaga.Size = new System.Drawing.Size(304, 36);
            this.txtPaga.TabIndex = 5;
            this.txtPaga.Texts = "";
            this.txtPaga.UnderlinedStyle = true;
            // 
            // txtCambio
            // 
            this.txtCambio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtCambio.BorderColor = System.Drawing.Color.RoyalBlue;
            this.txtCambio.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtCambio.BorderRadius = 0;
            this.txtCambio.BorderSize = 2;
            this.txtCambio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCambio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCambio.IsReadOnly = false;
            this.txtCambio.Location = new System.Drawing.Point(279, 174);
            this.txtCambio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCambio.Multiline = false;
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCambio.PasswordChar = false;
            this.txtCambio.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCambio.PlaceholderText = "Cambio";
            this.txtCambio.ShortcutsEnabled = false;
            this.txtCambio.Size = new System.Drawing.Size(304, 36);
            this.txtCambio.TabIndex = 6;
            this.txtCambio.Texts = "";
            this.txtCambio.UnderlinedStyle = true;
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(36)))));
            this.txtTarjeta.BorderColor = System.Drawing.Color.RoyalBlue;
            this.txtTarjeta.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtTarjeta.BorderRadius = 0;
            this.txtTarjeta.BorderSize = 2;
            this.txtTarjeta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTarjeta.IsReadOnly = false;
            this.txtTarjeta.Location = new System.Drawing.Point(279, 124);
            this.txtTarjeta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTarjeta.Multiline = false;
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtTarjeta.PasswordChar = false;
            this.txtTarjeta.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtTarjeta.PlaceholderText = "Numero de Tarjeta";
            this.txtTarjeta.ShortcutsEnabled = false;
            this.txtTarjeta.Size = new System.Drawing.Size(304, 36);
            this.txtTarjeta.TabIndex = 8;
            this.txtTarjeta.Texts = "";
            this.txtTarjeta.UnderlinedStyle = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.Green;
            this.btnConfirmar.BackgroundColor = System.Drawing.Color.Green;
            this.btnConfirmar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnConfirmar.BorderRadius = 20;
            this.btnConfirmar.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(279, 251);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(133, 40);
            this.btnConfirmar.TabIndex = 9;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextColor = System.Drawing.Color.White;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DarkRed;
            this.btnCancelar.BackgroundColor = System.Drawing.Color.DarkRed;
            this.btnCancelar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancelar.BorderRadius = 20;
            this.btnCancelar.BorderSize = 0;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(449, 251);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(136, 40);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton2.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 10;
            this.rjButton2.BorderSize = 0;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Location = new System.Drawing.Point(-6, -6);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(687, 342);
            this.rjButton2.TabIndex = 11;
            this.rjButton2.Text = "rjButton2";
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            this.rjButton2.Paint += new System.Windows.Forms.PaintEventHandler(this.BBordeMDPago_Paint);
            // 
            // mdPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(677, 330);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtTarjeta);
            this.Controls.Add(this.txtCambio);
            this.Controls.Add(this.txtPaga);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEfectivo);
            this.Controls.Add(this.btnTarjeta);
            this.Controls.Add(this.mdPagos2);
            this.Controls.Add(this.rjButton2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mdPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mdPagos";
            this.Load += new System.EventHandler(this.mdPagos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.RJControls.RJTextBox mdPagos2;
        private System.Windows.Forms.RadioButton btnTarjeta;
        private System.Windows.Forms.RadioButton btnEfectivo;
        private System.Windows.Forms.Label label1;
        private CustomControls.RJControls.RJTextBox txtMonto;
        private CustomControls.RJControls.RJTextBox txtPaga;
        private CustomControls.RJControls.RJTextBox txtCambio;
        private CustomControls.RJControls.RJTextBox txtTarjeta;
        private CustomControls.RJControls.RJButton btnConfirmar;
        private CustomControls.RJControls.RJButton btnCancelar;
        private CustomControls.RJControls.RJButton rjButton2;
    }
}