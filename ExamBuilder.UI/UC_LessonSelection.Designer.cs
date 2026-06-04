namespace ExamBuilder.UI
{
    partial class UC_LessonSelection
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
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            flpCheckBoxes = new FlowLayoutPanel();
            rbSelectedLesson = new Guna.UI2.WinForms.Guna2RadioButton();
            rbAllLessons = new Guna.UI2.WinForms.Guna2RadioButton();
            label1 = new Label();
            guna2ShadowPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(flpCheckBoxes);
            guna2ShadowPanel1.Controls.Add(rbSelectedLesson);
            guna2ShadowPanel1.Controls.Add(rbAllLessons);
            guna2ShadowPanel1.Controls.Add(label1);
            guna2ShadowPanel1.Dock = DockStyle.Fill;
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(0, 0);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 5;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowDepth = 80;
            guna2ShadowPanel1.Size = new Size(700, 226);
            guna2ShadowPanel1.TabIndex = 2;
            guna2ShadowPanel1.Paint += guna2ShadowPanel1_Paint;
            // 
            // flpCheckBoxes
            // 
            flpCheckBoxes.FlowDirection = FlowDirection.TopDown;
            flpCheckBoxes.Location = new Point(42, 102);
            flpCheckBoxes.Name = "flpCheckBoxes";
            flpCheckBoxes.Size = new Size(629, 110);
            flpCheckBoxes.TabIndex = 6;
            flpCheckBoxes.Paint += flpCheckBoxes_Paint;
            // 
            // rbSelectedLesson
            // 
            rbSelectedLesson.Animated = true;
            rbSelectedLesson.AutoSize = true;
            rbSelectedLesson.Checked = true;
            rbSelectedLesson.CheckedState.BorderThickness = 0;
            rbSelectedLesson.CheckedState.FillColor = Color.FromArgb(0, 192, 0);
            rbSelectedLesson.CheckedState.InnerColor = Color.White;
            rbSelectedLesson.CheckedState.InnerOffset = -4;
            rbSelectedLesson.Font = new Font("Segoe UI", 11.25F);
            rbSelectedLesson.Location = new Point(441, 60);
            rbSelectedLesson.Name = "rbSelectedLesson";
            rbSelectedLesson.RightToLeft = RightToLeft.Yes;
            rbSelectedLesson.Size = new Size(111, 24);
            rbSelectedLesson.TabIndex = 5;
            rbSelectedLesson.TabStop = true;
            rbSelectedLesson.Text = "انتخاب دستی";
            rbSelectedLesson.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            rbSelectedLesson.UncheckedState.BorderThickness = 2;
            rbSelectedLesson.UncheckedState.FillColor = Color.Transparent;
            rbSelectedLesson.UncheckedState.InnerColor = Color.Transparent;
            rbSelectedLesson.CheckedChanged += guna2RadioButton2_CheckedChanged;
            // 
            // rbAllLessons
            // 
            rbAllLessons.Animated = true;
            rbAllLessons.AutoSize = true;
            rbAllLessons.CheckedState.BorderThickness = 0;
            rbAllLessons.CheckedState.FillColor = Color.FromArgb(0, 192, 0);
            rbAllLessons.CheckedState.InnerColor = Color.White;
            rbAllLessons.CheckedState.InnerOffset = -4;
            rbAllLessons.Font = new Font("Segoe UI", 11.25F);
            rbAllLessons.Location = new Point(568, 60);
            rbAllLessons.Name = "rbAllLessons";
            rbAllLessons.RightToLeft = RightToLeft.Yes;
            rbAllLessons.Size = new Size(103, 24);
            rbAllLessons.TabIndex = 5;
            rbAllLessons.Text = "همه درس‌ها";
            rbAllLessons.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            rbAllLessons.UncheckedState.BorderThickness = 2;
            rbAllLessons.UncheckedState.FillColor = Color.Transparent;
            rbAllLessons.UncheckedState.InnerColor = Color.Transparent;
            rbAllLessons.CheckedChanged += guna2RadioButton1_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(520, 17);
            label1.Name = "label1";
            label1.Size = new Size(151, 20);
            label1.TabIndex = 0;
            label1.Text = "مرحله 2: انتخاب دروس";
            // 
            // UC_LessonSelection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna2ShadowPanel1);
            Name = "UC_LessonSelection";
            Size = new Size(700, 226);
            Load += UC_LessonSelection_Load;
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2RadioButton rbSelectedLesson;
        private Guna.UI2.WinForms.Guna2RadioButton rbAllLessons;
        private Label label1;
        private FlowLayoutPanel flpCheckBoxes;
    }
}
