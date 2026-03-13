using Bunifu.UI.WinForms;
using ExamBuilder.BLL;
using ExamBuilder.Shared;
using ExamBuilder.Shared.InformationClases;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;

namespace ExamBuilder.UI
{
    public partial class frmAddBook : Form
    {
        BookService bookService;
        LessonService lessonService;
        public frmAddBook()
        {
            InitializeComponent();
            bookService = new BookService();
            lessonService = new LessonService();
        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            var check = CheckValidationLesson();
            if (!check)
            {
                MessageBox.Show("لطفا نام تمامی دروس را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var bookInfo = new BookInfo()
            {
                Title = txtBookName.Text,
                GradeInfo = txtGradeInfo.Text,
            };
            if (rbElementary.Checked)
                bookInfo.Grade = Messages.Elementary + "-" + cbGrade.SelectedItem.ToString();
            else if (rbM1.Checked)
                bookInfo.Grade = Messages.MiddleSchoolGrades + "-" + cbGrade.SelectedItem.ToString();
            else if (rbM2.Checked)
                bookInfo.Grade = Messages.HighSchoolGrades + "-" + cbGrade.SelectedItem.ToString();
            else if (rbUni.Checked)
                bookInfo.Grade = Messages.University;
            else
                bookInfo.Grade = Messages.More;
            var bookOpration = await bookService.InsertAsync(bookInfo);
            int bookID = bookOpration.Data;
            if (bookOpration.IsSuccess)
            {
                var lessonsInfo = new List<LessonInfo>();
                int count = 1;
                foreach (var item in flpLessons.Controls)
                {
                    var control = item as UC_Lessons;
                    foreach (var panel in control.Controls)
                    {
                        var shadow = panel as Guna2ShadowPanel;
                        var lessonInfo = new LessonInfo();
                        foreach (var childItem in shadow.Controls)
                        {
                            if (childItem is BunifuTextBox)
                            {
                                var txt = childItem as BunifuTextBox;
                                lessonInfo.Title = txt.Text;
                                lessonInfo.LessonCount = count;
                                lessonInfo.BookID = bookID;
                                count++;
                            }
                        }
                        lessonsInfo.Add(lessonInfo);
                    }
                }
                var lessonOpration = await lessonService.InsertAsync(lessonsInfo);
                if (lessonOpration.IsSuccess)
                {
                    MessageBox.Show(lessonOpration.Message);
                }
                else
                {
                    MessageBox.Show(lessonOpration.Message);
                }
            }
            else
            {
                MessageBox.Show(bookOpration.Message);
            }
        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            btnCreatLesson.Enabled = CheckValidationBookInfo();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا از اطلاعات وارد شده اطمینان دارید؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                btnEnterBook.Enabled = true;
                panelbook.Enabled = false;
                for (int i = 1; i <= numberPick.Value; i++)
                {
                    flpLessons.Controls.Add(new UC_Lessons(i));
                }
                btnDelete.Visible = true;
            }
        }

        private void frmAddBook_Load(object sender, EventArgs e)
        {

        }

        private void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCreatLesson.Enabled = CheckValidationBookInfo();
        }
        private bool CheckValidationBookInfo()
        {
            if (((int)numberPick.Value) > 0 &&
                !string.IsNullOrEmpty(txtBookName.Text) &&
                ((cbGrade.Visible == true && cbGrade.SelectedIndex != -1) || cbGrade.Visible == false) &&
                (rbM1.Checked || rbM2.Checked || rbMore.Checked || rbUni.Checked))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckValidationLesson()
        {
            foreach (var item in flpLessons.Controls)
            {
                var control = item as UC_Lessons;
                foreach (var panel in control.Controls)
                {
                    var shadow = panel as Guna2ShadowPanel;
                    foreach (var childItem in shadow.Controls)
                    {
                        if (childItem is BunifuTextBox)
                        {
                            var txt = childItem as BunifuTextBox;
                            if (string.IsNullOrEmpty(txt.Text))
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            btnCreatLesson.Enabled = CheckValidationBookInfo();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا از حذف اطلاعات وارد شده اطمینان دارید؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                panelbook.Enabled = true;
                txtBookName.Text = "";
                numberPick.Value = 0;
                btnEnterBook.Enabled = false;
                flpLessons.Controls.Clear();
                btnDelete.Visible = false;
            }
        }

        private void bunifuRadioButton5_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            
        }

        private void rbM2_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {
            if (rbM2.Checked)
            {
                cbGrade.Visible = true;
                cbGrade.DataSource = Messages.HighSchoolGrades;
            }
        }

        private void rbMore_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {
            if (rbElementary.Checked)
            {
                cbGrade.Visible = true;
                cbGrade.DataSource = Messages.ElementaryGrades;
            }
            else
            {
                cbGrade.Visible = false;
            }
        }

        private void rbM1_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {
            if (rbM1.Checked)
            {
                cbGrade.Visible = true;
                cbGrade.DataSource = Messages.MiddleSchoolGrades;
            }
        }

        private void rbUni_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {

        }

        private void rbebtedaie_ChangeUICues(object sender, UICuesEventArgs e)
        {
            
        }
    }
}
