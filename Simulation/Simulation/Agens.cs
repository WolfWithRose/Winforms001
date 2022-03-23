using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    class Agens
    {
        static List<Agens> lista = new List<Agens>();
        public string nev;
        public bool nem;
        public Vektor hely;
        public Vektor seb;
        //public int term;
        //public int ev;
        //public int eleje;
        //public int vege;

        public Brush toll;

        public Agens(string nev, bool nem, Vektor hely)
        {
            var er = new Random();
            Point p = new Point(er.Next(-10, 10), er.Next(-10, 10));
            this.nev = nev;
            this.nem = nem;
            this.hely = hely;
            this.seb = new Vektor(p);

            if (nem)
            {
                toll = new SolidBrush(Color.Blue);
            }
            else
            {
                toll = new SolidBrush(Color.Red);
            }

            Agens.lista.Add(this);
        }

        public static void Rajzold_le_mind_ide(PictureBox Kepernyo)
        {
            Bitmap kep = new Bitmap(Kepernyo.Width, Kepernyo.Height);
            Graphics rajzolókészlet = Graphics.FromImage(kep);

            foreach (Agens agens in Agens.lista)
                agens.Rajzoldle(rajzolókészlet);

            Kepernyo.Image = kep;
            Kepernyo.Refresh();
        }
        void Rajzoldle(Graphics rajzolókészlet)
        {
            int R = 15;
            int xp = (int)Math.Round(hely.X - R);
            int yp = (int)Math.Round(hely.Y - R);          
            rajzolókészlet.FillEllipse(this.toll, new Rectangle(xp, yp, 2 * R, 2 * R));
        }
        public static void Összes_léptetése()
        {
            foreach (Agens agens in Agens.lista)
                agens.Léptet();
        }
        private void Léptet() => hely += seb;
        public static void Összes_lepattanás(PictureBox Kepernyo)
        {
            foreach (Agens agens in Agens.lista)
            {
                if (agens.hely.X > Kepernyo.Width || agens.hely.X < 0)
                {
                    Vektor fordulas = new Vektor(-agens.seb.X, agens.seb.Y);
                    agens.seb = fordulas;
                }                
                if (agens.hely.Y > Kepernyo.Height || agens.hely.Y < 0)
                {
                    Vektor fordulas = new Vektor(agens.seb.X, -agens.seb.Y);
                    agens.seb = fordulas;
                }
            }
        }
    }
}
