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
    public partial class UC_OptionalQuestion : UserControl
    {
        public UC_OptionalQuestion()
        {
            InitializeComponent();
        }
        public string Option1_Text => txtOptionA.Text.Trim();
        public string Option2_Text => txtOptionB.Text.Trim();
        public string Option3_Text => txtOptionC.Text.Trim();
        public string Option4_Text => txtOptionD.Text.Trim();
        private void UC_OptionalQuestion_Load(object sender, EventArgs e)
        {

        }
        public void LoadItem(OptionalItemInfo item, bool readOnly)
        {
            txtOptionA.Text = item.Option1;
            txtOptionB.Text = item.Option2;
            txtOptionC.Text = item.Option3;
            txtOptionD.Text = item.Option4;
            txtOptionA.ReadOnly = txtOptionB.ReadOnly = txtOptionC.ReadOnly = txtOptionD.ReadOnly = readOnly;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtOptionA_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
