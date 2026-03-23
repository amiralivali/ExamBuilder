namespace ExamBuilder.UI
{
    partial class UC_Descriptive_ShortQuestion
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
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(238, 23);
            label1.Name = "label1";
            label1.Size = new Size(207, 21);
            label1.TabIndex = 0;
            label1.Text = "سوال {0} اطلاعات دیگری ندارد";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(257, 59);
            label2.Name = "label2";
            label2.Size = new Size(189, 21);
            label2.TabIndex = 1;
            label2.Text = "سوال را با موفقیت ثبت کنید";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.check_5121;
            pictureBox1.Location = new Point(317, 97);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(77, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // UC_Descriptive_ShortQuestion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UC_Descriptive_ShortQuestion";
            Size = new Size(615, 195);
            Load += UC_Descriptive_ShortQuestion_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
    }
}
