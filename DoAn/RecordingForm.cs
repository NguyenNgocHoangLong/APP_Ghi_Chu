using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class RecordingForm : Form
    {
        public RecordingForm()
        {
            InitializeComponent();
        }

        private void startOrPause_Click(object sender, EventArgs e)
        {
            if (startOrPause.Text == "Start")
            {
                recordingLabel.Text = "Recording...";
                startOrPause.Text = "Pause";
            } 
            else
            {
                recordingLabel.Text = "";
                startOrPause.Text = "Start";
            }
        }
    }
}
