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

            // Display the full list (Date || Name)
            lblOutput.Text = volumeTitle + Environment.NewLine + Environment.NewLine +
                             string.Join(Environment.NewLine, entries);

            // Extract names from entries
            var names = new List<string>();

            foreach (var entry in entries)
            {
                var parts = entry.Split(new[] { "||" }, StringSplitOptions.None);

                if (parts.Length >= 2)
                {
                    string name = parts[1].Trim();
                    if (!string.IsNullOrWhiteSpace(name))
                        names.Add(name);
                }
            }

            // Default if we cannot reliably determine
            if (names.Count == 0)
            {
                txtTranscriber.Text = "escribers";
                return;
            }

            // Check if all names are identical (case-insensitive)
            bool allSame = names
                .All(n => n.Equals(names[0], StringComparison.OrdinalIgnoreCase));

            if (!allSame)
            {
                txtTranscriber.Text = "escribers";
                return;
            }

            // All names are the same → convert "First Last" → "lastnamefirstname"
            string[] nameParts = names[0]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length < 2)
            {
                // Unexpected format, fall back safely
                txtTranscriber.Text = "escribers";
                return;
            }

            string firstName = nameParts[0];
            string lastName = nameParts[^1]; // supports middle names safely

            txtTranscriber.Text = (lastName + firstName).ToLowerInvariant();

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
