using Aspose.Words;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolumeGeneratorApp.Oregon
{

    public partial class frmCertCaption : Form
    {
        private OregonCaptionData? _scrapedCaptionData;
        public string County => cboCounty.Text;
        public string Name1 => txtName1.Text;
        public string Name2 => txtName2.Text;
        public string Party1 => cboParty1.Text;
        public string Party2 => cboParty2.Text;
        public string CaseNumber => txtCaseNumbers.Text;
        public string AppealNumber => txtAppealNumbers.Text;

        public frmCertCaption(string mergedDocPath)
        {
            InitializeComponent();
            var scraper = new OregonCaptionScraper();
            _scrapedCaptionData = scraper.ParseFirstPage(mergedDocPath);
            if (_scrapedCaptionData != null)
            {
                cboCounty.Text = _scrapedCaptionData.County;
                txtName1.Text = _scrapedCaptionData.Name1;
                txtName2.Text = _scrapedCaptionData.Name2;
                cboParty1.Text = _scrapedCaptionData.Party1;
                cboParty2.Text = _scrapedCaptionData.Party2;
                txtCaseNumbers.Text = _scrapedCaptionData.CaseNumber;
                txtAppealNumbers.Text = _scrapedCaptionData.AppealNumber;
            }
        }

        private void frmCertCaption_Load(object sender, EventArgs e)
        {
            cboParty1.Items.AddRange(new string[]
            {
                "Plaintiff-Respondent",
                "Defendant-Appellant",
                "Defendant-Respondent"
            });
            cboParty2.Items.AddRange(new string[]
            {
                "Plaintiff-Respondent",
                "Defendant-Appellant",
                "Defendant-Respondent"
            });
            cboCounty.Items.AddRange(new string[]
            {
                "Jackson",
                "Lane",
                "Marion",
                "Multnomah",
                "Deschutes",
                "Linn"
            });
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
