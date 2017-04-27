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

        public Cell(int x_c, int y_c)
        {
            X_C = x_c;
            Y_C = y_c;
            
        }

        public void CreateCell(object sender, PaintEventArgs e, int x_c, int y_c)
        {
            // SolidBrush redBrush = new SolidBrush(Color.Blue);
            e.Graphics.FillEllipse(Brushes.Orange, x_c, y_c, 20, 20);
        }



    }
}
