using Aspose.Words;
using Aspose.Words.Tables;
using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Xml;
using VolumeGenerator;
using VolumeGeneratorApp.Oregon;

namespace VolumeGeneratorApp
{
    public partial class Form1 : Form
    {
        private string _cpCountyFromCertCaption = "";
        private string _cpAppeal = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtFolderPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {

            string folderPath = txtFolderPath.Text;

            if (string.IsNullOrWhiteSpace(folderPath))
            {
                MessageBox.Show("Please select a folder first.");
                return;
            }

            int maxPages = (int)numMaxPages.Value;

            var service = new VolumeService();

            // 1) Merge all DOCX in the folder into MERGED_DOC.docx
            lblOutput.Text = "Merging transcripts into one document";
            string mergedDocPath = service.MergeWordDocsInFolder(folderPath);

            // 2) Split the merged doc into volumes based on maxPages
            var volumes = service.SplitLastMergedIntoVolumes(maxPages);

            // 3) Jurisdiction specific processing
            string jurisdiction = cboJurisdiction.SelectedItem?.ToString() ?? "";

            switch (jurisdiction)
            {
                case "Oregon":
                    RunOregonWorkflow(folderPath, mergedDocPath, volumes, service);
                    break;

                case "CA Superior":
                    //RunCaliforniaSuperiorWorkflow(folderPath, mergedDocPath, volumes);
                    break;

                default:
                    MessageBox.Show(
                        $"No workflow implemented for jurisdiction: {jurisdiction}",
                        "Jurisdiction not supported",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    break;
            }

        }
        private void RunOregonWorkflow(string folderPath, string mergedDocPath, List<VolumeInfo> volumes, VolumeService service)
        {
            var coverIndexFiller = new OregonFillCoverIndex();
            coverIndexFiller.GatherTranscribersForVolumes(volumes);


            var oregon = new OregonWorkFlow(); // your Oregon.cs class

            // 3) Insert Cert of Filing and Preparation
            using (var captionForm = new frmCertCaption())
            {
                if (captionForm.ShowDialog(this) != DialogResult.OK)
                    return;

                _cpCountyFromCertCaption = captionForm.County;
                _cpAppeal = captionForm.AppealNumber;

                oregon.InsertOregonCertificatesWithAspose(mergedDocPath, captionForm);
            }

            // 4) Add appearances
            using (var appearancesForm = new frmCertAppearances())
            {
                if (appearancesForm.ShowDialog(this) != DialogResult.OK)
                    return;

                oregon.InsertOregonCertAppearancesWithAspose(mergedDocPath, appearancesForm, _cpCountyFromCertCaption);
            }

            // 5) Add date / volume / page ranges to cert pages
            lblOutput.Text += Environment.NewLine + "Generating Certificate of Filing and Preparation";

            var lines = oregon.BuildVolumeListing(volumes);
            oregon.InsertLinesAtBookmark(mergedDocPath, "certofprep", lines);
            oregon.InsertLinesAtBookmark(mergedDocPath, "certofprep2", lines);

            // 6) Export cert PDFs
            var exporter = new PdfExporter();
            string certOutputFolder = Path.Combine(folderPath, "Certificates");
            exporter.ExportCertificates(mergedDocPath, certOutputFolder);

            // 7) Get Transcriber names involved for file renaming purposes used later
            // Step 7: Ask user for transcriber override per volume
            oregon.CollectTranscriberOverridesPerVolume(this, volumes, service);


            // 8) Fill cover/index info in Volume_#.docx
            coverIndexFiller.ProcessAllVolumeDocs(volumes, _cpAppeal);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
