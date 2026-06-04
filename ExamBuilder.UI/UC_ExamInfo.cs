using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamBuilder.BLL;
using ExamBuilder.Shared;

namespace ExamBuilder.UI
{
    public partial class UC_ExamInfo : UserControl
    {
        [DefaultValue("")]
        public string BookName { private set; get; }
        BookService bookService;
        frmStyle _style;
        public UC_ExamInfo()
        {
            InitializeComponent();
            bookService = new BookService();
            _style = new frmStyle();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public OprationResult ValidateData()
        {
            if (!guna2RadioButton1.Checked && !guna2RadioButton2.Checked && !guna2RadioButton3.Checked)
            {
                return OprationResult.UnSuccess(Messages.SelectExamTypeError);
            }
            else
            {
                return OprationResult.Success();
            }
        }
        private async void UC_ExamInfo_Load(object sender, EventArgs e)
        {
            var check = await bookService.SelectAvailableGrades();
            if (check.IsSuccess)
            {
                cbGrade.DataSource = check.Data;
            }
            else
            {
                _style.ShowError(check.Message);
            }
        }

        private void cbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            BookName = cbBook.SelectedItem.ToString();
        }

        private async void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbBook.Enabled = true;
            var check = await bookService.SelectAsync(cbGrade.SelectedItem.ToString());
            if (check.IsSuccess)
            {
                cbBook.DataSource = check.Data;
            }
            else
            {
                _style.ShowError(check.Message);
            }
        }
    }
}
