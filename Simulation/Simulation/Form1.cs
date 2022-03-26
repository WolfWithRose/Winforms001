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
            new Agens(Nev.Text, nem, new Vektor(e.Location.X, e.Location.Y), 15, panel1);
            Agens.Rajzold_le_mind_ide(Kepernyo);
        }
        int het = 0;
        int ev = 0;
        private void metronom_Tick(object sender, EventArgs e)
        {
            //Agens.Monitor(panel1);
            Agens.Összes_lepattanás(Kepernyo);
            Agens.Összes_léptetése(label8);
            Agens.Összes_találkozás(panel1);
            Agens.Összes_születés(label6, panel1);
            Agens.Összes_halálozás();
            Agens.Söprögetés();
            Agens.Rajzold_le_mind_ide(Kepernyo);
            het++;
            if (het == 52)
            {
                ev++;
                label4.Text = ev.ToString();
                het = 0;
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Agens.Törlés();
            if (fut)
            {
                metronom.Stop();
                start.Text = "START";
                fut = !fut;
            }
            Agens.Rajzold_le_mind_ide(Kepernyo);
            het = 0;
            ev = 0;
            label4.Text = "0";
            label6.Text = "0";
            label8.Text = "0";
            Counter.Törlés();
            panel1.Controls.Clear();
        }
    }
}
