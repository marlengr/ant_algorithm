using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace ant_algh.Classes
{
    public class Ant
    {
        public Thread AntThread;
        public Point Point;
        public List<Cell> AntCells = new List<Cell>();
        public List<Road> RoadsMemoryList;
        public bool Run;

        public Ant(Point point,List<Cell> CellList )
        {
            Point = point;
            AntThread = new Thread(DoSomething);
            AntCells = new List<Cell>();
            RoadsMemoryList = new List<Road>();
            Run = true;

            for (int i = 0; i < CellList.Count; i++ )
            {
                Cell cell = new Cell(CellList[i].Point, 0, CellList[i].CellPheromonBack);
                AntCells.Add(cell); 
            }
        }
        
        public void DoSomething() 
        {
            while (Run)
            {
                Thread.Sleep(20000);
            }
        }
    }
}
