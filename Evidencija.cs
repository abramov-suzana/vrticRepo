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
    public partial class Evidencija : Form
    {
        public Evidencija()
        {
            InitializeComponent();
            popuniEvidenciju();
        }
        /// <summary>
        /// Popunja podatke s djecom iz dane grupe koju vodi odgajatelj
        /// </summary>
        public void popuniEvidenciju()
        {
            Baza b = new Baza();
            List<Dijete> lista = new List<Dijete>();
            lista =b.vratiDjecuPoGrupama();
            foreach(Dijete i in lista)
            {
                dgvEvidencija.Rows.Add(DateTime.Now.ToString(), i.OIB, i.ImeDjeteta, i.PrezimeDjeteta);
            }
        }
        /// <summary>
        /// Pohranjuje evidenciju prema zapisima iz datagridview-as
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPohrani_Click(object sender, EventArgs e)
        {
            
            Baza b = new Baza();
            foreach (DataGridViewRow redak in dgvEvidencija.Rows)
            {
                if (b.unesiEvidenciju(redak.Cells[0].Value.ToString(), (String)redak.Cells[1].Value, (bool)redak.Cells[4].Value, float.Parse(redak.Cells[5].Value.ToString()), float.Parse(redak.Cells[6].Value.ToString()),redak.Cells[7].Value.ToString()) > 0)
                {
                    MessageBox.Show("Evidentirano");
                }
                else
                {
                    MessageBox.Show("Nije evidentirano");
                }
            }
        }
    }
}
