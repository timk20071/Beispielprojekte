using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _026_Förderband {
    internal class ReadPredefinedContent : ReadAutoInformationen {
        

        public List<Fahrzeug> listautos = new();
        public ReadPredefinedContent() {
            listautos.Add(new Fahrzeug("Rot", "Audi", 10));
            listautos.Add(new Fahrzeug("blau", "bmw", 100));
            listautos.Add(new Fahrzeug("grün", "mercedes", 1000));
        }

        public override List<Fahrzeug> getFahrzeuge() {
            return listautos;
        }
    }
}

