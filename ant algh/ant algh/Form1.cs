using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace ant_algh
{
    public partial class Form1 : Form
    {
        private World World;
        private int counter;
        private Pen p;
        private Bitmap bmp;
        private Graphics g;

        
        
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            p = new Pen(Color.Black);
            p.Width = 5;
            counter = 0;
            World = new World();
            World.Generate(4);
           
        }


        public void buttonStart_click(object sender, EventArgs e)
        {
            Ant.Run = true;

            for (int i = 0; i < World.Ants.Count; i++)
            {
                World.Ants[i].AntThread.Start();
                while (!World.Ants[i].AntThread.IsAlive)
                {
                    Thread.Sleep(1);
                }

            }
        }

        public void buttonStop_Click(object sender, EventArgs e)
        {
                
            for (int i = 0; i < World.Ants.Count; i++)
            {
                World.Ants[i].AntThread.Abort();
            }
            Ant.Run = false;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            World.Ants.Clear();
            World.Generate(5);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (World.Ants.Count != 0)
            {
                
                g.Clear(Color.White);
                for (int x = 0; x < World.Ants.Count; x++)
                {
                    
                    Point p1 = new Point(World.Ants[x].X, World.Ants[x].Y);
                    Point p2 = new Point(World.Ants[x].X + 50, World.Ants[x].Y + 50);

                    Font drawFont = new Font("Arial", 8);
                    SolidBrush drawBrush = new SolidBrush(Color.Fuchsia);
                    g.DrawEllipse(p, World.Ants[x].X, World.Ants[x].Y, 5, 5);
                    g.DrawString(x.ToString(), drawFont, drawBrush, World.Ants[x].X + 25, World.Ants[x].Y - 5);
                }
                pictureBox1.Image = bmp;
            }
           
        }
        
        private void buttonAddAnt_Click(object sender, EventArgs e)
        {                   
            Ant ant = new Ant(World.random1(300), World.random2(750));
            World.Ants.Add(ant);
            /*ant.AntThread.Start();
            while (!ant.AntThread.IsAlive)
            {
                Thread.Sleep(1);
            }*/
        }
    }
}

