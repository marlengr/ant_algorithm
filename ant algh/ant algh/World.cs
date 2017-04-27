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

        Random rnd = new Random();
        public int random1(int maxValue)
        {
            maxValue = rnd.Next(1,700);
            return maxValue;
        }
        public int random2(int minValue)
        {
            minValue = rnd.Next(1,300);
            return minValue;
        }
        // tworzenie mrowki 
        public void Generate(int antsNumber) {
            for (int i = 0; i < antsNumber; i++)
            {
                Ant ant = new Ant(50 + i * 10, 50 + i * 10);
                Ants.Add(ant);
            }
        }

        public void GenerateCell(int cellNumber)
        {
            for (int i = 0; i < cellNumber; i++)
            {
                Cell cell = new Cell(rnd.Next(700), rnd.Next(300));
                Cells.Add(cell);  
            }
        }
    }
}
