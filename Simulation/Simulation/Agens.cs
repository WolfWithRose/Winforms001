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
        static List<Tuple<Agens, Agens, Agens>> párok = new List<Tuple<Agens, Agens, Agens>>();
        public string nev;
        public int nem;
        public Vektor hely;
        public Vektor seb;
        public int err;
        public bool kapcsolatban;
        public int term;
        public int ev;
        public int het;
        public int eev;
        public bool ded;
        public int dex;

        public Brush toll;

        public Agens(string nev, int nem, Vektor hely, int err, int dex)
        {
            var er = new Random();
            Point p = new Point(er.Next(-10, 10), er.Next(-10, 10));
            this.nev = nev;
            this.nem = nem;
            this.hely = hely;            
            this.err = err;
            this.ev = 0;
            this.het = 0;
            this.ded = false;
            this.dex = dex;

            if (nem == 1)
            {
                toll = new SolidBrush(Color.Blue);
                this.seb = new Vektor(p);
                this.kapcsolatban = false;
                this.term = -1;
                this.eev = er.Next(49, 82);
            }
            else if (nem == 0)
            {
                toll = new SolidBrush(Color.Red);
                this.seb = new Vektor(p);
                this.kapcsolatban = false;
                this.term = -1;
                this.eev = er.Next(51, 87);
            }
            else
            {
                toll = new SolidBrush(Color.Purple);
                this.seb = new Vektor(0, 0);
                this.kapcsolatban = true;
                this.term = er.Next(1, 7);
                this.eev = 88;
            }

            Agens.lista.Add(this);
        }

        public static void Rajzold_le_mind_ide(PictureBox Kepernyo)
        {
            Bitmap kep = new Bitmap(Kepernyo.Width, Kepernyo.Height);
            Graphics rajzolókészlet = Graphics.FromImage(kep);

            foreach (Agens agens in Agens.lista)
            {
                if ((agens.kapcsolatban == false || agens.nem == 2)&&!agens.ded)
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
                if (ev == eev)
                {
                    ded = true;
                }
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
                    if (Vektor.kétponttávolsága(lista[i].hely, lista[j].hely) <= lista[0].err*2 && !lista[i].ded && !lista[j].ded)
                    {
                        if ((lista[i].nem == lista[j].nem && lista[i].kapcsolatban == false && lista[j].kapcsolatban == false))
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
                            new Agens(nev, 2, Vektor.felezőpont(lista[i].hely, lista[j].hely), 20, párok.Count()-1);
                            Tuple<Agens, Agens, Agens> t = new Tuple<Agens, Agens, Agens>(lista[i], lista[j], lista[lista.Count() - 1]);
                            párok.Add(t);
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
                if (lista[i].nem == 2 && !lista[i].ded)
                {
                    if (lista[i].term == lista[i].ev)
                    {
                        var er = new Random();
                        new Agens(lista[i].nev, er.Next(0, 2), lista[i].hely, 15, -1);
                        lista[i].term = er.Next(1, 10);
                    }
                }
            }
        }
        public static void Összes_halálozás()
        {
            int z = párok.Count() - 1;
            for (int i = 0; i < z; i++)
            {
                if (párok[i].Item1.ded == true)
                {
                    párok[i].Item2.kapcsolatban = false;
                    var er = new Random();
                    Point p = new Point(er.Next(-10, 10), er.Next(-10, 10));
                    párok[i].Item2.seb = new Vektor(p);

                    párok[i].Item3.ded = true;

                    párok.RemoveAt(i);
                    i--;
                    z--;
                }
                else if (párok[i].Item2.ded == true)
                {
                    párok[i].Item1.kapcsolatban = false;
                    var er = new Random();
                    Point p = new Point(er.Next(-10, 10), er.Next(-10, 10));
                    párok[i].Item1.seb = new Vektor(p);

                    párok[i].Item3.ded = true;

                    párok.RemoveAt(i);
                    i--;
                    z--;
                }
            }
        }
    }
}
