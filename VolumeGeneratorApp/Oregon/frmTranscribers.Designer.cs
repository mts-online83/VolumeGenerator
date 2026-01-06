namespace VolumeGeneratorApp
{
    partial class frmTranscribers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTranscribers));
            lblOutput = new Label();
            label1 = new Label();
            label2 = new Label();
            txtTranscriber = new TextBox();
            btnContinue = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblOutput
            // 
            lblOutput.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOutput.Location = new Point(12, 181);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(590, 167);
            lblOutput.TabIndex = 0;
            lblOutput.Text = "label1";
            // 
            // label1
            // 
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(645, 161);
            label1.TabIndex = 1;
            label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 372);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 2;
            label2.Text = "Transcriber's Name:";
            // 
            // txtTranscriber
            // 
            txtTranscriber.Location = new Point(157, 369);
            txtTranscriber.Name = "txtTranscriber";
            txtTranscriber.Size = new Size(278, 23);
            txtTranscriber.TabIndex = 3;
            txtTranscriber.TextChanged += txtTranscriber_TextChanged;
            // 
            // btnContinue
            // 
            btnContinue.Enabled = false;
            btnContinue.Location = new Point(447, 361);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(98, 39);
            btnContinue.TabIndex = 4;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += btnContinue_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(551, 361);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(98, 39);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmTranscribers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 420);
            Controls.Add(btnCancel);
            Controls.Add(btnContinue);
            Controls.Add(txtTranscriber);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblOutput);
            Name = "frmTranscribers";
            Text = "frmTranscribers";
            Load += frmTranscribers_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOutput;
        private Label label1;
        private Label label2;
        private TextBox txtTranscriber;
        private Button btnContinue;
        private Button btnCancel;
    }
}