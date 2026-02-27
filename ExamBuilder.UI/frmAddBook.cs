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
    public partial class frmAddBook : Form
    {
        public frmAddBook()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (((int)numberPick.Value) > 0 && !string.IsNullOrEmpty(txtBookName.Text) && cbGrade.SelectedIndex != -1)
            {
                btnCreatLesson.Enabled = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void frmAddBook_Load(object sender, EventArgs e)
        {

        }
    }
}
