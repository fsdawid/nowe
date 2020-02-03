using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace warcaby_dawid_grabowski
{
    public partial class Form1 : Form
    {
        int przesuniecie = 0;
        bool ruchExtra = false;
        PictureBox wybory = null;
        List<PictureBox> niebieski = new List<PictureBox>();
        List<PictureBox> czerwony = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
            listapionkow();
        }

        private void listapionkow()
        {
            niebieski.Add(niebieski1);
            niebieski.Add(niebieski2);
            niebieski.Add(niebieski3);
            niebieski.Add(niebieski4);
            niebieski.Add(niebieski5);
            niebieski.Add(niebieski6);
            niebieski.Add(niebieski7);
            niebieski.Add(niebieski8);
            niebieski.Add(niebieski9);
            niebieski.Add(niebieski10);
            niebieski.Add(niebieski11);
            niebieski.Add(niebieski12);

            czerwony.Add(czerwony1);
            czerwony.Add(czerwony2);
            czerwony.Add(czerwony3);
            czerwony.Add(czerwony4);
            czerwony.Add(czerwony5);
            czerwony.Add(czerwony6);
            czerwony.Add(czerwony7);
            czerwony.Add(czerwony8);
            czerwony.Add(czerwony9);
            czerwony.Add(czerwony10);
            czerwony.Add(czerwony11);
            czerwony.Add(czerwony12);

        }

        public void wybor(object objekt)
        {
            try { wybory.BackColor = Color.Black; }
            catch { }
            PictureBox tab = (PictureBox)objekt;
            wybory = tab;
            wybory.BackColor = Color.Yellow;
        }

        private void poleClick(object sender, MouseEventArgs e)
        {
            ruch((PictureBox)sender);
        }
        private void wyborniebieskich(object sender, MouseEventArgs e)
        {
            if (przesuniecie % 2 == 1)
            {

                wybor(sender);
            }
            else { MessageBox.Show("kolej na czerwony"); }
        }

        private void wyborczerwonych(object sender, MouseEventArgs e)
        {
            if (przesuniecie % 2 == 0)
            {
                wybor(sender);
            }
            else
            {
                MessageBox.Show("kolej na niebieski");
            }
        }

            private void ruch(PictureBox pole)
        {
            if (wybory != null)
            {
                string color = wybory.Name.ToString().Contains("niebieski") ? "niebieski" : "czerwony";

                if (walidacja(wybory, pole, color))
                {

                    Point poprzedni = wybory.Location;
                    wybory.Location = pole.Location;
                    int gora = poprzedni.Y - pole.Location.Y;

                    if (!ruchyExtra(color) | Math.Abs(gora) == 50)
                    {
                        ifqueen(color);
                        przesuniecie++;
                        wybory.BackColor = Color.Black;
                        wybory = null;
                        ruchExtra = false;

                    }
                    else
                    {
                        ruchExtra = true;
                    }
                }
            }
        } 

        private bool ruchyExtra(string color)
        {
            List<PictureBox> tablicazboku = color == "czerwony" ? niebieski : czerwony;
            List<Point> pozycje = new List<Point>();
            int nowapozycja = color == "czerwony" ? -100 : 100;
            pozycje.Add(new Point(wybory.Location.X + 100, wybory.Location.Y + nowapozycja));
            pozycje.Add(new Point(wybory.Location.X - 100, wybory.Location.Y + nowapozycja));
            if (wybory.Tag == "queen")
            {
                pozycje.Add(new Point(wybory.Location.X + 100, wybory.Location.Y - nowapozycja));
                pozycje.Add(new Point(wybory.Location.X - 100, wybory.Location.Y - nowapozycja));
            }

            bool rezultaty = false;
            for (int i = 0; i < pozycje.Count; i++)
            {
                if (pozycje[i].X >= 50 && pozycje[i].X <= 400 && pozycje[i].Y >= 50 && pozycje[i].Y <= 400)
                {
                    if (!zajety(pozycje[i], czerwony) && !zajety(pozycje[i], niebieski))
                    {
                        Point punktsrodek = new Point(srednia(pozycje[i].X, wybory.Location.X), srednia(pozycje[i].Y, wybory.Location.Y));
                        if (zajety(punktsrodek, tablicazboku))
                        {
                            rezultaty = true;

                        }
                    }
                }
            }
            return rezultaty;
        }

        private bool zajety(Point punkt, List<PictureBox> bok)
        {
            for (int i = 0; i < bok.Count; i++)
            {
                if (punkt == bok[i].Location)
                {
                    return true;
                }
            }
            return false;
        }

        private int srednia(int n1, int n2)
        {
            int rezultaty = n1 + n2;
            rezultaty = rezultaty / 2;
            return Math.Abs(rezultaty);
        }

        private bool walidacja(PictureBox poczatek, PictureBox cel, string color)
        {
            Point punktpoczatek = poczatek.Location;
            Point punktcel = cel.Location;
            int gora = punktpoczatek.Y - punktcel.Y;
            gora = color == "czerwony" ? gora : (gora * -1);
            gora = wybory.Tag == "queen" ? Math.Abs(gora) : gora;
            if (gora == 50)
            {
                return true;
            }
            else if (gora == 100)
            {
                Point punktsrodek = new Point(srednia(punktcel.X, punktpoczatek.X), srednia(punktcel.Y, punktpoczatek.Y));
                List<PictureBox> tablicazboku = color == "czerwony" ? niebieski : czerwony;
                for (int i = 0; i < tablicazboku.Count; i++)
                {
                    if (tablicazboku[i].Location == punktsrodek)
                    {
                        tablicazboku[i].Location = new Point(0, 0);
                        tablicazboku[i].Visible = false;
                        return true;
                    }
                }


            }
            return false; 
           
        


        }



        private void ifqueen(string color)
        {
            if (color == "niebieski" && wybory.Location.Y == 400)
            {
               
                wybory.BackgroundImage = Properties.Resources.krolowaniebjpg;
                wybory.Tag = "queen";
            }
            else if (color == "czerwony" && wybory.Location.Y == 50)
            {
                
                wybory.BackgroundImage = Properties.Resources.krolowaczerjpg;
                wybory.Tag = "queen";
            }
            
        }

        private void wyborniebieski(object sender, MouseEventArgs e)
        {
            wybor(sender);
        }

        private void wyborczerwony(object sender, MouseEventArgs e)
        {
            wybor(sender);
        }

        

        
    }
}


