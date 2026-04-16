namespace ExamBuilder.UI
{
    partial class UC_Lessons
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Lessons));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            pictureBox1 = new PictureBox();
            lblLesson = new Label();
            lblCount = new Label();
            txtLessonName = new Bunifu.UI.WinForms.BunifuTextBox();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2ShadowPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.open_book;
            pictureBox1.Location = new Point(234, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 57);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // lblLesson
            // 
            lblLesson.AutoSize = true;
            lblLesson.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLesson.Location = new Point(188, 10);
            lblLesson.Name = "lblLesson";
            lblLesson.Size = new Size(40, 20);
            lblLesson.TabIndex = 5;
            lblLesson.Text = "درس";
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCount.Location = new Point(174, 11);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(18, 20);
            lblCount.TabIndex = 6;
            lblCount.Text = "1";
            // 
            // txtLessonName
            // 
            txtLessonName.AcceptsReturn = false;
            txtLessonName.AcceptsTab = false;
            txtLessonName.AnimationSpeed = 200;
            txtLessonName.AutoCompleteMode = AutoCompleteMode.None;
            txtLessonName.AutoCompleteSource = AutoCompleteSource.None;
            txtLessonName.AutoSizeHeight = true;
            txtLessonName.BackColor = Color.Transparent;
            txtLessonName.BackgroundImage = (Image)resources.GetObject("txtLessonName.BackgroundImage");
            txtLessonName.BorderColorActive = Color.DodgerBlue;
            txtLessonName.BorderColorDisabled = Color.FromArgb(204, 204, 204);
            txtLessonName.BorderColorHover = Color.FromArgb(105, 181, 255);
            txtLessonName.BorderColorIdle = Color.Silver;
            txtLessonName.BorderRadius = 20;
            txtLessonName.BorderThickness = 1;
            txtLessonName.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            txtLessonName.CharacterCasing = CharacterCasing.Normal;
            txtLessonName.DefaultFont = new Font("Segoe UI", 9.25F);
            txtLessonName.DefaultText = "";
            txtLessonName.FillColor = Color.White;
            txtLessonName.HideSelection = true;
            txtLessonName.IconLeft = null;
            txtLessonName.IconLeftCursor = Cursors.IBeam;
            txtLessonName.IconPadding = 10;
            txtLessonName.IconRight = null;
            txtLessonName.IconRightCursor = Cursors.IBeam;
            txtLessonName.Location = new Point(10, 37);
            txtLessonName.MaxLength = 32767;
            txtLessonName.MinimumSize = new Size(1, 1);
            txtLessonName.Modified = false;
            txtLessonName.Multiline = false;
            txtLessonName.Name = "txtLessonName";
            stateProperties5.BorderColor = Color.DodgerBlue;
            stateProperties5.FillColor = Color.Empty;
            stateProperties5.ForeColor = Color.Empty;
            stateProperties5.PlaceholderForeColor = Color.Empty;
            txtLessonName.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = Color.FromArgb(204, 204, 204);
            stateProperties6.FillColor = Color.FromArgb(240, 240, 240);
            stateProperties6.ForeColor = Color.FromArgb(109, 109, 109);
            stateProperties6.PlaceholderForeColor = Color.DarkGray;
            txtLessonName.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = Color.FromArgb(105, 181, 255);
            stateProperties7.FillColor = Color.Empty;
            stateProperties7.ForeColor = Color.Empty;
            stateProperties7.PlaceholderForeColor = Color.Empty;
            txtLessonName.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = Color.Silver;
            stateProperties8.FillColor = Color.White;
            stateProperties8.ForeColor = Color.Empty;
            stateProperties8.PlaceholderForeColor = Color.Empty;
            txtLessonName.OnIdleState = stateProperties8;
            txtLessonName.Padding = new Padding(3);
            txtLessonName.PasswordChar = '\0';
            txtLessonName.PlaceholderForeColor = Color.Silver;
            txtLessonName.PlaceholderText = "نام درس را وارد کنید (اختیاری)";
            txtLessonName.ReadOnly = false;
            txtLessonName.RightToLeft = RightToLeft.Yes;
            txtLessonName.ScrollBars = ScrollBars.None;
            txtLessonName.SelectedText = "";
            txtLessonName.SelectionLength = 0;
            txtLessonName.SelectionStart = 0;
            txtLessonName.ShortcutsEnabled = true;
            txtLessonName.Size = new Size(218, 30);
            txtLessonName.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            txtLessonName.TabIndex = 7;
            txtLessonName.TextAlign = HorizontalAlignment.Left;
            txtLessonName.TextMarginBottom = 0;
            txtLessonName.TextMarginLeft = 3;
            txtLessonName.TextMarginTop = 1;
            txtLessonName.TextPlaceholder = "نام درس را وارد کنید (اختیاری)";
            txtLessonName.UseSystemPasswordChar = false;
            txtLessonName.WordWrap = true;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(txtLessonName);
            guna2ShadowPanel1.Controls.Add(lblCount);
            guna2ShadowPanel1.Controls.Add(lblLesson);
            guna2ShadowPanel1.Controls.Add(pictureBox1);
            guna2ShadowPanel1.Dock = DockStyle.Fill;
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(0, 0);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 5;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowDepth = 20;
            guna2ShadowPanel1.Size = new Size(295, 79);
            guna2ShadowPanel1.TabIndex = 0;
            guna2ShadowPanel1.Paint += guna2ShadowPanel1_Paint;
            // 
            // UC_Lessons
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna2ShadowPanel1);
            Name = "UC_Lessons";
            Size = new Size(295, 79);
            Load += UC_Lessons_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblLesson;
        private Label lblCount;
        private Bunifu.UI.WinForms.BunifuTextBox txtLessonName;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
    }
}
