using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolumeGeneratorApp
{
    public partial class frmTranscribers : Form
    {
        public string SelectedTranscriber => txtTranscriber.Text.Trim();

        public frmTranscribers(string volumeTitle, List<string> entries)
        {
            InitializeComponent();

            lblOutput.Text = volumeTitle;

            // Show each entry on its own line
            lblOutput.Text = string.Join(Environment.NewLine, entries);

        }

        private void txtTranscriber_TextChanged(object sender, EventArgs e)
        {
            string transcriberName = txtTranscriber.Text;

            if (transcriberName != "")
            {
                btnContinue.Enabled = true;

            }
            else
            {
                btnContinue.Enabled = false;
            }

        }

        private void frmTranscribers_Load(object sender, EventArgs e)
        {

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
