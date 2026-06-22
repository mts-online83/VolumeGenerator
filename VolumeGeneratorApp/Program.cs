using Aspose.Words;
using System;
using System.Windows.Forms;
using Velopack;
using Velopack.Sources;
using System.Threading.Tasks;

namespace VolumeGeneratorApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            

            ApplyAsposeLicense();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void ApplyAsposeLicense()
        {
            var license = new License();
            license.SetLicense("Aspose.Total.NET 5.lic");
        }
    }
}