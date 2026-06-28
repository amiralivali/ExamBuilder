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
            var bookInfo = new BookInfo()
            {
                Title = txtBookName.Text.Trim(),
                GradeId = cbGrade.SelectedIndex + 1,
                GradeInfo = txtGradeInfo.Text,
            };
            if (bookInfo.IsValid)
            {
                var bookOpration = await bookService.InsertAsync(bookInfo);
                var bookId = await bookService.GetLastIdAsync(bookInfo.Title, bookInfo.GradeId, bookInfo.GradeInfo);
                if (bookOpration.IsSuccess)
                {
                    int count = 1;
                    var lessonInfo = new List<LessonInfo>();
                    foreach (var uc in flpLessons.Controls.OfType<UC_Lessons>())
                    {
                        lessonInfo.Add(new LessonInfo()
                        {
                            Title = uc.LessonName,
                            LessonCount = count++,
                            BookId = bookId.Data
                        });
                    }
                    var lessonOpration = await lessonService.InsertAsync(lessonInfo);
                    if (lessonOpration.IsSuccess)
                    {
                        ShowSuccess(lessonOpration.Message);
                        DeleteValueOfAllControls();
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
            else
            {
                ShowError(bookInfo.ErrorMessage);
            }
        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            btnCreatLesson.Enabled = CheckBookInformationValues();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            btnEnterBook.Enabled = true;
            btnCreatLesson.Enabled = false;
            numberPick.Enabled = false;
            for (int i = 1; i <= numberPick.Value; i++)
            {
                flpLessons.Controls.Add(new UC_Lessons(i));
            }
            btnDelete.Visible = true;
        }

        private void frmAddBook_Load(object sender, EventArgs e)
        {

        }

        private bool CheckBookInformationValues()
        {
            if (((int)numberPick.Value) > 0 &&
                !string.IsNullOrEmpty(txtBookName.Text) &&
                cbGrade.SelectedIndex != -1 &&
                numberPick.Enabled != false)//check if it isnt in lesson mode
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            btnCreatLesson.Enabled = CheckBookInformationValues();
        }
        private void DeleteLessonUserControls()
        {
            numberPick.Enabled = true;
            numberPick.Value = 0;
            btnEnterBook.Enabled = false;
            btnCreatLesson.Enabled = false;
            flpLessons.Controls.Clear();
            btnDelete.Visible = false;
        }
        private void DeleteValueOfAllControls()
        {
            DeleteLessonUserControls();
            txtBookName.Text = string.Empty;
            cbGrade.SelectedIndex = -1;
            txtGradeInfo.Text = string.Empty;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = ShowWarningQuestion("آیا از حذف دروس ایجاد شده اطمینان دارید؟");
            if (result == DialogResult.Yes)
            {
                DeleteLessonUserControls();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
