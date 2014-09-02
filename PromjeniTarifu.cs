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
    public partial class PromjeniTarifu : Form
    {
        public PromjeniTarifu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Baza b = new Baza();
            // prica o povratku int vrijednosti -> broj promjena unutar baze podataka
          int a =   b.promjeniTarife(txtprod.Text, txtred.Text);
          if (a > 0)
          {
              MessageBox.Show("Uspješno promijenjeno ");
          }
          else
              MessageBox.Show("Neuspjeh");
        }
    }
}
