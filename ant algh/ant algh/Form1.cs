using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;



namespace ant_algh
{


    public partial class Form1 : Form
    {
        World World = new World();


        public Form1()
        {
            InitializeComponent();
            //img = Image.FromFile("ant.png");
            //Ant ant = new Ant();
            //pictureBox2.Image = img;
        }

        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Ant.Run = true;

            for (int i = 0; i < World.Ants.Count; i++)
            {
               World.Ants[i].antThread.Start();
            }



        }


        public void button2_Click(object sender, EventArgs e)
        {
            Ant.Run = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
      
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = Graphics.FromImage(pictureBox1.Image);
            


            Pen p = new Pen(Color.Black);
            p.Width = 5;

            World.Generate();
            if (World.Ants.Count != 0)
            {
                for (int x = 0; x < World.Ants.Count; x++)
                {
                    Point p1 = new Point(World.Ants[x].X, World.Ants[x].Y);
                    //e.Graphics.DrawLine(p, p1, p1);

                    Pen myPen = new Pen(Color.Black);
                    SolidBrush mySolidBrush = new SolidBrush(Color.Red);
                    e.Graphics.DrawEllipse(myPen, p1.X, p1.Y, p1.X+5, p1.Y+5);


                }
            }

        }
    }
}

