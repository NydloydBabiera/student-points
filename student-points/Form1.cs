using Npgsql;
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
    public partial class MainForm : Form
    {
        private DBPostgres db = new DBPostgres(GlobalVariables.DbConnString);

        private bool lookupInProgress;
        private const int RfidLength = 10;
        private string currentRfidNumber = string.Empty;
       
        public MainForm()
        {
            InitializeComponent();
            Shown += (sender, e) => txtStudentName.Focus();
            txtStudentName.TextChanged += txtStudentName_TextChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            using (var addStudentForm = new AddStudent())
            {
                addStudentForm.ShowDialog(this);
            }
        }

        private void txtStudentName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private  void txtStudentName_TextChanged(object sender, EventArgs e)
        {

            string rfidNumber = txtStudentName.Text;

            if(currentRfidNumber == rfidNumber)
            {
                return;
            }

            if (rfidNumber.Length != RfidLength)
                return;

            txtStudentName.Clear();
            currentRfidNumber = rfidNumber;




            lookupInProgress = true;
            label1.Text = "Looking up student...";

            try
            {
                var result = db.GetStudentInformation(rfidNumber);

                if (!result.HasValue)
                {
                    label1.Text = "No student is registered to this card.";
                    return;
                }

                
                var student = result.Value;

                txtStudentName.Text = student.name;
                txtGradeLevel.Text = student.gradeLevel;
                txtSection.Text = student.levelSection;
                txtStudentIdNo.Text = student.studentIdNumber;
                txtPoints.Text = student.points;

                label1.Text = "Student found";
            }
            catch (NpgsqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                MessageBox.Show("Database lookup failed. Please scan again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //label1.Text = "Database lookup failed. Please scan again.";
            }

        }
    }
}
