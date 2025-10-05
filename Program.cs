using System;
using System.Windows.Forms;
using MunicipalityV4.Forms;

namespace MunicipalityV4
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
