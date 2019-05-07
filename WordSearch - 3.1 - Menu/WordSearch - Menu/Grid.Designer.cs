namespace WordSearch___Menu
{
    partial class Grid
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
            this.exitBtn = new System.Windows.Forms.Button();
            this.boxOfWords = new System.Windows.Forms.RichTextBox();
            this.listTitle = new System.Windows.Forms.Label();
            this.openMainMenu = new System.Windows.Forms.Button();
            this.msgLabel = new System.Windows.Forms.Label();
            this.showAnsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(12, 503);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(88, 23);
            this.exitBtn.TabIndex = 18;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // boxOfWords
            // 
            this.boxOfWords.BackColor = System.Drawing.SystemColors.Control;
            this.boxOfWords.Location = new System.Drawing.Point(12, 149);
            this.boxOfWords.Name = "boxOfWords";
            this.boxOfWords.ReadOnly = true;
            this.boxOfWords.Size = new System.Drawing.Size(100, 199);
            this.boxOfWords.TabIndex = 17;
            this.boxOfWords.Text = "";
            this.boxOfWords.TextChanged += new System.EventHandler(this.boxOfWords_TextChanged);
            // 
            // listTitle
            // 
            this.listTitle.AutoSize = true;
            this.listTitle.Location = new System.Drawing.Point(13, 123);
            this.listTitle.Name = "listTitle";
            this.listTitle.Size = new System.Drawing.Size(16, 13);
            this.listTitle.TabIndex = 16;
            this.listTitle.Text = "...";
            // 
            // openMainMenu
            // 
            this.openMainMenu.Location = new System.Drawing.Point(12, 93);
            this.openMainMenu.Name = "openMainMenu";
            this.openMainMenu.Size = new System.Drawing.Size(75, 23);
            this.openMainMenu.TabIndex = 15;
            this.openMainMenu.Text = "Main Menu";
            this.openMainMenu.UseVisualStyleBackColor = true;
            this.openMainMenu.Click += new System.EventHandler(this.openMainMenu_Click_1);
            // 
            // msgLabel
            // 
            this.msgLabel.AutoSize = true;
            this.msgLabel.Location = new System.Drawing.Point(227, 9);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(0, 13);
            this.msgLabel.TabIndex = 19;
            // 
            // showAnsBtn
            // 
            this.showAnsBtn.Location = new System.Drawing.Point(12, 474);
            this.showAnsBtn.Name = "showAnsBtn";
            this.showAnsBtn.Size = new System.Drawing.Size(88, 23);
            this.showAnsBtn.TabIndex = 20;
            this.showAnsBtn.Text = "Show Answers";
            this.showAnsBtn.UseVisualStyleBackColor = true;
            this.showAnsBtn.Click += new System.EventHandler(this.showAnsBtn_Click);
            // 
            // Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 538);
            this.Controls.Add(this.showAnsBtn);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.boxOfWords);
            this.Controls.Add(this.listTitle);
            this.Controls.Add(this.openMainMenu);
            this.Name = "Grid";
            this.Text = "Grid";
            this.Load += new System.EventHandler(this.Grid_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Grid_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.RichTextBox boxOfWords;
        private System.Windows.Forms.Label listTitle;
        private System.Windows.Forms.Button openMainMenu;
        private System.Windows.Forms.Label msgLabel;
        private System.Windows.Forms.Button showAnsBtn;
    }
}