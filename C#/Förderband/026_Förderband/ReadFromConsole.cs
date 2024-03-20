using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _026_Förderband {
    internal class ReadFromConsole : ReadAutoInformationen {
        public string? Marke { get; set; } = "Placeholder";
        public string? Farbe { get; set; }
        public int Gewicht { get; set; }

        public List<Fahrzeug> listautos = new();
        public ReadFromConsole() {
            Console.WriteLine("Gib die Autodaten ein und wenn du fertig bist, drücke Enter!");

            while (Marke != "") {
                Console.Write("Marke: ");
                Marke = Console.ReadLine();
                if (Marke != "") {
                    Console.Write("Farbe: ");
                    Farbe = Console.ReadLine();
                    Console.Write("Gewicht: ");
                    Gewicht = Convert.ToInt32(Console.ReadLine());
                    listautos.Add(new Fahrzeug(Farbe, Marke, Gewicht));
                }
            }
        }

        public override List<Fahrzeug> getFahrzeuge() {
            return listautos;
        }
    }
}