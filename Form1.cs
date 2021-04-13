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
        public DePicto()
        {
            InitializeComponent();
            g = pnlCrtanje.CreateGraphics();
            trenVelicina = 3;
            p = new Pen(Color.Black, trenVelicina);
            x = -1; y = -1;
            trenBoja = Color.Black;
        }

        private void pnlCrtanje_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlCrtanje_MouseDown(object sender, MouseEventArgs e)
        {
            pomeranje = true;
            x = e.X;
            y = e.Y;
        }

        private void pnlCrtanje_MouseMove(object sender, MouseEventArgs e)
        {
            if (pomeranje && x != -1 && x != -1)
            {
                g.DrawLine(p, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void picOlovka_Click(object sender, EventArgs e)
        {
            p = new Pen(trenBoja, trenVelicina);
        }

        private void picGumica_Click(object sender, EventArgs e)
        {
            p = new Pen(BackColor, 30);
        }

        private void pnlCrtanje_MouseUp(object sender, MouseEventArgs e)
        {
            pomeranje = false;
            x = -1;
            y = -1;
        }
    }
}



