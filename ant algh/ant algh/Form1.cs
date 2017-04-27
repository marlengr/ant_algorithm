using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace ant_algh
{
    public partial class Form1 : Form
    {
        private World World;
        //private int counter;
        public Pen pen,pen2, pen3, pen4;
        public Bitmap bmp;
        public Graphics g;
        public int j =0 ;
        Anthill Anthill = new Anthill();
        Food Food = new Food();
        

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pen = new Pen(Color.Black);
            pen2 = new Pen(Color.Blue);
            pen3 = new Pen(Color.Yellow);
            pen4 = new Pen(Color.Orange);
            pen4.Width = 9;
            pen3.Width = 9;
            pen2.Width = 6;
            pen.Width = 5;
            //counter = 0;
            World = new World();
            World.Generate(5);
            World.GenerateCell(10);


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
            World.Generate(1);
        }

        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Anthill.CreateAnthill(null, e);
            //Food.CreateFood(null, e);
        
            if (World.Ants.Count != 0)
            {
                g.Clear(Color.White);
                for (int x = 0; x < World.Ants.Count; x++)
                {
                   // Point p1 = new Point(World.Ants[x].X, World.Ants[x].Y);
                    //Point pen2 = new Point(World.Ants[x].X + 50, World.Ants[x].Y + 50);
                    Font drawFont = new Font("Arial", 8);
                    SolidBrush drawBrush = new SolidBrush(Color.Fuchsia);
                    //rysowanie punktow mrowek
                    g.DrawEllipse(pen, World.Ants[x].X, World.Ants[x].Y, 5, 5);
                    g.DrawString(x.ToString(), drawFont, drawBrush, World.Ants[x].X + 25, World.Ants[x].Y - 5);
                }
                pictureBox1.Image = bmp;
            }

            if (World.Cells.Count !=0)
            {
                for (int x = 0; x < World.Cells.Count; x++)
                {
                    //rysowanie cellow hehe
                    if (x == 0)
                    {
                        g.DrawEllipse(pen3,20,20, 11, 11);
                    }
                    if (x == World.Cells.Count-1)
                    {
                        g.DrawEllipse(pen4, 600,200, 11, 11);
                    }
                    if (x != 0 && x != World.Cells.Count-1)
                    {
                        g.DrawEllipse(pen2, World.Cells[x].X_C, World.Cells[x].Y_C, 10, 10);
                    }
                }
            }
            pictureBox1.Image = bmp;
            g.DrawLine(pen, World.Cells[7].X_C, World.Cells[7].Y_C, World.Cells[2].X_C, World.Cells[2].Y_C);

        }

        private void buttonAddAnt_Click(object sender, EventArgs e)
        {
            Ant ant = new Ant(50, 50);
            World.Ants.Add(ant);
            /*ant.AntThread.Start();
            while (!ant.AntThread.IsAlive)
            {
                Thread.Sleep(1);
            }*/
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            // i = ktora mrowka
            // j = ktory punkt
            Random rnd = new Random();            
            for (int i = 0; i < World.Ants.Count; i++)
            {
                if (j==0)
                {
                    World.Ants[i].X = 20;
                    World.Ants[i].Y = 20;
                }
                if (j == World.Cells.Count - 1)
                {
                    World.Ants[i].X = 600;
                    World.Ants[i].Y = 200;
                }
                if (j != 0 && j!=World.Cells.Count-1)
                {                    
                    World.Ants[i].X = World.Cells[j].X_C;
                    World.Ants[i].Y = World.Cells[j].Y_C;
                }
            }
            j = rnd.Next(0, World.Cells.Count);


            Invalidate();
        }
    }
}

