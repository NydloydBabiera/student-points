using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static student_points.DatabaseClass;

namespace student_points
{
    public partial class AddStudent : Form
    {
        private bool isEditMode = false;

        private DBPostgres db = new DBPostgres(GlobalVariables.DbConnString);
        public AddStudent()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            textboxesEnable();
            clearTextBoxes();
            dgvStudents.Enabled = false;
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            buttonsDefaultState();
            textboxesDefaultState();
            textboxesDisable();
            clearTextBoxes();
            LoadUserGrid();

            txtFirstName.CharacterCasing = CharacterCasing.Upper;
            txtMiddleName.CharacterCasing = CharacterCasing.Upper;
            txtLastName.CharacterCasing = CharacterCasing.Upper;
            txtGrade.CharacterCasing = CharacterCasing.Upper;
            txtStudentId.CharacterCasing = CharacterCasing.Upper;
           
        }

        private void LoadUserGrid()
        {

            dgvStudents.AutoGenerateColumns = false;
            db.LoadData("students", dgvStudents);
        }

        private void clearTextBoxes()
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtGrade.Text = "";
            txtRFIDNo.Text = "";
            txtSection.Text = "";
            txtStudentId.Text = "";
        }

        private void buttonsDefaultState()
        {
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void textboxesDefaultState()
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtGrade.Text = "";
            txtRFIDNo.Text = "";
            txtSection.Text = "";
            txtStudentId.Text = "";
        }

        private void textboxesEnable()
        {
            txtFirstName.Enabled = true;
            txtMiddleName.Enabled = true;
            txtLastName.Enabled = true;
            txtGrade.Enabled = true;
            txtRFIDNo.Enabled = true;
            txtStudentId.Enabled = true;
            txtSection.Enabled = true;
        }
        private void textboxesDisable()
        {
            txtFirstName.Enabled = false;
            txtMiddleName.Enabled = false;
            txtLastName.Enabled = false;
            txtGrade.Enabled = false;
            txtRFIDNo.Enabled = false;
            txtStudentId.Enabled = false;
            txtSection.Enabled = false;
        }

        private void txtRFIDNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRFIDNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string rfid = txtRFIDNo.Text.Trim();

                // The scanned ID is now available in rfid.
                // Keep it in txtRFIDNo or process it here.
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            GlobalVariables.SelectedStudentId = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["studentId"].Value);


            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = true;

            isEditMode = true;
        }

        //private async Task btnSave_Click(object sender, EventArgs e)
        //{
            
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var isConfirmed = MessageBox.Show(
        "Are you sure you want to delete this record? This action cannot be undone.",
        "Confirm Deletion",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
    );


            if (isConfirmed.Equals(DialogResult.Yes))
            {
                db.DeleteRowAsync("students", "studentId", GlobalVariables.SelectedStudentId);
                LoadUserGrid();
                buttonsDefaultState();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            buttonsDefaultState();
            textboxesDefaultState();
            dgvStudents.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = dgvStudents.CurrentRow.Cells["firstName"].Value.ToString();
            txtRFIDNo.Text = dgvStudents.CurrentRow.Cells["rfidNumber"].Value.ToString();
            txtSection.Text = dgvStudents.CurrentRow.Cells["levelSection"].Value.ToString();
            txtGrade.Text = dgvStudents.CurrentRow.Cells["gradeLevel"].Value.ToString();
            txtMiddleName.Text = dgvStudents.CurrentRow.Cells["middleName"].Value.ToString();
            txtLastName.Text = dgvStudents.CurrentRow.Cells["lastName"].Value.ToString();
            txtStudentId.Text = dgvStudents.CurrentRow.Cells["studentId"].Value.ToString();
            textboxesEnable();

            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                var columns = new Dictionary<string, object>
                {
                    { "firstName", txtFirstName.Text.Trim() },
                    { "middleName", txtMiddleName.Text.Trim() },
                    { "lastName", txtLastName.Text.Trim() },
                    { "gradeLevel", txtGrade.Text.Trim() },
                    { "rfidNumber", txtRFIDNo.Text.Trim() },
                    { "levelSection", txtSection.Text.Trim() },
                    { "studetIdNumber", txtStudentId.Text.Trim() },
                };
                {

                }
              ;
                int updated = await db.UpdateRowAsync("students",
                    "studentId",
                    GlobalVariables.SelectedStudentId,         // key value
                    columns
                );

                if (updated == 1)
                {
                    MessageBox.Show("Student updated successfully!");
                }
                else
                {
                    MessageBox.Show("Update failed or no matching row.");
                }
            }
            else
            {
                bool dataExists = db.CheckIfDataExists("students", "rfidNumber", txtRFIDNo.Text.Trim());
                if (dataExists)
                {
                    MessageBox.Show("⚠️ Record already exists.");
                }

                db.AddRecord("students", new Dictionary<string, object>
                    {
                        { "firstName", txtFirstName.Text.Trim() },
                        { "middleName", txtMiddleName.Text.Trim() },
                        { "lastName", txtLastName.Text.Trim() },
                        { "gradeLevel", txtGrade.Text.Trim() },
                        { "rfidNumber", txtRFIDNo.Text.Trim() },
                        { "levelSection", txtSection.Text.Trim() },
                        { "studetIdNumber", txtStudentId.Text.Trim() },
                    });

                MessageBox.Show("Student added successfully!");
            }
                LoadUserGrid();
                buttonsDefaultState();
                textboxesDefaultState();
                textboxesDisable();
                dgvStudents.Enabled = true;
        }
    }

}
