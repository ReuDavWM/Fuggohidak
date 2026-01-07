using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuggohidak
{    public class Fuggohid
    {
        public int Helyezes { get; set; }
        public string Nev { get; set; }
        public string Hely { get; set; }
        public string Orszag { get; set; }
        public int Hossz { get; set; }
        public int Ev { get; set; }

        public Fuggohid(string sor)
        {
            var m = sor.Split('\t');
            Helyezes = int.Parse(m[0]);
            Nev = m[1];
            Hely = m[2];
            Orszag = m[3];
            Hossz = int.Parse(m[4]);
            Ev = int.Parse(m[5]);
        }
    }
}
