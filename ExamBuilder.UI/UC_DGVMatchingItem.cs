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
using ExamBuilder.Shared;
using ExamBuilder.Shared.InformationClases;

namespace ExamBuilder.UI
{
    public partial class UC_DGVMatchingItem : UserControl
    {
        MatchingService service;
        private int _questionId;
        private frmStyle _style;
        public UC_DGVMatchingItem(int qustionId)
        {
            _questionId = qustionId;
            _style = new frmStyle();
            service = new MatchingService();
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
                dgvData.DataSource = result.Data;
            }
        }
        private async void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int questionId = int.Parse(dgvData.Rows[e.RowIndex].Cells[dgvData.Columns["QuestionId"].Index].Value.ToString());
            int itemId = int.Parse(dgvData.Rows[e.RowIndex].Cells[dgvData.Columns["Id"].Index].Value.ToString());
            if (e.ColumnIndex == dgvData.Columns["btnEdit"].Index)
            {
                var frmUpdate = new frmUpdateQuestion();
                frmUpdate.questionId = questionId;
                var type = QuestionTypes.QuestionType.MatchingQuestion;
                frmUpdate.questionType = type;
                frmUpdate.ShowDialog();
            }
            else if (e.ColumnIndex == dgvData.Columns["btnDelete"].Index)
            {
                var res = MessageBox.Show(Messages.DeleteItemWarning, Messages.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
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
