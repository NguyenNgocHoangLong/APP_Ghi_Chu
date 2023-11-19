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
            this.components = new System.ComponentModel.Container();
            this.recordingLabel = new System.Windows.Forms.Label();
            this.bntStartRecord = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.btnStopRecord = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // recordingLabel
            // 
            this.recordingLabel.AutoSize = true;
            this.recordingLabel.Location = new System.Drawing.Point(16, 11);
            this.recordingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.recordingLabel.Name = "recordingLabel";
            this.recordingLabel.Size = new System.Drawing.Size(0, 16);
            this.recordingLabel.TabIndex = 0;
            // 
            // bntStartRecord
            // 
            this.bntStartRecord.Location = new System.Drawing.Point(43, 247);
            this.bntStartRecord.Margin = new System.Windows.Forms.Padding(4);
            this.bntStartRecord.Name = "bntStartRecord";
            this.bntStartRecord.Size = new System.Drawing.Size(132, 28);
            this.bntStartRecord.TabIndex = 1;
            this.bntStartRecord.Text = "Start";
            this.bntStartRecord.UseVisualStyleBackColor = true;
            this.bntStartRecord.Click += new System.EventHandler(this.bntStartRecord_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(567, 247);
            this.save.Margin = new System.Windows.Forms.Padding(4);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(132, 28);
            this.save.TabIndex = 2;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            // 
            // btnStopRecord
            // 
            this.btnStopRecord.Location = new System.Drawing.Point(210, 247);
            this.btnStopRecord.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopRecord.Name = "btnStopRecord";
            this.btnStopRecord.Size = new System.Drawing.Size(132, 28);
            this.btnStopRecord.TabIndex = 3;
            this.btnStopRecord.Text = "Stop";
            this.btnStopRecord.UseVisualStyleBackColor = true;
            this.btnStopRecord.Click += new System.EventHandler(this.btnStopRecord_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(393, 247);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(132, 28);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Location = new System.Drawing.Point(327, 103);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(55, 16);
            this.lblElapsedTime.TabIndex = 5;
            this.lblElapsedTime.Text = "00:00:00";
            // 
            // RecordingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 338);
            this.Controls.Add(this.lblElapsedTime);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnStopRecord);
            this.Controls.Add(this.save);
            this.Controls.Add(this.bntStartRecord);
            this.Controls.Add(this.recordingLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RecordingForm";
            this.Text = "RecordingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label recordingLabel;
        private System.Windows.Forms.Button bntStartRecord;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button btnStopRecord;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblElapsedTime;
        private System.Windows.Forms.Timer timer2;
    }
}