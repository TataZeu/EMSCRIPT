namespace WindowsFormsApp1
{
    partial class Menu
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
            this.UpBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UpBtn
            // 
            this.UpBtn.Location = new System.Drawing.Point(409, 210);
            this.UpBtn.Name = "UpBtn";
            this.UpBtn.Size = new System.Drawing.Size(94, 39);
            this.UpBtn.TabIndex = 0;
            this.UpBtn.Text = "UpBtn";
            this.UpBtn.UseVisualStyleBackColor = true;
            this.UpBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Menu
            // 
            this.ClientSize = new System.Drawing.Size(562, 337);
            this.Controls.Add(this.UpBtn);
            this.Name = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UploadBtn;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button Testare;
        private System.Windows.Forms.Button UpBtn;
    }
}

