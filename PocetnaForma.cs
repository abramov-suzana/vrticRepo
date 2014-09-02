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
    /// Pocetna forma aplikacije
    /// </summary>
    public partial class PocetnaForma : Form
    {
        
        public PocetnaForma()
        {
            InitializeComponent();
            Baza b = new Baza();
            // Ovisno o prijavljenom tipu zaposlenika određene stvari postaju nevidljive
            switch (Baza.prijavljeniZaposlenik.TipZaposlenika)
            {
                case 1:
                    break;
                case 2:
                    {
                        djecaToolStripMenuItem.Enabled = false;
                        osobljeToolStripMenuItem.Enabled = false;
                    }
                    break;
                case 3:
                    {
                        osobljeToolStripMenuItem.Enabled = false;
                        računiToolStripMenuItem.Enabled = false;
                    }
                    break;
            }
            tslRod.Text += b.vratiRodendane();
        }
        /// <summary>
        /// Otvaranje popisa djece i postavljanje unutar glavne forme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popisDjeceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopisDjece popis = new PopisDjece(1);
            popis.MdiParent = this;
            popis.Dock = DockStyle.Fill;
            popis.Show();
           
        }

        /// <summary>
        /// Otvaranje popisa zaposlenika i postavljanje unutar glavne forme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popisOsobljaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopisOsoblja popis = new PopisOsoblja();
            popis.MdiParent = this;
            popis.Dock = DockStyle.Fill;
            popis.Show();
        }
        /// <summary>
        /// Otvaranje forme za unos (mjenjanje) zaposlenika i postavljenje iste unutar glavne forme aplikacije
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dodajZaposlenikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PodaciZaposlenika podaci = new PodaciZaposlenika();
            podaci.btnIzmjeni.Visible = false;
            podaci.MdiParent = this;
            podaci.Dock = DockStyle.Fill;
            podaci.Show();
        }
        /// <summary>
        /// Otvaranje forme za dodavanje novog djeteta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dodajDijeteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PodaciDjeteta podaci = new PodaciDjeteta(1);
            podaci.btnIzmjena.Visible = false;
            podaci.btnIspisi.Visible = false;
            podaci.MdiParent = this;
            podaci.Dock = DockStyle.Fill;
            podaci.Show();
        }

        private void evidencijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Evidencija podaci = new Evidencija();
            podaci.MdiParent = this;
            podaci.Dock = DockStyle.Fill;
            podaci.Show();
        }

        private void izdavanjeRačunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Izdajracun podaci = new Izdajracun();
            podaci.MdiParent = this;
            podaci.Dock = DockStyle.Fill;
            podaci.Show();
        }

        private void pregledIzvjestajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PregledIzvjestaja podaci = new PregledIzvjestaja();
            podaci.MdiParent = this;
            podaci.Dock = DockStyle.Fill;
            podaci.Show();
        }

        private void promjenaTarifeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromjeniTarifu podaci = new PromjeniTarifu();
            podaci.MdiParent = this;
            podaci.Dock = DockStyle.Fill;
            podaci.Show();
        }

       
    }
}
