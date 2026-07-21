namespace ExamBuilder.UI
{
    partial class UC_QuestionSelection
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            rbAuto = new Guna.UI2.WinForms.Guna2RadioButton();
            rbHand = new Guna.UI2.WinForms.Guna2RadioButton();
            label1 = new Label();
            guna2ShadowPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(flowLayoutPanel1);
            guna2ShadowPanel1.Controls.Add(rbAuto);
            guna2ShadowPanel1.Controls.Add(rbHand);
            guna2ShadowPanel1.Controls.Add(label1);
            guna2ShadowPanel1.Dock = DockStyle.Fill;
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(0, 0);
            guna2ShadowPanel1.Margin = new Padding(3, 4, 3, 4);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 5;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowDepth = 80;
            guna2ShadowPanel1.Size = new Size(800, 385);
            guna2ShadowPanel1.TabIndex = 4;
            guna2ShadowPanel1.Paint += guna2ShadowPanel1_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(14, 16);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(576, 361);
            flowLayoutPanel1.TabIndex = 8;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // rbAuto
            // 
            rbAuto.Animated = true;
            rbAuto.AutoSize = true;
            rbAuto.CheckedState.BorderThickness = 0;
            rbAuto.CheckedState.FillColor = Color.FromArgb(0, 192, 0);
            rbAuto.CheckedState.InnerColor = Color.White;
            rbAuto.CheckedState.InnerOffset = -4;
            rbAuto.Font = new Font("Segoe UI", 11.25F);
            rbAuto.Location = new Point(646, 119);
            rbAuto.Margin = new Padding(3, 4, 3, 4);
            rbAuto.Name = "rbAuto";
            rbAuto.RightToLeft = RightToLeft.Yes;
            rbAuto.Size = new Size(87, 29);
            rbAuto.TabIndex = 6;
            rbAuto.Text = "خودکار";
            rbAuto.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            rbAuto.UncheckedState.BorderThickness = 2;
            rbAuto.UncheckedState.FillColor = Color.Transparent;
            rbAuto.UncheckedState.InnerColor = Color.Transparent;
            rbAuto.CheckedChanged += rbSelectedLesson_CheckedChanged;
            // 
            // rbHand
            // 
            rbHand.Animated = true;
            rbHand.AutoSize = true;
            rbHand.CheckedState.BorderThickness = 0;
            rbHand.CheckedState.FillColor = Color.FromArgb(0, 192, 0);
            rbHand.CheckedState.InnerColor = Color.White;
            rbHand.CheckedState.InnerOffset = -4;
            rbHand.Font = new Font("Segoe UI", 11.25F);
            rbHand.Location = new Point(646, 221);
            rbHand.Margin = new Padding(3, 4, 3, 4);
            rbHand.Name = "rbHand";
            rbHand.RightToLeft = RightToLeft.Yes;
            rbHand.Size = new Size(81, 29);
            rbHand.TabIndex = 7;
            rbHand.Text = "دستی";
            rbHand.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            rbHand.UncheckedState.BorderThickness = 2;
            rbHand.UncheckedState.FillColor = Color.Transparent;
            rbHand.UncheckedState.InnerColor = Color.Transparent;
            rbHand.CheckedChanged += rbHand_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(597, 24);
            label1.Name = "label1";
            label1.Size = new Size(198, 25);
            label1.TabIndex = 0;
            label1.Text = "مرحله 3: انتخاب سوالات";
            // 
            // UC_QuestionSelection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna2ShadowPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_QuestionSelection";
            Size = new Size(800, 385);
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2RadioButton rbAuto;
        private Guna.UI2.WinForms.Guna2RadioButton rbHand;
    }
}
