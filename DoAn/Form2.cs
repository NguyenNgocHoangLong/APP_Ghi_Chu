using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
            LoadLatestNotes();
        }
        private const int ItemsPerPage = 6;
        private List<Notetext> allNotes;
        private int currentPage = 0;
        private void LoadLatestNotes()
        {
            allNotes = db.Notetexts.OrderByDescending(n => n.id).ToList();
            LoadNotesForPage(currentPage);

        }
        private void LoadNotesForPage(int page)
        {
            tableLayoutPanel1.Controls.Clear();

            var notesForPage = allNotes.Skip(page * ItemsPerPage).Take(ItemsPerPage).ToList();
            UpdateTableLayoutPanel(notesForPage);

            UpdatePagination();
        }
        private void UpdatePagination()
        {
            paginationPanel.Controls.Clear();

            int totalPages = (int)Math.Ceiling((double)allNotes.Count / ItemsPerPage);

            for (int i = 0; i < totalPages; i++)
            {
                Button pageButton = new Button();
                pageButton.Text = (i + 1).ToString();
                pageButton.Tag = i;
                pageButton.Click += PageButton_Click;

                paginationPanel.Controls.Add(pageButton);
            }
        }
        private void PageButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            currentPage = (int)clickedButton.Tag;
            LoadNotesForPage(currentPage);
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
                notePanel.BackColor = Color.LightGray; // Đặt màu nền cho Panel
                notePanel.Padding = new Padding(5); // Tạo khoảng cách xung quanh nội dung trong Panel
                notePanel.BorderStyle = BorderStyle.FixedSingle; // Đặt kiểu viền cho Panel
                //notePanel.BorderColor = Color.DarkGray; // Đặt màu viền cho Panel
                //notePanel.BorderWidth = 1; // Đặt độ rộng viền cho Panel

                // Tạo Label cho tiêu đề
                Label titleLabel = new Label();
                titleLabel.Text = note.title;
                titleLabel.Dock = DockStyle.Top;
                titleLabel.Font = new Font("Arial", 12, FontStyle.Bold); // Đặt font và kích thước chữ cho tiêu đề

                // Tạo Label cho nội dung
                Label contentLabel = new Label();
                contentLabel.Text = note.content;
                contentLabel.Dock = DockStyle.Fill;
                contentLabel.Font = new Font("Arial", 10, FontStyle.Regular); // Đặt font và kích thước chữ cho nội dung

                // Thêm các control vào notePanel
                notePanel.MouseDown += NotePanel_MouseDown;
                notePanel.MouseEnter += NotePanel_MouseEnter;
                notePanel.MouseLeave += NotePanel_MouseLeave;

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
        private void NotePanel_MouseEnter(object sender, EventArgs e)
        {
            Panel enteredPanel = sender as Panel;
            if (enteredPanel != null)
            {
                enteredPanel.BackColor = Color.LightBlue; // Thay đổi màu nền khi di chuột vào Panel
            }
        }

        private void NotePanel_MouseLeave(object sender, EventArgs e)
        {
            Panel leftPanel = sender as Panel;
            if (leftPanel != null)
            {
                leftPanel.BackColor = Color.LightGray; // Đặt lại màu nền khi chuột rời khỏi Panel
            }
        }
        private void NotePanel_MouseDown(object sender, MouseEventArgs e)
        {
            Panel clickedPanel = sender as Panel;
            if (clickedPanel != null)
            {
                // Xử lý sự kiện MouseDown của Panel ở đây
                MessageBox.Show("Panel được click!");
            }
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
                
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
