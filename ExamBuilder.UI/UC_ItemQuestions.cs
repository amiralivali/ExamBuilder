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
    public partial class UC_ItemQuestions : UserControl
    {
        private QuestionType _questionType;
        public UC_ItemQuestions(QuestionType type)
        {
            InitializeComponent();
            _questionType = type;
        }

        private void btnCreatItem_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= numberPick.Value; i++)
            {
                switch (_questionType)
                {
                    case QuestionType.FillInBlankQuestion:
                        flpItems.Controls.Add(new UC_FillInBlankItem(i));
                        break;
                    case QuestionType.MatchingQuestion:
                        flpItems.Controls.Add(new UC_MatchingItem(i));
                        break;
                    case QuestionType.TrueFalseQuestion:
                        flpItems.Controls.Add(new UC_TrueFalseItem(i));
                        break;
                }
            }
            btnCreatItem.Enabled = false;
            btnDeleteItem.Visible = true;
        }

        private void numberPick_ValueChanged(object sender, EventArgs e)
        {
            if (numberPick.Value > 0)
            {
                btnCreatItem.Enabled = true;
            }
            else
            {
                btnCreatItem.Enabled = false;
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            flpItems.Controls.Clear();
            btnCreatItem.Enabled = true;
            btnDeleteItem.Visible = false;
        }

        private void UC_ItemQuestions_Load(object sender, EventArgs e)
        {

        }
    }
}
