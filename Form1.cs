using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat
{
    public partial class DePicto : Form
    {
        Graphics g;
        Pen p;
        bool pomeranje = false;
        int x, y;
        Color trenBoja;
        int trenVelicina;
        List<List<Point>> linije;
        List<int> koordinate;
        List<Action> undo;
        //Form f2;
        //TextBox t;
        //Label label;
        //bool pom;
        public DePicto()
        {
            InitializeComponent();
            Inicijalizuj();
        }

        private void Inicijalizuj()
        {
            //f2 = new Form();
            //pom = false;
            g = pnlCrtanje.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            numVelicina.Value = 3;
            p = new Pen(Color.Black, (int)numVelicina.Value);
            trenBoja = Color.Black;
            trenVelicina = (int)numVelicina.Value;
            linije = new List<List<Point>>();
            koordinate = new List<int>();
            x = -1; y = -1;
            undo = new List<Action>();
            //t = new TextBox();
        }
        private void pnlCrtanje_MouseDown(object sender, MouseEventArgs e)
        {
            pomeranje = true;
            x = e.X;
            y = e.Y;
            linije.Add(new List<Point>());
            linije.Last().Add(e.Location);
        }

        private void pnlCrtanje_MouseMove(object sender, MouseEventArgs e)
        {
            if (pomeranje && x != -1 && x != -1)
            {
                g.DrawLine(p, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
                linije.Last().Add(e.Location);
                this.Invalidate();
            }
        }

        private void pnlCrtanje_MouseUp(object sender, MouseEventArgs e)
        {
            pomeranje = false;
            x = -1;
            y = -1;
            linije.Last().Add(e.Location);
            this.Invalidate();
        }

        private void pnlCrtanje_Paint(object sender, PaintEventArgs e)
        {
            DrawAll(e);
        }

        private void picOlovka_Click(object sender, EventArgs e)
        {
            p = new Pen(trenBoja, (int)numVelicina.Value);
        }

        private void picGumica_Click(object sender, EventArgs e)
        {
            p = new Pen(pnlCrtanje.BackColor, 30);
        }

        private void picCrvena_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            trenBoja = pic.BackColor;
            p = new Pen(trenBoja, trenVelicina);
        }

        private void numVelicina_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            trenVelicina = (int)num.Value;
            p = new Pen(trenBoja, trenVelicina);
        }

        private void picClear_Click(object sender, EventArgs e)
        {
            g.Clear(pnlCrtanje.BackColor);
        }

        private void picUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void Undo()
        {
            //...
            Rectangle rectangle = new Rectangle(0, 0, pnlCrtanje.Width, pnlCrtanje.Height);
            PaintEventArgs e = new PaintEventArgs(g, rectangle);
            Pen pen = new Pen(pnlCrtanje.BackColor, (int)numVelicina.Value + 2);
            if (linije.Count > 0) {
                e.Graphics.DrawLines(pen, this.linije.Last().ToArray());
                this.linije.RemoveAt(linije.Count - 1);
                this.Invalidate();
            }
        }

        /*private void picTekst_Click(object sender, EventArgs e)
        {
            t.Location = new Point(20, 50);
            f2.Controls.Add(t);
            Button b = new Button();
            b.Click += new System.EventHandler(b_Click);
            b.Size = new Size(100, 30);
            b.Text = "OK";
            b.Location = new Point(20, 90);
            f2.Controls.Add(b);
            f2.Text = "Dodaj text";
            f2.Show();
        }
        private void b_Click(Object sender, EventArgs e)
        {
            label = new Label();
            if (t.Text != "")
            {
                label.Text = t.Text;
                label.Location = new Point(0, 0);
                pnlCrtanje.Controls.Add(label);
                label.BackColor = Color.Transparent;
                label.MouseDown += new System.Windows.Forms.MouseEventHandler(label_MouseDown);
                label.MouseUp += new System.Windows.Forms.MouseEventHandler(label_MouseUp);
                label.MouseMove += new System.Windows.Forms.MouseEventHandler(label_MouseMove);
            }
            f2.Close();
        }
        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            pom = true;
        }

        private void label_MouseUp(object sender, MouseEventArgs e)
        {
            pom = false;
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            if (pom)
            {
                label.Location = new Point(label.Location.X + e.Location.X, label.Location.Y + e.Location.Y);
            }
        }*/
        public void DrawAll(PaintEventArgs e)
        {
            foreach (var item in linije) {
                e.Graphics.DrawLines(p, item.ToArray());
            }
        }
    }
}



