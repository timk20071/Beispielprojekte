using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_Türme_von_Hanoi_final {
    internal class Node {
        public Scheiben Data {  get; private set; }
        public Node? Next {  get; set; }

        public Node(Scheiben data) {
            Data = data;
        }

        
    }
}
