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
using System.Diagnostics;


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
            Timer timer = new Timer();
            timer.Interval = 1000; // Cập nhật mỗi giây
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        private void bntStartRecord_Click(System.Object sender, System.EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            record("open new Type waveaudio Alias recsound", "", 0, 0);
            record("record recsound", "", 0, 0);
            stopwatch.Restart();

        }

        private void btnStopRecord_Click(System.Object sender, System.EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;

            // Hiển thị hộp thoại xác nhận lưu file ghi âm
            DialogResult result = MessageBox.Show("Bạn có muốn lưu bản ghi âm?", "Xác nhận lưu",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                // Thiết lập các thuộc tính cho hộp thoại lưu
                saveFileDialog1.Filter = "WAV Files|*.wav";
                saveFileDialog1.Title = "Lưu file ghi âm";
                saveFileDialog1.InitialDirectory = @"C:\Users\HOADESIGN\Desktop\"; // Đường dẫn mặc định

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;
                    record("save recsound " + filePath, "", 0, 0);
                    MessageBox.Show("Bản ghi âm đã được lưu tại: " + filePath, "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Ngưng và đóng quá trình ghi âm
            record("close recsound", "", 0, 0);
            stopwatch.Stop();

        }
        private string audioFilePath = "";
        private void PlayAudio(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                SoundPlayer soundPlayer = new SoundPlayer(filePath);
                soundPlayer.Play();
            }
            else
            {
                MessageBox.Show("Không tìm thấy tệp âm thanh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPlay_Click(System.Object sender, System.EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "WAV Files|*.wav";
            openFileDialog1.Title = "Chọn tệp để phát lại";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                audioFilePath = openFileDialog1.FileName;
                PlayAudio(audioFilePath);
            }
            int totalDurationOfCurrentRecording = 60;

            StartPlaybackWithCountdown(totalDurationOfCurrentRecording);
        }
        private Stopwatch stopwatch = new Stopwatch();

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                TimeSpan elapsedTime = stopwatch.Elapsed;
                lblElapsedTime.Text = $"Thời gian chạy: {elapsedTime.Hours:D2}:{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";
            }
        }

        private int remainingTimeInSeconds; // Biến lưu trữ thời gian còn lại của bản ghi âm

        // Hàm bắt đầu phát lại đồng thời đếm ngược thời gian
        private void StartPlaybackWithCountdown(int totalDurationInSeconds)
        {
            remainingTimeInSeconds = totalDurationInSeconds;

            // Tạo và cấu hình Timer để cập nhật label mỗi giây
            Timer countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // 1 giây
            countdownTimer.Tick += (sender, e) =>
            {
                remainingTimeInSeconds--;

                if (remainingTimeInSeconds >= 0)
                {
                    TimeSpan timeSpan = TimeSpan.FromSeconds(remainingTimeInSeconds);
                    lblElapsedTime.Text = $"Thời gian còn lại: {timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
                }
                else
                {
                    countdownTimer.Stop();
                    lblElapsedTime.Text = "Thời gian còn lại: Hết thời gian";
                    // Thêm các hành động khi quá trình phát âm thanh kết thúc ở đây
                }
            };
            countdownTimer.Start();

            // Thêm code để bắt đầu phát lại âm thanh ở đây
        }

        private void save_Click(object sender, EventArgs e)
        {

        }
    }
}
