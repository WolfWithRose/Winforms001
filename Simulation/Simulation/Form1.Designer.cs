namespace Simulation
{
    partial class Form1
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
            this.Kepernyo = new System.Windows.Forms.PictureBox();
            this.Imput = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Kepernyo)).BeginInit();
            this.SuspendLayout();
            // 
            // Kepernyo
            // 
            this.Kepernyo.BackColor = System.Drawing.SystemColors.Desktop;
            this.Kepernyo.Location = new System.Drawing.Point(12, 12);
            this.Kepernyo.Name = "Kepernyo";
            this.Kepernyo.Size = new System.Drawing.Size(1142, 626);
            this.Kepernyo.TabIndex = 0;
            this.Kepernyo.TabStop = false;
            // 
            // Imput
            // 
            this.Imput.Location = new System.Drawing.Point(1160, 12);
            this.Imput.Name = "Imput";
            this.Imput.Size = new System.Drawing.Size(131, 61);
            this.Imput.TabIndex = 1;
            this.Imput.Text = "Hozzáadás";
            this.Imput.UseVisualStyleBackColor = true;
            this.Imput.Click += new System.EventHandler(this.Imput_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 650);
            this.Controls.Add(this.Imput);
            this.Controls.Add(this.Kepernyo);
            this.Name = "Form1";
            this.Text = "Last Names";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Kepernyo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Kepernyo;
        private System.Windows.Forms.Button Imput;
    }
}

