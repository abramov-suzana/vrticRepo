using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vrtic
{
    /// <summary>
    /// Klasa koja predstavlja zaposlenika iz baze podataka
    /// </summary>
    class Zaposlenik
    {

        
        public string OIB { get; set; }
        public string ImeZaposlenika { get; set; }
        public string PrezimeZaposlenika { get; set; }
        public int TipZaposlenika { get; set; }
        public string Adresa { get; set; }
        public string KontaktBrojs { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        
    }
}
