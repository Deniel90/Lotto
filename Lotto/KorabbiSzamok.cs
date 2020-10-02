using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class KorabbiSzamok
    {
        private int szam1, szam2, szam3, szam4, szam5;

        public KorabbiSzamok(int szam1, int szam2, int szam3, int szam4, int szam5)
        {
            this.szam1 = szam1;
            this.szam2 = szam2;
            this.szam3 = szam3;
            this.szam4 = szam4;
            this.szam5 = szam5;
        }

        public int Szam1 { get => szam1; set => szam1 = value; }
        public int Szam2 { get => szam2; set => szam2 = value; }
        public int Szam3 { get => szam3; set => szam3 = value; }
        public int Szam4 { get => szam4; set => szam4 = value; }
    }
}
