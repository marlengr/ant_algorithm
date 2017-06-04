using System.Drawing;
using System.Threading;

namespace ant_algh.Classes
{
    public class Cell
    {
        //float Pheromon;
        public Thread Pheromon;
        public Point Point;
        public int CellPheromonUp;
        public int CellPheromonBack;

        public Cell(Point point, int cellPheromonUp, int cellPheromonBack)
        {
            Point = point;
            CellPheromonUp = cellPheromonUp;
            CellPheromonBack = cellPheromonBack;
        }
    }
}
