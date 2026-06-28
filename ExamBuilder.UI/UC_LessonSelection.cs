using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamBuilder.BLL;
using ExamBuilder.Shared;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;

namespace ExamBuilder.UI
{
    public partial class UC_LessonSelection : UserControl
    {
        [DefaultValue("")]
        public string BookName { get; set; }
        [DefaultValue("")]
        public string GradeName { get; set; }
        LessonService lessonService;
        frmStyle _style;
        public UC_LessonSelection()
        {
            InitializeComponent();
            lessonService = new LessonService();
            _style = new frmStyle();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public OprationResult ValidateData()
        {
            if (rbSelectedLesson.Checked)
            {
                bool isCheck = false;
                foreach (var rb in flpCheckBoxes.Controls.OfType<Guna2CheckBox>())
                {
                    if (rb.Checked)
                    {
                        isCheck = true;
                        break;
                    }
                }
                if (!isCheck)
                {
                    return OprationResult.UnSuccess(Messages.SelectLessonError);
                }
                else
                {
                    return OprationResult.Success();
                }
            }
            else
            { 
                return OprationResult.Success();
            }
        }
        public async Task<List<int>> GetLessonsId()
        {
            List<int> lessonsCounts = new List<int>();
            int temp = 1;
            foreach (var rb in flpCheckBoxes.Controls.OfType<Guna2CheckBox>())
            {
                if (rb.Checked)
                {
                    lessonsCounts.Add(temp);
                }
                temp++;
            }
            var ids = await lessonService.GetLessonsId(lessonsCounts, BookName,GradeName);
            return ids.Data;
        }
        private async void UC_LessonSelection_Load(object sender, EventArgs e)
        {
            var oprationResult = await lessonService.SelectAsync(BookName,GradeName);
            if (oprationResult.IsSuccess)
            {
                flpCheckBoxes.Controls.Clear();
                var uncheck = new CustomCheckBoxState();
                uncheck.BorderColor = Color.FromArgb(125, 137, 149);
                uncheck.FillColor = Color.Transparent;
                var chekced = new CustomCheckBoxState();
                chekced.BorderColor = Color.FromArgb(16, 185, 129);
                chekced.FillColor = Color.FromArgb(0, 192, 0);
                foreach (var item in oprationResult.Data)
                {
                    var checkBox = new Guna2CheckBox()
                    {
                        Text = item,
                        RightToLeft = RightToLeft.Yes,
                        Animated = true,
                        CheckedState = chekced,
                        UncheckedState = uncheck,
                        Checked = false,
                        Cursor = Cursors.Hand
                    };
                    flpCheckBoxes.Controls.Add(checkBox);
                }
            }
            else
            {
                _style.ShowError(oprationResult.Message);
            }
        }

        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSelectedLesson.Checked)
            {
                foreach (var rb in flpCheckBoxes.Controls.OfType<Guna2CheckBox>())
                {
                    rb.Enabled = true;
                    rb.Checked = false;
                }
            }
        }

        private void flpCheckBoxes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAllLessons.Checked)
            {
                foreach (var rb in flpCheckBoxes.Controls.OfType<Guna2CheckBox>())
                {
                    rb.Checked = true;
                    rb.Enabled = false;
                }
            }
        }
    }
}
