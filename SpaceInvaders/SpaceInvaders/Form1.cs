using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class glownastrona : Form
    {
        private bool lewy = false;
        private bool prawy = false;

        private PictureBox[] kosmici = new PictureBox[12];
        private System.Drawing.Point[] lokacjakosmitow = new System.Drawing.Point[12];
        private bool[] kosmitastrzela = new bool[12];
        private Label[] kosmitastrzalLabel = new Label[12];

        private int zmianakierunkuKosmity = 2;

        private bool strzapocz;
        private bool strza1;
        private bool strza2;
        private bool strza3;
        private bool strza4;
        private bool strza5;

        private int ktorykosmita;

        private int wygrana = 0;
        private int poziom = 1;
        private int wynik = 0;

        private int wynik1 = 50;
        private int wynik2 = 40;
        private int wynik3 = 30;
        private int wynik4 = 20;
        private int wynik5 = 10;

        private string name1 = "Name";
        private string name2 = "Name";
        private string name3 = "Name";
        private string name4 = "Name";
        private string name5 = "Name";


        private Random randomowaliczba = new Random();

        public glownastrona()
        {
            InitializeComponent();
            tworzpole();
            kosmitaStrzela();
            tablicawyniku();
        }

        private void restartgre()
        {
            statekkosmiczny.Image = Properties.Resources.indeks;
            umarles.Hide();
            wynik = 0; 
            poziom = 1;
            wygrana = 0;
            strzapocz = false;
            strza1 = false;
            strza2 = false;
            strza3 = false;
            strza4 = false;
            strza5 = false;
            strzal1.Location = strzalpoczatkowy.Location;
            strzal2.Location = strzalpoczatkowy.Location;
            strzal3.Location = strzalpoczatkowy.Location;
            strzal4.Location = strzalpoczatkowy.Location;
            strzal5.Location = strzalpoczatkowy.Location;
            label2.Text = "Wynik: " + wynik;
            Poziompokaz.Text = "Poziom: " + poziom;

            for(int i = 0; i < 12 ; i++)
            {
                kosmici[i].Location = lokacjakosmitow[i];
                kosmici[i].Show();
                kosmitastrzela[i] = false;
                kosmitastrzalLabel[i].Hide();
                kosmitastrzalLabel[i].Location = kosmici[i].Location;
                kosmitastrzalLabel[i].Top = kosmici[i].Top + 105;
                kosmitastrzalLabel[i].Left = kosmici[i].Left + 52;
            }
        }

        private void tablicawyniku()
        {
            label3.Text = name1;
            label4.Text = name2;
            label5.Text = name3;    
            label6.Text = name4;
            label7.Text = name5;
            label8.Text = wynik1.ToString();
            label10.Text = wynik2.ToString();
            label11.Text = wynik3.ToString();
            label12.Text = wynik4.ToString();
            label13.Text = wynik5.ToString();
        }

        private void tworzpole()
        {
            kosmici[0] = kosmita1;
            kosmici[1] = kosmita2;
            kosmici[2] = kosmita3;
            kosmici[3] = kosmita4;
            kosmici[4] = kosmita5;
            kosmici[5] = kosmita6;
            kosmici[6] = kosmita7;
            kosmici[7] = kosmita8;
            kosmici[8] = kosmita9;
            kosmici[9] = kosmita10;
            kosmici[10] = kosmita11;
            kosmici[11] = kosmita12;
            for (int i = 0; i < 12; i++)
            {
                lokacjakosmitow[i] = kosmici[i].Location;
            }
        }

        private void poruszajkosmita()
        {
            for (int i = 0; i < 12; i++)
            {
                kosmici[i].Left = kosmici[i].Left + zmianakierunkuKosmity;
                if (kosmitastrzela[i] == false)
                {
                    kosmitastrzalLabel[i].Left = kosmitastrzalLabel[i].Left + zmianakierunkuKosmity;
                }
                if (kosmici[i].Bounds.IntersectsWith(statekkosmiczny.Bounds))
                {
                    statekumarl();
                }
            }
            int dlugoscPola = this.Width;
            if (kosmita6.Left > dlugoscPola - kosmita6.Width)
            {
                zmianakierunkuKosmity = zmianakierunkuKosmity * -1;
                for (int i = 0; i < 12; i++)
                {
                    kosmici[i].Top = kosmici[i].Top + 25;
                    if (kosmitastrzela[i] == false)
                    {
                        kosmitastrzalLabel[i].Top = kosmitastrzalLabel[i].Top + 25;
                    }
                }
            }
            else if (kosmita1.Left < 0)
            {
                zmianakierunkuKosmity = zmianakierunkuKosmity * -1;
                for (int i = 0; i < 12; i++)
                {
                    if (kosmitastrzela[i] == false)
                    {
                        kosmitastrzalLabel[i].Top = kosmitastrzalLabel[i].Top + 25;
                    }
                    kosmitastrzalLabel[i].Top = kosmitastrzalLabel[i].Top + 25;
                }
            }
        }

        private void kosmitaStrzela()
        {
            kosmitastrzalLabel[0] = rakiet1;
            kosmitastrzalLabel[1] = rakiet2;
            kosmitastrzalLabel[2] = rakiet3;
            kosmitastrzalLabel[3] = rakiet4;
            kosmitastrzalLabel[4] = rakiet5;
            kosmitastrzalLabel[5] = rakiet6;
            kosmitastrzalLabel[6] = rakiet7;
            kosmitastrzalLabel[7] = rakiet8;
            kosmitastrzalLabel[8] = rakiet9;
            kosmitastrzalLabel[9] = rakiet10;
            kosmitastrzalLabel[10] = rakiet11;
            kosmitastrzalLabel[11] = rakiet12;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Hide();
            startgry.Hide();
            zakonczgry.Hide();
            pictureBox1.Hide();
            stronagry.Show();
            poruszajstatkiem.Enabled = true;
            poruszajstatkiem.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void poruszajstatkiem_Tick(object sender, EventArgs e)
        {
            if (lewy == true)
            {
                statekkosmiczny.Left = statekkosmiczny.Left - 2;
                strzalpoczatkowy.Left = strzalpoczatkowy.Left - 3;

                if (strza1 == false)
                {
                    strzal1.Left = strzal1.Left - 3;
                }
                if (strza2 == false)
                {
                    strzal2.Left = strzal2.Left - 3;
                }
                if (strza3 == false)
                {
                    strzal3.Left = strzal3.Left - 3;
                }
                if (strza4 == false)
                {
                    strzal4.Left = strzal4.Left - 3;
                }
                if (strza5 == false)
                {
                    strzal5.Left = strzal5.Left - 3;
                }
            }
            if (statekkosmiczny.Left < 0)
            {
                statekkosmiczny.Left = statekkosmiczny.Left + 2;
                strzalpoczatkowy.Left = strzalpoczatkowy.Left + 3;

                if (strza1 == false)
                {
                    strzal1.Left = strzal1.Left + 3;
                }
                if (strza2 == false)
                {
                    strzal2.Left = strzal2.Left + 3;
                }
                if (strza3 == false)
                {
                    strzal3.Left = strzal3.Left + 3;
                }
                if (strza4 == false)
                {
                    strzal4.Left = strzal4.Left + 3;
                }
                if (strza5 == false)
                {
                    strzal5.Left = strzal5.Left + 3;
                }
            }
            else if (prawy == true)
            {
                statekkosmiczny.Left = statekkosmiczny.Left + 2;
                strzalpoczatkowy.Left = strzalpoczatkowy.Left + 3;

                if (strza1 == false)
                {
                    strzal1.Left = strzal1.Left + 3;
                }
                if (strza2 == false)
                {
                    strzal2.Left = strzal2.Left + 3;
                }
                if (strza3 == false)
                {
                    strzal3.Left = strzal3.Left + 3;
                }
                if (strza4 == false)
                {
                    strzal4.Left = strzal4.Left + 3;
                }
                if (strza5 == false)
                {
                    strzal5.Left = strzal5.Left + 3;
                }
            }
            if (statekkosmiczny.Left > this.Width - statekkosmiczny.Width)
            {
                statekkosmiczny.Left = statekkosmiczny.Left - 2;
                strzalpoczatkowy.Left = strzalpoczatkowy.Left - 3;

                if (strza1 == false)
                {
                    strzal1.Left = strzal1.Left - 3;
                }
                if (strza2 == false)
                {
                    strzal2.Left = strzal2.Left - 3;
                }
                if (strza3 == false)
                {
                    strzal3.Left = strzal3.Left - 3;
                }
                if (strza4 == false)
                {
                    strzal4.Left = strzal4.Left - 3;
                }
                if (strza5 == false)
                {
                    strzal5.Left = strzal5.Left - 3;
                }
            }
            poruszajkosmita();
            if (strzapocz == true)
            {
                sprawdzStrzal();
            }
            ruszstrzal();
            ruszrakiete();
        }

        private void poruszajwlewo(object sender, KeyEventArgs e)
        {
            int ruchL = (int)Keys.A;
            if (e.KeyValue == ruchL)
            {
                lewy = true;
            }
            int ruchP = (int)Keys.D;
            if (e.KeyValue == ruchP)
            {
                prawy = true;
            }
            int ruchS = (int)Keys.S;
            if (e.KeyValue == ruchS)
            {
                strzapocz = true;
            }
        }

        private void poruszajstop(object sender, KeyEventArgs e)
        {
            int ruch = (int)Keys.A;
            if (e.KeyValue == ruch)
            {
                lewy = false;
            }
            int ruchP = (int)Keys.D;
            if (e.KeyValue == ruchP)
            {
                prawy = false;
            }
            int ruchS = (int)Keys.S;
            if (e.KeyValue == ruchS)
            {
                strzapocz = false;
            }
        }

        private void sprawdzStrzal()
        {
            strzapocz = false;

            if (strza1 == false)
            {
                strza1 = true;
                strzal1.Show();
            }
            else if (strza2 == false)
            {
                strza2 = true;
                strzal2.Show();
            }
            else if (strza3 == false)
            {
                strza3 = true;
                strzal3.Show();
            }
            else if (strza4 == false)
            {
                strza4 = true;
                strzal4.Show();
            }
            else if (strza5 == false)
            {
                strza5 = true;
                strzal5.Show();
            }
        }

        private void ruszstrzal()
        {
            if (strza1 == true)
            {
                strzal1.Top = strzal1.Top - 3;
                for (int i = 0; i < 12; i++)
                {
                    if (strzal1.Bounds.IntersectsWith(kosmici[i].Bounds))
                    {
                        ktorykosmita = i;
                        strzal1trafienie();
                    }
                }
                if (strzal1.Top < 0)
                {
                    strzal1.Hide();
                    strza1 = false;
                    strzal1.Location = strzalpoczatkowy.Location;
                }
            }
            if (strza2 == true)
            {
                strzal2.Top = strzal2.Top - 3;
                for (int i = 0; i < 12; i++)
                {
                    if (strzal2.Bounds.IntersectsWith(kosmici[i].Bounds))
                    {
                        ktorykosmita = i;
                        strzal2trafienie();
                    }
                }
                if (strzal2.Top < 0)
                {
                    strzal2.Hide();
                    strza2 = false;
                    strzal2.Location = strzalpoczatkowy.Location;
                }
            }
            if (strza3 == true)
            {
                strzal3.Top = strzal3.Top - 3;
                for (int i = 0; i < 12; i++)
                {
                    if (strzal3.Bounds.IntersectsWith(kosmici[i].Bounds))
                    {
                        ktorykosmita = i;
                        strzal3trafienie();
                    }
                }
                if (strzal3.Top < 0)
                {
                    strzal3.Hide();
                    strza3 = false;
                    strzal3.Location = strzalpoczatkowy.Location;
                }
            }
            if (strza4 == true)
            {
                strzal4.Top = strzal4.Top - 3;
                for (int i = 0; i < 12; i++)
                {
                    if (strzal4.Bounds.IntersectsWith(kosmici[i].Bounds))
                    {
                        ktorykosmita = i;
                        strzal4trafienie();
                    }
                }
                if (strzal4.Top < 0)
                {
                    strzal4.Hide();
                    strza4 = false;
                    strzal4.Location = strzalpoczatkowy.Location;
                }
            }
            if (strza5 == true)
            {
                strzal5.Top = strzal5.Top - 3;
                for (int i = 0; i < 12; i++)
                {
                    if (strzal5.Bounds.IntersectsWith(kosmici[i].Bounds))
                    {
                        ktorykosmita = i;
                        strzal5trafienie();
                    }
                }
                if (strzal5.Top < 0)
                {
                    strzal5.Hide();
                    strza5 = false;
                    strzal5.Location = strzalpoczatkowy.Location;
                }
            }
        }

        private void strzal1trafienie()
        {
            strza1 = false;
            strzal1.Hide();
            strzal1.Location = strzalpoczatkowy.Location;
            kosmici[ktorykosmita].Top = kosmici[ktorykosmita].Top + 1000;
            wygrana += 1;
            if (wygrana == kosmici.Length)
            {
                wygranagra();
            }
            wynik += 1;
            label2.Text = "Wynik: " + wynik;
        }
        private void strzal2trafienie()
        {
            strza2 = false;
            strzal2.Hide();
            strzal2.Location = strzalpoczatkowy.Location;
            kosmici[ktorykosmita].Top = kosmici[ktorykosmita].Top + 1000;
            wygrana += 1;
            if (wygrana == kosmici.Length)
            {
                wygranagra();
            }
            wynik += 1;
            label2.Text = "Wynik: " + wynik;
        }
        private void strzal3trafienie()
        {
            strza3 = false;
            strzal3.Hide();
            strzal3.Location = strzalpoczatkowy.Location;
            kosmici[ktorykosmita].Top = kosmici[ktorykosmita].Top + 1000;
            wygrana += 1;
            if (wygrana == kosmici.Length)
            {
                wygranagra();
            }
            wynik += 1;
            label2.Text = "Wynik: " + wynik;
        }
        private void strzal4trafienie()
        {
            strza4 = false;
            strzal4.Hide();
            strzal4.Location = strzalpoczatkowy.Location;
            kosmici[ktorykosmita].Top = kosmici[ktorykosmita].Top + 1000;
            wygrana += 1;
            if (wygrana == kosmici.Length)
            {
                wygranagra();
            }
            wynik += 1;
            label2.Text = "Wynik: " + wynik;
        }
        private void strzal5trafienie()
        {
            strza5 = false;
            strzal5.Hide();
            strzal5.Location = strzalpoczatkowy.Location;
            kosmici[ktorykosmita].Top = kosmici[ktorykosmita].Top + 1000;
            wygrana += 1;
            if (wygrana == kosmici.Length)
            {
                wygranagra();
            }
            wynik += 1;
            label2.Text = "Wynik: " + wynik;
        }

        private void statekumarl()
        {
            poruszajstatkiem.Stop();
            statekkosmiczny.Image = Properties.Resources.isto;
            umarles.Show();
            timer1.Enabled = true;
            timer1.Start();
        }

        private void wygranagra()
        {
            wygrana = 0;
            poziom += 1;
            Poziompokaz.Text = "Poziom: " + poziom;
            for (int i = 0; i < 12; i++)
            {
                kosmici[i].Location = lokacjakosmitow[i];
            }
        }

        private void ruszrakiete()
        {
            for (int i = 0; i < 12; i++)
            {
                if (kosmitastrzela[i] == false)
                {
                    int rand = randomowaliczba.Next(1, 1001);
                    if (rand == 1000)
                    {
                        kosmitastrzela[i] = true;
                        kosmitastrzalLabel[i].Show();
                        if (kosmici[i].Top > 1000)
                        {
                            kosmitastrzela[i] = false;
                            kosmitastrzalLabel[i].Hide();
                        }
                    }
                }
            }
            for (int i = 0; i < 12; i++)
            {
                if (kosmitastrzela[i] == true)
                {
                    kosmitastrzalLabel[i].Top = kosmitastrzalLabel[i].Top + 3;
                    if (kosmitastrzalLabel[i].Bounds.IntersectsWith(statekkosmiczny.Bounds))
                    {
                        statekumarl();
                    }
                    if (kosmitastrzalLabel[i].Top > this.Height)
                    {
                        kosmitastrzela[i] = false;
                        kosmitastrzalLabel[i].Hide();
                        kosmitastrzalLabel[i].Location = kosmici[i].Location;
                        kosmitastrzalLabel[i].Left = kosmici[i].Left + 52;
                        kosmitastrzalLabel[i].Top = kosmici[i].Top + 105;
                    }
                }
            }
        }

        private void tablicawynikow()
        {
            if(wynik > wynik1)
            {
                wynik5 = wynik4;
                wynik4 = wynik3;
                wynik3 = wynik2;
                wynik2 = wynik1;
                wynik1 = wynik;
                name5 = name4;
                name4 = name3;
                name3 = name2;
                name2 = name1;
                name1 = textBox1.Text;
                label3.Text = name1;
                label4.Text = name2;
                label5.Text = name3;
                label6.Text = name4;
                label7.Text = name5;
                label8.Text = wynik1.ToString();
                label10.Text = wynik2.ToString(); 
                label11.Text = wynik3.ToString();
                label12.Text = wynik4.ToString();
                label13.Text = wynik5.ToString();
            }else if(wynik > wynik2)
            {
                wynik5 = wynik4;
                wynik4 = wynik3;
                wynik3 = wynik2;
                wynik2 = wynik;
                name5 = name4;
                name4 = name3;
                name3 = name2;
                name2 = textBox1.Text;
                label4.Text = name2;
                label5.Text = name3;
                label6.Text = name4;
                label7.Text = name5;
                label10.Text = wynik2.ToString();
                label11.Text = wynik3.ToString();
                label12.Text = wynik4.ToString();
                label13.Text = wynik5.ToString();
            }else if(wynik > wynik3)
            {
                wynik5 = wynik4;
                wynik4 = wynik3;
                wynik3 = wynik;
                name5 = name4;
                name4 = name3;
                name3 = textBox1.Text;
                label5.Text = name3;
                label6.Text = name4;
                label7.Text = name5;
                label11.Text = wynik3.ToString();
                label12.Text = wynik4.ToString();
                label13.Text = wynik5.ToString();
            }
            else if (wynik > wynik4)
            {
                wynik5 = wynik4;
                wynik4 = wynik;
                name5 = name4;
                name4 = textBox1.Text;
                label6.Text = name4;
                label7.Text = name5;
                label12.Text = wynik4.ToString();
                label13.Text = wynik5.ToString();
            }
            else if (wynik > wynik5)
            {
                wynik5 = wynik;
                name5 = textBox1.Text;
                label7.Text = name5;
                label13.Text = wynik5.ToString();
            }

        }

        private void enterdane(object sender, KeyEventArgs e)
        {
            int ruch = (int)Keys.Enter;
            if (e.KeyValue == ruch)
            {
                tablicawynikow();
                label3.Show();
                label4.Show();
                label5.Show();
                label6.Show();
                label7.Show();
                label8.Show();
                label10.Show();
                label11.Show();
                label12.Show();
                label13.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            panel1.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Hide();
            stronagry.Hide();
            label1.Show();
            startgry.Show();
            zakonczgry.Show();
            pictureBox1.Show();
            restartgre();
        }


        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void kosmita1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void kosmita13_Click(object sender, EventArgs e)
        {

        }

        private void kosmita12_Click(object sender, EventArgs e)
        {

        }

        private void kosmita11_Click(object sender, EventArgs e)
        {

        }

        private void kosmita10_Click(object sender, EventArgs e)
        {

        }

        private void kosmita9_Click(object sender, EventArgs e)
        {

        }

        private void kosmita8_Click(object sender, EventArgs e)
        {

        }

        private void kosmita6_Click(object sender, EventArgs e)
        {

        }

        private void kosmita5_Click(object sender, EventArgs e)
        {

        }

        private void kosmita4_Click(object sender, EventArgs e)
        {

        }

        private void kosmita3_Click(object sender, EventArgs e)
        {

        }

        private void kosmita2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void statekkosmiczny_Click(object sender, EventArgs e)
        {

        }

        private void strzal2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
       
    }
}
