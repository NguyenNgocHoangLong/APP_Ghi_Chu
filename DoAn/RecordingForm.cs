using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace DoAn
{
    public partial class RecordingForm : Form
    {
        string _fileName;

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        public RecordingForm()
        {
            InitializeComponent();
        }

        private void bntStartRecord_Click(System.Object sender, System.EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            record("open new Type waveaudio Alias recsound", "", 0, 0);
            record("record recsound", "", 0, 0);
        }

        private void btnStopRecord_Click(System.Object sender, System.EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            record("save recsound C:\\Users\\HOADESIGN\\Desktop\\disc.wav", "", 0, 0);
            record("close recsound", "", 0, 0);
        }

        private void btnPlay_Click(System.Object sender, System.EventArgs e)
        {

        }
    }
}
