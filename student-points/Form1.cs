using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static student_points.DatabaseClass;

namespace student_points
{
    public partial class MainForm : Form
    {
        private const string ArduinoPortName = "COM11";
        private const int ArduinoBaudRate = 115200;

        private readonly DBPostgres db = new DBPostgres(GlobalVariables.DbConnString);
        private readonly SerialPort arduinoPort = new SerialPort(ArduinoPortName, ArduinoBaudRate)
        {
            NewLine = "\n",
            ReadTimeout = 1000
        };

        private bool lookupInProgress;
        private const int RfidLength = 10;
        private string currentRfidNumber = string.Empty;
        private int studentId = -1;
        private decimal totalPts;

        public MainForm()
        {
            InitializeComponent();
            Shown += (sender, e) => txtrfidNumber.Focus();
            txtrfidNumber.TextChanged += txtStudentName_TextChanged;
            FormClosed += MainForm_FormClosed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            arduinoPort.DataReceived += ArduinoPort_DataReceived;
            try
            {
                arduinoPort.Open();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Could not open the Arduino on " + ArduinoPortName + ": " + ex.Message,
                    "Arduino Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Could not access " + ArduinoPortName + ". Check that no other program is using it. " + ex.Message,
                    "Arduino Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ArduinoPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string weightReading = arduinoPort.ReadLine().Trim();
                if (IsDisposed || !IsHandleCreated)
                    return;

                BeginInvoke((Action)(() =>
                {
                    txtWeight.Text = weightReading;

                    decimal weightInGrams;
                    if (TryParseWeightGrams(weightReading, out weightInGrams))
                    {
                        txtTotalPoints.Text = (weightInGrams * 0.12m).ToString("0.##", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        txtTotalPoints.Clear();
                    }
                }));
            }
            catch (TimeoutException)
            {
                // Ignore incomplete lines; the next data event can finish the reading.
            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.WriteLine("Arduino serial read failed: " + ex);
            }
            catch (InvalidOperationException ex)
            {
                System.Diagnostics.Debug.WriteLine("Arduino serial port is no longer available: " + ex);
            }
        }

        private static bool TryParseWeightGrams(string reading, out decimal weightInGrams)
        {
            weightInGrams = 0;
            int separatorIndex = reading.IndexOf(':');
            if (separatorIndex < 0)
                return false;

            string value = reading.Substring(separatorIndex + 1).Trim();
            value = value.TrimEnd('g', 'G').Trim();

            return decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out weightInGrams);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            arduinoPort.DataReceived -= ArduinoPort_DataReceived;
            if (arduinoPort.IsOpen)
                arduinoPort.Close();
            arduinoPort.Dispose();
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



        }
        private void recordPoints()
        {
            //db.AddRecord("studentpoints", new Dictionary<string, object>
            //        {
            //            { "firstName", rzr.Text.Trim() },
            //            { "middleName", txtMiddleName.Text.Trim() },
            //            { "lastName", txtLastName.Text.Trim() },
            //            { "gradeLevel", txtGrade.Text.Trim() },
            //            { "rfidNumber", txtRFIDNo.Text.Trim() },
            //            { "levelSection", txtSection.Text.Trim() },
            //            { "studetIdNumber", txtStudentId.Text.Trim() },
            //        });

            //MessageBox.Show("Student added successfully!");
        }

        private void txtrfidNumber_TextChanged(object sender, EventArgs e)
        {
            string rfidNumber = txtrfidNumber.Text.Trim();
            if (rfidNumber.Length != RfidLength)
                return;

            txtrfidNumber.Clear();

            if(currentRfidNumber == rfidNumber)
            {
                label1.Text = "Thank you for your cooperation!";
                label1.ForeColor = Color.Orange;
                currentRfidNumber = string.Empty;
                if (!decimal.TryParse(txtTotalPoints.Text.Trim(), out decimal totalPts))
                {
                    MessageBox.Show("Please enter a valid number for total points.");
                    return;
                }

                db.AddRecord("studentpoints", new Dictionary<string, object>
                {
                    { "studentid", GlobalVariables.LatestScannedStudentId },
                    { "points", totalPts }
                });

                MessageBox.Show("Student added successfully!");
                return;
            }

            txtStudentName.Clear();
            txtGradeLevel.Clear();
            txtSection.Clear();
            txtStudentIdNo.Clear();
            txtPoints.Clear();



            lookupInProgress = true;
            label1.Text = "Looking up student...";

            try
            {
                var result = db.GetStudentInformation(rfidNumber);

                if (!result.HasValue)
                {
                    label1.Text = "No student found!";
                    label1.ForeColor = Color.Red;
                    return;
                }

                label1.ForeColor = Color.Green;
                var student = result.Value;

                GlobalVariables.LatestScannedStudentId = student.studentId;
                txtStudentName.Text = student.name;
                txtGradeLevel.Text = student.gradeLevel;
                txtSection.Text = student.levelSection;
                txtStudentIdNo.Text = student.studentIdNumber;
                txtPoints.Text = student.points;

                label1.Text = "Student found";
                currentRfidNumber = rfidNumber;
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
