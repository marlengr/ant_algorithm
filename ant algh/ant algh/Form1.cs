using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;



namespace ant_algh
{


    public partial class Form1 : Form
    {

        Ant ant = new Ant();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Bitmap drawingAnthill = new Bitmap(723, 370);
            Graphics drawAnt = Graphics.FromImage(drawingAnthill);
            /*Random rnd = new Random();
                for (int i = 0; i < 0; i++)
             {
                 // calculate line start and end point here using the Random class:
                 int x0 = rnd.Next(0, drawingAnthill.Width);
                 int y0 = rnd.Next(0, drawingAnthill.Height);
                 int x1 = rnd.Next(0, drawingAnthill.Width);
                 int y1 = rnd.Next(0, drawingAnthill.Height);
                 drawAnt.DrawLine(Pens.Black, x0, y0, x1, x1);
             }
             */
            drawAnt.FillEllipse(Brushes.Black, 350, 200, 15, 15);
            drawAnt.FillEllipse(Brushes.Black, 200, 100, 15, 15);
            drawAnt.FillEllipse(Brushes.Black, 300, 150, 15, 15);
            drawAnt.FillEllipse(Brushes.Red, 50, 200, 20, 20);
            drawAnt.FillEllipse(Brushes.Red, 660, 220, 20, 20);
            drawAnt.FillEllipse(Brushes.Black, 550, 300, 15, 15);
            drawAnt.FillEllipse(Brushes.Black, 600, 130, 15, 15);
            drawAnt.FillEllipse(Brushes.Black, 500, 140, 15, 15);
            drawAnt.FillEllipse(Brushes.Black, 400, 250, 15, 15);
            drawAnt.FillEllipse(Brushes.Black, 200, 300, 15, 15);
            drawAnt.FillEllipse(Brushes.Black, 500, 200, 15, 15);
            drawAnt.FillEllipse(Brushes.Black, 390, 50, 15, 15);
            drawAnt.FillEllipse(Brushes.Black, 140, 190, 15, 15);

            Pen p = new Pen(Color.Black);
            p.Width = 5;
            Point p1 = new Point(350, 200);
            Point p2 = new Point(200, 100);
            Point p3 = new Point(300, 150);
            Point p4 = new Point(50, 200);
            Point p5 = new Point(660, 220);
            Point p6 = new Point(550, 300);
            Point p7 = new Point(600, 130);
            Point p8 = new Point(500, 140);
            Point p9 = new Point(400, 250);
            Point p10 = new Point(200, 300);
            Point p11 = new Point(500, 200);
            Point p12 = new Point(390, 50);
            Point p13 = new Point(140, 190);

            /*drawAnt.DrawLine(p, p1, p2);
            drawAnt.DrawLine(p, p2, p3);
            drawAnt.DrawLine(p, p3, p4);
            drawAnt.DrawLine(p, p4, p5);
            drawAnt.DrawLine(p, p5, p6);
            drawAnt.DrawLine(p, p6, p7);
            drawAnt.DrawLine(p, p7, p8);
            drawAnt.DrawLine(p, p8, p9);
            drawAnt.DrawLine(p, p9, p10);*/

            drawAnt.Dispose();

            pictureBox1.Image = drawingAnthill;
        }


        public void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}

