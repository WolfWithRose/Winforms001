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
            this.components = new System.ComponentModel.Container();
            this.Kepernyo = new System.Windows.Forms.PictureBox();
            this.start = new System.Windows.Forms.Button();
            this.Nev = new System.Windows.Forms.TextBox();
            this.Nem = new System.Windows.Forms.DomainUpDown();
            this.metronom = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Kepernyo)).BeginInit();
            this.SuspendLayout();
            // 
            // Kepernyo
            // 
            this.Kepernyo.BackColor = System.Drawing.SystemColors.Desktop;
            this.Kepernyo.Location = new System.Drawing.Point(12, 12);
            this.Kepernyo.Name = "Kepernyo";
            this.Kepernyo.Size = new System.Drawing.Size(1000, 600);
            this.Kepernyo.TabIndex = 0;
            this.Kepernyo.TabStop = false;
            this.Kepernyo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Kepernyo_MouseDown);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(1301, 12);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(131, 61);
            this.start.TabIndex = 1;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // Nev
            // 
            this.Nev.Location = new System.Drawing.Point(1160, 12);
            this.Nev.Name = "Nev";
            this.Nev.Size = new System.Drawing.Size(100, 20);
            this.Nev.TabIndex = 2;
            // 
            // Nem
            // 
            this.Nem.Location = new System.Drawing.Point(1160, 38);
            this.Nem.Name = "Nem";
            this.Nem.Size = new System.Drawing.Size(120, 20);
            this.Nem.TabIndex = 3;
            this.Nem.Text = "Nem";
            // 
            // metronom
            // 
            this.metronom.Interval = 10;
            this.metronom.Tick += new System.EventHandler(this.metronom_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 750);
            this.Controls.Add(this.Nem);
            this.Controls.Add(this.Nev);
            this.Controls.Add(this.start);
            this.Controls.Add(this.Kepernyo);
            this.Name = "Form1";
            this.Text = "Last Names";
            ((System.ComponentModel.ISupportInitialize)(this.Kepernyo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Kepernyo;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox Nev;
        private System.Windows.Forms.DomainUpDown Nem;
        private System.Windows.Forms.Timer metronom;
    }
}

