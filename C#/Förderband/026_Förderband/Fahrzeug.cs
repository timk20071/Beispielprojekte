using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _026_Förderband {
    internal class Fahrzeug {
        public string Farbe {  get; set; }
        public string Marke { get; private set; }
        public int Gewicht { get; private set; }
        public int Id { get; set; }
        public Reifen? Reifen { get; set; } = null;
        public Fahrzeug(string farbe, string marke, int gewicht) {
            Farbe = farbe;
            Marke = marke;
            Gewicht = gewicht;
        }

        public override string ToString() {
            return $"{Id}\t{Farbe}\t{Marke}\t{Gewicht}";
        }

    }
}
