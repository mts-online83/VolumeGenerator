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
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(187, 633);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(98, 38);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(66, 633);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(98, 38);
            btnConfirm.TabIndex = 7;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtAppealNumbers
            // 
            txtAppealNumbers.Font = new Font("Tahoma", 12F);
            txtAppealNumbers.Location = new Point(24, 516);
            txtAppealNumbers.Multiline = true;
            txtAppealNumbers.Name = "txtAppealNumbers";
            txtAppealNumbers.Size = new Size(290, 94);
            txtAppealNumbers.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 12F);
            label5.Location = new Point(24, 481);
            label5.Name = "label5";
            label5.Size = new Size(145, 19);
            label5.TabIndex = 24;
            label5.Text = "Appeal Number(s):";
            // 
            // txtCaseNumbers
            // 
            txtCaseNumbers.Font = new Font("Tahoma", 12F);
            txtCaseNumbers.Location = new Point(24, 355);
            txtCaseNumbers.Multiline = true;
            txtCaseNumbers.Name = "txtCaseNumbers";
            txtCaseNumbers.Size = new Size(290, 94);
            txtCaseNumbers.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F);
            label4.Location = new Point(24, 320);
            label4.Name = "label4";
            label4.Size = new Size(129, 19);
            label4.TabIndex = 22;
            label4.Text = "Case Number(s):";
            // 
            // cboCounty
            // 
            cboCounty.Font = new Font("Tahoma", 12F);
            cboCounty.FormattingEnabled = true;
            cboCounty.Location = new Point(95, 262);
            cboCounty.Name = "cboCounty";
            cboCounty.Size = new Size(219, 27);
            cboCounty.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F);
            label3.Location = new Point(24, 265);
            label3.Name = "label3";
            label3.Size = new Size(65, 19);
            label3.TabIndex = 20;
            label3.Text = "County:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F);
            label2.Location = new Point(127, 122);
            label2.Name = "label2";
            label2.Size = new Size(22, 19);
            label2.TabIndex = 19;
            label2.Text = "v.";
            // 
            // cboParty2
            // 
            cboParty2.Font = new Font("Tahoma", 12F);
            cboParty2.FormattingEnabled = true;
            cboParty2.Location = new Point(74, 183);
            cboParty2.Name = "cboParty2";
            cboParty2.Size = new Size(240, 27);
            cboParty2.TabIndex = 3;
            // 
            // cboParty1
            // 
            cboParty1.Font = new Font("Tahoma", 12F);
            cboParty1.FormattingEnabled = true;
            cboParty1.Location = new Point(74, 94);
            cboParty1.Name = "cboParty1";
            cboParty1.Size = new Size(240, 27);
            cboParty1.TabIndex = 1;
            // 
            // txtName2
            // 
            txtName2.Font = new Font("Tahoma", 12F);
            txtName2.Location = new Point(24, 150);
            txtName2.Name = "txtName2";
            txtName2.Size = new Size(290, 27);
            txtName2.TabIndex = 2;
            // 
            // txtName1
            // 
            txtName1.Font = new Font("Tahoma", 12F);
            txtName1.Location = new Point(24, 61);
            txtName1.Name = "txtName1";
            txtName1.Size = new Size(290, 27);
            txtName1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F);
            label1.Location = new Point(24, 32);
            label1.Name = "label1";
            label1.Size = new Size(107, 19);
            label1.TabIndex = 14;
            label1.Text = "Case Caption:";
            // 
            // frmCertCaption
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 694);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(txtAppealNumbers);
            Controls.Add(label5);
            Controls.Add(txtCaseNumbers);
            Controls.Add(label4);
            Controls.Add(cboCounty);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cboParty2);
            Controls.Add(cboParty1);
            Controls.Add(txtName2);
            Controls.Add(txtName1);
            Controls.Add(label1);
            Name = "frmCertCaption";
            Text = "frmCertCaption";
            Load += frmCertCaption_Load;
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
    }
}