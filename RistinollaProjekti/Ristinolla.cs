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
    public partial class Ristinolla : Form
    {
        int[] ristinolla = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };  //-1 tyhjä, 0 nolla ja  1 risti
        int vuoro = 1;  //0 = nolla
                        // 1 = risti

        bool aloita;

       

        
        public Ristinolla()
        {
            InitializeComponent();
            
        }
        public void Uudestaan1()
        {
            DialogResult dr = MessageBox.Show(cmbPelaaja1.Text+" voitti!\n\nHaluatko pelata uudestaan?", "Vastaa", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Application.Restart();
            }
            else if(dr == DialogResult.No)
            {
                Application.Exit();
            }
        }
        public void Uudestaan2()
        {
            DialogResult dr = MessageBox.Show(cmbPelaaja2.Text+" voitti!\n\nHaluatko pelata uudestaan?", "Vastaa", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Application.Restart();
            }
            else if (dr == DialogResult.No)
            {
                Application.Exit();
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
            else if(ristinolla[3] == 1 && ristinolla[4] == 1 && ristinolla[5] == 1)
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

            if(ristinolla[index] == 1)
            {
                formGraphics.DrawLine(pen, 0, 0, panel.Width, panel.Height);
                formGraphics.DrawLine(pen, 0, panel.Height, panel.Width, 0);
            }
            else if(ristinolla[index] == 0) 
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
                if (ristinolla[index] == -1)
                {
                    ristinolla[index] = vuoro;
                    vuoro = vuoro == 0 ? 1 : 0;
                    p.Refresh();
                }
                TestaaVoittaja();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tiedot tiedot = new Tiedot(this);

            tiedot.Show();
        }

        public void setPelaajat(Pelaaja p1)
        {
            cmbPelaaja1.Items.Add(p1.Nimi);
            cmbPelaaja2.Items.Add(p1.Nimi);
        }

        private void btnAloita_Click(object sender, EventArgs e)
        {
            aloita = true;
            tmrKello.Enabled = true;
        }
    }
}
