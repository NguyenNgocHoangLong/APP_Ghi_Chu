namespace DoAn
{
    partial class RecordingForm
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
            this.recordingLabel = new System.Windows.Forms.Label();
            this.startOrPause = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recordingLabel
            // 
            this.recordingLabel.AutoSize = true;
            this.recordingLabel.Location = new System.Drawing.Point(12, 9);
            this.recordingLabel.Name = "recordingLabel";
            this.recordingLabel.Size = new System.Drawing.Size(0, 13);
            this.recordingLabel.TabIndex = 0;
            // 
            // startOrPause
            // 
            this.startOrPause.Location = new System.Drawing.Point(12, 25);
            this.startOrPause.Name = "startOrPause";
            this.startOrPause.Size = new System.Drawing.Size(118, 23);
            this.startOrPause.TabIndex = 1;
            this.startOrPause.Text = "Start";
            this.startOrPause.UseVisualStyleBackColor = true;
            this.startOrPause.Click += new System.EventHandler(this.startOrPause_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(136, 25);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 2;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            // 
            // RecordingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 61);
            this.Controls.Add(this.save);
            this.Controls.Add(this.startOrPause);
            this.Controls.Add(this.recordingLabel);
            this.Name = "RecordingForm";
            this.Text = "RecordingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label recordingLabel;
        private System.Windows.Forms.Button startOrPause;
        private System.Windows.Forms.Button save;
    }
}