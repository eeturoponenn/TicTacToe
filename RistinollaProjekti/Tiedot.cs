using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RistinollaProjekti
{
    public partial class Tiedot : Form
    {
        Ristinolla paaformi = null;
        public Tiedot(Ristinolla f1)
        {
            InitializeComponent();
            paaformi = f1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pelaaja p1 = default;
            p1.Nimi = tbNimi.Text;
            p1.Syntymavuosi = int.Parse(tbVuosi.Text);
            paaformi.setPelaajat(p1);
            Close();

            
            
        }
    }
}
