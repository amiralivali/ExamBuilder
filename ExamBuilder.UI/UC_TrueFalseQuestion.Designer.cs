namespace ExamBuilder.UI
{
    partial class UC_TrueFalseQuestion
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            numberPick = new Guna.UI2.WinForms.Guna2NumericUpDown();
            label5 = new Label();
            btnCreatItem = new Guna.UI2.WinForms.Guna2Button();
            btnDeleteItem = new Guna.UI2.WinForms.Guna2Button();
            guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            flpItems = new FlowLayoutPanel();
            guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)numberPick).BeginInit();
            guna2ShadowPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // numberPick
            // 
            numberPick.BackColor = Color.Transparent;
            numberPick.CustomizableEdges = customizableEdges1;
            numberPick.Font = new Font("Segoe UI", 9F);
            numberPick.Location = new Point(505, 78);
            numberPick.Name = "numberPick";
            numberPick.ShadowDecoration.CustomizableEdges = customizableEdges2;
            numberPick.Size = new Size(71, 32);
            numberPick.TabIndex = 27;
            numberPick.UpDownButtonFillColor = Color.FromArgb(37, 99, 235);
            numberPick.ValueChanged += numberPick_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(458, 41);
            label5.Name = "label5";
            label5.Size = new Size(162, 19);
            label5.TabIndex = 28;
            label5.Text = "تعداد آیتم های صحیح غلط";
            // 
            // btnCreatItem
            // 
            btnCreatItem.Animated = true;
            btnCreatItem.AnimatedGIF = true;
            btnCreatItem.AutoRoundedCorners = true;
            btnCreatItem.BackColor = Color.Transparent;
            btnCreatItem.CustomizableEdges = customizableEdges3;
            btnCreatItem.DisabledState.BorderColor = Color.DarkGray;
            btnCreatItem.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCreatItem.DisabledState.FillColor = Color.LightSteelBlue;
            btnCreatItem.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCreatItem.Enabled = false;
            btnCreatItem.FillColor = Color.FromArgb(37, 99, 235);
            btnCreatItem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreatItem.ForeColor = Color.White;
            btnCreatItem.HoverState.FillColor = Color.FromArgb(0, 0, 192);
            btnCreatItem.Location = new Point(465, 135);
            btnCreatItem.Name = "btnCreatItem";
            btnCreatItem.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCreatItem.Size = new Size(145, 40);
            btnCreatItem.TabIndex = 29;
            btnCreatItem.Text = "ایجاد آیتم";
            btnCreatItem.Click += btnCreatItem_Click;
            // 
            // btnDeleteItem
            // 
            btnDeleteItem.Animated = true;
            btnDeleteItem.AnimatedGIF = true;
            btnDeleteItem.AutoRoundedCorners = true;
            btnDeleteItem.BackColor = Color.Transparent;
            btnDeleteItem.CustomizableEdges = customizableEdges5;
            btnDeleteItem.DisabledState.BorderColor = Color.DarkGray;
            btnDeleteItem.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDeleteItem.DisabledState.FillColor = Color.LightSteelBlue;
            btnDeleteItem.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDeleteItem.FillColor = Color.FromArgb(37, 99, 235);
            btnDeleteItem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteItem.ForeColor = Color.White;
            btnDeleteItem.HoverState.FillColor = Color.FromArgb(0, 0, 192);
            btnDeleteItem.Location = new Point(14, 10);
            btnDeleteItem.Name = "btnDeleteItem";
            btnDeleteItem.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnDeleteItem.Size = new Size(155, 36);
            btnDeleteItem.TabIndex = 30;
            btnDeleteItem.Text = "حذف آیتم ها";
            btnDeleteItem.Visible = false;
            btnDeleteItem.Click += btnDeleteItem_Click;
            // 
            // guna2ShadowPanel2
            // 
            guna2ShadowPanel2.BackColor = Color.Transparent;
            guna2ShadowPanel2.Controls.Add(btnDeleteItem);
            guna2ShadowPanel2.Controls.Add(flpItems);
            guna2ShadowPanel2.Controls.Add(guna2Separator2);
            guna2ShadowPanel2.Controls.Add(label6);
            guna2ShadowPanel2.Dock = DockStyle.Left;
            guna2ShadowPanel2.FillColor = Color.White;
            guna2ShadowPanel2.Location = new Point(0, 0);
            guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            guna2ShadowPanel2.Radius = 5;
            guna2ShadowPanel2.ShadowColor = Color.Black;
            guna2ShadowPanel2.ShadowDepth = 20;
            guna2ShadowPanel2.Size = new Size(449, 195);
            guna2ShadowPanel2.TabIndex = 31;
            // 
            // flpItems
            // 
            flpItems.AutoScroll = true;
            flpItems.Location = new Point(11, 51);
            flpItems.Name = "flpItems";
            flpItems.Size = new Size(429, 135);
            flpItems.TabIndex = 0;
            // 
            // guna2Separator2
            // 
            guna2Separator2.FillColor = Color.Silver;
            guna2Separator2.Location = new Point(3, 41);
            guna2Separator2.Name = "guna2Separator2";
            guna2Separator2.Size = new Size(443, 19);
            guna2Separator2.TabIndex = 30;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(324, 18);
            label6.Name = "label6";
            label6.Size = new Size(110, 20);
            label6.TabIndex = 29;
            label6.Text = "اضافه کردن آیتم";
            // 
            // UC_TrueFalseQuestion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna2ShadowPanel2);
            Controls.Add(btnCreatItem);
            Controls.Add(numberPick);
            Controls.Add(label5);
            Name = "UC_TrueFalseQuestion";
            Size = new Size(615, 195);
            ((System.ComponentModel.ISupportInitialize)numberPick).EndInit();
            guna2ShadowPanel2.ResumeLayout(false);
            guna2ShadowPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2NumericUpDown numberPick;
        private Label label5;
        private Guna.UI2.WinForms.Guna2Button btnCreatItem;
        private Guna.UI2.WinForms.Guna2Button btnDeleteItem;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private FlowLayoutPanel flpItems;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Label label6;
    }
}
