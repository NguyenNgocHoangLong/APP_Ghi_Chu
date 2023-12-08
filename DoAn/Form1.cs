using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class Form1 : Form
    {
        private Notetext noteToEdit;

        public Form1()
        {
            InitializeComponent();
        }
        public event EventHandler NoteSaved;
        public event EventHandler NoteDelete;

        public Form1(Notetext note) : this()
        {
            noteToEdit = note;
            id = noteToEdit.id;
            titleBox.Text = noteToEdit.title;
            noteBox.Text = noteToEdit.content;
        }


        NoteAppEntities db = new NoteAppEntities();
        Notetext nt = new Notetext();
        int id = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            SetDataInGridView();
        }
        public void ClearData()
        {
            titleBox.Text = noteBox.Text = string.Empty;
            deleteButton.Enabled = false;
            saveButton.Text = "Save";
            id = 0;
        }
        public void SetDataInGridView()
        {
            previousNotes.AutoGenerateColumns = false;
            previousNotes.DataSource = db.Notetexts.ToList<Notetext>();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record ?", "Delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.Notetexts.Remove(nt);
                db.SaveChanges();
                ClearData();
                SetDataInGridView();
                MessageBox.Show("Record Deleted Successfully");
            }
            OnNoteDelete();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (noteToEdit != null)
            {
                var existingNote = db.Notetexts.Find(noteToEdit.id);

                if (existingNote != null)
                {
                    existingNote.title = titleBox.Text.Trim();
                    existingNote.content = noteBox.Text.Trim();

                    db.SaveChanges();
                    ClearData();
                    SetDataInGridView();
                    MessageBox.Show("Cập nhật ghi chú thành công");
                    OnNoteSaved();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy ghi chú để cập nhật.");
                }
            }
            else
            {
                // Tạo mới đối tượng Notetext để thêm vào cơ sở dữ liệu
                Notetext newNote = new Notetext
                {
                    title = titleBox.Text.Trim(),
                    content = noteBox.Text.Trim()
                };

                db.Notetexts.Add(newNote);
                db.SaveChanges();
                ClearData();
                SetDataInGridView();
                MessageBox.Show("Thêm ghi chú mới thành công");
                OnNoteSaved();
            }
        }


        protected virtual void OnNoteSaved()
        {
            NoteSaved?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnNoteDelete()
        {
            NoteDelete?.Invoke(this, EventArgs.Empty);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void previousNotes_DoubleClick(object sender, EventArgs e)
        {
            if (previousNotes.CurrentCell.RowIndex != -1)
            {
                id = Convert.ToInt32(previousNotes.CurrentRow.Cells["noteid"].Value);
                nt = db.Notetexts.Where(x => x.id == id).FirstOrDefault();
                titleBox.Text = nt.title;
                noteBox.Text = nt.content;
            }
            saveButton.Text = "Update";
            deleteButton.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                var searchResult = db.Notetexts.Where(x => x.title.Contains(searchText)).ToList();
                previousNotes.DataSource = searchResult;
                if (searchResult.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy note.");
                }
            }
            else
            {
                SetDataInGridView();
            }
        }
    }
}
