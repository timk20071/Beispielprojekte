using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_Türme_von_Hanoi_final {
    internal class SpielfeldIterativ : Spielfeld {
        
        public SpielfeldIterativ(int anzscheiben) : base(anzscheiben) { 
        }

        public bool MoveIterativ(int startstab, int zielstab) {
            Stack? Startstab = ReturnStab(startstab);
            Stack? Zielstab = ReturnStab(zielstab);
            if (Startstab != Zielstab && Startstab != null &&  Zielstab != null) {
                Move(Startstab, Zielstab);
                Write();
                Print();
                Gewinnabpruefung();
                return true;
            }
            return false;
        }

        public void Gewinnabpruefung() {
            int i = 0;
            Node? temp = Stab3.Top;
            while(temp != null) {
                temp = temp.Next;
                i++;
            }

            if (Anzscheiben == i) {
                Console.WriteLine("Du hast gewonnen!");
                Environment.Exit(1);
            }
        }

        public void Read() {
            FileStream fs = new FileStream($"../../../savegame-{Anzscheiben}.txt",FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            if (!File.Exists("../../../savegame.txt")) {
                Console.WriteLine("File existiert nicht!");
                Environment.Exit(1);
            }
            string[] scheiben = new string[3];
/**/

            scheiben = sr.ReadToEnd().Trim().Split('E');
            string[] strstab;
            Remove();

            for (int i = 0; i < 3; i++){
                strstab = scheiben[i].Trim().Split(" ");
                if (strstab[0] != null && strstab[0] != "") {
                    foreach (string str in strstab) {
                        ReturnStab(i + 1).Push(new Scheiben(Convert.ToInt32(str.Trim())));
                    }
                }
                
            }
            sr.Close();
            fs.Close();
        }

        public void Write() {
        FileStream fs = new FileStream($"../../../savegame-{Anzscheiben}.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach(Stack s in Staebe) {
                sw.Write(s.Print() + "E");
            }
            sw.Close();
            fs.Close();
        }
    }
}