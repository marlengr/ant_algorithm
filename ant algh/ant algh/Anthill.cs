using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;


namespace ant_algh
{
    public partial class Anthill
    {
        //private PictureBox pictureBox1 = new PictureBox();
        public void CreateAnthill(object sender, PaintEventArgs e)
        {
            SolidBrush redBrush = new SolidBrush(Color.Red);
            e.Graphics.FillEllipse(redBrush, 50, 50, 20, 20);
        }
    }
}

