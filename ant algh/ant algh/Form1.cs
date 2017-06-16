using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Timers;
using ant_algh.Classes;
using Timer = System.Windows.Forms.Timer;

namespace ant_algh
{
    public partial class MainForm : Form
    {
        private readonly World _world;
        private readonly Pen _pen;
        private readonly Pen _pen2;
        private readonly Pen _pen3;
        private readonly Bitmap _bitmap;
        private readonly Graphics _graphics;
        bool _startstop = false;
        

        public MainForm()
        {
            InitializeComponent();

            _world = new World();
            _bitmap = new Bitmap(pictureBoxWorld.Width, pictureBoxWorld.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
            _pen = new Pen(Color.DarkGray, 1);
            _pen2 = new Pen(Color.Black, 2);
            _pen3 = new Pen(Color.Yellow, 5);            
            World.GenerateCell(6, _bitmap.Width / 6);
            
            ReDraw();
        }

        public void ButtonStart_click(object sender, EventArgs e)

        {
            if (_startstop == true) MessageBox.Show("Nie możesz ponownie wystartować wątków");
            else
            {
                World.Run = true;
                //autoreset Timera
                World.Timer.AutoReset = true;
                World.Timer.Elapsed += new ElapsedEventHandler(World.CellPheromonBackDec);
                World.Timer.Start();

                for (int i = 0; i < World.Ants.Count; i++)
                {
                    if (World.Ants[i].Run == false)
                    {
                        World.Ants[i].Run = true;
                        World.Ants[i].AntThread.Start();
                        while (!World.Ants[i].AntThread.IsAlive)
                        {
                            Thread.Sleep(1);
                        }
                    }
                }
                ReDraw();
            }
        }

        public void ButtonStop_Click(object sender, EventArgs e)
        {
            _startstop = true;
            World.Run = false;
            World.Timer.Stop();
            for (int i = 0; i < World.Ants.Count; i++)
            {
                if (World.Ants[i].Run)
                {
                    World.Ants[i].Run = false;
                    if (!World.Ants[i].AntThread.IsAlive)
                        World.Ants[i].AntThread.Abort();
                }
            }
            ReDraw();
        }
                
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            //zabezpieczenie przez znakami lub pustym polem
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]") || (textBox1.Text == ""))
            {
                MessageBox.Show("Musisz wpisać liczbę");
            }

            else
            {
                for (int i = 0; i < int.Parse(textBox1.Text); i++)
                {
                    Ant ant = new Ant(new Point(World.Cells[0].Point.X, World.Cells[0].Point.Y), World.Cells);
                    ant.AntCells[0].cellPheromoneUp++;
                    World.Ants.Add(ant);
                    AntCountLabel.Text = World.Ants.Count.ToString();
                }
            }
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {            
            if (World.Run)
            {
                const int dist = 3;
                if (World.Ants.Count > 0)
                {
                    _graphics.Clear(Color.White);
                    for (int x = 0; x < World.Ants.Count; x++)
                    {
                        if (!World.Ants[x].Run) continue;
                        //rysowanie punktow mrowek
                        _graphics.DrawEllipse(new Pen(Color.Green, 10), World.Ants[x].Point.X - dist, World.Ants[x].Point.Y - dist, 5, 5);
                    }
                }

                if (World.Cells.Count != 0)
                {
                    for (int x = 0; x < World.Roads.Count; x++)
                    {
                        Font drawFont = new Font("Arial", 8);
                        SolidBrush drawBrush = new SolidBrush(Color.Black);
                        //rysowanie drog
                        _graphics.DrawLine(_pen, World.Roads[x].P1, World.Roads[x].P2);
                    }
                    for (int x = 0; x < World.Cells.Count; x++)
                    {
                        Font drawFont = new Font("Arial", 8);
                        SolidBrush drawBrush = new SolidBrush(Color.Red);
                        //rysowanie komorek
                        if (x == 0)
                        {
                            _graphics.DrawEllipse(_pen3, World.Cells[x].Point.X - dist, World.Cells[x].Point.Y - dist, 8, 8);//poczatek
                        }
                        if (x == World.Cells.Count - 1)
                        {
                            _graphics.DrawEllipse(_pen3, World.Cells[x].Point.X - dist, World.Cells[x].Point.Y - dist, 8, 8);//koniec - food
                        }
                        if (x != 0 && x != World.Cells.Count - 1)
                        {
                            _graphics.DrawEllipse(_pen2, World.Cells[x].Point.X - dist, World.Cells[x].Point.Y - dist, 6, 6);
                        }
                        _graphics.DrawString(World.Cells[x].cellPheromoneBack.ToString(), drawFont, drawBrush, World.Cells[x].Point.X + 5, World.Cells[x].Point.Y + 5);
                    }
                }
                
                ReDraw();

            }
        }

        private void ReDraw()
        {
            pictureBoxWorld.Image = _bitmap;
        }
    }
}