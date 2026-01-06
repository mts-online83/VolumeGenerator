namespace VolumeGeneratorApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFolderPath = new TextBox();
            btnBrowse = new Button();
            btnMerge = new Button();
            numMaxPages = new NumericUpDown();
            cboJurisdiction = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnReset = new Button();
            btnHelp = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            lblOutput = new Label();
            ((System.ComponentModel.ISupportInitialize)numMaxPages).BeginInit();
            SuspendLayout();
            // 
            // txtFolderPath
            // 
            txtFolderPath.Location = new Point(110, 91);
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.Size = new Size(335, 23);
            txtFolderPath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(451, 91);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(91, 23);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnMerge
            // 
            btnMerge.Location = new Point(118, 279);
            btnMerge.Name = "btnMerge";
            btnMerge.Size = new Size(104, 27);
            btnMerge.TabIndex = 2;
            btnMerge.Text = "Merge";
            btnMerge.UseVisualStyleBackColor = true;
            btnMerge.Click += btnMerge_Click;
            // 
            // numMaxPages
            // 
            numMaxPages.Location = new Point(160, 142);
            numMaxPages.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numMaxPages.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxPages.Name = "numMaxPages";
            numMaxPages.Size = new Size(54, 23);
            numMaxPages.TabIndex = 3;
            numMaxPages.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // cboJurisdiction
            // 
            cboJurisdiction.FormattingEnabled = true;
            cboJurisdiction.Items.AddRange(new object[] { "Oregon" });
            cboJurisdiction.Location = new Point(110, 39);
            cboJurisdiction.Name = "cboJurisdiction";
            cboJurisdiction.Size = new Size(432, 23);
            cboJurisdiction.TabIndex = 4;
            cboJurisdiction.Text = "Select Jurisdiction";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 42);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 5;
            label1.Text = "Jurisdiction:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 94);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 6;
            label2.Text = "Job Folder:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 144);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 7;
            label3.Text = "Pages per Volume:";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(228, 279);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(104, 27);
            btnReset.TabIndex = 8;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(338, 279);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(104, 27);
            btnHelp.TabIndex = 9;
            btnHelp.Text = "Help";
            btnHelp.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(25, 180);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(72, 19);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Option 1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(25, 205);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(72, 19);
            checkBox2.TabIndex = 11;
            checkBox2.Text = "Option 1";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(25, 230);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(72, 19);
            checkBox3.TabIndex = 12;
            checkBox3.Text = "Option 1";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // lblOutput
            // 
            lblOutput.BackColor = SystemColors.AppWorkspace;
            lblOutput.BorderStyle = BorderStyle.FixedSingle;
            lblOutput.Location = new Point(26, 318);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(511, 127);
            lblOutput.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 459);
            Controls.Add(lblOutput);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(btnHelp);
            Controls.Add(btnReset);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboJurisdiction);
            Controls.Add(numMaxPages);
            Controls.Add(btnMerge);
            Controls.Add(btnBrowse);
            Controls.Add(txtFolderPath);
            Name = "Form1";
            Text = "Volume Generator";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numMaxPages).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFolderPath;
        private Button btnBrowse;
        private Button btnMerge;
        private NumericUpDown numMaxPages;
        private ComboBox cboJurisdiction;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnReset;
        private Button btnHelp;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private Label lblOutput;
    }
}
