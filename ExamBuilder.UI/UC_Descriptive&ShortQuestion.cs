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
    public partial class UC_Descriptive_ShortQuestion : UserControl
    {
        public UC_Descriptive_ShortQuestion(string type)
        {
            InitializeComponent();
            label1.Text = string.Format(label1.Text, type);
        }

        private void UC_Descriptive_ShortQuestion_Load(object sender, EventArgs e)
        {

        }
    }
}
