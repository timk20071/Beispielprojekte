namespace _019_Türme_von_Hanoi_final {
    internal class Program {
        static void Main(string[] args) {
            int anzscheiben;


            Console.WriteLine("***** Türme von Hanoi *****\n\n");


            Console.WriteLine("Druecke:\n" +
                "\t1...Rekursive Lösung (Lösung vom Programm)\n" +
                "\t2...Iterative Lösung (Benutzereingabe)\n");
            
            switch (Convert.ToInt32(Console.ReadLine())) {
                
                case 1:
                    Console.Write("Anzahl der scheiben, mit denen gespielt werden soll:");
                    anzscheiben = Convert.ToInt32(Console.ReadLine());
                    SpielfeldRekursiv com = new SpielfeldRekursiv(anzscheiben);
                    com.Solve(anzscheiben,com.Stab1,com.Stab3,com.Stab2);
                    break;
                case 2:
                    int startstab;
                    int zielstab;
                    Console.Write("Anzahl der scheiben, mit denen gespielt werden soll:");
                    anzscheiben = Convert.ToInt32(Console.ReadLine());
                    SpielfeldIterativ sp = new SpielfeldIterativ(anzscheiben);
                    Console.WriteLine("Druecke:\n" +
                        "\t1...Neues Spiel\n" +
                        "\t2...Letztes Spiel laden\n");
                    switch (Convert.ToInt32(Console.ReadLine())) {
                        case 1:
                            break;

                        case 2:
                            sp.Read();
                            break;

                        default:
                            Console.WriteLine("Ungültige Eingabe!");
                            break;
                    }
                    

                    while (true) {
                        Console.Write("Wähle den Startstab: ");
                        startstab = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Wähle den Zielstab: ");
                        zielstab = Convert.ToInt32(Console.ReadLine());
                        sp.MoveIterativ(startstab, zielstab);
                    }
                default:
                    Console.WriteLine("Ungültige Eingabe!");
                    break;
            }
        }
    }
}