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
    public partial class UC_MatchingItem : UserControl
    {
        public string ItemRight_Text => txtRight.Text.Trim();
        public string ItemLeft_Text => txtLeft.Text.Trim();
        public UC_MatchingItem(int _count)
        {
            InitializeComponent();
            lblCount.Text = _count.ToString();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
