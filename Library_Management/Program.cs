using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
            //Home home = new Home();
            //home.ShowDialog();

        }
    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Home home = new Home();
    //        home.ShowDialog();
    //    }
    //}
}