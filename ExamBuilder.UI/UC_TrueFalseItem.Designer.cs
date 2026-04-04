namespace ExamBuilder.UI
{
    partial class UC_TrueFalseItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_TrueFalseItem));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            txtItemName = new Bunifu.UI.WinForms.BunifuTextBox();
            lblCount = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2ShadowPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtItemName
            // 
            txtItemName.AcceptsReturn = false;
            txtItemName.AcceptsTab = false;
            txtItemName.AnimationSpeed = 200;
            txtItemName.AutoCompleteMode = AutoCompleteMode.None;
            txtItemName.AutoCompleteSource = AutoCompleteSource.None;
            txtItemName.AutoSizeHeight = true;
            txtItemName.BackColor = Color.Transparent;
            txtItemName.BackgroundImage = (Image)resources.GetObject("txtItemName.BackgroundImage");
            txtItemName.BorderColorActive = Color.DodgerBlue;
            txtItemName.BorderColorDisabled = Color.FromArgb(204, 204, 204);
            txtItemName.BorderColorHover = Color.FromArgb(105, 181, 255);
            txtItemName.BorderColorIdle = Color.Silver;
            txtItemName.BorderRadius = 20;
            txtItemName.BorderThickness = 1;
            txtItemName.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            txtItemName.CharacterCasing = CharacterCasing.Normal;
            txtItemName.DefaultFont = new Font("Segoe UI", 9.25F);
            txtItemName.DefaultText = "";
            txtItemName.FillColor = Color.White;
            txtItemName.HideSelection = true;
            txtItemName.IconLeft = null;
            txtItemName.IconLeftCursor = Cursors.IBeam;
            txtItemName.IconPadding = 10;
            txtItemName.IconRight = null;
            txtItemName.IconRightCursor = Cursors.IBeam;
            txtItemName.Location = new Point(10, 38);
            txtItemName.MaxLength = 32767;
            txtItemName.MinimumSize = new Size(1, 1);
            txtItemName.Modified = false;
            txtItemName.Multiline = false;
            txtItemName.Name = "txtItemName";
            stateProperties1.BorderColor = Color.DodgerBlue;
            stateProperties1.FillColor = Color.Empty;
            stateProperties1.ForeColor = Color.Empty;
            stateProperties1.PlaceholderForeColor = Color.Empty;
            txtItemName.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = Color.FromArgb(204, 204, 204);
            stateProperties2.FillColor = Color.FromArgb(240, 240, 240);
            stateProperties2.ForeColor = Color.FromArgb(109, 109, 109);
            stateProperties2.PlaceholderForeColor = Color.DarkGray;
            txtItemName.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = Color.FromArgb(105, 181, 255);
            stateProperties3.FillColor = Color.Empty;
            stateProperties3.ForeColor = Color.Empty;
            stateProperties3.PlaceholderForeColor = Color.Empty;
            txtItemName.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = Color.Silver;
            stateProperties4.FillColor = Color.White;
            stateProperties4.ForeColor = Color.Empty;
            stateProperties4.PlaceholderForeColor = Color.Empty;
            txtItemName.OnIdleState = stateProperties4;
            txtItemName.Padding = new Padding(3);
            txtItemName.PasswordChar = '\0';
            txtItemName.PlaceholderForeColor = Color.Silver;
            txtItemName.PlaceholderText = "متن آیتم را وارد کنید ";
            txtItemName.ReadOnly = false;
            txtItemName.RightToLeft = RightToLeft.Yes;
            txtItemName.ScrollBars = ScrollBars.None;
            txtItemName.SelectedText = "";
            txtItemName.SelectionLength = 0;
            txtItemName.SelectionStart = 0;
            txtItemName.ShortcutsEnabled = true;
            txtItemName.Size = new Size(404, 30);
            txtItemName.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            txtItemName.TabIndex = 7;
            txtItemName.TextAlign = HorizontalAlignment.Left;
            txtItemName.TextMarginBottom = 0;
            txtItemName.TextMarginLeft = 3;
            txtItemName.TextMarginTop = 1;
            txtItemName.TextPlaceholder = "متن آیتم را وارد کنید ";
            txtItemName.UseSystemPasswordChar = false;
            txtItemName.WordWrap = true;
            txtItemName.TextChanged += txtItemName_TextChanged;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCount.Location = new Point(369, 11);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(18, 20);
            lblCount.TabIndex = 6;
            lblCount.Text = "1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(382, 11);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 5;
            label1.Text = "آیتم";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.blue_plus_11976_512;
            pictureBox1.Location = new Point(418, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(56, 57);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(txtItemName);
            guna2ShadowPanel1.Controls.Add(lblCount);
            guna2ShadowPanel1.Controls.Add(label1);
            guna2ShadowPanel1.Controls.Add(pictureBox1);
            guna2ShadowPanel1.Dock = DockStyle.Fill;
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(0, 0);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 5;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowDepth = 20;
            guna2ShadowPanel1.Size = new Size(484, 81);
            guna2ShadowPanel1.TabIndex = 1;
            guna2ShadowPanel1.Paint += guna2ShadowPanel1_Paint;
            // 
            // UC_TrueFalseItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna2ShadowPanel1);
            Name = "UC_TrueFalseItem";
            Size = new Size(484, 81);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Bunifu.UI.WinForms.BunifuTextBox txtItemName;
        private Label lblCount;
        private Label label1;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
    }
}
