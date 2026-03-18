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
    public partial class UC_TrueFalseItem : UserControl
    {
        public UC_TrueFalseItem(int _count)
        {
            InitializeComponent();
            lblCount.Text = _count.ToString();
        }
    }
}
