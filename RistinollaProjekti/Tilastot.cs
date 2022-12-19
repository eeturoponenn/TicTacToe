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
    public partial class Tilastot : Form
    {
        string personsfile = "c:\\temp\\ristinolla.txt";
        List<Pelaaja> pelaajat = new List<Pelaaja>();
        

        public Tilastot()
        {
            InitializeComponent();
            pelaajat = DeserializeJSON();
            dgvTilastot.DataSource = pelaajat;
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

    }
}
