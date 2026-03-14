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
    public partial class frmAddQuestions : frmStyle
    {
        public frmAddQuestions()
        {
            InitializeComponent();
        }

        private void cbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBook.SelectedIndex == 0)
                cbBook.ForeColor = Color.Gray;
            else
                cbBook.ForeColor = Color.Black;
            //
        }

        private void frmAddQuestions_Load(object sender, EventArgs e)
        {

        }
    }
}
