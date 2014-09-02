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
    /// Forma na kojoj se nalaze podaci za upis(mjenjanje) djeteta
    /// </summary>
    public partial class PodaciDjeteta : Form
    {
        int nacin;
          public PodaciDjeteta(int nacin)
        {
            InitializeComponent();
            this.nacin = nacin;
            popuniGrupe();
        }
        /// <summary>
        /// Puni sve moguce grupe u combobox kako bi se dale odabrati
        /// </summary>
          private void popuniGrupe()
          {
              Baza b = new Baza();
              foreach(int i in b.vratiSveGrupe())
              {
                  cbGrupa.Items.Add(i);
              }
          }
        /// <summary>
        /// dodaje dijete u sustav
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
          private void btnDodajDijete_Click(object sender, EventArgs e)
          {
              
              Dijete NovoDijete = new Dijete();
              NovoDijete.OIB = this.tbOIB.Text;
              NovoDijete.ImeDjeteta = this.tbIme.Text;
              NovoDijete.PrezimeDjeteta = this.tbPrezime.Text;
              NovoDijete.ImeOca = this.tbOtacIme.Text;
              NovoDijete.PrezimeOca = this.tbOtacPrezime.Text;
              NovoDijete.ImeMajke = this.tbMajkaIme.Text;
              NovoDijete.PrezimeMajke = this.tbMajkaPrezime.Text;
              NovoDijete.Adresa = this.tbAdresa.Text;
              NovoDijete.KontaktBroj = this.tbKontaktBroj.Text;
              NovoDijete.DatumRodenja = this.dtpDatumRodenja.Value;
              NovoDijete.BrojGrupe = int.Parse(this.cbGrupa.SelectedItem.ToString());
              NovoDijete.Status = "1";
              Baza b = new Baza();
              if (this.nacin == 1)//upisuje se novo dijete
              {
                  if (b.Dodaj(NovoDijete, "Dijete") > 0)
                  {
                      MessageBox.Show("Novo dijete dodano");
                      this.Close();
                  }
                  else
                  {
                      MessageBox.Show("Dogodila se pogreška");
                  }
              }
              else//nacin == 0 -> dijete koje je bilo u jaslicama pa se opet koriste podaci -> dijete ne treba opet upisivat nego samo status 0 ->1
              {
                  if (b.Izmjeni(NovoDijete, "Dijete") > 0)
                  {
                      MessageBox.Show("Uspješna promjena");
                      this.Close();
                  }
                  else
                  {
                      MessageBox.Show("Dogodila se pogreška");
                  }
              }
            
          }
        /// <summary>
        /// Mjenja dijete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
          private void btnIzmjena_Click(object sender, EventArgs e)
          {
              Dijete NovoDijete = new Dijete();
              NovoDijete.OIB = this.tbOIB.Text;
              NovoDijete.ImeDjeteta = this.tbIme.Text;
              NovoDijete.PrezimeDjeteta = this.tbPrezime.Text;
              NovoDijete.ImeOca = this.tbOtacIme.Text;
              NovoDijete.PrezimeOca = this.tbOtacPrezime.Text;
              NovoDijete.ImeMajke = this.tbMajkaIme.Text;
              NovoDijete.PrezimeMajke = this.tbMajkaPrezime.Text;
              NovoDijete.Adresa = this.tbAdresa.Text;
              NovoDijete.KontaktBroj = this.tbKontaktBroj.Text;
              NovoDijete.DatumRodenja = this.dtpDatumRodenja.Value;
              // cb-> combobox -> selected item je vrijednost oznacena 
              NovoDijete.BrojGrupe = int.Parse(this.cbGrupa.SelectedItem.ToString());

              Baza b = new Baza();
              if(b.Izmjeni(NovoDijete, "Dijete")> 0)
              {
                  MessageBox.Show("Promjenjeni su podaci o djetetu");
                  this.Close();
              }
              else
              {
                  MessageBox.Show("Dogodila se pogreška");
              }
          }

          private void btnUpisano_Click(object sender, EventArgs e)
          {
              // ukoliko dijete je bilo u jaslicama prikaz sve djece koja imaju status 0
              PopisDjece popis = new PopisDjece(0);
              popis.MdiParent = this.MdiParent;
              popis.Show();
          }

          private void btnIspisi_Click(object sender, EventArgs e)
          {
              Dijete NovoDijete = new Dijete();
              NovoDijete.OIB = this.tbOIB.Text;
              NovoDijete.ImeDjeteta = this.tbIme.Text;
              NovoDijete.PrezimeDjeteta = this.tbPrezime.Text;
              NovoDijete.ImeOca = this.tbOtacIme.Text;
              NovoDijete.PrezimeOca = this.tbOtacPrezime.Text;
              NovoDijete.ImeMajke = this.tbMajkaIme.Text;
              NovoDijete.PrezimeMajke = this.tbMajkaPrezime.Text;
              NovoDijete.Adresa = this.tbAdresa.Text;
              NovoDijete.KontaktBroj = this.tbKontaktBroj.Text;
              NovoDijete.DatumRodenja = this.dtpDatumRodenja.Value;
              NovoDijete.BrojGrupe = int.Parse(this.cbGrupa.SelectedItem.ToString());
              NovoDijete.Status = "0";
              Baza b= new Baza();
                  if (b.Izmjeni(NovoDijete, "Dijete") > 0)
                  {
                      MessageBox.Show("Uspješna promjena");
                      this.Close();
                  }
                  else
                  {
                      MessageBox.Show("Dogodila se pogreška");
                  }
              
          }
       
    }
}
