using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;



namespace ant_algh
{
    class Ant
    {

        public Thread antThread;

        public Ant()
        {
            antThread = new Thread(doSomething);
            //MessageBox.Show("utworzono watek");
        }


        public static void doSomething()
        {
            //Graphics myGraphics = base.CreateGraphics();
            //Pen myPen = new Pen(Color.Red);
            //SolidBrush mySolidBrush = new SolidBrush(Color.Red);
            //yGraphics.DrawEllipse(myPen, 10, 10, 10, 10);

            // for (int i = 0; i <= 1; i++)
            //   MessageBox.Show("utworzyles watek");

        }

       
              
        Graphics g;
        //jak sie dostac do niestatycznej metody??
        public void Run()
        {
            Pen myPen = new Pen(Color.Black);
            SolidBrush mySolidBrush = new SolidBrush(Color.Red);
            g.DrawEllipse(myPen, 10, 10, 10, 10);
        }
        

    }
}
