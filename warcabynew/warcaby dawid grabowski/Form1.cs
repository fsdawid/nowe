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
                string color = seleccionado.Name.ToString().Substring(0, 4);
                if (validaction(seleccionado, cuadro, color))
                {

                    Point anterior = seleccionado.Location;
                    seleccionado.Location = cuadro.Location;
                    int avance = anterior.Y - cuadro.Location.Y;

                    if (!movimientosExtras(color) | Math.Abs(avance) == 50)
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

        private bool movimientosExtras(string color)
        {
            List<PictureBox> bandoContrario = color == "roja" ? azules : rojas;
            List<Point> posiciones = new List<Point>();
            int sigPosicion = color == "roja" ? -100 : 100;
            posiciones.Add(new Point(seleccionado.Location.X + 100, seleccionado.Location.Y + sigPosicion));
            posiciones.Add(new Point(seleccionado.Location.X - 100, seleccionado.Location.Y + sigPosicion));
            if (seleccionado.Tag == "queen")
            {
                posiciones.Add(new Point(seleccionado.Location.X + 100, seleccionado.Location.Y - sigPosicion));
                posiciones.Add(new Point(seleccionado.Location.X - 100, seleccionado.Location.Y - sigPosicion));
            }

            bool resultado = false;
            for (int i = 0; i < posiciones.Count; i++)
            {
                if (posiciones[i].X >= 50 && posiciones[i].X <= 400 && posiciones[i].Y >= 50 && posiciones[i].Y <= 400)
                {
                    if (!ocupado(posiciones[i], rojas) && !ocupado(posiciones[i], azules))
                    {
                        Point puntoMedio = new Point(promedio(posiciones[i].X, seleccionado.Location.X), promedio(posiciones[i].Y, seleccionado.Location.Y));
                        if (ocupado(puntoMedio, bandoContrario))
                        {
                            resultado = true;

                        }
                    }
                }
            }
            return resultado;
        }

        private bool ocupado(Point punto, List<PictureBox> bando)
        {
            for (int i = 0; i < bando.Count; i++)
            {
                if (punto == bando[i].Location)
                {
                    return true;
                }
            }
            return false;
        }

        private int promedio(int n1, int n2)
        {
            int resultado = n1 + n2;
            resultado = resultado / 2;
            return Math.Abs(resultado);
        }

        private bool validaction(PictureBox origen, PictureBox destino, string color)
        {
            Point puntoOrigen = origen.Location;
            Point puntoDestino = destino.Location;
            int avance = puntoOrigen.Y - puntoDestino.Y;
            avance = color == "reja" ? avance : (avance * -1);
            avance = seleccionado.Tag == "queen" ? Math.Abs(avance) : avance;

            if (avance == 50)
            {
                return true;
            }
            else if (avance == 100)
            {
                Point puntoMedio = new Point(promedio(puntoDestino.X, puntoOrigen.X), promedio(puntoDestino.Y, puntoOrigen.Y));
                List<PictureBox> bandoContrario = color == "roja" ? azules : rojas;
                for (int i = 0; i < bandoContrario.Count; i++)
                {
                    if (bandoContrario[i].Location == puntoMedio)
                    {
                        bandoContrario[i].Location = new Point(0, 0);
                        bandoContrario[i].Visible = false;
                        return true;
                    }
                }


            }
            return false; 
           
        

.
        }

        private void ifqueen(string color)
        {
            if (color == "azul" && seleccionado.Location.Y == 400)
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


