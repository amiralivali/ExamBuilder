using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamBuilder.Shared;
using static ExamBuilder.Shared.QuestionTypes;

namespace ExamBuilder.UI
{
    public partial class UC_Descriptive_ShortQuestion : UserControl
    {
        public UC_Descriptive_ShortQuestion(QuestionType questionType)
        {
            InitializeComponent();
            if (questionType == QuestionType.ShortAnswerQuestion)
            {
                label1.Text = string.Format(label1.Text, Messages.ShortAnswer);
            }
            else
            {
                label1.Text = string.Format(label1.Text, Messages.Descriptive);
            }
        }

        private void UC_Descriptive_ShortQuestion_Load(object sender, EventArgs e)
        {

        }
    }
}
