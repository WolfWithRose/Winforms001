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

        public Agens(string nev, bool nem, Vektor hely, Panel panel)
        {
            this.nev = nev;
            this.nem = nem;
            this.hely = hely;
            this.seb = new Vektor(0, 0);
        }
    }
}
