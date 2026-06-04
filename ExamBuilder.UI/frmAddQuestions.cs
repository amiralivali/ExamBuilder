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
        string _pictureLocation;
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
                            cbSuggestion.Items.AddRange(Messages.AllQuestionText_Suggestions.ToArray());
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
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_Descriptive_ShortQuestion(QuestionType.ShortAnswerQuestion)); })));
            _questionType = QuestionType.ShortAnswerQuestion;
        }

        private void btnDescritive_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_Descriptive_ShortQuestion(QuestionType.DescriptiveQuestion)); })));
            _questionType = QuestionType.DescriptiveQuestion;
        }

        private void btnTrueFalse_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_ItemQuestions(QuestionType.TrueFalseQuestion)); })));
            _questionType = QuestionType.TrueFalseQuestion;
            AddSuggestionsText(Messages.TrueFalseText_Suggestions.ToArray());
        }

        private void btnBlank_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_ItemQuestions(QuestionType.FillInBlankQuestion)); })));
            _questionType = QuestionType.FillInBlankQuestion;
            AddSuggestionsText(Messages.FillInBlankText_Suggestions.ToArray());
        }

        private void btnMatching_Click(object sender, EventArgs e)
        {
            flpQuestions.Controls.Clear();
            Task.Delay(220).ContinueWith(t => this.Invoke(new Action(() => { flpQuestions.Controls.Add(new UC_ItemQuestions(QuestionType.MatchingQuestion)); })));
            _questionType = QuestionType.MatchingQuestion;
            AddSuggestionsText(Messages.MatchingText_Suggestions.ToArray());
        }

        private void AddSuggestionsText(string[] texts)
        {
            cbSuggestion.Items.Clear();
            cbSuggestion.Items.Add("متن سوال های پیشنهادی");
            cbSuggestion.Items.AddRange(texts);
            cbSuggestion.SelectedIndex = 0;
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp;*.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                chipCheckPic.Visible = true;
                chipCheckPic.BringToFront();
                chipCheckPic.Parent = panelQuestionInfo;
                _pictureLocation = ofd.FileName;
            }
        }

        private OptionalItemInfo GetOptionalItem()
        {
            var optionalItems = new OptionalItemInfo();
            foreach (var uc in flpQuestions.Controls.OfType<UC_OptionalQuestion>())
            {
                optionalItems.Option1 = uc.Option1_Text;
                optionalItems.Option2 = uc.Option2_Text;
                optionalItems.Option3 = uc.Option3_Text;
                optionalItems.Option4 = uc.Option4_Text;
            }
            return optionalItems;
        }
        private List<TrueFalseItemInfo> GetTrueFalseItem()
        {
            var items = new List<TrueFalseItemInfo>();
            foreach (var uc in flpQuestions.Controls.OfType<UC_ItemQuestions>())
            {
                foreach (var control in uc.Controls)
                {
                    if (control is Guna2ShadowPanel)
                    {
                        var panel = control as Guna2ShadowPanel;
                        foreach (var flp in panel.Controls)
                        {
                            if (flp is FlowLayoutPanel)
                            {
                                var flpItems = flp as FlowLayoutPanel;
                                foreach (var ucItem in flpItems.Controls.OfType<UC_TrueFalseItem>())
                                {
                                    items.Add(new TrueFalseItemInfo()
                                    {
                                        Text = ucItem.Item_Text,
                                    });
                                }
                            }
                        }
                    }
                }
            }
            return items;
        }
        private List<FillInBlankItemInfo> GetFillInBlankItem()
        {
            var items = new List<FillInBlankItemInfo>();
            foreach (var uc in flpQuestions.Controls.OfType<UC_ItemQuestions>())
            {
                foreach (var control in uc.Controls)
                {
                    if (control is Guna2ShadowPanel)
                    {
                        var panel = control as Guna2ShadowPanel;
                        foreach (var flp in panel.Controls)
                        {
                            if (flp is FlowLayoutPanel)
                            {
                                var flpItems = flp as FlowLayoutPanel;
                                foreach (var ucItem in flpItems.Controls.OfType<UC_FillInBlankItem>())
                                {
                                    items.Add(new FillInBlankItemInfo()
                                    {
                                        Text = ucItem.Item_Text,
                                    });
                                }
                            }
                        }
                    }
                }
            }
            return items;
        }
        private List<MatchingItemInfo> GetMatchingItem()
        {
            var items = new List<MatchingItemInfo>();
            foreach (var uc in flpQuestions.Controls.OfType<UC_ItemQuestions>())
            {
                foreach (var control in uc.Controls)
                {
                    if (control is Guna2ShadowPanel)
                    {
                        var panel = control as Guna2ShadowPanel;
                        foreach (var flp in panel.Controls)
                        {
                            if (flp is FlowLayoutPanel)
                            {
                                var flpItems = flp as FlowLayoutPanel;
                                foreach (var ucItem in flpItems.Controls.OfType<UC_MatchingItem>())
                                {
                                    items.Add(new MatchingItemInfo()
                                    {
                                        RightText = ucItem.ItemRight_Text,
                                        LeftText = ucItem.ItemLeft_Text,
                                    });
                                }
                            }
                        }
                    }
                }
            }
            return items;
        }

        private async void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            var lessonId = await lessonService.GetLessonIdAsync(cbLesson.SelectedIndex, cbBook.SelectedItem.ToString());
            if (lessonId.IsSuccess)
            {
                var questionInfo = new QuestionInfo()
                {
                    LessonId = lessonId.Data,
                    DifficultyLevelId = cbDifficalty.SelectedIndex,
                    QuestionText = txtQuestionText.Text.Trim(),
                };
                if (chipCheckPic.Parent != null && _pictureLocation != null)
                {
                    questionInfo.Picture = _pictureLocation;
                }
                if (questionInfo.IsValid)
                {
                    if (_questionType != null)
                    {
                        var oprationResult = new OprationResult();
                        oprationResult = null;
                        bool itemValid = true;
                        switch (_questionType)
                        {
                            case QuestionType.DescriptiveQuestion:
                                var descriptiveService = new DescriptiveService();
                                oprationResult = await descriptiveService.InsertAsync(questionInfo);
                                break;
                            case QuestionType.ShortAnswerQuestion:
                                var shortAnswerService = new ShortAnswerService();
                                oprationResult = await shortAnswerService.InsertAsync(questionInfo);
                                break;
                            case QuestionType.OptionalQuestion:
                                var optionalService = new OptionalService();
                                var options = GetOptionalItem();
                                if (options.IsValid)
                                {
                                    oprationResult = await optionalService.InsertAsync(questionInfo, options);
                                }
                                else
                                {
                                    ShowError(options.ErrorMessage);
                                }
                                break;
                            case QuestionType.TrueFalseQuestion:
                                var trueFalseService = new TrueFalseService();
                                var trueFalseItems = GetTrueFalseItem();
                                if (trueFalseItems.Count != 0)
                                {
                                    foreach (var trueFalseItem in trueFalseItems)
                                    {
                                        if (!trueFalseItem.IsValid)
                                        {
                                            ShowError(trueFalseItem.ErrorMessage);
                                            itemValid = false;
                                            break;
                                        }
                                    }
                                    if (itemValid)
                                    {
                                        oprationResult = await trueFalseService.InsertAsync(questionInfo, trueFalseItems);
                                    }
                                }
                                else
                                {
                                    ShowError(Messages.SelectItemError);
                                }
                                break;
                            case QuestionType.MatchingQuestion:
                                var matchingService = new MatchingService();
                                var matchingItems = GetMatchingItem();
                                if (matchingItems.Count != 0)
                                {
                                    foreach (var matchingitem in matchingItems)
                                    {
                                        if (!matchingitem.IsValid)
                                        {
                                            ShowError(matchingitem.ErrorMessage);
                                            itemValid = false;
                                            break;
                                        }
                                    }
                                    if (itemValid)
                                    {
                                        oprationResult = await matchingService.InsertAsync(questionInfo, matchingItems);
                                    }
                                }
                                else
                                {
                                    ShowError(Messages.SelectItemError);
                                }
                                break;
                            case QuestionType.FillInBlankQuestion:
                                var fillInBlankService = new FillInBlankService();
                                var fillInBlankItems = GetFillInBlankItem();
                                if (fillInBlankItems.Count != 0)
                                {
                                    foreach (var fillInBlankItem in fillInBlankItems)
                                    {
                                        if (!fillInBlankItem.IsValid)
                                        {
                                            ShowError(fillInBlankItem.ErrorMessage);
                                            itemValid = false;
                                            break;
                                        }
                                    }
                                    if (itemValid)
                                    {
                                        oprationResult = await fillInBlankService.InsertAsync(questionInfo, fillInBlankItems);
                                    }
                                }
                                else
                                {
                                    ShowError(Messages.SelectItemError);
                                }
                                break;
                        }
                        if (oprationResult != null)
                        {
                            if (oprationResult.IsSuccess)
                            {
                                ShowSuccess(oprationResult.Message);
                                ClearControls();
                            }
                            else
                            {
                                ShowError(oprationResult.Message);
                            }
                        }
                    }
                    else
                    {
                        ShowError(Messages.SelectQuestionError);
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

        private void ClearControls()
        {
            txtQuestionText.Clear();
            cbDifficalty.SelectedIndex = 0;
            flpQuestions.Controls.Clear();
            foreach (var item in panelTypeQuestions.Controls)
            {
                if (item is Guna2Button)
                {
                    var btn = (Guna2Button)item;
                    if (btn.Checked)
                    {
                        btn.Checked = false;
                        break;
                    }
                }
            }
            _questionType = null;
            _pictureLocation = null;
        }

        private void txtQuestionText_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbSuggestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSuggestion.SelectedIndex != 0)
            {
                txtQuestionText.Text = cbSuggestion.SelectedItem.ToString();
                cbSuggestion.SelectedIndex = 0;
            }
        }

        private void chipCheckPic_Click(object sender, EventArgs e)
        {

        }

        private void btnMatching_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void flpQuestions_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
