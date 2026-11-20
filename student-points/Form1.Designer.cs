namespace student_points
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.txtGradeLevel = new System.Windows.Forms.TextBox();
            this.txtSection = new System.Windows.Forms.TextBox();
            this.txtStudentIdNo = new System.Windows.Forms.TextBox();
            this.txtPoints = new System.Windows.Forms.TextBox();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(150, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1049, 93);
            this.label1.TabIndex = 0;
            this.label1.Text = "SCAN YOUR ID TO START";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtStudentName
            // 
            this.txtStudentName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentName.Location = new System.Drawing.Point(166, 358);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(1164, 62);
            this.txtStudentName.TabIndex = 1;
            this.txtStudentName.TextChanged += new System.EventHandler(this.txtStudentName_TextChanged);
            this.txtStudentName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStudentName_KeyDown);
            // 
            // txtGradeLevel
            // 
            this.txtGradeLevel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGradeLevel.Location = new System.Drawing.Point(166, 440);
            this.txtGradeLevel.Name = "txtGradeLevel";
            this.txtGradeLevel.Size = new System.Drawing.Size(423, 62);
            this.txtGradeLevel.TabIndex = 2;
            // 
            // txtSection
            // 
            this.txtSection.Font = new System.Drawing.Font("Arial Rounded MT Bold", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSection.Location = new System.Drawing.Point(620, 440);
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(710, 62);
            this.txtSection.TabIndex = 3;
            // 
            // txtStudentIdNo
            // 
            this.txtStudentIdNo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentIdNo.Location = new System.Drawing.Point(166, 535);
            this.txtStudentIdNo.Name = "txtStudentIdNo";
            this.txtStudentIdNo.Size = new System.Drawing.Size(854, 62);
            this.txtStudentIdNo.TabIndex = 4;
            // 
            // txtPoints
            // 
            this.txtPoints.Font = new System.Drawing.Font("Arial Rounded MT Bold", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoints.Location = new System.Drawing.Point(166, 629);
            this.txtPoints.Name = "txtPoints";
            this.txtPoints.Size = new System.Drawing.Size(854, 62);
            this.txtPoints.TabIndex = 5;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.BackColor = System.Drawing.Color.Transparent;
            this.btnAddStudent.FlatAppearance.BorderSize = 2;
            this.btnAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStudent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStudent.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnAddStudent.Location = new System.Drawing.Point(605, 736);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(424, 62);
            this.btnAddStudent.TabIndex = 6;
            this.btnAddStudent.Text = "ADD STUDENT";
            this.btnAddStudent.UseVisualStyleBackColor = false;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::student_points.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1449, 944);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.txtPoints);
            this.Controls.Add(this.txtStudentIdNo);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.txtGradeLevel);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.TextBox txtGradeLevel;
        private System.Windows.Forms.TextBox txtSection;
        private System.Windows.Forms.TextBox txtStudentIdNo;
        private System.Windows.Forms.TextBox txtPoints;
        private System.Windows.Forms.Button btnAddStudent;
    }
}

