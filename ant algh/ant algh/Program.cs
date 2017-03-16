using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ant_algh
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            List<Ant> antsList = new List<Ant>();
            for (int i = 1; i < 10; i++)
            {
                antsList.Add(new Ant());
                //MessageBox.Show("utworzono watek");
            }
            // antsList[0].antThread.robcos//dostep do danej mrowki po indeksie z listy
            
        }
    }
}
