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

        public Form1()
        {
            InitializeComponent();
        }
        public event EventHandler NoteSaved;
        public event EventHandler NoteDelete;



        NoteAppEntities db = new NoteAppEntities();
        Notetext nt = new Notetext();
        int id = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearData();
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
            nt.title = titleBox.Text.Trim();
            nt.content = noteBox.Text.Trim();
            if (id > 0)
                db.Entry(nt).State = EntityState.Modified;
            else
            {
                db.Notetexts.Add(nt);
            }
            db.SaveChanges();
            ClearData();
            SetDataInGridView();
            MessageBox.Show("Record Save Successfully");
            OnNoteSaved();
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
    }
}
