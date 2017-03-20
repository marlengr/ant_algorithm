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
        public int X = 0;
        public int Y = 0;
        public static bool Run = false;

        public Ant()
        {
            antThread = new Thread(doSomething);
            //MessageBox.Show("utworzono watek");
        }

        public Ant(int x, int y)
        {
            X = x;
            Y = y;
            antThread = new Thread(doSomething);
            //MessageBox.Show("utworzono watek");
        }


        public void doSomething()
        {
            while (Run)
            {
                Random r = new Random();
                X = r.Next(100);
                Y = r.Next(100);
                Thread.Sleep(2000);
            }
        }

       


    }
}
