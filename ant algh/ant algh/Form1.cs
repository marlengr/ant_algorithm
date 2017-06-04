using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using ant_algh.Classes;

namespace ant_algh
{
    public partial class MainForm : Form
    {
        private readonly World _world;
        private readonly Pen _pen;
        private readonly Pen _pen2;
        private readonly Pen _pen3;
        private readonly Pen _pen4;
        private readonly Bitmap _bitmap;
        private readonly Graphics _graphics;
        private int _counter;
        

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
            _pen4 = new Pen(Color.Orange, 5);

            _world.GenerateCell(5, _bitmap.Width / 5);

            _counter = 0;
        }

        public void ButtonStart_click(object sender, EventArgs e)
        {
            for (int i = 0; i < _world.Ants.Count; i++)
            {
                _world.Ants[i].Run = true;
                _world.Ants[i].AntThread.Start();
                while (!_world.Ants[i].AntThread.IsAlive)
                {
                    Thread.Sleep(1);
                }
            }
        }

        public void ButtonStop_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < _world.Ants.Count; i++)
            //{
            //    _world.Ants[i].Run = false;
            //    _world.Ants[i].AntThread.Abort();
            //}
            
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            _world.Ants.Clear();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (_world.Ants.Count == 0)
            {
                Ant ant = new Ant(new Point(_world.Cells[0].Point.X, _world.Cells[0].Point.Y), _world.Cells); 
                ant.AntCells[0].CellPheromonUp++;
                _world.Ants.Add(ant);
                
            }
            else //spr czy jest juz jakas mrowka, jesli tak to dostaje liste komorek od ostatniej mrowki w liscie bo feromony
            {
                Ant ant = new Ant(new Point(_world.Cells[0].Point.X, _world.Cells[0].Point.Y), _world.Ants[_world.Ants.Count - 1].AntCells);
                ant.AntCells[0].CellPheromonUp++;
                _world.Ants.Add(ant);
            }

            _counter = _world.Ants.Count;
            AntCountLabel.Text = _counter.ToString();
            AntCountLabel.Update();

        }

        private void ButtonMove_Click(object sender, EventArgs e)
        {

            Random rnd = new Random();
            List<Road> tempRoad = new List<Road>();
            List<Cell> tempCell = new List<Cell>();
            for (int i = 0; i < _world.Ants.Count; i++)
            {
                tempRoad.Clear();
                tempCell.Clear();
                //pobieram dostepne drogi z komorki w ktorej jestem
                foreach (Road road in _world.Roads) //dodaje drogi dostepne dla mrowki z kazdego pkt
                {
                    if (_world.Ants[i].Point.Equals(road.P1))
                    {
                        tempRoad.Add(new Road(_world.Ants[i].Point, road.P2));
                    }
                }
                //jesli jest w ostatnim pkt = jedzonko to wroc
                if (_world.Ants[i].Point.Equals(_world.Ants[i].AntCells[_world.Ants[i].AntCells.Count - 1].Point))
                {
                    MoveBack(_world.Ants[i]);
                }
                else
                {
                    //Pobieram Komorki dostepne z dostepych drog
                    for (int ii = tempRoad.Count; ii > 0; ii--)
                    {
                        for (int jj = _world.Ants[i].AntCells.Count; jj > 0; jj--)
                        {
                            if (tempRoad[ii - 1].P2.Equals(_world.Ants[i].AntCells[jj - 1].Point)) //porownujemy wszystkie komorki dla konkretnej mrowki z dosstepnymi drogami
                            {
                                tempCell.Add(new Cell(_world.Ants[i].AntCells[jj - 1].Point, _world.Ants[i].AntCells[jj - 1].CellPheromonUp, _world.Cells[jj - 1].CellPheromonBack));
                                //feromon up specyficzny dla kazxdej mrowki, back z listy globalnej
                            }
                        }
                    }
                    //wyciagam z listy tempCell komorke z najmniejsza wartoscia CellPheromonUp 
                    //i najwieksza wartoscia CellPheromonBack
                    //oraz jesli spelniane sa te warunki przez wiecej niz 1 obiekt
                    //zwracany jest randomowo.

                    int minUp = tempCell.Min(s => s.CellPheromonUp);
                    var minCellPheromonList1 = from Cell c in tempCell
                                               where (c.CellPheromonUp == minUp)
                                               select c;
                    int maxBack = minCellPheromonList1.Max(s => s.CellPheromonBack);
                    var minCellPheromonList2 = from Cell c in minCellPheromonList1
                                               where (c.CellPheromonBack == maxBack)
                                               select c;
                    //up najmn, back najw
                    var minCellPheromon1 = minCellPheromonList2.ElementAt(rnd.Next(0, minCellPheromonList2.Count()));

                    //IDE
                    for (int ww = tempRoad.Count; ww > 0; ww--)
                    {
                        if (_world.Ants[i].Point.Equals(tempRoad[ww - 1].P1) && minCellPheromon1.Point.Equals(tempRoad[ww - 1].P2))
                        {
                            _world.Ants[i].RoadsMemoryList.Add(tempRoad[ww - 1]);
                            _world.Ants[i].Point = minCellPheromon1.Point;

                            for (int zz = _world.Ants[i].AntCells.Count; zz > 0; zz--)
                            {
                                if (_world.Ants[i].AntCells[zz - 1].Point.Equals(minCellPheromon1.Point))
                                {
                                    _world.Ants[i].AntCells[zz - 1].CellPheromonUp++;
                                }
                            }
                        }
                    }
                }
            }
            Invalidate();
            
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            const int dist = 3;
            if (_world.Ants.Count != 0)
            {
                _graphics.Clear(Color.White);
                for (int x = 0; x < _world.Ants.Count; x++)
                {
                    if (!_world.Ants[x].Run) continue;
                    Font drawFont = new Font("Arial", 8);
                    SolidBrush drawBrush = new SolidBrush(Color.Fuchsia);
                    //rysowanie punktow mrowek
                    _graphics.DrawEllipse(new Pen(Color.Green, 10), _world.Ants[x].Point.X - dist, _world.Ants[x].Point.Y - dist, 5, 5);
                    _graphics.DrawString(x.ToString(), drawFont, drawBrush, _world.Ants[x].Point.X - dist + 25, _world.Ants[x].Point.Y - dist - 5);
                }
                pictureBoxWorld.Image = _bitmap;
                _counter++;
                bzduraLabel.Text = _counter.ToString();
            }

            if (_world.Cells.Count != 0)
            {
                for (int x = 0; x < _world.Roads.Count; x++)
                {
                    //rysowanie drog
                    _graphics.DrawLine(_pen, _world.Roads[x].P1, _world.Roads[x].P2);
                }
                for (int x = 0; x < _world.Cells.Count; x++)
                {
                    //rysowanie komorek
                    if (x == 0)
                    {
                        _graphics.DrawEllipse(_pen3, _world.Cells[x].Point.X - dist, _world.Cells[x].Point.Y - dist, 8, 8);//poczatek
                    }
                    if (x == _world.Cells.Count - 1)
                    {
                        _graphics.DrawEllipse(_pen4, _world.Cells[x].Point.X - dist, _world.Cells[x].Point.Y - dist, 8, 8);//koniec - food
                    }
                    if (x != 0 && x != _world.Cells.Count - 1)
                    {
                        _graphics.DrawEllipse(_pen2, _world.Cells[x].Point.X - dist, _world.Cells[x].Point.Y - dist, 6, 6);
                    }
                }
            }
            //MoveAnts();
            pictureBoxWorld.Image = _bitmap;
        }

        private void MoveBack(Ant ant)
        {
            for (int i = ant.RoadsMemoryList.Count - 1; i >= 0; i--)
            {
                ant.Point = ant.RoadsMemoryList[i].P1;
                Update();
            }
            for (int i = 0; i < ant.RoadsMemoryList.Count; i++)
            {
                for (int ii = 0; ii < ant.AntCells.Count; ii++)
                {
                    if (ant.RoadsMemoryList[i].P2.Equals(ant.AntCells[ii].Point))
                    {
                        _world.Cells[ii].CellPheromonBack++;
                    }
                    ant.AntCells[ii].CellPheromonUp = 0;
                }
            }
            _world.Cells[0].CellPheromonBack++;
            ant.AntCells[0].CellPheromonUp++;
            ant.RoadsMemoryList.Clear();
        }

        private void MoveAnts()
        {
            Random rnd = new Random();
            List<Road> tempRoad = new List<Road>();
            List<Cell> tempCell = new List<Cell>();
            for (int i = 0; i < _world.Ants.Count; i++)
            {
                tempRoad.Clear();
                tempCell.Clear();
                //pobieram dostepne drogi z komorki w ktorej jestem
                foreach (Road road in _world.Roads)
                {
                    if (_world.Ants[i].Point.Equals(road.P1))
                    {
                        tempRoad.Add(new Road(_world.Ants[i].Point, road.P2));
                    }
                }
                if (_world.Ants[i].Point.Equals(_world.Ants[i].AntCells[_world.Ants[i].AntCells.Count - 1].Point))
                {
                    MoveBack(_world.Ants[i]);
                }
                else
                {
                    //Pobieram Komorki dostepne z dostepych drog
                    for (int ii = tempRoad.Count; ii > 0; ii--)
                    {
                        for (int jj = _world.Ants[i].AntCells.Count; jj > 0; jj--)
                        {
                            if (tempRoad[ii - 1].P2.Equals(_world.Ants[i].AntCells[jj - 1].Point))
                            {
                                tempCell.Add(new Cell(_world.Ants[i].AntCells[jj - 1].Point, _world.Ants[i].AntCells[jj - 1].CellPheromonUp, _world.Cells[jj - 1].CellPheromonBack));
                            }
                        }
                    }
                    //'wyciagam' z listy tempCell komorke z najmniejsza wartoscia CellPheromonUp 
                    //i najwieksza wartoscia CellPheromonBack
                    //oraz jesli spelniane sa te warunki przez wiecej niz 1 obiekt
                    //zwracany jest randomowo.

                    int minUp = tempCell.Min(s => s.CellPheromonUp);
                    var minCellPheromonList1 = from Cell c in tempCell
                                               where (c.CellPheromonUp == minUp)
                                               select c;
                    int maxBack = minCellPheromonList1.Max(s => s.CellPheromonBack);
                    var minCellPheromonList2 = from Cell c in minCellPheromonList1
                                               where (c.CellPheromonBack == maxBack)
                                               select c;
                    var minCellPheromon1 = minCellPheromonList2.ElementAt(rnd.Next(0, minCellPheromonList2.Count()));

                    //IDE
                    for (int ww = tempRoad.Count; ww > 0; ww--)
                    {
                        if (_world.Ants[i].Point.Equals(tempRoad[ww - 1].P1) && minCellPheromon1.Point.Equals(tempRoad[ww - 1].P2))
                        {
                            _world.Ants[i].RoadsMemoryList.Add(tempRoad[ww - 1]);
                            _world.Ants[i].Point = minCellPheromon1.Point;

                            for (int zz = _world.Ants[i].AntCells.Count; zz > 0; zz--)
                            {
                                if (_world.Ants[i].AntCells[zz - 1].Point.Equals(minCellPheromon1.Point))
                                {                               
                                    _world.Ants[i].AntCells[zz - 1].CellPheromonUp++;
                                }
                            }
                        }
                    }
                }
            }
            Invalidate();
            Thread.Sleep(400);
        }
    }
}