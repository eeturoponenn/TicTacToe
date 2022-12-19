using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace RistinollaProjekti
{
    public partial class Ristinolla : Form
    {
        Random rnd = new Random();
        int sekunti = 0;

        int[] ristinolla = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };  //-1 tyhjä, 0 nolla ja  1 risti
        int vuoro = 1;  //0 = nolla
                        // 1 = risti
        string personsfile = "c:\\temp\\ristinolla.txt";

        bool aloita;

        bool loytyi = true;

        List<Pelaaja> pelaajat = new List<Pelaaja>();

        Pelaaja p1 = new Pelaaja();

        public void TallennaAikaX()
        {
            for (int i = 0; i < pelaajat.Count; i++)
            {
                if (pelaajat[i].Nimi == cmbPelaaja1.Text)
                {
                    pelaajat[i].PeliAikaSekunteina += sekunti;
                }
            }
        }
        public void TallennaAikaO()
        {
            for (int i = 0; i < pelaajat.Count; i++)
            {
                if (pelaajat[i].Nimi == cmbPelaaja2.Text)
                {
                    pelaajat[i].PeliAikaSekunteina += sekunti;
                }
            }
        }
        public void TallennaHavioO()
        {
            for (int i = 0; i < pelaajat.Count; i++)
            {
                if (pelaajat[i].Nimi == cmbPelaaja2.Text)
                {
                    pelaajat[i].Tappiot++;
                }
            }

        }
        public void TallennaHavioX()
        {

            for (int i = 0; i < pelaajat.Count; i++)
            {
                if (pelaajat[i].Nimi == cmbPelaaja1.Text)
                {
                    pelaajat[i].Tappiot++;
                }
            }
        }
        public void TallennaVoittoO()
        {

            for (int i = 0; i < pelaajat.Count; i++)
            {
                if (pelaajat[i].Nimi == cmbPelaaja2.Text)
                {
                    pelaajat[i].Voitot++;
                }
            }
        }
        public void TallennaVoittoX()
        {

            for (int i = 0; i < pelaajat.Count; i++)
            {
                if (pelaajat[i].Nimi == cmbPelaaja1.Text)
                {
                    pelaajat[i].Voitot++;
                }
            }
        }
        public void TallennaTasapeli()
        {
            for (int i = 0; i < pelaajat.Count; i++)
            {
                if (pelaajat[i].Nimi == cmbPelaaja2.Text || pelaajat[i].Nimi == cmbPelaaja1.Text)
                {
                    pelaajat[i].Tasapelit++;
                }
            }
        }
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

        public Ristinolla()
        {
            InitializeComponent();
            FileInfo ristinolla = new FileInfo("c:\\temp\\ristinolla.txt");     //Tekee alkuun ristinolla.txt tiedoston jos sitä ei ole jo.
            if (ristinolla.Exists == false)
            {
                ristinolla.Create();
            }
            
            setPelaajat();

            btnAloita.Enabled = false;



        }

        public void Uudestaan1()
        {
            tmrKello.Enabled = false;   //Pysäyttää kellon, koska peli päättyi
            DialogResult dr = MessageBox.Show(cmbPelaaja1.Text + " voitti!\n\nHaluatko pelata uudestaan?", "Vastaa", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                TallennaVoittoX();
                TallennaHavioO();
                TallennaAikaO();
                TallennaAikaX();
                SerializeJSON(pelaajat);
                Application.Restart();
            }
            else if (dr == DialogResult.No)
            {
                TallennaVoittoX();
                TallennaHavioO();
                TallennaAikaO();
                TallennaAikaX();
                SerializeJSON(pelaajat);
                Application.Exit();
            }
        }
        public void Uudestaan2()
        {
            tmrKello.Enabled = false; //Pysäyttää kellon, koska peli päättyi
            DialogResult dr = MessageBox.Show(cmbPelaaja2.Text + " voitti!\n\nHaluatko pelata uudestaan?", "Vastaa", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                TallennaHavioX();
                TallennaVoittoO();
                TallennaAikaO();
                TallennaAikaX();
                SerializeJSON(pelaajat);
                Application.Restart();
            }
            else if (dr == DialogResult.No)
            {
                TallennaHavioX();
                TallennaVoittoO();
                TallennaAikaO();
                TallennaAikaX();
                SerializeJSON(pelaajat);
                Application.Exit();
            }
        }

        public void VoittoVaiTasapeli()
        {
            if
              (ristinolla[0] == -1 ||
               ristinolla[1] == -1 ||
               ristinolla[2] == -1 ||
               ristinolla[3] == -1 ||
               ristinolla[4] == -1 ||
               ristinolla[5] == -1 ||
               ristinolla[6] == -1 ||
               ristinolla[7] == -1 ||
               ristinolla[8] == -1)
            {
                TestaaVoittaja();

            }
            else
            {
                TestaaVoittaja();
                tmrKello.Enabled = false;       //Pysäyttää kellon, koska peli päättyi
                DialogResult dr = MessageBox.Show("Tasapeli!\n\nHaluatko pelata uudestaan?", "Vastaa", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {

                    TallennaTasapeli();
                    TallennaAikaO();
                    TallennaAikaX();
                    SerializeJSON(pelaajat);
                    Application.Restart();
                }
                else if (dr == DialogResult.No)
                {
                    TallennaTasapeli();
                    TallennaAikaO();
                    TallennaAikaX();
                    SerializeJSON(pelaajat);
                    Application.Exit();
                }
            }
        }

        public void TestaaVoittaja()
        {
            if (ristinolla[0] == 1 && ristinolla[1] == 1 && ristinolla[2] == 1)
            {
                panel1.BackColor = Color.Coral;
                panel2.BackColor = Color.Coral;
                panel3.BackColor = Color.Coral;
                Uudestaan1();
            }
            else if (ristinolla[3] == 1 && ristinolla[4] == 1 && ristinolla[5] == 1)
            {
                panel4.BackColor = Color.Coral;
                panel5.BackColor = Color.Coral;
                panel6.BackColor = Color.Coral;
                Uudestaan1();
            }
            else if (ristinolla[6] == 1 && ristinolla[7] == 1 && ristinolla[8] == 1)
            {
                panel7.BackColor = Color.Coral;
                panel8.BackColor = Color.Coral;
                panel9.BackColor = Color.Coral;
                Uudestaan1();
            }
            else if (ristinolla[0] == 1 && ristinolla[3] == 1 && ristinolla[6] == 1)
            {
                panel1.BackColor = Color.Coral;
                panel4.BackColor = Color.Coral;
                panel7.BackColor = Color.Coral;
                Uudestaan1();
            }
            else if (ristinolla[1] == 1 && ristinolla[4] == 1 && ristinolla[7] == 1)
            {
                panel2.BackColor = Color.Coral;
                panel5.BackColor = Color.Coral;
                panel8.BackColor = Color.Coral;
                Uudestaan1();
            }
            else if (ristinolla[2] == 1 && ristinolla[5] == 1 && ristinolla[8] == 1)
            {
                panel3.BackColor = Color.Coral;
                panel6.BackColor = Color.Coral;
                panel9.BackColor = Color.Coral;
                Uudestaan1();
            }
            else if (ristinolla[0] == 1 && ristinolla[4] == 1 && ristinolla[8] == 1)
            {
                panel1.BackColor = Color.Coral;
                panel5.BackColor = Color.Coral;
                panel9.BackColor = Color.Coral;
                Uudestaan1();
            }
            else if (ristinolla[6] == 1 && ristinolla[4] == 1 && ristinolla[2] == 1)
            {
                panel7.BackColor = Color.Coral;
                panel5.BackColor = Color.Coral;
                panel3.BackColor = Color.Coral;
                Uudestaan1();
            }
            else if (ristinolla[0] == 0 && ristinolla[1] == 0 && ristinolla[2] == 0)
            {
                panel1.BackColor = Color.Coral;
                panel2.BackColor = Color.Coral;
                panel3.BackColor = Color.Coral;
                Uudestaan2();
            }
            else if (ristinolla[3] == 0 && ristinolla[4] == 0 && ristinolla[5] == 0)
            {
                panel4.BackColor = Color.Coral;
                panel5.BackColor = Color.Coral;
                panel6.BackColor = Color.Coral;
                Uudestaan2();
            }
            else if (ristinolla[6] == 0 && ristinolla[7] == 0 && ristinolla[8] == 0)
            {
                panel7.BackColor = Color.Coral;
                panel8.BackColor = Color.Coral;
                panel9.BackColor = Color.Coral;
                Uudestaan2();
            }
            else if (ristinolla[0] == 0 && ristinolla[3] == 0 && ristinolla[6] == 0)
            {
                panel1.BackColor = Color.Coral;
                panel4.BackColor = Color.Coral;
                panel7.BackColor = Color.Coral;
                Uudestaan2();
            }
            else if (ristinolla[1] == 0 && ristinolla[4] == 0 && ristinolla[7] == 0)
            {
                panel2.BackColor = Color.Coral;
                panel5.BackColor = Color.Coral;
                panel8.BackColor = Color.Coral;
                Uudestaan2();
            }
            else if (ristinolla[2] == 0 && ristinolla[5] == 0 && ristinolla[8] == 0)
            {
                panel3.BackColor = Color.Coral;
                panel6.BackColor = Color.Coral;
                panel9.BackColor = Color.Coral;
                Uudestaan2();
            }
            else if (ristinolla[0] == 0 && ristinolla[4] == 0 && ristinolla[8] == 0)
            {
                panel1.BackColor = Color.Coral;
                panel5.BackColor = Color.Coral;
                panel9.BackColor = Color.Coral;
                Uudestaan2();
            }
            else if (ristinolla[6] == 0 && ristinolla[4] == 0 && ristinolla[2] == 0)
            {
                panel7.BackColor = Color.Coral;
                panel5.BackColor = Color.Coral;
                panel3.BackColor = Color.Coral;
                Uudestaan2();
            }
        }  // if-elsellä käyty kaikki voitto mahdollisuudet läpi ristillä ja nollalla.
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Panel panel = (Panel)sender;
            Pen pen = new Pen(Color.Black);
            SolidBrush myBrush = new SolidBrush(Color.Red);
            Graphics formGraphics;
            formGraphics = panel.CreateGraphics();

            int index = int.Parse(panel.Tag.ToString());

            if (ristinolla[index] == 1)
            {
                formGraphics.DrawLine(pen, 0, 0, panel.Width, panel.Height);
                formGraphics.DrawLine(pen, 0, panel.Height, panel.Width, 0);
                

            }
            else if (ristinolla[index] == 0)
            {

                
                formGraphics.FillEllipse(myBrush, 0, 0, panel.Width, panel.Height);
                


            }
            
            myBrush.Dispose();
            pen.Dispose();
            formGraphics.Dispose();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            
            if (aloita)
            {
            
                Panel p = (Panel)sender;

                int index = int.Parse(p.Tag.ToString());

                if (cbTietokone.Checked == false)       //Kaveria vastaan
                {
                    

                    if (ristinolla[index] == -1)
                    {

                        ristinolla[index] = vuoro;
                        vuoro = vuoro == 0 ? 1 : 0;

                        if (vuoro == 1)
                        {
                            tsslPelaaja.Text = cmbPelaaja1.Text + "n vuoro";
                            panelPelaaja1.BackColor = Color.Green;
                            panelPelaaja2.BackColor = Color.White;

                        }
                        else
                        {
                            tsslPelaaja.Text = cmbPelaaja2.Text + "n vuoro";
                            panelPelaaja2.BackColor = Color.Green;
                            panelPelaaja1.BackColor = Color.White;

                        }
                        p.Refresh();
                        
                    }
                    

                }
                else if(cbTietokone.Checked == true)           //Tietokonetta vastaan
                {
                    
                        if (ristinolla[index] == -1)
                        {
                            
                            ristinolla[index] = vuoro;
                            vuoro = vuoro == 0 ? 1 : 0;

                              if (vuoro == 1)
                              {


                                     tsslPelaaja.Text = cmbPelaaja1.Text + "n vuoro";
                                     panelPelaaja1.BackColor = Color.Green;



                              }
                              else
                              {
                            
                                  Tietokone();  //Tein erikseen "tekoälyn" toiselle funktioille kun if-elseä tuli joku 350 riviä.
                                  

                              }

                        
                        p.Refresh();

                        

                        
                        }
                    
                }
                VoittoVaiTasapeli();
            }

        }

            
        
        private void button1_Click(object sender, EventArgs e)
        {
            Tiedot tiedot = new Tiedot(this);
           
            tiedot.Show();
        }

        public void setPelaajat()
        {
            pelaajat = DeserializeJSON();


            BindingContext bcG1 = new BindingContext();

            cmbPelaaja1.BindingContext = bcG1;

            cmbPelaaja1.DataSource = pelaajat;
            cmbPelaaja1.DisplayMember = "Nimi";
            cmbPelaaja1.ValueMember = "Nimi";

            cmbPelaaja2.DataSource = pelaajat;
            cmbPelaaja2.DisplayMember = "Nimi";
            cmbPelaaja2.ValueMember = "Nimi";






        }

        private void btnAloita_Click(object sender, EventArgs e)
        {
            tsslPelaaja.Text = cmbPelaaja1.Text + "n vuoro";  // Alkuun aina on 1. pelaajan vuoro.

            panelPelaaja1.BackColor = Color.Green;
            panelPelaaja2.BackColor = Color.White;

            aloita = true;      // aloita saa true arvon jonka avulla pystyy alkaa klikkailemaan ruutuja


            tmrKello.Enabled = true;        // Kello lähtee käyntiin.

            panel1.BackColor = Color.CadetBlue;
            panel2.BackColor = Color.CadetBlue;
            panel3.BackColor = Color.CadetBlue;
            panel4.BackColor = Color.CadetBlue;
            panel5.BackColor = Color.CadetBlue;                 //Visuaalinen muutos kun peli lähtee käyntiin.
            panel6.BackColor = Color.CadetBlue;
            panel7.BackColor = Color.CadetBlue;
            panel8.BackColor = Color.CadetBlue;
            panel9.BackColor = Color.CadetBlue;



        }

        private void cmbPelaaja1_Leave(object sender, EventArgs e)
        {
            if(cmbPelaaja1.Text != "" && cmbPelaaja2.Text != "")
            {
                btnAloita.Enabled = true;
                tsmiAloita.Enabled = true;       // Silloin vasta kun molemmissa combobokseissa tekstiä niin aloita nappi tulee käyntiin.
            }
        }

        private void tmrKello_Tick(object sender, EventArgs e)
        {
            sekunti++;
        }

        private void cbTietokone_CheckedChanged(object sender, EventArgs e)
        {
            if(cbTietokone.Checked == true)            
            {
                cmbPelaaja2.Enabled = false;
                cmbPelaaja2.Text = "Tietokone";
            }                                           
            else
            {
                cmbPelaaja2.Enabled = true;
                cmbPelaaja2.Text = "";
            }

            if (pelaajat == null)
            {
                pelaajat = new List<Pelaaja>();
            }

            p1.Nimi = "Tietokone";

            p1.Syntymavuosi = 10101;

            
            foreach (Pelaaja item in pelaajat)
            {
                if (item.Nimi == "Tietokone")
                {
                    loytyi = false;                         // Tehdään tietokoneelle oma "pelaaja profiili" niin voi seurata tietokoneen tilastoja
                }
            }
            if (loytyi)
            {
                pelaajat.Add(p1);
            }
        }

        public void Tietokone()
        {
            for (int i = 0; i < 9; i++)
            {
                
                if (ristinolla[0] == 1 && ristinolla[1] == 1 && ristinolla[2] == -1)
                {
                    
                    ristinolla[2] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;

                }
                else if (ristinolla[3] == 1 && ristinolla[4] == 1 && ristinolla[5] == -1)
                {
                    ristinolla[5] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[6] == 1 && ristinolla[7] == 1 && ristinolla[8] == -1)
                {
                    ristinolla[8] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[3] == -1 && ristinolla[4] == 1 && ristinolla[5] == 1)
                {
                    ristinolla[3] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[3] == 1 && ristinolla[4] == -1 && ristinolla[5] == 1)
                {
                    ristinolla[4] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[6] == -1 && ristinolla[7] == 1 && ristinolla[8] == 1)
                {
                    ristinolla[6] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[6] == 1 && ristinolla[7] == -1 && ristinolla[8] == 1)
                {
                    ristinolla[7] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[0] == 1 && ristinolla[1] == -1 && ristinolla[2] == 1)
                {
                    ristinolla[1] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[0] == 1 && ristinolla[4] == 1 && ristinolla[8] == -1)
                {
                    ristinolla[8] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[0] == -1 && ristinolla[4] == 1 && ristinolla[8] == 1)
                {
                    ristinolla[0] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[0] == 1 && ristinolla[4] == -1 && ristinolla[8] == 1)
                {
                    ristinolla[4] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[6] == 1 && ristinolla[4] == 1 && ristinolla[2] == -1)
                {
                    ristinolla[2] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[6] == -1 && ristinolla[4] == 1 && ristinolla[2] == 1)
                {
                    ristinolla[6] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[6] == 1 && ristinolla[4] == -1 && ristinolla[2] == 1)
                {
                    ristinolla[4] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[0] == 1 && ristinolla[3] == 1 && ristinolla[6] == -1)
                {
                    ristinolla[6] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[0] == -1 && ristinolla[3] == 1 && ristinolla[6] == 1)
                {
                    ristinolla[0] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[0] == 1 && ristinolla[3] == -1 && ristinolla[6] == 1)
                {
                    ristinolla[3] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[1] == 1 && ristinolla[4] == 1 && ristinolla[7] == -1)
                {
                    ristinolla[7] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[1] == -1 && ristinolla[4] == 1 && ristinolla[7] == 1)
                {
                    ristinolla[1] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[1] == 1 && ristinolla[4] == -1 && ristinolla[7] == 1)
                {
                    ristinolla[4] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[2] == 1 && ristinolla[5] == 1 && ristinolla[8] == -1)
                {
                    ristinolla[8] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[2] == -1 && ristinolla[5] == 1 && ristinolla[8] == 1)
                {
                    ristinolla[2] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[2] == 1 && ristinolla[5] == -1 && ristinolla[8] == 1)
                {
                    ristinolla[5] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }

                    break;
                }
                else if (ristinolla[i] == -1)
                {
                    
                    ristinolla[i] = vuoro;
                    
                    vuoro = vuoro == 0 ? 1 : 0;
                    
                    foreach (Control c in this.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Refresh();
                        }
                    }
                    break;


                }
                
            }
        }

        private void tilastotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tilastot tilastot = new Tilastot();

            tilastot.Show();
        }

        private void lopetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
