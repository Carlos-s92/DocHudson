namespace TestGit.Modales
{
    partial class mdLogin
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CampoContraseña = new CustomControls.RJControls.RJTextBox();
            this.CampoUsuario = new CustomControls.RJControls.RJTextBox();
            this.BtnLogin = new CustomControls.RJControls.RJButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TestGit.Properties.Resources.image_Photoroom1;
            this.pictureBox1.Location = new System.Drawing.Point(177, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // CampoContraseña
            // 
            this.CampoContraseña.BackColor = System.Drawing.SystemColors.Window;
            this.CampoContraseña.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.CampoContraseña.BorderFocusColor = System.Drawing.Color.HotPink;
            this.CampoContraseña.BorderRadius = 10;
            this.CampoContraseña.BorderSize = 2;
            this.CampoContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampoContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CampoContraseña.IsReadOnly = false;
            this.CampoContraseña.Location = new System.Drawing.Point(103, 235);
            this.CampoContraseña.Margin = new System.Windows.Forms.Padding(4);
            this.CampoContraseña.Multiline = false;
            this.CampoContraseña.Name = "CampoContraseña";
            this.CampoContraseña.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.CampoContraseña.PasswordChar = false;
            this.CampoContraseña.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.CampoContraseña.PlaceholderText = "Contraseña";
            this.CampoContraseña.ShortcutsEnabled = true;
            this.CampoContraseña.Size = new System.Drawing.Size(250, 31);
            this.CampoContraseña.TabIndex = 6;
            this.CampoContraseña.Texts = "";
            this.CampoContraseña.UnderlinedStyle = false;
            // 
            // CampoUsuario
            // 
            this.CampoUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.CampoUsuario.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.CampoUsuario.BorderFocusColor = System.Drawing.Color.HotPink;
            this.CampoUsuario.BorderRadius = 10;
            this.CampoUsuario.BorderSize = 2;
            this.CampoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampoUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CampoUsuario.IsReadOnly = false;
            this.CampoUsuario.Location = new System.Drawing.Point(103, 177);
            this.CampoUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.CampoUsuario.Multiline = false;
            this.CampoUsuario.Name = "CampoUsuario";
            this.CampoUsuario.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.CampoUsuario.PasswordChar = false;
            this.CampoUsuario.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.CampoUsuario.PlaceholderText = "Usuario";
            this.CampoUsuario.ShortcutsEnabled = true;
            this.CampoUsuario.Size = new System.Drawing.Size(250, 31);
            this.CampoUsuario.TabIndex = 5;
            this.CampoUsuario.Texts = "";
            this.CampoUsuario.UnderlinedStyle = false;
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnLogin.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnLogin.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnLogin.BorderRadius = 20;
            this.BtnLogin.BorderSize = 0;
            this.BtnLogin.FlatAppearance.BorderSize = 0;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.ForeColor = System.Drawing.Color.White;
            this.BtnLogin.Location = new System.Drawing.Point(120, 304);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(209, 54);
            this.BtnLogin.TabIndex = 4;
            this.BtnLogin.Text = "Iniciar Sesion";
            this.BtnLogin.TextColor = System.Drawing.Color.White;
            this.BtnLogin.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.BtnLogin);
            this.panel1.Controls.Add(this.CampoUsuario);
            this.panel1.Controls.Add(this.CampoContraseña);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 450);
            this.panel1.TabIndex = 8;
            // 
            // mdLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mdLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJTextBox CampoContraseña;
        private CustomControls.RJControls.RJTextBox CampoUsuario;
        private CustomControls.RJControls.RJButton BtnLogin;
        private System.Windows.Forms.Panel panel1;
    }
}