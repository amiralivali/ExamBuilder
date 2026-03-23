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
    public partial class UC_FillInBlankItem : UserControl
    {
        public UC_FillInBlankItem(int _count)
        {
            InitializeComponent();
            lblCount.Text = _count.ToString();
        }

        private void btnAddBlank_Click(object sender, EventArgs e)
        {

        }
    }
}
