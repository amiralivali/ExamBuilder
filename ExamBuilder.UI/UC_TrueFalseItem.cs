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
    public partial class UC_TrueFalseItem : UserControl
    {
        public string Item_Text => txtItemName.Text.Trim();
        public UC_TrueFalseItem(int _count)
        {
            InitializeComponent();
            lblCount.Text = _count.ToString();
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {

        }
        public void LoadItem(TrueFalseItemInfo item, bool readOnly)
        {
            txtItemName.Text = item.Text;
            txtItemName.ReadOnly = readOnly;
        }
        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
