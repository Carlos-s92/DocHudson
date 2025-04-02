namespace TestGit.Modales
{
    partial class ucLogin
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnLogin = new CustomControls.RJControls.RJButton();
            this.CampoUsuario = new CustomControls.RJControls.RJTextBox();
            this.CampoContraseña = new CustomControls.RJControls.RJTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::TestGit.Properties.Resources.image_Photoroom1;
            this.pictureBox1.Location = new System.Drawing.Point(130, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(154, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Login";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(116)))));
            this.BtnLogin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(116)))));
            this.BtnLogin.BorderColor = System.Drawing.Color.MidnightBlue;
            this.BtnLogin.BorderRadius = 20;
            this.BtnLogin.BorderSize = 3;
            this.BtnLogin.FlatAppearance.BorderSize = 0;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.ForeColor = System.Drawing.Color.White;
            this.BtnLogin.Location = new System.Drawing.Point(78, 316);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(209, 54);
            this.BtnLogin.TabIndex = 11;
            this.BtnLogin.Text = "Iniciar Sesion";
            this.BtnLogin.TextColor = System.Drawing.Color.White;
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // CampoUsuario
            // 
            this.CampoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(58)))));
            this.CampoUsuario.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.CampoUsuario.BorderFocusColor = System.Drawing.Color.HotPink;
            this.CampoUsuario.BorderRadius = 10;
            this.CampoUsuario.BorderSize = 2;
            this.CampoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampoUsuario.ForeColor = System.Drawing.Color.White;
            this.CampoUsuario.IsReadOnly = false;
            this.CampoUsuario.Location = new System.Drawing.Point(61, 189);
            this.CampoUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.CampoUsuario.Multiline = false;
            this.CampoUsuario.Name = "CampoUsuario";
            this.CampoUsuario.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.CampoUsuario.PasswordChar = false;
            this.CampoUsuario.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.CampoUsuario.PlaceholderText = "Usuario";
            this.CampoUsuario.ShortcutsEnabled = false;
            this.CampoUsuario.Size = new System.Drawing.Size(250, 31);
            this.CampoUsuario.TabIndex = 9;
            this.CampoUsuario.Texts = "";
            this.CampoUsuario.UnderlinedStyle = true;
            // 
            // CampoContraseña
            // 
            this.CampoContraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(58)))));
            this.CampoContraseña.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.CampoContraseña.BorderFocusColor = System.Drawing.Color.HotPink;
            this.CampoContraseña.BorderRadius = 10;
            this.CampoContraseña.BorderSize = 2;
            this.CampoContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampoContraseña.ForeColor = System.Drawing.Color.White;
            this.CampoContraseña.IsReadOnly = false;
            this.CampoContraseña.Location = new System.Drawing.Point(61, 247);
            this.CampoContraseña.Margin = new System.Windows.Forms.Padding(4);
            this.CampoContraseña.Multiline = false;
            this.CampoContraseña.Name = "CampoContraseña";
            this.CampoContraseña.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.CampoContraseña.PasswordChar = true;
            this.CampoContraseña.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.CampoContraseña.PlaceholderText = "Contraseña";
            this.CampoContraseña.ShortcutsEnabled = false;
            this.CampoContraseña.Size = new System.Drawing.Size(250, 31);
            this.CampoContraseña.TabIndex = 10;
            this.CampoContraseña.Texts = "";
            this.CampoContraseña.UnderlinedStyle = true;
            // 
            // ucLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.CampoUsuario);
            this.Controls.Add(this.CampoContraseña);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ucLogin";
            this.Size = new System.Drawing.Size(360, 425);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.RJControls.RJButton BtnLogin;
        private CustomControls.RJControls.RJTextBox CampoUsuario;
        private CustomControls.RJControls.RJTextBox CampoContraseña;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}
