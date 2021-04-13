
namespace Projekat
{
    partial class DePicto
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCrtanje = new System.Windows.Forms.Panel();
            this.picOlovka = new System.Windows.Forms.PictureBox();
            this.picGumica = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picOlovka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGumica)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCrtanje
            // 
            this.pnlCrtanje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCrtanje.BackColor = System.Drawing.Color.White;
            this.pnlCrtanje.Location = new System.Drawing.Point(0, 39);
            this.pnlCrtanje.Name = "pnlCrtanje";
            this.pnlCrtanje.Size = new System.Drawing.Size(800, 411);
            this.pnlCrtanje.TabIndex = 0;
            this.pnlCrtanje.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCrtanje_Paint);
            this.pnlCrtanje.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlCrtanje_MouseDown);
            this.pnlCrtanje.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlCrtanje_MouseMove);
            this.pnlCrtanje.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlCrtanje_MouseUp);
            // 
            // picOlovka
            // 
            this.picOlovka.Image = global::Projekat.Properties.Resources.pencil;
            this.picOlovka.Location = new System.Drawing.Point(0, 1);
            this.picOlovka.Name = "picOlovka";
            this.picOlovka.Size = new System.Drawing.Size(36, 36);
            this.picOlovka.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOlovka.TabIndex = 0;
            this.picOlovka.TabStop = false;
            this.picOlovka.Click += new System.EventHandler(this.picOlovka_Click);
            // 
            // picGumica
            // 
            this.picGumica.Image = global::Projekat.Properties.Resources.eraser;
            this.picGumica.Location = new System.Drawing.Point(42, 1);
            this.picGumica.Name = "picGumica";
            this.picGumica.Size = new System.Drawing.Size(36, 36);
            this.picGumica.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGumica.TabIndex = 1;
            this.picGumica.TabStop = false;
            this.picGumica.Click += new System.EventHandler(this.picGumica_Click);
            // 
            // DePicto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picGumica);
            this.Controls.Add(this.picOlovka);
            this.Controls.Add(this.pnlCrtanje);
            this.Name = "DePicto";
            this.Text = "DePicto";
            ((System.ComponentModel.ISupportInitialize)(this.picOlovka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGumica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCrtanje;
        private System.Windows.Forms.PictureBox picOlovka;
        private System.Windows.Forms.PictureBox picGumica;
    }
}

