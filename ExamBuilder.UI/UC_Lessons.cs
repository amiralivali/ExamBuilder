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
    public partial class UC_Lessons : UserControl
    {
        public UC_Lessons()
        {
            InitializeComponent();
        }
        private int _count;
        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UC_Lessons_Load(object sender, EventArgs e)
        {
            lblCount.Text = _count.ToString();
        }
    }
}
