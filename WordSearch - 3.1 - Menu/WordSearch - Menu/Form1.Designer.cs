namespace WordSearch___Menu
{
    partial class MainMenu
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
            this.groupBoxMenu = new System.Windows.Forms.GroupBox();
            this.continueBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.infoBtn = new System.Windows.Forms.Button();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.newGameBtn = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMenu
            // 
            this.groupBoxMenu.Controls.Add(this.continueBtn);
            this.groupBoxMenu.Controls.Add(this.exitBtn);
            this.groupBoxMenu.Controls.Add(this.infoBtn);
            this.groupBoxMenu.Controls.Add(this.settingsBtn);
            this.groupBoxMenu.Controls.Add(this.newGameBtn);
            this.groupBoxMenu.Location = new System.Drawing.Point(12, 108);
            this.groupBoxMenu.MinimumSize = new System.Drawing.Size(115, 150);
            this.groupBoxMenu.Name = "groupBoxMenu";
            this.groupBoxMenu.Size = new System.Drawing.Size(115, 180);
            this.groupBoxMenu.TabIndex = 0;
            this.groupBoxMenu.TabStop = false;
            this.groupBoxMenu.Text = "Menu";
            this.groupBoxMenu.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // continueBtn
            // 
            this.continueBtn.Location = new System.Drawing.Point(6, 51);
            this.continueBtn.Name = "continueBtn";
            this.continueBtn.Size = new System.Drawing.Size(100, 25);
            this.continueBtn.TabIndex = 4;
            this.continueBtn.Text = "Continue Game";
            this.continueBtn.UseVisualStyleBackColor = true;
            this.continueBtn.Click += new System.EventHandler(this.continueBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(6, 144);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(99, 25);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // infoBtn
            // 
            this.infoBtn.Location = new System.Drawing.Point(6, 113);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(99, 25);
            this.infoBtn.TabIndex = 2;
            this.infoBtn.Text = "Information";
            this.infoBtn.UseVisualStyleBackColor = true;
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Location = new System.Drawing.Point(7, 82);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(99, 25);
            this.settingsBtn.TabIndex = 1;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // newGameBtn
            // 
            this.newGameBtn.Location = new System.Drawing.Point(7, 20);
            this.newGameBtn.Name = "newGameBtn";
            this.newGameBtn.Size = new System.Drawing.Size(100, 25);
            this.newGameBtn.TabIndex = 0;
            this.newGameBtn.Text = "New Game";
            this.newGameBtn.UseVisualStyleBackColor = true;
            this.newGameBtn.Click += new System.EventHandler(this.newGameBtn_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Showcard Gothic", 35F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(12, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(358, 59);
            this.title.TabIndex = 1;
            this.title.Text = "Word Search";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WordSearch___Menu.Properties.Resources.tiger;
            this.pictureBox1.Location = new System.Drawing.Point(158, 95);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 205);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumOrchid;
            this.ClientSize = new System.Drawing.Size(434, 321);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.groupBoxMenu);
            this.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.MenuText;
            this.MaximumSize = new System.Drawing.Size(450, 360);
            this.MinimumSize = new System.Drawing.Size(450, 360);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMenu;
        private System.Windows.Forms.Button newGameBtn;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.Button infoBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button continueBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

