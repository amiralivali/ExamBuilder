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

namespace ExamBuilder.UI
{
    public partial class UC_DGVFillInBlankItem : UserControl
    {
        public UC_DGVFillInBlankItem(List<FillInBlankItemInfo> itemInfos)
        {
            InitializeComponent();
            var texts = RearrangeBlanks(itemInfos.Select(x => x.Text).ToList()).ToArray();
            int count = 0;
            var items = itemInfos.Select(x => new FillInBlankItemInfo()
            {
                Id = x.Id,
                Text = texts[count++],
                QuestionId = x.QuestionId,
            }).ToList();
            dgvData.DataSource = items;
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

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
