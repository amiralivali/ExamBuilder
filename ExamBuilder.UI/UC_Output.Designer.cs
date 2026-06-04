namespace ExamBuilder.UI
{
    partial class UC_Output
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
            label2 = new Label();
            label1 = new Label();
            rbPdf = new Guna.UI2.WinForms.Guna2RadioButton();
            rbWord = new Guna.UI2.WinForms.Guna2RadioButton();
            pictureBox1 = new PictureBox();
            guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(pictureBox1);
            guna2ShadowPanel1.Controls.Add(rbPdf);
            guna2ShadowPanel1.Controls.Add(rbWord);
            guna2ShadowPanel1.Controls.Add(label2);
            guna2ShadowPanel1.Controls.Add(label1);
            guna2ShadowPanel1.Dock = DockStyle.Fill;
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(0, 0);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 5;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowDepth = 80;
            guna2ShadowPanel1.Size = new Size(700, 226);
            guna2ShadowPanel1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(585, 82);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 1;
            label2.Text = "نوع خروجی :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(560, 24);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 0;
            label1.Text = "مرحله 5: خروجی";
            // 
            // rbPdf
            // 
            rbPdf.Animated = true;
            rbPdf.AutoSize = true;
            rbPdf.Checked = true;
            rbPdf.CheckedState.BorderThickness = 0;
            rbPdf.CheckedState.FillColor = Color.FromArgb(0, 192, 0);
            rbPdf.CheckedState.InnerColor = Color.White;
            rbPdf.CheckedState.InnerOffset = -4;
            rbPdf.Font = new Font("Segoe UI", 11.25F);
            rbPdf.Location = new Point(605, 131);
            rbPdf.Name = "rbPdf";
            rbPdf.RightToLeft = RightToLeft.Yes;
            rbPdf.Size = new Size(53, 24);
            rbPdf.TabIndex = 8;
            rbPdf.TabStop = true;
            rbPdf.Text = "PDF";
            rbPdf.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            rbPdf.UncheckedState.BorderThickness = 2;
            rbPdf.UncheckedState.FillColor = Color.Transparent;
            rbPdf.UncheckedState.InnerColor = Color.Transparent;
            // 
            // rbWord
            // 
            rbWord.Animated = true;
            rbWord.AutoSize = true;
            rbWord.CheckedState.BorderThickness = 0;
            rbWord.CheckedState.FillColor = Color.FromArgb(0, 192, 0);
            rbWord.CheckedState.InnerColor = Color.White;
            rbWord.CheckedState.InnerOffset = -4;
            rbWord.Font = new Font("Segoe UI", 11.25F);
            rbWord.Location = new Point(595, 161);
            rbWord.Name = "rbWord";
            rbWord.RightToLeft = RightToLeft.Yes;
            rbWord.Size = new Size(63, 24);
            rbWord.TabIndex = 9;
            rbWord.Text = "Word";
            rbWord.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            rbWord.UncheckedState.BorderThickness = 2;
            rbWord.UncheckedState.FillColor = Color.Transparent;
            rbWord.UncheckedState.InnerColor = Color.Transparent;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.pass_fail_480px;
            pictureBox1.Location = new Point(105, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(222, 180);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // UC_Output
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna2ShadowPanel1);
            Name = "UC_Output";
            Size = new Size(700, 226);
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2RadioButton rbPdf;
        private Guna.UI2.WinForms.Guna2RadioButton rbWord;
    }
}
