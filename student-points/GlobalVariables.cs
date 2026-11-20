using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_points
{
    public class GlobalVariables
    {
        public static string DbConnString { get; set; } = "Host=localhost;Username=postgres;Password=postgres1234;Database=student_points;";
        public static int SelectedStudentId { get; set; }
    }
}
