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
    public partial class Prijava : Form
    {
        public Prijava()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Prijava na sustav
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrijava_Click(object sender, EventArgs e)
        {
            Baza b = new Baza();
            if (b.prijava(tbKorIme.Text, tbLozinka.Text))
            {
                //prijavljeni zaposlenik je staticka klasa tako da joj se moze od svugdje pristupat -> a uvijek ce biti samo jedan prijavljeni zaposlenik
                // Mozda vam tu singleton spomenu -> singleton je uzorak dizajna u kojem klasa se instancira samo jednom ali se pritom na svaki ponovni poziv vraca postojeca instanca
                // Osoba o =  new Osoba("Ana");
                // svaki put kad se bude sad pozivala nova Osoba imat ce ime Ana jer je tako prvi put postavljeno
                // google -> singleton (digresija ali mozda dobro dodje da znate)
                // Iako je i ovo dobro rjesenje :)
                MessageBox.Show("Uspješno prijavljen " + Baza.prijavljeniZaposlenik.ImeZaposlenika + " " + Baza.prijavljeniZaposlenik.PrezimeZaposlenika);
               
                PocetnaForma pocetna = new PocetnaForma();
                
                pocetna.Show();
               
            }
            else
            {
                MessageBox.Show("Neisprravan unos");
            }

        }
    }
}
