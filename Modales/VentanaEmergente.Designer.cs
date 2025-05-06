namespace TestGit.Modales
{
    partial class VentanaEmergente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaEmergente));
            this.PTituloVE = new System.Windows.Forms.Panel();
            this.BCloseVE = new System.Windows.Forms.Button();
            this.LTituloVE = new System.Windows.Forms.Label();
            this.IPBVE = new FontAwesome.Sharp.IconPictureBox();
            this.LInfoVE = new System.Windows.Forms.Label();
            this.BNoVE = new CustomControls.RJControls.RJButton();
            this.BSIVE = new CustomControls.RJControls.RJButton();
            this.BAceptarVE = new CustomControls.RJControls.RJButton();
            this.PTituloVE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IPBVE)).BeginInit();
            this.SuspendLayout();
            // 
            // PTituloVE
            // 
            this.PTituloVE.BackColor = System.Drawing.Color.RoyalBlue;
            this.PTituloVE.Controls.Add(this.BCloseVE);
            this.PTituloVE.Controls.Add(this.LTituloVE);
            this.PTituloVE.Controls.Add(this.IPBVE);
            this.PTituloVE.ForeColor = System.Drawing.Color.White;
            this.PTituloVE.Location = new System.Drawing.Point(2, 2);
            this.PTituloVE.Margin = new System.Windows.Forms.Padding(2);
            this.PTituloVE.Name = "PTituloVE";
            this.PTituloVE.Size = new System.Drawing.Size(397, 38);
            this.PTituloVE.TabIndex = 0;
            // 
            // BCloseVE
            // 
            this.BCloseVE.BackColor = System.Drawing.Color.Transparent;
            this.BCloseVE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BCloseVE.BackgroundImage")));
            this.BCloseVE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BCloseVE.FlatAppearance.BorderSize = 0;
            this.BCloseVE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BCloseVE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BCloseVE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCloseVE.Location = new System.Drawing.Point(370, 8);
            this.BCloseVE.Margin = new System.Windows.Forms.Padding(2);
            this.BCloseVE.Name = "BCloseVE";
            this.BCloseVE.Size = new System.Drawing.Size(20, 20);
            this.BCloseVE.TabIndex = 2;
            this.BCloseVE.UseVisualStyleBackColor = false;
            this.BCloseVE.Click += new System.EventHandler(this.BCloseVE_Click);
            // 
            // LTituloVE
            // 
            this.LTituloVE.AutoSize = true;
            this.LTituloVE.BackColor = System.Drawing.Color.Transparent;
            this.LTituloVE.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloVE.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LTituloVE.Location = new System.Drawing.Point(40, 10);
            this.LTituloVE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LTituloVE.Name = "LTituloVE";
            this.LTituloVE.Size = new System.Drawing.Size(36, 19);
            this.LTituloVE.TabIndex = 0;
            this.LTituloVE.Text = "Info";
            // 
            // IPBVE
            // 
            this.IPBVE.BackColor = System.Drawing.Color.Transparent;
            this.IPBVE.IconChar = FontAwesome.Sharp.IconChar.None;
            this.IPBVE.IconColor = System.Drawing.Color.White;
            this.IPBVE.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IPBVE.IconSize = 26;
            this.IPBVE.Location = new System.Drawing.Point(8, 6);
            this.IPBVE.Margin = new System.Windows.Forms.Padding(2);
            this.IPBVE.Name = "IPBVE";
            this.IPBVE.Size = new System.Drawing.Size(27, 26);
            this.IPBVE.TabIndex = 1;
            this.IPBVE.TabStop = false;
            // 
            // LInfoVE
            // 
            this.LInfoVE.AutoEllipsis = true;
            this.LInfoVE.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LInfoVE.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LInfoVE.Location = new System.Drawing.Point(7, 41);
            this.LInfoVE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LInfoVE.Name = "LInfoVE";
            this.LInfoVE.Size = new System.Drawing.Size(387, 89);
            this.LInfoVE.TabIndex = 3;
            this.LInfoVE.Text = "MSG";
            this.LInfoVE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BNoVE
            // 
            this.BNoVE.BackColor = System.Drawing.Color.Transparent;
            this.BNoVE.BackgroundColor = System.Drawing.Color.Transparent;
            this.BNoVE.BorderColor = System.Drawing.Color.Aqua;
            this.BNoVE.BorderRadius = 10;
            this.BNoVE.BorderSize = 1;
            this.BNoVE.FlatAppearance.BorderSize = 0;
            this.BNoVE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BNoVE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BNoVE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BNoVE.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.BNoVE.ForeColor = System.Drawing.Color.White;
            this.BNoVE.Location = new System.Drawing.Point(65, 135);
            this.BNoVE.Margin = new System.Windows.Forms.Padding(2);
            this.BNoVE.Name = "BNoVE";
            this.BNoVE.Size = new System.Drawing.Size(41, 31);
            this.BNoVE.TabIndex = 8;
            this.BNoVE.Text = " NO";
            this.BNoVE.TextColor = System.Drawing.Color.White;
            this.BNoVE.UseVisualStyleBackColor = false;
            this.BNoVE.Click += new System.EventHandler(this.BNoVE_Click);
            // 
            // BSIVE
            // 
            this.BSIVE.BackColor = System.Drawing.Color.Transparent;
            this.BSIVE.BackgroundColor = System.Drawing.Color.Transparent;
            this.BSIVE.BorderColor = System.Drawing.Color.Aqua;
            this.BSIVE.BorderRadius = 10;
            this.BSIVE.BorderSize = 1;
            this.BSIVE.FlatAppearance.BorderSize = 0;
            this.BSIVE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BSIVE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BSIVE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSIVE.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.BSIVE.ForeColor = System.Drawing.Color.White;
            this.BSIVE.Location = new System.Drawing.Point(17, 134);
            this.BSIVE.Margin = new System.Windows.Forms.Padding(2);
            this.BSIVE.Name = "BSIVE";
            this.BSIVE.Size = new System.Drawing.Size(36, 31);
            this.BSIVE.TabIndex = 7;
            this.BSIVE.Text = " SI";
            this.BSIVE.TextColor = System.Drawing.Color.White;
            this.BSIVE.UseVisualStyleBackColor = false;
            this.BSIVE.Click += new System.EventHandler(this.BSIVE_Click);
            // 
            // BAceptarVE
            // 
            this.BAceptarVE.BackColor = System.Drawing.Color.Transparent;
            this.BAceptarVE.BackgroundColor = System.Drawing.Color.Transparent;
            this.BAceptarVE.BorderColor = System.Drawing.Color.Aqua;
            this.BAceptarVE.BorderRadius = 5;
            this.BAceptarVE.BorderSize = 1;
            this.BAceptarVE.FlatAppearance.BorderSize = 0;
            this.BAceptarVE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BAceptarVE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BAceptarVE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAceptarVE.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAceptarVE.ForeColor = System.Drawing.Color.White;
            this.BAceptarVE.Location = new System.Drawing.Point(317, 133);
            this.BAceptarVE.Margin = new System.Windows.Forms.Padding(2);
            this.BAceptarVE.Name = "BAceptarVE";
            this.BAceptarVE.Size = new System.Drawing.Size(76, 30);
            this.BAceptarVE.TabIndex = 9;
            this.BAceptarVE.Text = "Aceptar";
            this.BAceptarVE.TextColor = System.Drawing.Color.White;
            this.BAceptarVE.UseVisualStyleBackColor = false;
            this.BAceptarVE.Click += new System.EventHandler(this.BAceptarVE_Click);
            // 
            // VentanaEmergente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(400, 170);
            this.Controls.Add(this.BNoVE);
            this.Controls.Add(this.BSIVE);
            this.Controls.Add(this.LInfoVE);
            this.Controls.Add(this.BAceptarVE);
            this.Controls.Add(this.PTituloVE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VentanaEmergente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.VentanaEmergente_Load);
            this.PTituloVE.ResumeLayout(false);
            this.PTituloVE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IPBVE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PTituloVE;
        private FontAwesome.Sharp.IconPictureBox IPBVE;
        private System.Windows.Forms.Label LTituloVE;
        private System.Windows.Forms.Label LInfoVE;
        private System.Windows.Forms.Button BCloseVE;
        private CustomControls.RJControls.RJButton BSIVE;
        private CustomControls.RJControls.RJButton BNoVE;
        private CustomControls.RJControls.RJButton BAceptarVE;
    }
}