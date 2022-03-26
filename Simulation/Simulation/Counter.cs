using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    class Counter
    {
        static List<Counter> lista = new List<Counter>();
        static Dictionary<string, int> darab = new Dictionary<string, int>();
        public string nev;
        Label cimke;
        public Counter(string nev, Panel panel)
        {
            darab.Add(nev, 1);
            this.nev = nev;

            int letolas = (darab.Count() - 1) * 20;
            this.cimke = new Label();
            this.cimke.Text = (nev + ": " + (darab[nev]).ToString());
            this.cimke.Location = new Point(0, 0 + letolas);
            this.cimke.AutoSize = true;
            panel.Controls.Add(cimke);

            Counter.lista.Add(this);
        }
        public static void Addolj(string nev)
        {
            darab[nev]++;
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].nev == nev)
                {
                    lista[i].cimke.Text = (nev + ": " + (darab[nev]).ToString());
                    break;
                }
            }
        }
        public static void Vegyél_el(string nev)
        {
            darab[nev]--;
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].nev == nev)
                {
                    lista[i].cimke.Text = (nev + ": " + (darab[nev]).ToString());
                    break;
                }
            }
        }
        public static void Törlés()
        {
            lista.Clear();
            darab.Clear();
        }
    }
}
