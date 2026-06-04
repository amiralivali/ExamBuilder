using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamBuilder.BLL.Interface;
using ExamBuilder.BLL;
using ExamBuilder.Shared;
using ExamBuilder.Shared.InformationClases;
using static ExamBuilder.Shared.QuestionTypes;

namespace ExamBuilder.UI
{
    public partial class UC_DGVFillInBlankItem : UserControl
    {
        FillInBlankService service;
        private int _questionId;
        private frmStyle _style;
        public UC_DGVFillInBlankItem(int questionId)
        {
            InitializeComponent();
            service = new FillInBlankService();
            _style = new frmStyle();
            _questionId = questionId;
            FillDGV();
        }
        async void FillDGV()
        {
            var result = await service.SelectItemsAsync(_questionId);
            if (!result.IsSuccess)
            {
                _style.ShowError(result.Message);
            }
            else
            {
                var texts = RearrangeBlanks(result.Data.Select(x => x.Text).ToList()).ToArray();
                int count = 0;
                var items = result.Data.Select(x => new FillInBlankItemInfo()
                {
                    Id = x.Id,
                    Text = texts[count++],
                    QuestionId = x.QuestionId,
                }).ToList();
                dgvData.DataSource = items;
            }
        }
        public List<string> RearrangeBlanks(List<string> texts)
        {
            var outPut = new List<string>();
            foreach (string text in texts)
            {
                if (!text.Contains(Messages.Blank_Marker))
                    break;
                string[] parts = text.Split(new string[] { Messages.Blank_Marker }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    outPut.Add(parts[1].Trim() + $" {Messages.Blank_Marker} " + parts[0].Trim());
                }
                else
                {
                    string firstPart = parts[0].Trim();
                    string rest = string.Join($" {Messages.Blank_Marker} ", parts.Skip(1).Select(p => p.Trim()));
                    outPut.Add(rest + " #BLANK# " + firstPart);
                }
            }
            return outPut;
        }

        private async void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int questionId = int.Parse(dgvData.Rows[e.RowIndex].Cells[dgvData.Columns["QuestionId"].Index].Value.ToString());
            int itemId = int.Parse(dgvData.Rows[e.RowIndex].Cells[dgvData.Columns["Id"].Index].Value.ToString());
            if (e.ColumnIndex == dgvData.Columns["btnEdit"].Index)
            {
                var frmUpdate = new frmUpdateQuestion();
                frmUpdate.questionId = questionId;
                var type = QuestionTypes.QuestionType.FillInBlankQuestion;
                frmUpdate.questionType = type;
                frmUpdate.ShowDialog();
            }
            else if (e.ColumnIndex == dgvData.Columns["btnDelete"].Index)
            {
                var res = MessageBox.Show(Messages.DeleteItemWarning,Messages.Warning,MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
                if (res == DialogResult.Yes)
                {
                    var deleteOpration = await service.DeleteItemAsync(itemId);
                    if (deleteOpration.IsSuccess)
                    {
                        _style.ShowSuccess(deleteOpration.Message);
                        FillDGV();
                    }
                    else
                    {
                        _style.ShowError(deleteOpration.Message);
                    }
                }
            }
        }
    }
}
