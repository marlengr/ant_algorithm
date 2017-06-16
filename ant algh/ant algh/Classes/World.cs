using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;

namespace ant_algh.Classes
{
    public class World
    {
        public static Anthill Anthill = new Anthill();
        public static Food Food = new Food();
        public static List<Ant> Ants = new List<Ant>();
        public static List<Cell> Cells = new List<Cell>();
        public static List<Road> Roads = new List<Road>();
        public static bool Run = false;
        public static Timer Timer = new Timer(TimeSpan.FromMilliseconds(250).TotalMilliseconds);
        private static readonly Random Random = new Random();
        private static readonly object SyncLock = new object();

        public static int RandomNumber(int min, int max)
        {
            lock (SyncLock)
            { // synchronize
                return Random.Next(min, max);
            }
        }

        public static void CellPheromonBack(Point point)
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                if (point.Equals(Cells[i].Point))
                {
                    Cells[i].cellPheromoneBack++;
                }
            }
        }

        public static void CellPheromonBackDec(object sender, ElapsedEventArgs e)
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                Cells[i].cellPheromoneBack--;
                if (Cells[i].cellPheromoneBack <= 0)
                {
                    Cells[i].cellPheromoneBack = 0;
                }
            }
        }

        public static void GenerateCell(int cellNumber, int distance)
        {
            for (int i = 0; i < cellNumber; i++)
            {
                for (int j = 0; j < cellNumber; j++)
                {
                    Cell cell = new Cell(new Point(50 + j * distance, 50 + i * distance / 2), 0, 0);
                    Cells.Add(cell);
                }
            }
            GenerateRoad(cellNumber);
        }

        public static void GenerateRoad(int cellNumber)
        {
            for (int x = 0; x < Cells.Count; x++)
            {
                //dodawanie drog
                Road road;
                if (x + cellNumber < Cells.Count)//pionowo
                {
                    road = new Road(Cells[x].Point, Cells[x + cellNumber].Point);
                    Roads.Add(road);
                }
                if (x + 1 < Cells.Count && (x + 1) % (cellNumber) != 0)//poziomo
                {
                    road = new Road(Cells[x].Point, Cells[x + 1].Point);
                    Roads.Add(road);
                }
                if (x - cellNumber >= 0)//pionowo
                {
                    road = new Road(Cells[x].Point, Cells[x - cellNumber].Point);
                    Roads.Add(road);
                }
                if (x - 1 >= 0 && (x) % (cellNumber) != 0)//poziomo
                {
                    road = new Road(Cells[x].Point, Cells[x - 1].Point);
                    Roads.Add(road);
                }
            }
        }
    }
}
