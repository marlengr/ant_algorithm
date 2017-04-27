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
        private static readonly Random Random = new Random();
        
        private static readonly object SyncLock = new object();

        public static int RandomNumber(int min, int max)
        {
            lock (SyncLock)
            { // synchronize
                return Random.Next(min, max);
            }
        }

        public static bool Run = false;

        public Ant(int x, int y)
        {
            X = x;
            Y = y;
            AntThread = new Thread(DoSomething);
        }
        
        public void DoSomething() 
        {
            while (Run)
            {
                X = Random.Next(700);
                Y = Random.Next(350);
                Thread.Sleep(2000);
            }
        }
        
    }
}
