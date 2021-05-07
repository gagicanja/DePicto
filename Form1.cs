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
    enum Mode { Linija, Elipsa, Pravougaonik }
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
        int k1, k2; bool klik, m;
        Form f2;
        TextBox t;
        Label label;
        Mode mode;
        Point p1;
        Point p2;
        List<Point> p1ListaL;
        List<Point> p2ListaL;
        List<Point> p1ListaE;
        List<Point> p2ListaE;
        List<Point> p1ListaP;
        List<Point> p2ListaP;
        public DePicto()
        {
            InitializeComponent();
            Inicijalizuj();
        }

        private void Inicijalizuj()
        {
            g = pnlCrtanje.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            numVelicina.Value = 3;
            p = new Pen(Color.Black, (int)numVelicina.Value);
            trenBoja = Color.Black;
            trenVelicina = (int)numVelicina.Value;
            linije = new List<List<Point>>();
            koordinate = new List<int>();
            x = -1; y = -1;
            klik = false; m = false; k1 = -1; k2 = -1;
            undo = new List<Action>();
            t = new TextBox();
            label = new Label();
            f2 = new Form();
            p1ListaL = new List<Point>();
            p2ListaL = new List<Point>();
            p1ListaE = new List<Point>();
            p2ListaE = new List<Point>();
            p1ListaP = new List<Point>();
            p2ListaP = new List<Point>();
            cmbOblici.SelectedIndex = 0;
            mode = Mode.Linija;
        }
        private void pnlCrtanje_MouseDown(object sender, MouseEventArgs e)
        {
            if (!checkOblici.Checked)
            {
                pomeranje = true;
                x = e.X;
                y = e.Y;
                linije.Add(new List<Point>());
                linije.Last().Add(e.Location);
            }
            else p1 = new Point(e.X, e.Y);
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
            if (!checkOblici.Checked)
            {
                pomeranje = false;
                x = -1;
                y = -1;
                if (linije.Count != 0)
                {
                    linije.Last().Add(e.Location);
                }
                this.Invalidate();
            }

            if (checkOblici.Checked)
            {
                p2 = new Point(e.X, e.Y);
                if (mode == Mode.Linija)
                {
                    NacrtajLiniju(p1, p2);
                }
                if (mode == Mode.Elipsa)
                {
                    NacrtajElipsu(p1,p2);
                }
                if (mode == Mode.Pravougaonik)
                {
                    NacrtajPravougaonik(p1,p2);
                }
            }
        }

        private void NacrtajLiniju(Point p1, Point p2)
        {
            g.DrawLine(p, p1, p2);
            p1ListaL.Add(p1);
            p2ListaL.Add(p2);
        }

        private void NacrtajElipsu(Point p1, Point p2)
        {
            Rectangle r = new Rectangle(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
            g.DrawEllipse(p, r);
            p1ListaE.Add(p1);
            p2ListaE.Add(p2);
        }

        private void NacrtajPravougaonik(Point p1, Point p2)
        {
            Rectangle r = new Rectangle(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
            g.DrawRectangle(p, r);
            p1ListaP.Add(p1);
            p2ListaP.Add(p2);
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
        private void picTekst_Click(object sender, EventArgs e)
        {
            m = true;
            t = new TextBox();
            t.Location = new Point(20, 50);
            f2.Controls.Add(t);
            Button b = new Button();
            b.Click += new System.EventHandler(b_Click);
            b.Size = new Size(100, 30);
            b.Text = "OK";
            b.Location = new Point(20, 90);
            f2.Controls.Add(b);
            f2.Text = "Dodaj text";
            if (klik && k1!=-1 && k2 != -1)
            {
                f2.Show();
                label.Location = new Point(k1, k2);
                pnlCrtanje.Controls.Add(label);
            }
            klik = false;
        }

        private void checkOblici_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        
        private void cmbOblici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbOblici.SelectedIndex == 0)
            {
                mode = Mode.Linija;
            }
            if(cmbOblici.SelectedIndex == 1)
            {
                mode = Mode.Elipsa;
            }
            if(cmbOblici.SelectedIndex == 2)
            {
                mode = Mode.Pravougaonik;
            }
        }

        private void b_Click(Object sender, EventArgs e)
        {
            label = new Label();
            if (t.Text != "")
            {
                label.Text = t.Text;
                /*label.MouseDown += new System.Windows.Forms.MouseEventHandler(label_MouseDown);
                label.MouseUp += new System.Windows.Forms.MouseEventHandler(label_MouseUp);
                label.MouseMove += new System.Windows.Forms.MouseEventHandler(label_MouseMove);*/
            }
            f2.Close();
            f2 = new Form();
            t = new TextBox();
        }
        /*private void label_MouseDown(object sender, MouseEventArgs e)
        {
            pom = true;
        }

        private void label_MouseUp(object sender, MouseEventArgs e)
        {
            pom = false;
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            Label lab = (Label)sender;
            if (pom)
            {
                lab.Location = new Point(lab.Location.X + e.Location.X, lab.Location.Y + e.Location.Y);
            }
        }*/

        private void pnlCrtanje_MouseClick(object sender, MouseEventArgs e)
        {
            if (m)
            {
                klik = true;
                k1 = e.X;
                k2 = e.Y;
            }

        }
        /*
        public Color PickColor(Panel pnl, Point lokacija)
        {
            Bitmap bmp = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(bmp, new Rectangle(0, 0, pnl.Width, pnl.Height));
            Color col = bmp.GetPixel(lokacija.X, lokacija.Y);
            MessageBox.Show(col.ToString());
            bmp.Dispose();
            return col;
        }

        private void picColorPick_Click(object sender, EventArgs e)
        {
            m = true;
            if (klik && k1 != -1 && k2 != -1)
            {
                Point lok = new Point(k1, k2);
                p.Color = PickColor(pnlCrtanje, lok);
            }
            klik = false;
            k1 = -1;
            k2 = -1;
        }
        */
        public void DrawAll(PaintEventArgs e)
        {
            foreach (var item in linije) {
                e.Graphics.DrawLines(p, item.ToArray());
            }
            for (int i = 0; i < p1ListaL.Count; i++)
            {
                g.DrawLine(p, p1ListaL[i], p2ListaL[i]);
            }
            for (int i = 0; i < p1ListaE.Count; i++)
            {
                Rectangle r = new Rectangle(Math.Min(p1ListaE[i].X, p2ListaE[i].X), Math.Min(p1ListaE[i].Y, p2ListaE[i].Y), Math.Abs(p1ListaE[i].X - p2ListaE[i].X), Math.Abs(p1ListaE[i].Y - p2ListaE[i].Y));
                g.DrawEllipse(p, r);
            }
            for (int i = 0; i < p1ListaP.Count; i++)
            {
                Rectangle r = new Rectangle(Math.Min(p1ListaP[i].X, p2ListaP[i].X), Math.Min(p1ListaP[i].Y, p2ListaP[i].Y), Math.Abs(p1ListaP[i].X - p2ListaP[i].X), Math.Abs(p1ListaP[i].Y - p2ListaP[i].Y));
                g.DrawRectangle(p, r);
            }
        }
    }
}



