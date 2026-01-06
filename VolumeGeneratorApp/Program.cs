using Aspose.Words;
using System;
using System.Windows.Forms;

namespace VolumeGeneratorApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize Aspose license ONCE at application startup
            ApplyAsposeLicense();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static void ApplyAsposeLicense()
        {
            var license = new License();
            // This assumes the file is copied to the output folder (bin\Debug\netX\)
            license.SetLicense("Aspose.Total.NET 5.lic");
        }
    }
}