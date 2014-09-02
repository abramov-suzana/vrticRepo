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
    public partial class Izdajracun : Form
    {
        public Izdajracun()
        {
            InitializeComponent();
            popuni();
        }

        private void popuni()
        {
            // Ovo je jedini nacin da se ubaci tipka gore za izradu racuna -> dodajem je na zadnje mjesto i kazem izradi i tako se pokrece izdavanje racuna
            DataGridViewButtonColumn a = (DataGridViewButtonColumn)dgvPopis.Columns[dgvPopis.Columns.Count - 1];//0 1 3 n-1
            a.Name = "Izradi";
            a.HeaderText = "Izradi";
            a.Text = "Izradi";
            a.UseColumnTextForButtonValue = true;
            
         
            Baza b = new Baza();
            List<Dijete> lista = new List<Dijete>();
            lista = b.vratiSve("Dijete",1) as List<Dijete>;
            foreach(Dijete i in lista)
            {

                dgvPopis.Rows.Add(i.OIB, i.ImeDjeteta, i.PrezimeDjeteta);

            }
        }

        private void dgvPopis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Provjeri je pritisnuta tipka za izradu racuna
            if (e.ColumnIndex == (dgvPopis.Columns.Count - 1))
            {
                Racun r = new Racun(dgvPopis.Rows[e.RowIndex].Cells[0].Value.ToString());
                r.Show();
                // A        B           C
                //1
                //1
               // MessageBox.Show("kliknuta tipka");
            }
        }

    }
}
