using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _026_Förderband {
    internal class Reifen {
        public int Breite {  get; set; }
        public int BreiteHoeheVerhaeltnis { get; set; }
        public char Bauart {  get; set; }
        public int Felgendurchesser;

        public Reifen(int breite,int breiteHoeheVerhaeltnis,char bauart,int felgendurchesser) {
            Breite = breite;
            BreiteHoeheVerhaeltnis = breiteHoeheVerhaeltnis;
            Bauart = bauart;
            Felgendurchesser = felgendurchesser;
        }

        public string GetReifenData() {
            return $"{Breite}/{BreiteHoeheVerhaeltnis} {Bauart} {Felgendurchesser}";
        }
    }
}
