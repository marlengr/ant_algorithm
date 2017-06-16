using System.Drawing;
using System.Threading;

namespace ant_algh.Classes
{
    public class Cell
    {
        public Point Point;
        public int cellPheromoneUp;
        public int cellPheromoneBack;

        public Cell(Point point, int cellPheromoneUp, int cellPheromoneBack)
        {
            Point = point;
            this.cellPheromoneUp = cellPheromoneUp;
            this.cellPheromoneBack = cellPheromoneBack;
        }
    }
}
