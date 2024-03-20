using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _019_Türme_von_Hanoi_final {
    internal class Spielfeld {
        public int Anzscheiben { get; set;}
        public Stack Stab1 { get; set; }
        public Stack Stab2 { get; set; } 
        public Stack Stab3 { get; set; }

        public Stack[] Staebe = new Stack[3];
        
        public Spielfeld(int anzscheiben) {
            Stab1 = new Stack(anzscheiben);
            Stab2 = new Stack(anzscheiben);
            Stab3 = new Stack(anzscheiben);
            Staebe[0] = Stab1;
            Staebe[1] = Stab2;
            Staebe[2] = Stab3;
            Reset(anzscheiben);
            Anzscheiben = anzscheiben;
        }

        public Stack? ReturnStab(int id) {
            if (id < 4 && id > 0) {
                return Staebe[id - 1];
            }
            else {
                return null;
            }
        }

        public void Move(Stack Startstab,Stack Zielstab) {
            int? startwert = Startstab.Top.Data.Groessescheibe;
            
            if(Zielstab.Length == 0) {
                Zielstab.Push(Startstab.Top.Data);
                Startstab.Pop();
            }
                
            else {
                int Zielwert = Zielstab.Top.Data.Groessescheibe;
                if (Zielwert > startwert) {
                    Zielstab.Push(Startstab.Top.Data);
                    Startstab.Pop();
                }
                else {
                    Console.WriteLine("Es dürfen nur wertnidrigere Scheiben auf werthöheren gestapelt werden!");
                }
            }

            
        }

        public void Reset(int anzScheiben) {
            Remove();
            for (int i = anzScheiben; i > 0; i--) {
                Stab1.Push(new Scheiben(i));
            }
        }

        public void Remove() {
            Stab1.Top = null;
            Stab2.Top = null;
            Stab3.Top = null;
        }

        public void Print() {
            Console.WriteLine("|");
            Console.Write("Stab 1: ");
            Console.Write(Stab1.Print());
            Console.Write(Environment.NewLine);
            Console.Write("Stab 2: ");
            Console.Write(Stab2.Print());
            Console.Write(Environment.NewLine);
            Console.Write("Stab 3: ");
            Console.Write(Stab3.Print());
            Console.Write(Environment.NewLine);
            Console.WriteLine("|");
        }
    }
}