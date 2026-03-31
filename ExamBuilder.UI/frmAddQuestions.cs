using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using ExamBuilder.BLL;
using ExamBuilder.DAL.Entities;
using ExamBuilder.Shared;
using ExamBuilder.Shared.InformationClases;
using Guna.UI2.WinForms;
using static ExamBuilder.Shared.QuestionTypes;

namespace ExamBuilder.UI
{
    public partial class frmAddQuestions : frmStyle
    {
        BookService bookService;
        LessonService lessonService;
        private QuestionType? _questionType;
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
            {
                cbLesson.ForeColor = Color.Gray;
                btnSaveQ.Enabled = false;
            }
            else
            {
                cbLesson.ForeColor = Color.Black;
                btnSaveQ.Enabled = true;
            }
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
            _questionType = QuestionType.OptionalQuestion;
        }

        private void btnShort_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_Descriptive_ShortQuestion(Messages.ShortAnswer)); })));
            _questionType = QuestionType.ShortQuestion;
        }

        private void btnDescritive_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_Descriptive_ShortQuestion(Messages.Descriptive)); })));
            _questionType = QuestionType.DescriptiveQuestion;
        }

        private void btnTrueFalse_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_ItemQuestions(QuestionType.TrueFalseQuestion)); })));
            _questionType = QuestionType.TrueFalseQuestion;
        }

        private void btnBlank_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_ItemQuestions(QuestionType.FillInBlankQuestion)); })));
            _questionType = QuestionType.FillInBlankQuestion;
        }

        private void btnMatching_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_ItemQuestions(QuestionType.MatchingQuestion)); })));
            _questionType = QuestionType.MatchingQuestion;
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
        private void CheckButtonsSelection()
        {
            foreach (var item in panelTypeQuestions.Controls)
            {
                if (item is Guna2Button)
                {
                    var btn = (Guna2Button)item;
                    if (btn.Checked)
                    { 
                        
                    }
                }
            }
        }
        private OptionalItemInfo GetOptionalItem()
        {
            string[] options = new string[4];
            int count = 0;
            foreach (var item in flpQuestions.Controls)
            {
                if (item is BunifuTextBox)
                {
                    var txt= (BunifuTextBox)item;
                    options[count++] = (string)txt.Text;
                }
            }
            OptionalItemInfo optionalItems = new OptionalItemInfo()
            {
                Option1 = options[0],
                Option2 = options[1],
                Option3 = options[2],
                Option4 = options[3],
            };
            return optionalItems;
        }
        //private ItemQuestionInfo GetTrueFalseItem()
        //{
        //    string[] options = new string[4];
        //    int count = 0;
        //    foreach (var item in flpQuestions.Controls)
        //    {
        //        if (item is BunifuTextBox)
        //        {
        //            var txt = (BunifuTextBox)item;
        //            options[count++] = (string)txt.Text;
        //        }
        //    }
        //    OptionalItemInfo optionalItems = new OptionalItemInfo()
        //    {
        //        Option1 = options[0],
        //        Option2 = options[1],
        //        Option3 = options[2],
        //        Option4 = options[3],
        //    };
        //    return optionalItems;
        //}
        //private ItemQuestionInfo GetFillInBlankItem()
        //{ 
        
        //}
        //private ItemQuestionInfo GetItemQuestion()
        //{ 
        
        //}
        private async void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            var lessonService = new LessonService();
            var lessonId = await lessonService.GetLessonIDAsync(cbLesson.SelectedIndex, cbBook.SelectedItem.ToString());
            if (lessonId.IsSuccess)
            {
                var questionInfo = new QuestionInfo()
                {
                    LessonID = lessonId.Data,
                    DifficultyLevelID = cbDifficalty.SelectedIndex,
                    QuestionText = txtQuestionText.Text,
                };
                if (questionInfo.IsValid)
                {
                    if (_questionType != null)
                    {
                        OprationResult oprationResult = new OprationResult();
                        switch (_questionType)
                        {
                            case QuestionType.DescriptiveQuestion:
                                var descriptiveService = new DescriptiveService();
                                oprationResult = await descriptiveService.InsertAsync(questionInfo);
                                break;
                            case QuestionType.ShortQuestion:
                                var shortAnswerService = new ShortAnswerService();
                                oprationResult = await shortAnswerService.InsertAsync(questionInfo);
                                break;
                            case QuestionType.OptionalQuestion:
                                var optionalService = new OptionalService();
                                var options = GetOptionalItem();
                                if (options.IsValid)
                                {
                                    oprationResult = await optionalService.InsertAsync(questionInfo,options);
                                }
                                else
                                {
                                    ShowError(options.ErrorMessage);
                                }
                                break;
                            case QuestionType.TrueFalseQuestion:
                                var trueFalseService = new TrueFalseService();
                                oprationResult = await trueFalseService.InsertAsync(questionInfo);
                                break;
                            case QuestionType.MatchingQuestion:
                                var matchingService = new MatchingService();
                                oprationResult = await matchingService.InsertAsync(questionInfo);
                                break;
                            case QuestionType.FillInBlankQuestion:
                                var fillInBlankService = new FillInBlankService();
                                oprationResult = await fillInBlankService.InsertAsync(questionInfo);
                                break;
                        }
                    }
                    else
                    {
                        ShowError("لطفا نوع سوال رو انتخاب کنید");
                    }
                }
                else
                {
                    ShowError(questionInfo.ErrorMessage);
                }
            }
            else 
            {
                ShowError(lessonId.Message);
            }
        }
    }
}
