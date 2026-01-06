using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolumeGeneratorApp.Oregon
{
    public partial class frmCertAppearances : Form
    {
        public string AppellantAttorney => txtAttorney1.Text;
        public string AppellantFirm => txtFirm1.Text;
        public string AppellantAddress => txtAdd1.Text;
        public string AppellantCity => txtCity1.Text;
        public string AppellantState => cboState1.Text;
        public string AppellantZip => txtZip1.Text;
        public string AppellantPhone => txtPhone1.Text;
        public string AppellantEmail => txtEmail1.Text;

        public string RespondentAttorney => txtAttorney2.Text;
        public string RespondentFirm => txtFirm2.Text;
        public string RespondentAddress => txtAdd2.Text;
        public string RespondentCity => txtCity2.Text;
        public string RespondentState => cboState2.Text;
        public string RespondentZip => txtZip2.Text;
        public string RespondentPhone => txtPhone2.Text;
        public string RespondentEmail => txtEmail2.Text;
        public frmCertAppearances()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmCertAppearances_Load(object sender, EventArgs e)
        {
            string[] states = new[]
                {
                    "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado",
                    "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho",
                    "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana",
                    "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota",
                    "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada",
                    "New Hampshire", "New Jersey", "New Mexico", "New York",
                    "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon",
                    "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota",
                    "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington",
                    "West Virginia", "Wisconsin", "Wyoming"
                };

            cboState1.Items.AddRange(states);
            cboState2.Items.AddRange(states);

            txtAttorney1.Text = "Jane Attorney";
            txtFirm1.Text = "Anderson & Smith LLP";
            txtAdd1.Text = "123 Main Street";
            txtCity1.Text = "Portland";
            cboState1.SelectedIndex = 6;
            txtZip1.Text = "97204";
            txtPhone1.Text = "(503) 555-1234";
            txtEmail1.Text = "jane.attorney@example.com";

            // Respondent
            txtAttorney2.Text = "Robert Counselor";
            txtFirm2.Text = "Law Offices of Robert C.";
            txtAdd2.Text = "456 Elm Avenue";
            txtCity2.Text = "Salem";
            cboState2.SelectedIndex = 4;
            txtZip2.Text = "97301";
            txtPhone2.Text = "(503) 555-9876";
            txtEmail2.Text = "robert.counselor@example.com";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
