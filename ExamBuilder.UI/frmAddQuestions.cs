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
using ExamBuilder.DAL.Entities;
using ExamBuilder.Shared;
using Guna.UI2.WinForms;
using static ExamBuilder.Shared.QuestionTypes;

namespace ExamBuilder.UI
{
    public partial class frmAddQuestions : frmStyle
    {
        BookService bookService;
        LessonService lessonService;
        public frmAddQuestions()
        {
            InitializeComponent();
            bookService = new BookService();
            lessonService = new LessonService();
        }

        private async void cbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBook.SelectedIndex == 0)
            {
                cbBook.ForeColor = Color.Gray;
                cbLesson.Enabled = false;
                cbLesson.SelectedIndex = 0;
            }
            else
            {
                cbBook.ForeColor = Color.Black;
                cbLesson.Enabled = true;
                var list = await lessonService.SelectAsync(cbBook.SelectedItem.ToString());
                cbLesson.Items.Clear();
                cbLesson.Items.Add("درس را انتخاب کنید");
                cbLesson.Items.AddRange(list.Data.ToArray());
                cbLesson.SelectedIndex = 0;
            }
        }

        private async void frmAddQuestions_Load(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                var check = await bookService.SelectAvailableGrades();
                if (check.IsSuccess)
                {
                    if (check.Data.Count != 0)
                    {
                        this.Invoke(new Action(() =>
                        {
                            cbGrade.Items.AddRange(check.Data.ToArray());
                        }));
                    }
                    else
                    {
                        ShowError("هیچ کتابی اضافه نشده است.لطفا ابتدا کتاب اضافه کنید");
                        this.Invoke(new Action(() =>
                        {
                            this.Close();
                        }));
                    }
                }
                else
                {
                    ShowError(check.Message);
                    this.Invoke(new Action(() =>
                    {
                        this.Close();
                    }));
                }
            });
        }

        private async void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGrade.SelectedIndex == 0)
            {
                cbGrade.ForeColor = Color.Gray;
                cbBook.Enabled = false;
                cbBook.SelectedIndex = 0;
                cbLesson.Enabled = false;
                cbLesson.SelectedIndex = 0;
            }
            else
            {
                cbGrade.ForeColor = Color.Black;
                cbBook.Enabled = true;
                var list = await bookService.SelectAsync(cbGrade.SelectedItem.ToString());
                cbBook.Items.Clear();
                cbBook.Items.Add("کتاب را انتخاب کنید");
                cbBook.Items.AddRange(list.Data.ToArray());
                cbBook.SelectedIndex = 0;
            }
        }

        private void cbLesson_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbLesson.SelectedIndex == 0)
                cbLesson.ForeColor = Color.Gray;
            else
                cbLesson.ForeColor = Color.Black;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDifficalty.SelectedIndex == 0)
                cbDifficalty.ForeColor = Color.Gray;
            else
                cbDifficalty.ForeColor = Color.Black;
        }

        private void btnOptional_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_OptionalQuestion()); })));
        }

        private void btnShort_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_Descriptive_ShortQuestion(Messages.ShortAnswer)); })));
        }

        private void btnDescritive_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_Descriptive_ShortQuestion(Messages.Descriptive)); })));
        }

        private void btnTrueFalse_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_ItemQuestions(QuestionType.TrueFalseQuestion)); })));
        }

        private void btnBlank_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_ItemQuestions(QuestionType.FillInBlankQuestion)); })));
        }

        private void btnMatching_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_ItemQuestions(QuestionType.MatchingQuestion)); })));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp;*.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                chipCheckPic.Visible = true;
                chipCheckPic.Parent = guna2ShadowPanel1;
            }
        }

        private void chipCheckPic_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
