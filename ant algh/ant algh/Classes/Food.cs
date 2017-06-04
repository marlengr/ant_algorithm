using System.Drawing;
using System.Windows.Forms;

namespace ant_algh.Classes
{
    public class Food
    {
        public void CreateFood(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Aqua, 550, 250, 20, 20);
        }
    }
}

