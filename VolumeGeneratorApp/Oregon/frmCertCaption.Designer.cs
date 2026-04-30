namespace VolumeGeneratorApp.Oregon
{
    partial class frmCertCaption
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCertCaption));
            btnCancel = new Button();
            btnConfirm = new Button();
            txtAppealNumbers = new TextBox();
            label5 = new Label();
            txtCaseNumbers = new TextBox();
            label4 = new Label();
            cboCounty = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            cboParty2 = new ComboBox();
            cboParty1 = new ComboBox();
            txtName2 = new TextBox();
            txtName1 = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Blue;
            btnCancel.Location = new Point(263, 751);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(98, 38);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.Blue;
            btnConfirm.FlatStyle = FlatStyle.Popup;
            btnConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(142, 751);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(98, 38);
            btnConfirm.TabIndex = 7;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtAppealNumbers
            // 
            txtAppealNumbers.Font = new Font("Tahoma", 12F);
            txtAppealNumbers.Location = new Point(53, 636);
            txtAppealNumbers.Multiline = true;
            txtAppealNumbers.Name = "txtAppealNumbers";
            txtAppealNumbers.Size = new Size(413, 94);
            txtAppealNumbers.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label5.ForeColor = Color.Blue;
            label5.Location = new Point(53, 605);
            label5.Name = "label5";
            label5.Size = new Size(163, 19);
            label5.TabIndex = 24;
            label5.Text = "Appeal Number(s):";
            // 
            // txtCaseNumbers
            // 
            txtCaseNumbers.Font = new Font("Tahoma", 12F);
            txtCaseNumbers.Location = new Point(53, 477);
            txtCaseNumbers.Multiline = true;
            txtCaseNumbers.Name = "txtCaseNumbers";
            txtCaseNumbers.Size = new Size(413, 94);
            txtCaseNumbers.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Blue;
            label4.Location = new Point(53, 443);
            label4.Name = "label4";
            label4.Size = new Size(145, 19);
            label4.TabIndex = 22;
            label4.Text = "Case Number(s):";
            // 
            // cboCounty
            // 
            cboCounty.Font = new Font("Tahoma", 12F);
            cboCounty.FormattingEnabled = true;
            cboCounty.Location = new Point(53, 389);
            cboCounty.Name = "cboCounty";
            cboCounty.Size = new Size(413, 27);
            cboCounty.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(53, 354);
            label3.Name = "label3";
            label3.Size = new Size(72, 19);
            label3.TabIndex = 20;
            label3.Text = "County:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F);
            label2.Location = new Point(122, 175);
            label2.Name = "label2";
            label2.Size = new Size(22, 19);
            label2.TabIndex = 19;
            label2.Text = "v.";
            // 
            // cboParty2
            // 
            cboParty2.Font = new Font("Tahoma", 12F);
            cboParty2.FormattingEnabled = true;
            cboParty2.Location = new Point(192, 264);
            cboParty2.Name = "cboParty2";
            cboParty2.Size = new Size(240, 27);
            cboParty2.TabIndex = 3;
            // 
            // cboParty1
            // 
            cboParty1.Font = new Font("Tahoma", 12F);
            cboParty1.FormattingEnabled = true;
            cboParty1.Location = new Point(192, 135);
            cboParty1.Name = "cboParty1";
            cboParty1.Size = new Size(240, 27);
            cboParty1.TabIndex = 1;
            // 
            // txtName2
            // 
            txtName2.Font = new Font("Tahoma", 12F);
            txtName2.Location = new Point(19, 197);
            txtName2.Multiline = true;
            txtName2.Name = "txtName2";
            txtName2.Size = new Size(413, 61);
            txtName2.TabIndex = 2;
            // 
            // txtName1
            // 
            txtName1.Font = new Font("Tahoma", 12F);
            txtName1.Location = new Point(19, 68);
            txtName1.Multiline = true;
            txtName1.Name = "txtName1";
            txtName1.Size = new Size(413, 61);
            txtName1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(19, 23);
            label1.Name = "label1";
            label1.Size = new Size(122, 19);
            label1.TabIndex = 14;
            label1.Text = "Case Caption:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtName1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtName2);
            groupBox1.Controls.Add(cboParty1);
            groupBox1.Controls.Add(cboParty2);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(34, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(460, 312);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            // 
            // frmCertCaption
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(512, 810);
            Controls.Add(groupBox1);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(txtAppealNumbers);
            Controls.Add(label5);
            Controls.Add(txtCaseNumbers);
            Controls.Add(label4);
            Controls.Add(cboCounty);
            Controls.Add(label3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmCertCaption";
            Text = "Certificate Caption";
            Load += frmCertCaption_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnConfirm;
        private TextBox txtAppealNumbers;
        private Label label5;
        private TextBox txtCaseNumbers;
        private Label label4;
        private ComboBox cboCounty;
        private Label label3;
        private Label label2;
        private ComboBox cboParty2;
        private ComboBox cboParty1;
        private TextBox txtName2;
        private TextBox txtName1;
        private Label label1;
        private GroupBox groupBox1;
    }
}