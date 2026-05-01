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
            // MUST be first line
            VelopackApp.Build().Run();
            MessageBox.Show("Checking for updates...");

            try
            {
                var mgr = new UpdateManager(
                    new Velopack.Sources.GithubSource(
                        "https://github.com/mts-online83/VolumeGenerator",
                        null,
                        false
                    )
                );

                var updateInfo = mgr.CheckForUpdatesAsync().GetAwaiter().GetResult();

                if (updateInfo != null)
                {
                    mgr.DownloadUpdatesAsync(updateInfo).GetAwaiter().GetResult();
                    mgr.ApplyUpdatesAndRestart(updateInfo);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error:\n\n" + ex.ToString());
            }

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