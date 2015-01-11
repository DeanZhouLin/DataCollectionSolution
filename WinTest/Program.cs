using System;
using System.Windows.Forms;

namespace WinTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。modify
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
