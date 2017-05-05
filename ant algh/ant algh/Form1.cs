using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

namespace ant_algh
{
    public partial class Form1 : Form
    {
        private World World;
        public Pen pen, pen2, pen3, pen4;
        public Bitmap bmp;
        public Graphics g;
        public int counter = 0;
        public int counter2;
        //public int j =0 ;
        Anthill Anthill = new Anthill();
        Food Food = new Food();



        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pen = new Pen(Color.Black, 2);
            pen2 = new Pen(Color.Black, 6);
            pen3 = new Pen(Color.Yellow, 7);
            pen4 = new Pen(Color.Orange, 7);

            World = new World();
            //World.GenerateAnt(5);
            World.GenerateCell(5);
            //World.GenerateRoads();
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
            //World.GenerateAnt(1);
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (World.Ants.Count != 0)
            {
                g.Clear(Color.White);
                for (int x = 0; x < World.Ants.Count; x++)
                {
                    Font drawFont = new Font("Arial", 8);
                    SolidBrush drawBrush = new SolidBrush(Color.Fuchsia);
                    //rysowanie punktow mrowek
                    g.DrawEllipse(new Pen(Color.Green, 20), World.Ants[x].p.X, World.Ants[x].p.Y, 5, 5);
                    g.DrawString(x.ToString(), drawFont, drawBrush, World.Ants[x].X + 25, World.Ants[x].Y - 5);
                }
                pictureBox1.Image = bmp;
                counter++;
                label2.Text = counter.ToString();
            }

            if (World.Cells.Count != 0)
            {
                for (int x = 0; x < World.Cells.Count; x++)
                {
                    //rysowanie cellow hehe
                    if (x == 0)
                    {
                        g.DrawEllipse(pen3, World.Cells[x].X_C, World.Cells[x].Y_C, 6, 6);
                    }
                    if (x == World.Cells.Count - 1)
                    {
                        g.DrawEllipse(pen4, World.Cells[x].X_C, World.Cells[x].Y_C, 6, 6);
                    }
                    if (x != 0 && x != World.Cells.Count - 1)
                    {
                        g.DrawEllipse(pen2, World.Cells[x].X_C, World.Cells[x].Y_C, 6, 6);
                    }
                }
                for (int x = 0; x < World.Roads.Count; x++)
                {
                    //rysowanie drog
                    g.DrawLine(pen, World.Roads[x].P1, World.Roads[x].P2);
                }
            }
            pictureBox1.Image = bmp;
            MoveAnts();
        }

        private void buttonAddAnt_Click(object sender, EventArgs e)
        {
            Ant ant = new Ant(new Point(World.Cells[0].X_C, World.Cells[0].Y_C));
            World.Ants.Add(ant);
            counter++;
            label1.Text = counter.ToString();
            label1.Update();
            /*ant.AntThread.Start();
            while (!ant.AntThread.IsAlive)
            {
                Thread.Sleep(1);
            }*/
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            int temp = 0;
            Random rnd = new Random();
            List<Road> tempRoad = new List<Road>(); ;
            for (int i = 0; i < World.Ants.Count; i++)
            {
                tempRoad.Clear();
                if (World.Ants[i].p.Equals(World.Cells[World.Cells.Count - 1]))
                    continue;
                foreach (Road road in World.Roads)
                {
                    if (World.Ants[i].p.Equals(road.P1))
                    {
                        tempRoad.Add(new Road(World.Ants[i].p, road.P2));
                    }
                }
                temp = rnd.Next(0, tempRoad.Count);
                World.Ants[i].p = tempRoad[temp].P2;
            }
            Invalidate();
        }
        private void MoveAnts()
        {

            int temp = 0;
            Random rnd = new Random();
            List<Road> tempRoad = new List<Road>(); ;
            for (int i = 0; i < World.Ants.Count; i++)
            {
                tempRoad.Clear();
                if (World.Ants[i].p.Equals(World.Cells[World.Cells.Count - 1]))
                    continue;
                foreach (Road road in World.Roads)
                {
                    if (World.Ants[i].p.Equals(road.P1))
                    {
                        tempRoad.Add(new Road(World.Ants[i].p, road.P2));
                    }
                }
                temp = rnd.Next(0, tempRoad.Count);
                World.Ants[i].p = tempRoad[temp].P2;
            }
            Invalidate();
        }
    }
}


