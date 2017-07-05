namespace Rulers
{
    partial class Hint
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
            this.labelMessage = new System.Windows.Forms.Label();
            this.labelTItle = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMessage.ForeColor = System.Drawing.Color.Aqua;
            this.labelMessage.Location = new System.Drawing.Point(99, 43);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(229, 19);
            this.labelMessage.TabIndex = 5;
            this.labelMessage.Text = "majorworld@outlook.com";
            // 
            // labelTItle
            // 
            this.labelTItle.AutoSize = true;
            this.labelTItle.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTItle.ForeColor = System.Drawing.Color.HotPink;
            this.labelTItle.Location = new System.Drawing.Point(114, 18);
            this.labelTItle.Name = "labelTItle";
            this.labelTItle.Size = new System.Drawing.Size(196, 20);
            this.labelTItle.TabIndex = 4;
            this.labelTItle.Text = "Rulers 2016-06-12";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxLogo.Location = new System.Drawing.Point(27, 27);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxLogo.TabIndex = 3;
            this.pictureBoxLogo.TabStop = false;
            // 
            // Hint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(360, 85);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.labelTItle);
            this.Controls.Add(this.pictureBoxLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Hint";
            this.ShowInTaskbar = false;
            this.Text = "Hint";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Hint_Load);
            this.MouseEnter += new System.EventHandler(this.Hint_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Hint_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelTItle;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}