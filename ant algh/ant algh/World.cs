using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ant_algh
{
    class World
    {
        public Cell[,] Map = new Cell [100,100];
        public Anthill Anthill = new Anthill();
        public Food Food = new Food();
        public List<Ant> Ants = new List<Ant>();

        public void Generate() {
            for (int i = 1; i < 10; i++)
            {
                Ants.Add(new Ant(30+i,30+i));
                //MessageBox.Show("utworzono watek");
            }
        }
    }


}
