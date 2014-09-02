using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace vrtic
{   
       /// <summary>
       /// Forma na kojoj će se naci cijeli popis djece iz vrtica
       /// </summary>
    public partial class PopisDjece : Form
    {
        int nacin;
        public PopisDjece(int nacin)
        {
            // nacin-> status -> 0 koji su nekad davno bili upisani
            InitializeComponent();
            this.nacin = nacin;
            PopuniPodatke(nacin);
        }
        /// <summary>
        /// Puni podatke datagridViewva sa podacima djece
        /// </summary>
        public void PopuniPodatke(int nacin)
        {
            dgvPopisDjece.Rows.Clear();
            Baza b = new Baza();
           List<Dijete> dijete =  new List<Dijete>();
            if(nacin == 1)
            dijete= b.vratiSve("Dijete",1) as List<Dijete>;
            else
                dijete = b.vratiSve("Dijete", 0) as List<Dijete>;

            //poredas kao sto si tamo dodala 
          foreach (Dijete i in dijete)
            {
                dgvPopisDjece.Rows.Add(i.OIB, i.ImeDjeteta, i.PrezimeDjeteta, i.DatumRodenja, i.ImeOca, i.Adresa);
            }
        }
        /// <summary>
        /// Prikaz podataka o djetetu u zasbnoj formi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPopisDjece_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Baza b = new Baza();
            //tablica, oib je na prvom mjestu
          
          Dijete dijeteZaPregled = new Dijete();
          dijeteZaPregled = b.vratiJednog("Dijete", dgvPopisDjece.Rows[e.RowIndex].Cells[0].Value.ToString()) as Dijete;
         
          PodaciDjeteta podaciDjeteta = new PodaciDjeteta(this.nacin);
          if (nacin == 1)
          {
              podaciDjeteta.btnDodajDijete.Visible = false;
          }
                podaciDjeteta.tbOIB.Text = dijeteZaPregled.OIB;
          podaciDjeteta.tbIme.Text = dijeteZaPregled.ImeDjeteta;
          podaciDjeteta.tbPrezime.Text = dijeteZaPregled.PrezimeDjeteta;
          podaciDjeteta.tbOtacIme.Text = dijeteZaPregled.ImeOca;
          podaciDjeteta.tbOtacPrezime.Text = dijeteZaPregled.PrezimeOca;
          podaciDjeteta.tbMajkaIme.Text = dijeteZaPregled.ImeMajke;
          podaciDjeteta.tbMajkaPrezime.Text = dijeteZaPregled.PrezimeMajke;
          podaciDjeteta.tbKontaktBroj.Text = dijeteZaPregled.KontaktBroj;
          podaciDjeteta.tbAdresa.Text = dijeteZaPregled.Adresa;
          podaciDjeteta.dtpDatumRodenja.Value = dijeteZaPregled.DatumRodenja.Date;
          podaciDjeteta.cbGrupa.SelectedItem = dijeteZaPregled.BrojGrupe;
          podaciDjeteta.MdiParent = this.MdiParent;
          this.Close();
          podaciDjeteta.Show();

        }
    }
}
