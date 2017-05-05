using System.Collections.Generic;
using System;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;


namespace ant_algh
{
    public class Ant
    {
        public Thread AntThread;
        public int X;
        public int Y;
        public Point p;
        private static readonly Random Random = new Random();
        World World = new World();
        
        private static readonly object SyncLock = new object();

        public static int RandomNumber(int min, int max)
        {
            lock (SyncLock)
            { // synchronize
                return Random.Next(min, max);
            }
        }

        public static bool Run = false;

        public Ant(Point p)
        {
            this.p = p;
            X = p.X;
            Y = p.Y;
            AntThread = new Thread(DoSomething);
        }

        
        public void DoSomething() 
        {
            while (Run)
            {
                //p.X = Random.Next(700);
                //p.Y = Random.Next(350);
                Thread.Sleep(2000);
            }
        }
        

    }
}
