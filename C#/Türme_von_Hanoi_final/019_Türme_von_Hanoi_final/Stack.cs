using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _019_Türme_von_Hanoi_final {
    internal class Stack {
        public Node? Top { get; set;}
        public int Length = 0;
        public int Anzscheiben;
        public Stack(int anzscheiben) { 
            Anzscheiben = anzscheiben;
        }

        public void Push(Scheiben s) {
            Node n = new(s);
            if (Top == null) {
                Top = n;
            }
            else {
                n.Next = Top;
                Top = n;
            }
            Length++;
        }

        public void Pop() {
            if (Top != null) {
                Length--;
            }
            if (Top == null || Top.Next == null) 
                Top = null;
            else
                Top = Top.Next;
        }

        public string Print() {
            string str = String.Empty;
            if (Top != null) {
                int i = 0;
                int[] dataarr = new int[Anzscheiben];
                Node? temp = Top;
                while(temp != null) {
                    dataarr[i] = temp.Data.Groessescheibe;
                    temp = temp.Next;
                    i++;
                }
                for(int j = i; j >= 1; j--) {
                    str += dataarr[j -1] + " ";
                }

                
            }
            return str;
        }
    }
}