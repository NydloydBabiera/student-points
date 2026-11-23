namespace student_points
{
    partial class StudentPoints
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DGVStudentPoints = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradeLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studetidnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStudentPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGVStudentPoints);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1380, 476);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Points";
            // 
            // DGVStudentPoints
            // 
            this.DGVStudentPoints.AllowUserToAddRows = false;
            this.DGVStudentPoints.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGVStudentPoints.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVStudentPoints.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVStudentPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVStudentPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.gradeLevel,
            this.levelSection,
            this.studetidnumber,
            this.points});
            this.DGVStudentPoints.Location = new System.Drawing.Point(6, 29);
            this.DGVStudentPoints.Name = "DGVStudentPoints";
            this.DGVStudentPoints.ReadOnly = true;
            this.DGVStudentPoints.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVStudentPoints.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVStudentPoints.RowHeadersVisible = false;
            this.DGVStudentPoints.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGVStudentPoints.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVStudentPoints.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGVStudentPoints.RowTemplate.Height = 24;
            this.DGVStudentPoints.Size = new System.Drawing.Size(1368, 441);
            this.DGVStudentPoints.TabIndex = 0;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Student Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 450;
            // 
            // gradeLevel
            // 
            this.gradeLevel.DataPropertyName = "gradeLevel";
            this.gradeLevel.HeaderText = "Grade";
            this.gradeLevel.MinimumWidth = 6;
            this.gradeLevel.Name = "gradeLevel";
            this.gradeLevel.ReadOnly = true;
            this.gradeLevel.Width = 300;
            // 
            // levelSection
            // 
            this.levelSection.DataPropertyName = "levelSection";
            this.levelSection.HeaderText = "Section";
            this.levelSection.MinimumWidth = 6;
            this.levelSection.Name = "levelSection";
            this.levelSection.ReadOnly = true;
            this.levelSection.Width = 200;
            // 
            // studetidnumber
            // 
            this.studetidnumber.DataPropertyName = "studetidnumber";
            this.studetidnumber.HeaderText = "ID number";
            this.studetidnumber.MinimumWidth = 6;
            this.studetidnumber.Name = "studetidnumber";
            this.studetidnumber.ReadOnly = true;
            this.studetidnumber.Width = 250;
            // 
            // points
            // 
            this.points.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.points.DataPropertyName = "points";
            this.points.HeaderText = "Points";
            this.points.MinimumWidth = 6;
            this.points.Name = "points";
            this.points.ReadOnly = true;
            // 
            // StudentPoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 507);
            this.Controls.Add(this.groupBox1);
            this.Name = "StudentPoints";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentPoints";
            this.Load += new System.EventHandler(this.StudentPoints_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVStudentPoints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGVStudentPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn gradeLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn studetidnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn points;
    }
}