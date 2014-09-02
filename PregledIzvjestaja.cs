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
    public partial class PregledIzvjestaja : Form
    {
        public PregledIzvjestaja()
        {
            InitializeComponent();
            postaviVrijednosti();
        }
        /// <summary>
        /// Preuzimam listu iz baze
        /// </summary>
        private void postaviVrijednosti()
        {
            Baza b = new Baza();
            //ovo je lista iz baze b.vratiIzvjestaj() -> i ako je pretvorimo u array i dodamo u row tablice on ce to automatski prepoznat i dodat svaki dio kao ćeliju 
            List<List<string>> povrat = new List<List<string>>();
            povrat = b.vratiIzvjestaje();
            foreach(List<string> a in povrat)
            {
                
                    dgvPopis.Rows.Add(a.ToArray());
            }
   
        }
    }
}
