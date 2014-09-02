using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vrtic
{
    /// <summary>
    /// Forma na kojoj ce se nalaziti popis svih zaposlenih osoba u vrticu
    /// </summary>
    public partial class PopisOsoblja : Form
    {
        public PopisOsoblja()
        {
            InitializeComponent();
            dohvatiSveZaposlenike();
        }
        /// <summary>
        /// Prikaz svih zaposlenika na datagridView, ovo cu promjenit da radi preko liste zaposlenika :)
        /// </summary>
        public void dohvatiSveZaposlenike()
        {
            Baza b = new Baza();
           List<Zaposlenik> lista =  new List<Zaposlenik>();
            lista =  b.vratiSve("Zaposlenik",1) as List<Zaposlenik>;
           foreach(Zaposlenik i in lista)
            {
                dgvPopisOsoblja.Rows.Add(i.OIB, i.ImeZaposlenika, i.PrezimeZaposlenika,i.Adresa);
            }
        }
        /// <summary>
        /// Prikaz zaposlenika na novoj formi
        /// na klik celije se otvaraju podaci za odabranog djelatnika 
        ///   PodaciZaposlenika podaci = new PodaciZaposlenika(); je lnija u kojoj se prebacuju podaci na novu formu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPopisOsoblja_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Baza b = new Baza();
            Zaposlenik zaposlenikZaPregled = new Zaposlenik();
            zaposlenikZaPregled=b.vratiJednog("Zaposlenik", dgvPopisOsoblja.Rows[e.RowIndex].Cells[0].Value.ToString()) as Zaposlenik;
              
            

            PodaciZaposlenika podaci = new PodaciZaposlenika();
            podaci.btnDodaj.Visible = false;
            podaci.tbAdresa.Text = zaposlenikZaPregled.Adresa;
            podaci.tbIme.Text = zaposlenikZaPregled.ImeZaposlenika;
            podaci.tbKontakBroj.Text = zaposlenikZaPregled.KontaktBrojs;
            podaci.tbOIB.Text = zaposlenikZaPregled.OIB;
            podaci.tbPrezime.Text = zaposlenikZaPregled.PrezimeZaposlenika;
            podaci.tbKorisnickoIme.Text = zaposlenikZaPregled.KorisnickoIme;
            podaci.tbLozinka.Text = zaposlenikZaPregled.Lozinka;
            podaci.cbTipZaposlenika.SelectedItem = zaposlenikZaPregled.TipZaposlenika;
            podaci.MdiParent = this.MdiParent;
            podaci.Show();
        }


    }
}
