using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RistinollaProjekti
{
    public class Pelaaja
    {
        public string Nimi { get; set; }
        public int Syntymavuosi { get; set; }

        public int Voitot { get; set; }

        public int Tappiot { get; set; }

        public int Tasapelit { get; set; }

        public double PeliAikaSekunteina { get; set; }
    }
}
