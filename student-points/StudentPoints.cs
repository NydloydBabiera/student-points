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
    public partial class StudentPoints : Form
    {
        private DBPostgres db = new DBPostgres(GlobalVariables.DbConnString);
        public StudentPoints()
        {
            InitializeComponent();
        }

        private void LoadStudentPoints()
        {

            DGVStudentPoints.AutoGenerateColumns = false;
            db.LoadStudentPoints(DGVStudentPoints);
        }

        private void StudentPoints_Load(object sender, EventArgs e)
        {
            LoadStudentPoints();
        }
    }
}
