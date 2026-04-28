namespace ExamBuilder.UI
{
    partial class UC_DGVTrueFalseItem
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
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            IsValid = new DataGridViewTextBoxColumn();
            ErrorMessage = new DataGridViewTextBoxColumn();
            QuestionId = new DataGridViewTextBoxColumn();
            dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            ItemText = new DataGridViewTextBoxColumn();
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
            dgvData.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, IsValid, ErrorMessage, QuestionId, dataGridViewButtonColumn1, dataGridViewButtonColumn2, ItemText });
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
            dgvData.ReadOnly = true;
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
            dgvData.Size = new Size(859, 216);
            dgvData.TabIndex = 8;
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
            dgvData.ThemeStyle.ReadOnly = true;
            dgvData.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvData.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.Single;
            dgvData.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvData.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvData.ThemeStyle.RowsStyle.Height = 45;
            dgvData.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(237, 233, 254);
            dgvData.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            dataGridViewTextBoxColumn1.HeaderText = "شناسه";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
            dataGridViewTextBoxColumn1.Visible = false;
            // 
            // IsValid
            // 
            IsValid.DataPropertyName = "IsValid";
            IsValid.HeaderText = "معتبر";
            IsValid.Name = "IsValid";
            IsValid.ReadOnly = true;
            IsValid.Visible = false;
            // 
            // ErrorMessage
            // 
            ErrorMessage.DataPropertyName = "ErrorMessage";
            ErrorMessage.HeaderText = "متن خطا";
            ErrorMessage.Name = "ErrorMessage";
            ErrorMessage.ReadOnly = true;
            ErrorMessage.Visible = false;
            // 
            // QuestionId
            // 
            QuestionId.DataPropertyName = "QuestionId";
            QuestionId.HeaderText = "شناسه سوال";
            QuestionId.Name = "QuestionId";
            QuestionId.ReadOnly = true;
            QuestionId.Visible = false;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewButtonColumn1.FillWeight = 30F;
            dataGridViewButtonColumn1.HeaderText = "ویرایش";
            dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            dataGridViewButtonColumn1.ReadOnly = true;
            dataGridViewButtonColumn1.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewButtonColumn2
            // 
            dataGridViewButtonColumn2.FillWeight = 30F;
            dataGridViewButtonColumn2.HeaderText = "حذف";
            dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            dataGridViewButtonColumn2.ReadOnly = true;
            dataGridViewButtonColumn2.Resizable = DataGridViewTriState.False;
            // 
            // ItemText
            // 
            ItemText.DataPropertyName = "Text";
            ItemText.HeaderText = "متن آیتم";
            ItemText.Name = "ItemText";
            ItemText.ReadOnly = true;
            // 
            // UC_DGVTrueFalseItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvData);
            Name = "UC_DGVTrueFalseItem";
            Size = new Size(859, 216);
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvData;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn IsValid;
        private DataGridViewTextBoxColumn ErrorMessage;
        private DataGridViewTextBoxColumn QuestionId;
        private DataGridViewButtonColumn dataGridViewButtonColumn1;
        private DataGridViewButtonColumn dataGridViewButtonColumn2;
        private DataGridViewTextBoxColumn ItemText;
    }
}
