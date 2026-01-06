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
        public string County => cboCounty.Text;
        public string Name1 => txtName1.Text;
        public string Name2 => txtName2.Text;
        public string Party1 => cboParty1.Text;
        public string Party2 => cboParty2.Text;
        public string CaseNumber => txtCaseNumbers.Text;
        public string AppealNumber => txtAppealNumbers.Text;

        public frmCertCaption()
        {
            InitializeComponent();
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

            cboCounty.Text = "Multnomah";
            txtName1.Text = "John Smith";
            txtName2.Text = "Mary Johnson";
            cboParty1.SelectedIndex = 0;
            cboParty2.SelectedIndex = 1;
            txtCaseNumbers.Text = "C-12345";
            txtAppealNumbers.Text = "A-6789";

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
