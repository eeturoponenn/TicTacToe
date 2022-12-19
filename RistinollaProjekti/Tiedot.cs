using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace RistinollaProjekti
{

    public partial class Tiedot : Form
    {
        bool loytyi = true;
        string personsfile = "c:\\temp\\ristinolla.txt";
        Ristinolla paaformi = null;
        List<Pelaaja> pelaajat = new List<Pelaaja>();
        


        public void SerializeJSON(List<Pelaaja> input)
        {
            string json = JsonConvert.SerializeObject(input);

            System.IO.File.WriteAllText(personsfile, json);
        }

        public List<Pelaaja> DeserializeJSON()
        {
            if (File.Exists(personsfile))
            {
                using (StreamReader r = new StreamReader(personsfile))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Pelaaja>>(json);
                }
            }
            else
                return null;
        }
        public Tiedot(Ristinolla f1)
        {
            InitializeComponent();
            paaformi = f1;
           
            pelaajat = DeserializeJSON();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(pelaajat == null)
            {
                pelaajat = new List<Pelaaja>();
            }
            Pelaaja p1 = new Pelaaja();
            

            string Nimi = tbNimi.Text;
            int syntymavuosi = int.Parse(tbVuosi.Text);
            p1.Nimi = Nimi;

            p1.Syntymavuosi = syntymavuosi;
            

            foreach (Pelaaja item in pelaajat)
            {
                if (item.Nimi == tbNimi.Text)
                {
                    loytyi = false;
                }
            }
            if (loytyi)
            {
                pelaajat.Add(p1);
            }


            SerializeJSON(pelaajat);

            paaformi.setPelaajat();
            Close();



        }

        private void tbVuosi_Validating(object sender, CancelEventArgs e)
        {

            string errorMsg = "Anna syntymävuosi muotoon YYYY";
            string ikaStr = tbVuosi.Text.Trim();
            tbVuosi.Text = ikaStr;
            int ika;
            bool ok = int.TryParse(ikaStr, out ika);
            if (!ok || ika < 1000 || ika > 9999)
            {
                e.Cancel = true;
                tbVuosi.Select(0, tbVuosi.Text.Length);
               
                this.errorProvider1.SetError(tbVuosi, errorMsg);
            }
        }

        private void tbVuosi_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbVuosi, "");
        }
    }
}
