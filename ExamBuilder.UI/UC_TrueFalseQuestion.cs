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
    public partial class UC_TrueFalseQuestion : UserControl
    {
        public UC_TrueFalseQuestion()
        {
            InitializeComponent();
        }

        private void btnCreatItem_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= numberPick.Value; i++)
            {
                flpItems.Controls.Add(new UC_TrueFalseItem(i));
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
    }
}
