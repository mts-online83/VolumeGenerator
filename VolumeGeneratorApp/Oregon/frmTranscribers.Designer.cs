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
            lblOutput.Location = new Point(12, 272);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(590, 210);
            lblOutput.TabIndex = 0;
            lblOutput.Text = "label1";
            // 
            // label1
            // 
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(715, 252);
            label1.TabIndex = 1;
            label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(13, 496);
            label2.Name = "label2";
            label2.Size = new Size(147, 21);
            label2.TabIndex = 2;
            label2.Text = "Transcriber's Name:";
            // 
            // txtTranscriber
            // 
            txtTranscriber.Font = new Font("Segoe UI", 12F);
            txtTranscriber.Location = new Point(178, 494);
            txtTranscriber.Name = "txtTranscriber";
            txtTranscriber.Size = new Size(278, 29);
            txtTranscriber.TabIndex = 3;
            txtTranscriber.TextChanged += txtTranscriber_TextChanged;
            // 
            // btnContinue
            // 
            btnContinue.BackColor = Color.Blue;
            btnContinue.Enabled = false;
            btnContinue.FlatStyle = FlatStyle.Popup;
            btnContinue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnContinue.ForeColor = Color.White;
            btnContinue.Location = new Point(492, 486);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(98, 39);
            btnContinue.TabIndex = 4;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = false;
            btnContinue.Click += btnContinue_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.Location = new Point(596, 486);
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
            BackColor = Color.White;
            ClientSize = new Size(734, 547);
            Controls.Add(btnCancel);
            Controls.Add(btnContinue);
            Controls.Add(txtTranscriber);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblOutput);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmTranscribers";
            Text = "Transcribers in this volume";
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