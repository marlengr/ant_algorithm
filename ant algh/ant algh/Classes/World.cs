using System;
using System.Collections.Generic;
using System.Drawing;

namespace ant_algh.Classes
{
    public class World
    {
        public Anthill Anthill = new Anthill();
        public Food Food = new Food();
        public List<Ant> Ants = new List<Ant>();
        public List<Cell> Cells = new List<Cell>();
        public List<Road> Roads = new List<Road>();

        readonly Random _random = new Random();

        public int Random1(int maxValue)
        {
            maxValue = _random.Next(1, 700);
            return maxValue;
        }

        public int Random2(int minValue)
        {
            minValue = _random.Next(1, 300);
            return minValue;
        }

        private static readonly Random Random = new Random();
        private static readonly object SyncLock = new object();

        public static int RandomNumber(int min, int max)
        {
            lock (SyncLock)
            { // synchronize
                return Random.Next(min, max);
            }
        }

        public void GenerateCell(int cellNumber, int distance)
        {
            for (int i = 0; i < cellNumber; i++)
            {
                for (int j = 0; j < cellNumber; j++)
                {
                    //int distance = 40;
                    //Cell cell = new Cell(new Point(distance + j * distance*2, distance + i * distance), 0, 0);
                    Cell cell = new Cell(new Point(50 + j*distance, 50 + i*distance/2 ),0,0);
                    Cells.Add(cell);
                }
            }
            GenerateRoads(cellNumber);
        }

        public void GenerateRoads(int cellNumber)
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
