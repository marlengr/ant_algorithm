using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace ant_algh
{
    public class Food
    {
        public void CreateFood(object sender, PaintEventArgs e)
        {
           // SolidBrush redBrush = new SolidBrush(Color.Blue);
            e.Graphics.FillEllipse(Brushes.Aqua, 550, 250, 20, 20);
        }
    }
}

