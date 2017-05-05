using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace ant_algh
{
    class World
    {
        //public Cell[,] Map = new Cell [100,100];
        public Anthill Anthill = new Anthill();
        public Food Food = new Food();
        public List<Ant> Ants = new List<Ant>();
        public List<Cell> Cells = new List<Cell>();
        public List<Road> Roads = new List<Road>();

        Random rnd = new Random();
        public int random1(int maxValue)
        {
            maxValue = rnd.Next(1, 700);
            return maxValue;
        }
        public int random2(int minValue)
        {
            minValue = rnd.Next(1, 300);
            return minValue;
        }
        // tworzenie mrowki 
        //public void GenerateAnt(int antsNumber)
        //{
        //    for (int i = 0; i < antsNumber; i++)
        //    {
        //        Ant ant = new Ant(50 + i * 10, 50 + i * 10);
        //        Ants.Add(ant);
        //    }
        //}

        public void GenerateCell(int cellNumber)
        {
            for (int i = 0; i < cellNumber; i++)
            {
                for (int j = 0; j < cellNumber; j++)
                {
                    Cell cell = new Cell(20 + j * 30, 20 + i * 30);
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
                if (x + cellNumber < Cells.Count)//pionowo
                {
                    Road road = new Road(Cells[x].Point, Cells[x + cellNumber].Point);
                    Roads.Add(road);
                }
                if (x + 1 < Cells.Count && (x + 1) % (cellNumber) != 0)//poziomo
                {
                    Road road = new Road(Cells[x].Point, Cells[x + 1].Point);
                    Roads.Add(road);
                }
                if (x - cellNumber >= 0)//pionowo
                {
                    Road road = new Road(Cells[x].Point, Cells[x - cellNumber].Point);
                    Roads.Add(road);
                }
                if (x - 1 >= 0 && (x) % (cellNumber) != 0)//poziomo
                {
                    Road road = new Road(Cells[x].Point, Cells[x - 1].Point);
                    Roads.Add(road);
                }

            }
        }

        
    }
}
