using Bunifu.UI.WinForms;
using ExamBuilder.BLL;
using ExamBuilder.Shared;
using ExamBuilder.Shared.InformationClases;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;

namespace ExamBuilder.UI
{
    public partial class frmAddBook : frmStyle
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
                ShowError("لطفا نام تمامی دروس را وارد کنید");
                return;
            }
            var bookInfo = new BookInfo()
            {
                Title = txtBookName.Text.Trim(),
                GradeID=cbGrade.SelectedIndex+1,
                GradeInfo = txtGradeInfo.Text,
            };
            var bookOpration = await bookService.InsertAsync(bookInfo);
            var bookId=await bookService.GetLastIDAsync(bookInfo.Title,bookInfo.GradeID,bookInfo.GradeInfo);
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
                                lessonInfo.BookID = bookId.Data;
                                count++;
                            }
                        }
                        lessonsInfo.Add(lessonInfo);
                    }
                }
                var lessonOpration = await lessonService.InsertAsync(lessonsInfo);
                if (lessonOpration.IsSuccess)
                {
                    ShowSuccess(lessonOpration.Message);
                }
                else
                {
                    ShowError(lessonOpration.Message);
                }
            }
            else
            {
                ShowError(bookOpration.Message);
            }
        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            btnCreatLesson.Enabled = CheckValidationBookInfo();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var result = ShowWarningQuestion("آیا از اطلاعات وارد شده اطمینان دارید؟");
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
                cbGrade.SelectedIndex!=-1)
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
            var result = ShowWarningQuestion("آیا از حذف اطلاعات وارد شده اطمینان دارید؟");
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
    }
}
