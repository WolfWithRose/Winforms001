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
        static List<Agens> agensek = new List<Agens>();
        public string nev;
        public bool nem;
        public Vektor hely;
        public Vektor v;

        Label nevcimke;
        public Brush toll;

        public Agens()
        {

        }
    }
}
