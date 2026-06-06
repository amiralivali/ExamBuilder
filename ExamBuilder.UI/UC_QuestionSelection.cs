using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamBuilder.UI
{
    public partial class UC_QuestionSelection : UserControl
    {
        [DefaultValue("")]
        public List<int> lessonsId { get; set; }
        public UC_QuestionSelection()
        {
            InitializeComponent();
        }
        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbSelectedLesson_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAuto.Checked)
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Controls.Add(new UC_AutoSelectionSetting() { LessonIds = lessonsId });
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbHand_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHand.Checked)
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Controls.Add(new UC_ManualQuestionSelection() { LessonsIds = lessonsId });
            }
        }
    }
}
