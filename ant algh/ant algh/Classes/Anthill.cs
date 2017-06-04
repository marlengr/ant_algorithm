using System.Drawing;
using System.Windows.Forms;

namespace ant_algh.Classes
{
    public class Anthill
    {
        public void CreateAnthill(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, 50, 50, 20, 20);
        }
    }
}

