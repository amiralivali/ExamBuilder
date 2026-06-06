namespace ExamBuilder.UI
{
    partial class UC_ManualQuestionSelection
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            dgvData = new Guna.UI2.WinForms.Guna2DataGridView();
            Select = new DataGridViewCheckBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            Picture = new DataGridViewTextBoxColumn();
            QuestionText = new DataGridViewTextBoxColumn();
            DifficultyLevel = new DataGridViewTextBoxColumn();
            Grade = new DataGridViewTextBoxColumn();
            book = new DataGridViewTextBoxColumn();
            lesson = new DataGridViewTextBoxColumn();
            QuestionType = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(237, 233, 254);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvData.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(109, 40, 217);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(109, 40, 217);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvData.ColumnHeadersHeight = 45;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Select, Id, Picture, QuestionText, DifficultyLevel, Grade, book, lesson, QuestionType });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(237, 233, 254);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            dgvData.Dock = DockStyle.Fill;
            dgvData.GridColor = Color.MediumPurple;
            dgvData.Location = new Point(0, 0);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvData.RowHeadersVisible = false;
            dgvData.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvData.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvData.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvData.RowTemplate.Height = 45;
            dgvData.RowTemplate.Resizable = DataGridViewTriState.False;
            dgvData.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvData.Size = new Size(500, 265);
            dgvData.TabIndex = 5;
            dgvData.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvData.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 9F);
            dgvData.ThemeStyle.AlternatingRowsStyle.ForeColor = SystemColors.ControlText;
            dgvData.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(237, 233, 254);
            dgvData.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvData.ThemeStyle.BackColor = Color.White;
            dgvData.ThemeStyle.GridColor = Color.MediumPurple;
            dgvData.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvData.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvData.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvData.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvData.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvData.ThemeStyle.HeaderStyle.Height = 45;
            dgvData.ThemeStyle.ReadOnly = false;
            dgvData.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvData.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.Single;
            dgvData.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvData.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvData.ThemeStyle.RowsStyle.Height = 45;
            dgvData.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(237, 233, 254);
            dgvData.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // Select
            // 
            Select.FillWeight = 20F;
            Select.HeaderText = "انتخاب";
            Select.Name = "Select";
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "شناسه";
            Id.Name = "Id";
            Id.Resizable = DataGridViewTriState.False;
            Id.Visible = false;
            // 
            // Picture
            // 
            Picture.DataPropertyName = "Picture";
            Picture.HeaderText = "عکس";
            Picture.Name = "Picture";
            Picture.Visible = false;
            // 
            // QuestionText
            // 
            QuestionText.DataPropertyName = "QuestionText";
            QuestionText.FillWeight = 130F;
            QuestionText.HeaderText = "متن سوال";
            QuestionText.Name = "QuestionText";
            QuestionText.Resizable = DataGridViewTriState.False;
            // 
            // DifficultyLevel
            // 
            DifficultyLevel.DataPropertyName = "DifficultyLevel";
            DifficultyLevel.FillWeight = 30F;
            DifficultyLevel.HeaderText = "سطح سوال";
            DifficultyLevel.Name = "DifficultyLevel";
            // 
            // Grade
            // 
            Grade.DataPropertyName = "Grade";
            Grade.FillWeight = 60F;
            Grade.HeaderText = "مقطع تحصیلی";
            Grade.Name = "Grade";
            Grade.Resizable = DataGridViewTriState.False;
            Grade.Visible = false;
            // 
            // book
            // 
            book.DataPropertyName = "BookName";
            book.FillWeight = 40F;
            book.HeaderText = "کتاب";
            book.Name = "book";
            book.Resizable = DataGridViewTriState.False;
            book.Visible = false;
            // 
            // lesson
            // 
            lesson.DataPropertyName = "LessonName";
            lesson.FillWeight = 40F;
            lesson.HeaderText = "درس";
            lesson.Name = "lesson";
            lesson.Resizable = DataGridViewTriState.False;
            lesson.Visible = false;
            // 
            // QuestionType
            // 
            QuestionType.DataPropertyName = "QuestionType";
            QuestionType.FillWeight = 45F;
            QuestionType.HeaderText = "نوع سوال";
            QuestionType.Name = "QuestionType";
            QuestionType.Resizable = DataGridViewTriState.False;
            // 
            // UC_ManualQuestionSelection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvData);
            Name = "UC_ManualQuestionSelection";
            Size = new Size(500, 265);
            Load += UC_ManualQuestionSelection_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvData;
        private DataGridViewCheckBoxColumn Select;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Picture;
        private DataGridViewTextBoxColumn QuestionText;
        private DataGridViewTextBoxColumn DifficultyLevel;
        private DataGridViewTextBoxColumn Grade;
        private DataGridViewTextBoxColumn book;
        private DataGridViewTextBoxColumn lesson;
        private DataGridViewTextBoxColumn QuestionType;
    }
}
