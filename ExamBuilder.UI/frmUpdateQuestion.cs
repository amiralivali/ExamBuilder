using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamBuilder.BLL;
using ExamBuilder.BLL.Interface;
using ExamBuilder.Shared;
using ExamBuilder.Shared.DTOClases;
using ExamBuilder.Shared.InformationClases;
using static ExamBuilder.Shared.QuestionTypes;

namespace ExamBuilder.UI
{
    public partial class frmUpdateQuestion : frmStyle
    {
        BookService bookService;
        LessonService lessonService;
        private string _pictureLocation;
        ISelectQuestions selectDTO;
        public int questionId;
        private bool _isPriviousData;
        public QuestionType questionType;

        public frmUpdateQuestion()
        {
            InitializeComponent();
            bookService = new BookService();
            lessonService = new LessonService();
        }
        private void txtQuestionText_TextChanged(object sender, EventArgs e)
        {

        }
        private void AddSuggestionsText(string[] texts)
        {
            cbSuggestion.Items.Clear();
            cbSuggestion.Items.Add("متن سوال های پیشنهادی");
            cbSuggestion.Items.AddRange(texts);
            cbSuggestion.SelectedIndex = 0;
        }
        private async void frmUpdateQuestion_Load(object sender, EventArgs e)
        {
            switch (questionType)
            {
                case QuestionType.DescriptiveQuestion:
                    selectDTO = new DescriptiveService();
                    break;
                case QuestionType.FillInBlankQuestion:
                    selectDTO = new FillInBlankService();
                    break;
                case QuestionType.MatchingQuestion:
                    selectDTO = new MatchingService();
                    break;
                case QuestionType.OptionalQuestion:
                    selectDTO = new OptionalService();
                    break;
                case QuestionType.ShortAnswerQuestion:
                    selectDTO = new ShortAnswerService();
                    break;
                case QuestionType.TrueFalseQuestion:
                    selectDTO = new TrueFalseService();
                    break;
            }
            var questionOpration = await selectDTO.SelectQuestionAsync(questionId);
            if (questionOpration.IsSuccess)
            {
                _isPriviousData = true;
                var questionInfo = questionOpration.Data;
                var gradeOpration = await bookService.SelectAvailableGrades();
                var bookOpration = await bookService.SelectAsync(questionInfo.Grade);
                var lessonOpration = await lessonService.SelectAsync(questionInfo.BookName);
                if (gradeOpration.IsSuccess && bookOpration.IsSuccess && lessonOpration.IsSuccess)
                {
                    cbGrade.Items.AddRange(gradeOpration.Data.ToArray());
                    cbGrade.SelectedItem = questionInfo.Grade;
                    cbBook.Items.AddRange(bookOpration.Data.ToArray());
                    cbBook.SelectedItem = questionInfo.BookName;
                    cbLesson.Items.AddRange(lessonOpration.Data.ToArray());
                    cbLesson.SelectedItem = questionInfo.LessonName;
                    cbSuggestion.Items.AddRange(Messages.AllQuestionText_Suggestions.ToArray());
                    if (!string.IsNullOrEmpty(questionInfo.Picture))
                    {
                        chipCheckPic.Visible = true;
                        chipCheckPic.BringToFront();
                        chipCheckPic.Parent = guna2ShadowPanel1;
                        _pictureLocation = questionInfo.Picture;
                    }
                    cbDifficalty.SelectedItem = questionInfo.DifficultyLevel;
                    txtQuestionText.Text = questionInfo.QuestionText;
                    switch (questionType)
                    {
                        case QuestionType.DescriptiveQuestion:
                            btnDescritive.Checked = true;
                            flpQuestions.Controls.Add(new UC_Descriptive_ShortQuestion(questionType));
                            break;
                        case QuestionType.FillInBlankQuestion:
                            {
                                btnBlank.Checked = true;
                                var service = new FillInBlankService();
                                var items = await service.SelectItemsAsync(questionId);
                                if (items.IsSuccess)
                                {
                                    var uc = new UC_ItemQuestions(questionType);
                                    uc.LoadItems<FillInBlankItemInfo>(items.Data);
                                    flpQuestions.Controls.Add(uc);
                                }
                            }
                            break;
                        case QuestionType.MatchingQuestion:
                            {
                                btnMatching.Checked = true;
                                var service = new MatchingService();
                                var items = await service.SelectItemsAsync(questionId);
                                if (items.IsSuccess)
                                {
                                    var uc = new UC_ItemQuestions(questionType);
                                    uc.LoadItems<MatchingItemInfo>(items.Data);
                                    flpQuestions.Controls.Add(uc);
                                }
                            }
                            break;
                        case QuestionType.OptionalQuestion:
                            {
                                btnOptional.Checked = true;
                                var service = new OptionalService();
                                var item = await service.SelectItemsAsync(questionId);
                                if (item.IsSuccess)
                                {
                                    var uc = new UC_OptionalQuestion();
                                    uc.LoadItem(item.Data, false);
                                    flpQuestions.Controls.Add(uc);
                                }
                            }
                            break;
                        case QuestionType.ShortAnswerQuestion:
                            {
                                btnShort.Checked = true;
                                flpQuestions.Controls.Add(new UC_Descriptive_ShortQuestion(questionType));
                            }
                            break;
                        case QuestionType.TrueFalseQuestion:
                            {
                                btnTrueFalse.Checked = true;
                                var service = new TrueFalseService();
                                var items = await service.SelectItemsAsync(questionId);
                                if (items.IsSuccess)
                                {
                                    var uc = new UC_ItemQuestions(questionType);
                                    uc.LoadItems<TrueFalseItemInfo>(items.Data);
                                    flpQuestions.Controls.Add(uc);
                                }
                            }
                            break;
                    }
                }
                else
                {
                    if (!gradeOpration.IsSuccess) ShowError(gradeOpration.Message);
                    else if (!bookOpration.IsSuccess) ShowError(bookOpration.Message);
                    else ShowError(lessonOpration.Message);
                    this.Close();
                }
            }
            else
            {
                ShowError(questionOpration.Message);
                this.Close();
            }
        }

