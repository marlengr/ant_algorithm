using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace ant_algh
{
    class World
    {
        public Cell[,] Map = new Cell [100,100];
        public Anthill Anthill = new Anthill();
        public Food Food = new Food();
        public List<Ant> Ants = new List<Ant>();

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

        public void Generate(int antsNumber) {
            for (int i = 0; i < antsNumber; i++)
            {
                Ant ant = new Ant(50 + i * 10, 50 + i * 10);
                Ants.Add(ant);
            }
        }
    }


}
