using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vrtic
{
    /// <summary>
    /// Forma koja sluzi za unos (mjenjanje) zaposlenika
    /// </summary>
    public partial class PodaciZaposlenika : Form
    {
        public PodaciZaposlenika()
        {
            InitializeComponent();
            popuniTipove();
        }
        /// <summary>
        /// Funkcija koja kupi sve unesene informacije te ih prosljeđuje za upis u bazu podataka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Zaposlenik zaposlenik = new Zaposlenik();
            Baza b = new Baza();
            zaposlenik.ImeZaposlenika = this.tbIme.Text;
            zaposlenik.PrezimeZaposlenika = this.tbPrezime.Text;
            zaposlenik.KontaktBrojs = this.tbKontakBroj.Text;
            zaposlenik.Adresa = this.tbAdresa.Text;
            zaposlenik.OIB = this.tbOIB.Text;
            zaposlenik.KorisnickoIme = this.tbKorisnickoIme.Text;
            zaposlenik.Lozinka = this.tbLozinka.Text;
            zaposlenik.TipZaposlenika = int.Parse(cbTipZaposlenika.SelectedItem.ToString());//Index ce oznacavat koji je tip (prema dogovoru), a stvarno ime ce bit ispisano na indexu npr. 0- admin,1-racunovodstvo itd....
           // Poziv baze
            b.Dodaj(zaposlenik,"Zaposlenik");
        }
        /// <summary>
        /// Puni combobox s tipovima zaposlenika
        /// </summary>
        private void popuniTipove()
        {
            Baza b = new Baza();
            foreach (int i in b.vratiSveTipove())
            {
                cbTipZaposlenika.Items.Add(i);
            }
        }
        /// <summary>
        /// Mjenja podatke o zaposleniku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIzmjeni_Click(object sender, EventArgs e)
        {
            Zaposlenik zaposlenik = new Zaposlenik();
            Baza b = new Baza();
            zaposlenik.ImeZaposlenika = this.tbIme.Text;
            zaposlenik.PrezimeZaposlenika = this.tbPrezime.Text;
            zaposlenik.KontaktBrojs = this.tbKontakBroj.Text;
            zaposlenik.Adresa = this.tbAdresa.Text;
            zaposlenik.OIB = this.tbOIB.Text;
            zaposlenik.KorisnickoIme = this.tbKorisnickoIme.Text;
            zaposlenik.Lozinka = this.tbLozinka.Text;
            zaposlenik.TipZaposlenika = int.Parse(cbTipZaposlenika.SelectedItem.ToString());//Index ce oznacavat koji je tip (prema dogovoru), a stvarno ime ce bit ispisano na indexu npr. 0- admin,1-racunovodstvo itd....
            b.Izmjeni(zaposlenik, "Zaposlenik");

        }
    }
}