        private async void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
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
                if (!_isPriviousData)
                {
                    var list = await bookService.SelectAsync(cbGrade.SelectedItem.ToString());
                    cbBook.Items.Clear();
                    cbBook.Items.Add("کتاب را انتخاب کنید");
                    cbBook.Items.AddRange(list.Data.ToArray());
                    cbBook.SelectedIndex = 0;
                }
            }

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
                if (!_isPriviousData)
                {
                    var list = await lessonService.SelectAsync(cbBook.SelectedItem.ToString());
                    cbLesson.Items.Clear();
                    cbLesson.Items.Add("درس را انتخاب کنید");
                    cbLesson.Items.AddRange(list.Data.ToArray());
                    cbLesson.SelectedIndex = 0;
                }
            }
        }

        private void cbLesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLesson.SelectedIndex == 0)
            {
                cbLesson.ForeColor = Color.Gray;
                btnSaveQ.Enabled = false;
            }
            else
            {
                cbLesson.ForeColor = Color.Black;
                btnSaveQ.Enabled = true;
                _isPriviousData = false;
            }
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp;*.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                chipCheckPic.Visible = true;
                chipCheckPic.BringToFront();
                chipCheckPic.Parent = guna2ShadowPanel1;
                _pictureLocation = ofd.FileName;
            }
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbDifficalty_SelectedIndexChanged(object sender, EventArgs e)
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
            questionType = QuestionType.OptionalQuestion;
        }

        private void btnBlank_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_ItemQuestions(QuestionType.FillInBlankQuestion)); })));
            questionType = QuestionType.FillInBlankQuestion;
            AddSuggestionsText(Messages.FillInBlankText_Suggestions.ToArray());
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnShort_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_Descriptive_ShortQuestion(QuestionType.ShortAnswerQuestion)); })));
            questionType = QuestionType.ShortAnswerQuestion;
        }

        private void btnDescritive_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_Descriptive_ShortQuestion(QuestionType.DescriptiveQuestion)); })));
            questionType = QuestionType.DescriptiveQuestion;
        }

        private void btnTrueFalse_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_ItemQuestions(QuestionType.TrueFalseQuestion)); })));
            questionType = QuestionType.TrueFalseQuestion;
            AddSuggestionsText(Messages.TrueFalseText_Suggestions.ToArray());
        }

        private void btnMatching_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_ItemQuestions(QuestionType.MatchingQuestion)); })));
            questionType = QuestionType.MatchingQuestion;
            AddSuggestionsText(Messages.MatchingText_Suggestions.ToArray());
        }
    }
}
