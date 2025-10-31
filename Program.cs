///
///<summary>
///refrences:
///https://learn.microsoft.com/en-us/dotnet/standard/collections/
///https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/
///https://learn.microsoft.com/en-us/dotnet/desktop/winforms/
/// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-9.0
/// https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/layout
/// https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/layout


/// </summary>
///
using System;
using System.Windows.Forms;
using MunicipalityV4.Forms;


namespace MunicipalityV4
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.MainForm());
        }
    }
}
