using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vrtic
{
    // Obicna klasa koja sluzi kao pomoc za obracun cijena

    class PodaciRacuna
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string SatiRedovni { get; set; }
        public DateTime Datum { get; set; }
        public string SatiPrekovremeni { get; set; }
        public float cijena { get; set; }
    }
}
