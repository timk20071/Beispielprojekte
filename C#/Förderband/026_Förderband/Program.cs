namespace _026_Förderband {
    internal class Program {
        static void Main(string[] args) {
            //Vorgefertigter userinput
            //ReadAutoInformationen rfc = new ReadPredefinedContent();

            ReadAutoInformationen rfc = new ReadFromConsole();

            //Vorgefertigte Liste für Reifen
            List<Reifen> listreifen = new List<Reifen>();
            listreifen.Add(new Reifen(15, 50, 'F', 15));
            listreifen.Add(new Reifen(20, 35, 'G', 12));
            listreifen.Add(new Reifen(30, 10, 'R', 20));

            //Umlagerung von List auf Förderband(Queue)
            List<Fahrzeug> fahrzeug = rfc.getFahrzeuge();
            Foerderband foerderband = new Foerderband();
            foreach(Fahrzeug f in fahrzeug) {
                foerderband.Enqueue(f);
            }

            Console.WriteLine(foerderband.ToString());
            Console.WriteLine();

            foerderband.Dequeue();
            

            //Reifen hinzufügen / Allwithreifenbauart
            foerderband.AddReifen(listreifen[1], 3);
            foerderband.AddReifen(listreifen[0], 2);
            Console.WriteLine(foerderband.allWithReifenBauart('G'));
        }
    }
}
