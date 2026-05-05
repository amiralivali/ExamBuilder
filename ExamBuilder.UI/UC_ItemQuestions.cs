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
using ExamBuilder.Shared.InformationClases;
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
        public void LoadItems<T>(List<T> items) where T : class
        {
            int i = 1;
            foreach (var item in items)
            {
                switch (_questionType)
                {
                    case QuestionType.FillInBlankQuestion:
                        {
                            var uc = new UC_FillInBlankItem(i++);
                            uc.LoadItem(item as FillInBlankItemInfo, false);
                            flpItems.Controls.Add(uc);
                        }
                        break;
                    case QuestionType.MatchingQuestion:
                        {
                            var uc = new UC_MatchingItem(i++);
                            uc.LoadItem(item as MatchingItemInfo, false);
                            flpItems.Controls.Add(uc);
                        }
                        break;
                    case QuestionType.TrueFalseQuestion:
                        {
                            var uc = new UC_TrueFalseItem(i++);
                            uc.LoadItem(item as TrueFalseItemInfo, false);
                            flpItems.Controls.Add(uc);
                        }
                        break;
                }
            }
            numberPick.Value = items.Count;
            btnCreatItem.FillColor = Color.FromArgb(123, 127, 133);
            btnDeleteItem.FillColor = Color.FromArgb(123, 127, 133);
            numberPick.UpDownButtonFillColor = Color.FromArgb(123, 127, 133);
            btnCreatItem.DisabledState.FillColor = Color.FromArgb(160, 164, 168);
            btnDeleteItem.DisabledState.FillColor = Color.FromArgb(160, 164, 168);
            numberPick.DisabledState.FillColor = Color.FromArgb(160, 164, 168);
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

        private void flpItems_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
