using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _019_Türme_von_Hanoi_final {
    internal class SpielfeldRekursiv : Spielfeld {
        int anzzuege = 0;
        public SpielfeldRekursiv(int anzscheiben) : base(anzscheiben) { }

        public void Solve(int n,Stack Startstab, Stack Zielstab, Stack Tempstab) {
            if(n > 0) {
                Thread.Sleep(250);
                Solve(n - 1,Startstab,Tempstab,Zielstab);
                anzzuege++;
                Move(Startstab, Zielstab);
                Print();
                Solve(n - 1, Tempstab, Zielstab, Startstab);
                anzzuege++;
            }
        }

    }
}
