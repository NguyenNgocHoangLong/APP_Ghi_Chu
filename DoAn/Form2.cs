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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadLatestNotes();

        }

        NoteAppEntities db = new NoteAppEntities();
        Notetext nt = new Notetext();

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void LoadLatestNotes()
        {
            var latestNotes = db.Notetexts.OrderByDescending(n => n.id).Take(6).ToList();

            UpdateTableLayoutPanel(latestNotes);
        }
        private void UpdateTableLayoutPanel(List<Notetext> notes)
        {
            tableLayoutPanel1.Controls.Clear();

            int row = 0;
            int col = 0;

            foreach (var note in notes)
            {
                // Tạo Panel cho mỗi note
                Panel notePanel = new Panel();
                notePanel.Dock = DockStyle.Fill;
                notePanel.BorderStyle = BorderStyle.FixedSingle;

                // Tạo Label cho tiêu đề
                Label titleLabel = new Label();
                titleLabel.Text = note.title;
                titleLabel.Dock = DockStyle.Top;
                titleLabel.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);

                // Tạo Label cho nội dung
                Label contentLabel = new Label();
                contentLabel.Text = note.content;
                contentLabel.Dock = DockStyle.Fill;

                // Thêm các control vào notePanel
                notePanel.Controls.Add(contentLabel);
                notePanel.Controls.Add(titleLabel);

                // Thêm notePanel vào TableLayoutPanel
                tableLayoutPanel1.Controls.Add(notePanel, col, row);

                // Cập nhật vị trí cho note tiếp theo
                col++;
                if (col >= tableLayoutPanel1.ColumnCount)
                {
                    col = 0;
                    row++;
                }
            }
            tableLayoutPanel1.Update();
            tableLayoutPanel1.Refresh();
        }





        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fmb = new Form1();
            fmb.FormClosing += new FormClosingEventHandler(fmb_FormClosing);
            fmb.NoteSaved += Form1_NoteSaved;
            fmb.Show();
            this.Hide();
        }
        private void Form1_NoteSaved(object sender, EventArgs e)
        {
            // Khi có note mới được lưu, cập nhật lại danh sách note
            LoadLatestNotes();
        }
        private void fmb_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RecordingForm recordingForm = new RecordingForm();
            recordingForm.Show();
        }

    }
}
