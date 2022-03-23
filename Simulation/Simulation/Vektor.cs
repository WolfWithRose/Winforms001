using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Simulation
{
    class Vektor
    {
        public Random R;
        public double X { get; set; }
        public double Y { get; set; }

        public Vektor(double x, double y) => (X, Y) = (x, y);
        public Vektor(Point P) => (X, Y) = ((double)P.X, (double)P.Y);

        public static Vektor operator +(Vektor a, Vektor b) => new Vektor(a.X + b.X, a.Y + b.Y);
        public static Vektor operator -(Vektor a, Vektor b) => new Vektor(a.X - b.X, a.Y - b.Y);
        public static double operator *(Vektor a, Vektor b) => a.X * b.X + a.Y * b.Y;
        public static Vektor operator *(double lambda, Vektor b) => new Vektor(lambda * b.X, lambda * b.Y);
        public static Vektor operator *(Vektor b, double lambda) => lambda * b;
        public double távolságnégyzete(Vektor b) => (this - b).HosszNégyzet();
        public static Vektor operator /(Vektor b, double lambda) => (1 / lambda) * b;
        public double HosszNégyzet() => X * X + Y * Y;
        public double Hossz() => Math.Sqrt(HosszNégyzet());
    }
}
