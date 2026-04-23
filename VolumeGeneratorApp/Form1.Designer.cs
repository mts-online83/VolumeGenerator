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
            label2 = new Label();
            btnReset = new Button();
            btnHelp = new Button();
            lblOutput = new Label();
            SuspendLayout();
            // 
            // txtFolderPath
            // 
            txtFolderPath.Location = new Point(110, 32);
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.Size = new Size(335, 23);
            txtFolderPath.TabIndex = 0;
            txtFolderPath.TextChanged += txtFolderPath_TextChanged;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(451, 32);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(91, 23);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnMerge
            // 
            btnMerge.Enabled = false;
            btnMerge.Location = new Point(117, 141);
            btnMerge.Name = "btnMerge";
            btnMerge.Size = new Size(104, 27);
            btnMerge.TabIndex = 2;
            btnMerge.Text = "Merge";
            btnMerge.UseVisualStyleBackColor = true;
            btnMerge.Click += btnMerge_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 35);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 6;
            label2.Text = "Job Folder:";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(227, 141);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(104, 27);
            btnReset.TabIndex = 8;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(337, 141);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(104, 27);
            btnHelp.TabIndex = 9;
            btnHelp.Text = "Help";
            btnHelp.UseVisualStyleBackColor = true;
            // 
            // lblOutput
            // 
            lblOutput.BackColor = SystemColors.AppWorkspace;
            lblOutput.BorderStyle = BorderStyle.FixedSingle;
            lblOutput.Location = new Point(25, 180);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(511, 127);
            lblOutput.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 318);
            Controls.Add(lblOutput);
            Controls.Add(btnHelp);
            Controls.Add(btnReset);
            Controls.Add(label2);
            Controls.Add(btnMerge);
            Controls.Add(btnBrowse);
            Controls.Add(txtFolderPath);
            Name = "Form1";
            Text = "Oregon Volume Generator";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFolderPath;
        private Button btnBrowse;
        private Button btnMerge;
        private Label label2;
        private Button btnReset;
        private Button btnHelp;
        private Label lblOutput;
    }
}
