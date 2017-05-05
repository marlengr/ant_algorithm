using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace ant_algh
{
    class Cell
    {
        //float Pheromon;
        public Thread Pheromon;
        public int X_C, Y_C;
        public Point Point;

        public Cell(int x_c, int y_c)
        {
            X_C = x_c;
            Y_C = y_c;
            Point = new Point(X_C, Y_C);            
        }
    }
}
