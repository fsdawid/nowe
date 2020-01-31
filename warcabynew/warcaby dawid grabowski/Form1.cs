using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace warcaby_dawid_grabowski
{
    public partial class Form1 : Form
    {
        int turno = 0;
        bool movExtra = false;
        PictureBox seleccionado = null;
        List<PictureBox> azules = new List<PictureBox>();
        List<PictureBox> rojas = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
            cargarListas();
        }

        private void cargarListas()
        {
            azules.Add(azul1);
            azules.Add(azul2);
            azules.Add(azul3);
            azules.Add(azul4);
            azules.Add(azul5);
            azules.Add(azul6);
            azules.Add(azul7);
            azules.Add(azul8);
            azules.Add(azul9);
            azules.Add(azul10);
            azules.Add(azul11);
            azules.Add(azul12);

            rojas.Add(roja1);
            rojas.Add(roja2);
            rojas.Add(roja3);
            rojas.Add(roja4);
            rojas.Add(roja5);
            rojas.Add(roja6);
            rojas.Add(roja7);
            rojas.Add(roja8);
            rojas.Add(roja9);
            rojas.Add(roja10);
            rojas.Add(roja11);
            rojas.Add(roja12);
  
        }

        public void seleccion(object objeto)
        {
            try { seleccionado.BackColor = Color.Black; }
            catch { }
            PictureBox ficha = (PictureBox)objeto;
            seleccionado = ficha;
            seleccionado.BackColor = Color.Lime;
        }

        private void cuadroClick(object sender, MouseEventArgs e)
        {
            movimiento((PictureBox)sender);
        }

        private void movimiento(PictureBox cuadro)
        {
            if (seleccionado != null)
            {
                if (true)
                {
                    string color = seleccionado.Name.ToString().Substring(0, 4);
                    Point anterior = seleccionado.Location;
                    seleccionado.Location = cuadro.Location;
                    int avance = anterior.Y - cuadro.Location.Y;

                    if (true)
                    {
                        ifqueen(color);
                        turno++;
                        seleccionado.BackColor = Color.Black;
                        seleccionado = null;
                        movExtra = false;

                    }
                    else
                    {
                        movExtra = true;
                    }
                }
            }
        }

        private void ifqueen(string color)
        {
            if(color=="azul" && seleccionado.Location.Y == 400)
            {
                seleccionado.BackgroundImage = Properties.Resources.Bez_nazwy_2kpng;
                seleccionado.Tag = "queen";
            }
            else if (color == "roja" && seleccionado.Location.Y == 50)
            {
                seleccionado.BackgroundImage = Properties.Resources.Bez_nazwy_1k;
                seleccionado.Tag = "queen";
            }

        }

        private void seleccionAzul(object sender, MouseEventArgs e)
        {
            seleccion(sender);
        }

        private void seleccionRoja(object sender, MouseEventArgs e)
        {
            seleccion(sender);
        }
    }
}
