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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtFolderPath = new TextBox();
            btnBrowse = new Button();
            btnMerge = new Button();
            label2 = new Label();
            btnReset = new Button();
            btnHelp = new Button();
            lblOutput = new Label();
            progress = new ProgressBar();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label4 = new Label();
            groupBox3 = new GroupBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // txtFolderPath
            // 
            txtFolderPath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFolderPath.Location = new Point(6, 56);
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.Size = new Size(568, 29);
            txtFolderPath.TabIndex = 0;
            txtFolderPath.TextChanged += txtFolderPath_TextChanged;
            // 
            // btnBrowse
            // 
            btnBrowse.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBrowse.ForeColor = Color.Blue;
            btnBrowse.Location = new Point(580, 56);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(105, 29);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "📂 Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnMerge
            // 
            btnMerge.BackColor = Color.Blue;
            btnMerge.Enabled = false;
            btnMerge.FlatStyle = FlatStyle.Popup;
            btnMerge.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMerge.ForeColor = Color.White;
            btnMerge.Location = new Point(24, 63);
            btnMerge.Name = "btnMerge";
            btnMerge.Size = new Size(217, 50);
            btnMerge.TabIndex = 2;
            btnMerge.Text = "📃 Generate Volumes";
            btnMerge.UseVisualStyleBackColor = false;
            btnMerge.Click += btnMerge_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(183, 21);
            label2.TabIndex = 6;
            label2.Text = "📂 1. Select Job Folder";
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.White;
            btnReset.FlatStyle = FlatStyle.Popup;
            btnReset.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnReset.ForeColor = Color.Blue;
            btnReset.Location = new Point(247, 63);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(217, 50);
            btnReset.TabIndex = 8;
            btnReset.Text = "🔄️ Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnHelp
            // 
            btnHelp.FlatStyle = FlatStyle.Popup;
            btnHelp.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnHelp.ForeColor = Color.Blue;
            btnHelp.Location = new Point(470, 63);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(217, 50);
            btnHelp.TabIndex = 9;
            btnHelp.Text = "❔ Help";
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            // 
            // lblOutput
            // 
            lblOutput.BackColor = Color.White;
            lblOutput.BorderStyle = BorderStyle.FixedSingle;
            lblOutput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOutput.ForeColor = Color.Black;
            lblOutput.Location = new Point(14, 56);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(677, 154);
            lblOutput.TabIndex = 13;
            // 
            // progress
            // 
            progress.BackColor = Color.White;
            progress.ForeColor = Color.Lime;
            progress.Location = new Point(13, 614);
            progress.Maximum = 9;
            progress.Name = "progress";
            progress.Size = new Size(708, 31);
            progress.Style = ProgressBarStyle.Continuous;
            progress.TabIndex = 14;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(123, 101);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(160, 25);
            label1.Name = "label1";
            label1.Size = new Size(454, 47);
            label1.TabIndex = 16;
            label1.Text = "Oregon Volume Generator";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(170, 81);
            label3.Name = "label3";
            label3.Size = new Size(263, 15);
            label3.TabIndex = 17;
            label3.Text = "Split Word documents into separate volume files";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtFolderPath);
            groupBox1.Controls.Add(btnBrowse);
            groupBox1.Location = new Point(19, 124);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(698, 102);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(btnMerge);
            groupBox2.Controls.Add(btnReset);
            groupBox2.Controls.Add(btnHelp);
            groupBox2.Location = new Point(17, 230);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(700, 138);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Blue;
            label4.Location = new Point(8, 19);
            label4.Name = "label4";
            label4.Size = new Size(181, 21);
            label4.TabIndex = 7;
            label4.Text = "⚙️ 2. Generate Output";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(lblOutput);
            groupBox3.Location = new Point(13, 382);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(708, 226);
            groupBox3.TabIndex = 20;
            groupBox3.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Blue;
            label5.Location = new Point(14, 19);
            label5.Name = "label5";
            label5.Size = new Size(148, 21);
            label5.TabIndex = 14;
            label5.Text = "📋  3. Status / Log";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(731, 659);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(progress);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "eScribers Oregon Volume Generator v1.0.2";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
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
        private ProgressBar progress;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label3;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label4;
        private GroupBox groupBox3;
        private Label label5;
    }
}
