using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _026_Förderband {
    internal class Node {
        public Fahrzeug Data {  get; set; }
        public Node? Next { get; set; } = null;
        public static int Id = 1;

        public Node(Fahrzeug data) {
            Data = data;
            Data.Id = Id;
            Id++;
        }
    }
}
