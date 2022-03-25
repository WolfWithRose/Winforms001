using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    public partial class Form1 : Form
    {
        public Random randr;
        public Form1()
        {
            InitializeComponent();

            DomainUpDown.DomainUpDownItemCollection collection = Nem.Items;
            collection.Add("Nő");
            collection.Add("Férfi");
            Nem.SelectedIndex = 0;
        }
        private void Kepernyo_MouseDown(object sender, MouseEventArgs e)
        {
            int nem = 0;
            if (Nem.Text == "Férfi")
            {
                nem = 1;
            }
            new Agens(Nev.Text, nem, new Vektor(e.Location.X, e.Location.Y), 15, -1);
            Agens.Rajzold_le_mind_ide(Kepernyo);
        }
        private void metronom_Tick(object sender, EventArgs e)
        {
            Agens.Összes_lepattanás(Kepernyo);
            Agens.Összes_léptetése();
            Agens.Összes_találkozás();
            Agens.Összes_születés();
            Agens.Összes_halálozás();
            Agens.Rajzold_le_mind_ide(Kepernyo);
        }

        bool fut = false;
        private void start_Click(object sender, EventArgs e) => Metronomkapcsolas();

        private void Metronomkapcsolas()
        {
            if (fut)
            {
                metronom.Stop();
                start.Text = "START";

            }
            else
            {
                metronom.Start();
                start.Text = "STOP";
            }
            fut = !fut;
        }
    }
}
