using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _026_Förderband {
    internal class Foerderband {
        public Node? Front = null;
        public Node? Back = null;
        public int minid = 0;
        public int maxid = 0;

        public Foerderband() { }

        public void Enqueue(Fahrzeug f) { 
            Node n = new Node(f);
            if(Back == null) {
                Back = n;
                Front = n;
                minid++;
            }
            else {
                Back.Next = n;
                Back = Back.Next;
            }
            maxid++;
        }

        public void Dequeue() {
            if(Front != null) { 
                Console.WriteLine("Entfernt: " + Front.Data.ToString());
                Front = Front.Next;
                minid++;
            }
            else {
                minid = 0;
            }
        } 

        public int NumberElements() { 
            if(minid != 0) {
                    return maxid - minid + 1;
            }
            return 0;
        }

        public Fahrzeug? GetObjectAtPosition(int position) {
            Node? temp = Front;
            if(position >= Front.Data.Id && position <= Back.Data.Id) { 
                for(int i = 0; i < position; i++) { 
                    temp = temp.Next;
                }
                return temp.Data;
            }
            return null;
        }

        public string allWithReifenBauart(char bauart) {
            Node? temp = Front;
            string str = String.Empty;
            while(temp != null) {
                if (temp.Data.Reifen.Bauart == bauart){
                    str += temp.Data.ToString() + "\t";
                    str += temp.Data.Reifen.GetReifenData() + "\n";
                }
                temp = temp.Next;
            }
            return str;
        }

        public void AddReifen(Reifen r, int id) {
            if(GetFahrzeugAtId(id) != null) { 
                Fahrzeug? f = GetFahrzeugAtId(id);
                if(f != null) {
                    f.Reifen = r;
                }

                // Console.WriteLine(f.ToString() + "\t" + f.Reifen.GetReifenData());
            }
            else {
                Console.WriteLine("Invalide id, Reifen konnte nicht hinzugefügt werden!");
            }
        }
        
        public Fahrzeug? GetFahrzeugAtId(int id) {
            Node? temp = Front;
            while(temp != null) {
                if(temp.Data.Id == id) {
                    return temp.Data;
                }
                temp = temp.Next;
            }
            return null;
        }
        public override string ToString() {
            string str = String.Empty;
            Node? temp = Front;
            while(temp != null) {
                str += temp.Data.ToString() + "\n";
                temp = temp.Next;
            }
            return str;
        }
    }
}
