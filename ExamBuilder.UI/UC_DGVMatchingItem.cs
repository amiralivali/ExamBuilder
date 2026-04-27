using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamBuilder.Shared.InformationClases;

namespace ExamBuilder.UI
{
    public partial class UC_DGVMatchingItem : UserControl
    {
        public UC_DGVMatchingItem(List<MatchingItemInfo> itemInfos)
        {
            InitializeComponent();
            dgvData.DataSource = itemInfos;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
