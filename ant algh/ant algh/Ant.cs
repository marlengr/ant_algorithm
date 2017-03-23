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
    public class Ant
    {

        public Thread antThread;
        public int X = 0;
        public int Y = 0;
        public static bool Run = false;

        public Ant()
        {
            antThread = new Thread(doSomething);
            //MessageBox.Show("utworzono watek");
        }

        public Ant(int x, int y)
        {
            X = x;
            Y = y;
            antThread = new Thread(doSomething);
            //MessageBox.Show("utworzono watek");
        }

        PictureBox pictureBox1 = new PictureBox();
        public void drawAnt()
        {
            pictureBox1.Size = new Size(730, 370);
            //this.Add(pictureBox1);
            Bitmap bitmap = new Bitmap(730, 370);

            Pen p = new Pen(Color.Black);
            Graphics drawAnt = Graphics.FromImage(bitmap);
            drawAnt.FillEllipse(Brushes.Black, 350, 200, 5, 5);
            drawAnt.DrawLine(p, 353, 200, 370, 190);
            pictureBox1.Image = bitmap;
            //Form1.pictureBox1.Image = drawingAnthill;

        }



        public void doSomething()
        {
            while (Run)
            {
                Random r = new Random();
                X = r.Next(100);
                Y = r.Next(100);
                Thread.Sleep(2000);
            }
        }

       


    }
}
