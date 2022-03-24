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
        public int nem;
        public Vektor hely;
        public Vektor seb;
        public int err;
        public bool kapcsolatban;
        public int term;
        //public int menny;
        public int ev;
        public int het;
        //public int eleje;
        //public int vege;

        public Brush toll;

        public Agens(string nev, int nem, Vektor hely, int err)
        {
            var er = new Random();
            Point p = new Point(er.Next(-10, 10), er.Next(-10, 10));
            this.nev = nev;
            this.nem = nem;
            this.hely = hely;            
            this.err = err;
            this.ev = 0;
            this.het = 0;

            if (nem == 1)
            {
                toll = new SolidBrush(Color.Blue);
                this.seb = new Vektor(p);
                this.kapcsolatban = false;
                this.term = -1;
            }
            else if (nem == 0)
            {
                toll = new SolidBrush(Color.Red);
                this.seb = new Vektor(p);
                this.kapcsolatban = false;
                this.term = -1;
            }
            else
            {
                toll = new SolidBrush(Color.Purple);
                this.seb = new Vektor(0, 0);
                this.kapcsolatban = true;
                this.term = er.Next(1, 10);
            }

            Agens.lista.Add(this);
        }

        public static void Rajzold_le_mind_ide(PictureBox Kepernyo)
        {
            Bitmap kep = new Bitmap(Kepernyo.Width, Kepernyo.Height);
            Graphics rajzolókészlet = Graphics.FromImage(kep);

            foreach (Agens agens in Agens.lista)
            {
                if (agens.kapcsolatban == false || agens.nem == 2)
                {
                    agens.Rajzoldle(rajzolókészlet, agens.err);
                }
            }
                
            Kepernyo.Image = kep;
            Kepernyo.Refresh();
        }
        void Rajzoldle(Graphics rajzolókészlet, int R)
        {
            int xp = (int)Math.Round(hely.X - R);
            int yp = (int)Math.Round(hely.Y - R);          
            rajzolókészlet.FillEllipse(this.toll, new Rectangle(xp, yp, 2 * R, 2 * R));
        }
        public static void Összes_léptetése()
        {
            foreach (Agens agens in Agens.lista)
            {
                agens.Léptet();
                agens.Öregedés();
            }
        }
        private void Léptet() => hely += seb;
        private void Öregedés()
        {
            het ++;
            if (het == 52)
            {
                ev += 1;
                het = 0;
            }
        }
        public static void Összes_lepattanás(PictureBox Kepernyo)
        {
            foreach (Agens agens in Agens.lista)
            {
                if (agens.hely.X >= Kepernyo.Width - agens.err)
                {
                    if (agens.seb.X > 0)
                    {
                        Vektor fordulas = new Vektor(-agens.seb.X, agens.seb.Y);
                        agens.seb = fordulas;
                    }                    
                }
                if (agens.hely.X <= 0 + agens.err)
                {
                    if (agens.seb.X < 0)
                    {
                        Vektor fordulas = new Vektor(-agens.seb.X, agens.seb.Y);
                        agens.seb = fordulas;
                    }
                }
                if (agens.hely.Y >= Kepernyo.Height - agens.err)
                {
                    if (agens.seb.Y > 0)
                    {
                        Vektor fordulas = new Vektor(agens.seb.X, -agens.seb.Y);
                        agens.seb = fordulas;
                    }                    
                }
                if (agens.hely.Y <= 0 + agens.err)
                {
                    if (agens.seb.Y < 0)
                    {
                        Vektor fordulas = new Vektor(agens.seb.X, -agens.seb.Y);
                        agens.seb = fordulas;
                    }
                }
            }
        }
        public static void Összes_találkozás()
        {
            for (int i = 0; i < lista.Count() - 1; i++)
            {
                for (int j = i + 1; j < lista.Count(); j++)
                {
                    if (Vektor.kétponttávolsága(lista[i].hely, lista[j].hely) <= lista[0].err*2)
                    {
                        if (lista[i].nem == lista[j].nem && lista[i].kapcsolatban == false && lista[j].kapcsolatban == false)
                        {
                            if (Vektor.kétponttávolsága(lista[i].hely + lista[i].seb, lista[j].hely + lista[j].seb) < Vektor.kétponttávolsága(lista[i].hely, lista[j].hely))
                            {
                                Vektor a = lista[i].seb;
                                Vektor b = lista[j].seb;
                                lista[i].seb = b;
                                lista[j].seb = a;
                            }                            
                        }
                        else if (lista[i].kapcsolatban == false && lista[j].kapcsolatban == false && lista[i].nev != lista[j].nev)
                        {
                            lista[i].kapcsolatban = true;
                            lista[j].kapcsolatban = true;
                            lista[i].seb = new Vektor (0, 0);
                            lista[j].seb = new Vektor (0, 0);
                            string nev = "";
                            if (lista[i].nem == 1)
                            {
                                nev = lista[i].nev;
                            }
                            else
                            {
                                nev = lista[j].nev;
                            }
                            new Agens(nev, 2, Vektor.felezőpont(lista[i].hely, lista[j].hely), 20);
                        }
                    }
                }
            }
        }
        public static void Összes_születés()
        {
            int z = lista.Count();
            for (int i = 0; i < z; i++)
            {
                if (lista[i].nem == 2)
                {
                    if (lista[i].term == lista[i].ev)
                    {
                        var er = new Random();
                        new Agens(lista[i].nev, er.Next(0, 2), lista[i].hely, 15);
                        lista[i].term = er.Next(1, 10);
                    }
                }
            }
        }
    }
}
