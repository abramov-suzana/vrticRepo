using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vrtic
{
    public partial class Racun : Form
    {
        // da se zna za koji oib trebam racun
        String oib;
        public Racun(string OIB)
        {
            InitializeComponent();
            oib = OIB;
        }

        private void Racun_Load(object sender, EventArgs e)
        {
            // preko dretve se hvata novi racun iz baze, te se u source reporta dodju informacije   PodaciRacunaBindingSource.Add(a); -> unutar metode koju poziva dretva
            Thread t = new Thread(new ThreadStart(dodajRacun));
            t.Start();
            reportViewer1.Refresh();
            reportViewer1.RefreshReport();
        }
        private void dodajRacun()
        {
            List<PodaciRacuna> racuni = new List<PodaciRacuna>();
            Baza b = new Baza();
            racuni = b.izvuciPodatkeDjeteta(this.oib);
            foreach (var a in racuni)
                PodaciRacunaBindingSource.Add(a);
            
        }
       

 
    }
}
