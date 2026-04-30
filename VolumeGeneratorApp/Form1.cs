using Aspose.Words;
using Aspose.Words.Tables;
using Microsoft.VisualBasic;
using System;
using System.Diagnostics.Eventing.Reader;
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
        private OregonCaptionData? _oregonCaptionData;
        private OregonWorkFlow? _oregonAppearances;

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

            int maxPages = 300;

            var service = new VolumeService();

            // 1) Merge all DOCX in the folder into MERGED_DOC.docx
            lblOutput.Text = "🟢 Merging transcripts into one document";
            string mergedDocPath = service.MergeWordDocsInFolder(folderPath);
            progress.Value += 1;

            lblOutput.Text += Environment.NewLine + "🟢 Splitting master document into separate volumes";
            // 2) Split the merged doc into volumes based on maxPages
            var volumes = service.SplitLastMergedIntoVolumes(maxPages);
            progress.Value += 1;

            // 3) Jurisdiction specific processing
            RunOregonWorkflow(folderPath, mergedDocPath, volumes, service);

            lblOutput.Text += Environment.NewLine + "✅ Processing complete.  Please click reset to start a new job.";
            txtFolderPath.Text = null;

            MessageBox.Show("The job has completed processing", "Job Completed", MessageBoxButtons.OK);
        }
        private void RunOregonWorkflow(string folderPath, string mergedDocPath, List<VolumeInfo> volumes, VolumeService service)
        {
            var coverIndexFiller = new OregonFillCoverIndex();

            var oregon = new OregonWorkFlow(); // your Oregon.cs class

            lblOutput.Text += Environment.NewLine + "🟢 Generating Certificate of Filing and Preparation";
            // 3) Insert Cert of Filing and Preparation

            using (var captionForm = new frmCertCaption(mergedDocPath))
            {


                if (captionForm.ShowDialog(this) != DialogResult.OK)
                    return;

                _cpCountyFromCertCaption = captionForm.County;
                _cpAppeal = captionForm.AppealNumber;
                _oregonCaptionData = new OregonCaptionData
                {
                    County = captionForm.County,
                    Name1 = captionForm.Name1,
                    Name2 = captionForm.Name2,
                    Party1 = captionForm.Party1,
                    Party2 = captionForm.Party2,
                    CaseNumber = captionForm.CaseNumber,
                    AppealNumber = captionForm.AppealNumber
                };
                oregon.InsertOregonCertificatesWithAspose(mergedDocPath, captionForm);
            }

            progress.Value += 1;
            // 4) Add appearances
            using (var appearancesForm = new frmCertAppearances())
            {
                if (appearancesForm.ShowDialog(this) != DialogResult.OK)
                    return;

                _oregonAppearances = new OregonWorkFlow
                {

                    AppellantAttorney = appearancesForm.AppellantAttorney,
                    AppellantFirm = appearancesForm.AppellantFirm,
                    AppellantAddress = appearancesForm.AppellantAddress,
                    AppellantCity = appearancesForm.AppellantCity,
                    AppellantState = appearancesForm.AppellantState,
                    AppellantZip = appearancesForm.AppellantZip,
                    AppellantEmail = appearancesForm.AppellantEmail,
                    AppellantPhone = appearancesForm.AppellantPhone,

                    RespondentAttorney = appearancesForm.RespondentAttorney,
                    RespondentFirm = appearancesForm.RespondentFirm,
                    RespondentAddress = appearancesForm.RespondentAddress,
                    RespondentCity = appearancesForm.RespondentCity,
                    RespondentState = appearancesForm.RespondentState,
                    RespondentZip = appearancesForm.RespondentZip,
                    RespondentEmail = appearancesForm.RespondentEmail,
                    RespondentPhone = appearancesForm.RespondentPhone
                };

                oregon.InsertOregonCertAppearancesWithAspose(mergedDocPath, appearancesForm, _cpCountyFromCertCaption);
            }

            progress.Value += 1;
            // 5) Add date / volume / page ranges to cert pages


            var lines = oregon.BuildVolumeListing(volumes);
            oregon.InsertLinesAtBookmark(mergedDocPath, "certofprep", lines);
            oregon.InsertLinesAtBookmark(mergedDocPath, "certofprep2", lines);

            lblOutput.Text += Environment.NewLine + "🟢 Generating PDFs for Certificate pages";

            progress.Value += 1;
            // 6) Export cert PDFs
            var exporter = new PdfExporter();
            string certOutputFolder = Path.Combine(folderPath, "Certificates");
            exporter.ExportCertificates(mergedDocPath, certOutputFolder, _cpAppeal);

            progress.Value += 1;
            // 7) Get Transcriber names involved for file renaming purposes used later
            // Step 7: Ask user for transcriber override per volume
            oregon.CollectTranscriberOverridesPerVolume(this, volumes, service);

            lblOutput.Text += Environment.NewLine + "🟢 Filling in cover pages and index pages with the proper volume and page range information";

            progress.Value += 1;
            // 8) Fill cover/index info in Volume_#.docx
            coverIndexFiller.ProcessAllVolumeDocs(volumes, _cpAppeal);

            lblOutput.Text += Environment.NewLine + "🟢 Generating the Extension of Time and Payment Documents";

            progress.Value += 1;
            // 9) Generate Extension of Time and Payment Word Docx
            if (_oregonCaptionData != null)
            {
                var captionBuilder = new OregonTimeExtensionDocBuilder();
                var nopayBuilder = new OregonWorkFlow();
                captionBuilder.CreateTimeExtensionDocument(folderPath, _oregonCaptionData, _oregonAppearances);
                nopayBuilder.CreateNoPaymentLetter(folderPath);
            }
            progress.Value += 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtFolderPath_TextChanged(object sender, EventArgs e)
        {
            if (txtFolderPath.Text.Length > 0)
            {
                btnMerge.Enabled = true;
            }
            else
            {
                btnMerge.Enabled = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFolderPath.Text = null;
            progress.Value = 0;
            lblOutput.Text = "Ready to process the next job.  Please click the browse button to select the job folder";
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How to materials have not been published yet.  Please wait for the next update.", "", MessageBoxButtons.OK);
        }
    }
}
