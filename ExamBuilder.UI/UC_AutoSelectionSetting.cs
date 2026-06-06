using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamBuilder.BLL;

namespace ExamBuilder.UI
{
    public partial class UC_AutoSelectionSetting : UserControl
    {
        [DefaultValue("")]
        public List<int> LessonIds { get; set; }
        public UC_AutoSelectionSetting()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void UC_AutoSelectionSetting_Load(object sender, EventArgs e)
        {
            var service = new LessonService();
            var oprationResult = await service.GetCountQuestionsInLessonsAsync(LessonIds);
            if (oprationResult.IsSuccess)
            {
                numberPick.Maximum = oprationResult.Data;
                label7.Text = string.Format(label7.Text, oprationResult.Data);
            }
            else
            {
                var frmStyle = new frmStyle();
                frmStyle.ShowError(oprationResult.Message);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
