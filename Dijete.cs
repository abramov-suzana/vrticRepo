using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vrtic
{
    /// <summary>
    /// Klasa koja predstavlja tablicu iz baze podataka (za lakse rukovanje)
    /// </summary>
    class Dijete
    {
        public string tablica ="Dijete";
        public string OIB { get; set; }
        public string ImeDjeteta { get; set; }
        public string PrezimeDjeteta { get; set; }
        public string ImeOca { get; set; }
        public string PrezimeOca { get; set; }
        public string ImeMajke { get; set; }
        public string PrezimeMajke { get; set; }
        public string Adresa { get; set; }
        public string KontaktBroj { get; set; }
        public DateTime DatumRodenja { get; set; }
        public int BrojGrupe { get; set; }
        public string Status { get; set; }

        

       
    }
}
