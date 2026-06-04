using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamBuilder.BLL;
using ExamBuilder.BLL.Interface;
using ExamBuilder.DAL;
using ExamBuilder.DAL.Entities;
using ExamBuilder.Shared;
using ExamBuilder.Shared.DTOClases;
using ExamBuilder.Shared.InformationClases;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static ExamBuilder.Shared.QuestionTypes;

namespace ExamBuilder.UI
{
    public partial class frmManagementQuestion : frmStyle
    {
        BookService bookService;
        ISelectQuestions selectDTO;
        public frmManagementQuestion()
        {
            InitializeComponent();
            bookService = new BookService();
        }

        private List<QuestionDTO> CurrentData;
        int _pageSize = 5;
        private int _currentPage;
        private int _countPage;

        private async void FillDGV(string search = "")
        {
            CurrentData = null;
            string grade = "";
            if (cbGrade.SelectedIndex > 0)
            {
                grade = cbGrade.SelectedItem.ToString();
            }
            string book = "";
            if (cbBook.SelectedIndex > 0)
            {
                book = cbBook.SelectedItem.ToString();
            }
            string lesson = "";
            if (cbLesson.SelectedIndex > 0)
            {
                lesson = cbLesson.SelectedItem.ToString();
            }
            OprationResult<List<QuestionDTO>> opration;
            if (cbQuestionType.SelectedIndex != 0)
            {
                opration = await SelectSelectedQuestionDTO(search, grade, book, lesson);
            }
            else
            {
                opration = await SelectAllQuestionDTOs(search, grade, book, lesson);
            }
            if (opration.IsSuccess)
            {
                CurrentData = opration.Data;
                if (CurrentData.Count <= 5)
                {
                    btnNext.Enabled = false;
                }
                _currentPage = 1;
                ChangeGridViewPage();
            }
            else
            {
                ShowError(opration.Message);
            }
        }
        private async Task<OprationResult<List<QuestionDTO>>> SelectAllQuestionDTOs(string search, string grade, string book, string lesson)
        {
            var services = new List<ISelectQuestions>
            {
                new DescriptiveService(),
                new ShortAnswerService(),
                new OptionalService(),
                new FillInBlankService(),
                new TrueFalseService(),
                new MatchingService()
            };
            var questionDTOs = new List<QuestionDTO>();
            foreach (var service in services)
            {
                var result = await service.SelectFilterQuestionsAsync(search, grade, book, lesson);
                if (!result.IsSuccess)
                {
                    return result;
                }
                questionDTOs.AddRange(result.Data);
            }
            return OprationResult<List<QuestionDTO>>.Success(questionDTOs);
        }
        private async Task<OprationResult<List<QuestionDTO>>> SelectSelectedQuestionDTO(string search, string grade, string book, string lesson)
        {
            var result = await selectDTO.SelectFilterQuestionsAsync(search, grade, book, lesson);
            return result;
        }
        private void ChangeGridViewPage()
        {
            int countItems = CurrentData.Count;
            if (countItems % _pageSize == 0)
            {
                _countPage = countItems / _pageSize;
            }
            else
            {
                _countPage = (countItems / _pageSize) + 1;
            }
            int skip = (_currentPage - 1) * 5;
            lblPage.Text = string.Format(Messages.PageOf, _currentPage, _countPage);
            if (_countPage > 1)
            {
                btnNext.Enabled = true;
            }
            var data = CurrentData.Skip(skip).Take(_pageSize).ToList();
            dgvData.DataSource = data;
        }
        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int questionId = int.Parse(dgvData.Rows[e.RowIndex].Cells[dgvData.Columns["Id"].Index].Value.ToString());
            string questionType = dgvData.Rows[e.RowIndex].Cells[dgvData.Columns["QuestionType"].Index].Value.ToString();
            if (e.ColumnIndex == dgvData.Columns["showItems"].Index)
            {
                flpDisplayItem.Controls.Clear();
                switch (questionType)
                {
                    case Messages.Descriptive:
                    case Messages.ShortAnswer:
                        ShowError(Messages.QuestionWithoutItemError);
                        return;

                    case Messages.TrueFalse:
                        {
                            var service = new TrueFalseService();
                            var result = await service.SelectItemsAsync(questionId);
                            if (!result.IsSuccess)
                            {
                                ShowError(result.Message);
                                return;
                            }
                            var uc = new UC_DGVTrueFalseItem(questionId);
                            flpDisplayItem.Controls.Add(uc);
                            break;
                        }

                    case Messages.Optional:
                        {
                            var service = new OptionalService();
                            var result = await service.SelectItemsAsync(questionId);
                            if (!result.IsSuccess)
                            {
                                ShowError(result.Message);
                                return;
                            }
                            var uc = new UC_OptionalQuestion();
                            uc.Margin = new Padding(100, 25, 0, 0);
                            uc.LoadItem(result.Data, true);
                            flpDisplayItem.Controls.Add(uc);
                            break;
                        }

                    case Messages.FillInBlank:
                        {
                            var service = new FillInBlankService();
                            var result = await service.SelectItemsAsync(questionId);
                            if (!result.IsSuccess)
                            {
                                ShowError(result.Message);
                                return;
                            }
                            var uc = new UC_DGVFillInBlankItem(questionId);
                            flpDisplayItem.Controls.Add(uc);
                            break;
                        }

                    case Messages.Matching:
                        {
                            var service = new MatchingService();
                            var result = await service.SelectItemsAsync(questionId);
                            if (!result.IsSuccess)
                            {
                                ShowError(result.Message);
                                return;
                            }
                            var uc = new UC_DGVMatchingItem(questionId);
                            flpDisplayItem.Controls.Add(uc);
                            break;
                        }
                }
                panelDisplayItems.BringToFront();
                panelDisplayItems.Visible = true;
            }
            else if (e.ColumnIndex == dgvData.Columns["btnEdit"].Index)
            {
                var frmUpdate = new frmUpdateQuestion();
                frmUpdate.questionId = questionId;
                var type = QuestionTypes.QuestionType.FillInBlankQuestion;
                switch (questionType)
                {
                    case Messages.Descriptive:
                        type = QuestionTypes.QuestionType.DescriptiveQuestion;
                        break;
                    case Messages.ShortAnswer:
                        type = QuestionTypes.QuestionType.ShortAnswerQuestion;
                        break;
                    case Messages.TrueFalse:
                        type = QuestionTypes.QuestionType.TrueFalseQuestion;
                        break;
                    case Messages.Optional:
                        type = QuestionTypes.QuestionType.OptionalQuestion;
                        break;
                    case Messages.FillInBlank:
                        type = QuestionTypes.QuestionType.FillInBlankQuestion;
                        break;
                    case Messages.Matching:
                        type = QuestionTypes.QuestionType.MatchingQuestion;
                        break;
                }
                frmUpdate.questionType = type;
                frmUpdate.ShowDialog();
            }
            else if(e.ColumnIndex == dgvData.Columns["btnDelete"].Index)
            {
                var res = ShowWarningQuestion(Messages.DeleteQuestionWarning);
                if (res == DialogResult.Yes)
                {
                    IDeleteQuestion deleteQuestion = new DescriptiveService();
                    switch (questionType)
                    {
                        case Messages.Descriptive:
                            deleteQuestion = new DescriptiveService();
                            break;
                        case Messages.ShortAnswer:
                            deleteQuestion = new ShortAnswerService();
                            break;
                        case Messages.TrueFalse:
                            deleteQuestion = new TrueFalseService();
                            break;
                        case Messages.Optional:
                            deleteQuestion = new OptionalService();
                            break;
                        case Messages.FillInBlank:
                            deleteQuestion = new FillInBlankService();
                            break;
                        case Messages.Matching:
                            deleteQuestion = new MatchingService();
                            break;
                    }
                    var deleteOpration = await deleteQuestion.DeleteQuestionAsync(questionId);
                    if (deleteOpration.IsSuccess)
                    {
                        ShowSuccess(deleteOpration.Message);
                        FillDGV();
                    }
                    else
                    {
                        ShowError(deleteOpration.Message);
                    }
                }
            }
        }
        private async void frmManagementQuestion_Load(object sender, EventArgs e)
        {
            var check = await bookService.SelectAvailableGrades();
            if (check.IsSuccess)
            {
                cbGrade.Items.AddRange(check.Data.ToArray());
                cbQuestionType.Items.AddRange(Messages.AllQuestionTypes.ToArray());
                FillDGV();

            }
            else
            {
                ShowError(check.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _currentPage++;
            ChangeGridViewPage();
            btnPrevious.Enabled = true;
            if (_currentPage + 1 > _countPage)
            {
                btnNext.Enabled = false;
            }
        }

        private void btnPrivious_Click(object sender, EventArgs e)
        {
            _currentPage--;
            ChangeGridViewPage();
            btnNext.Enabled = true;
            if (_currentPage - 1 < 1)
            {
                btnPrevious.Enabled = false;
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
                var list = await bookService.SelectAsync(cbGrade.SelectedItem.ToString());
                cbBook.Items.Clear();
                cbBook.Items.Add("کتاب را انتخاب کنید");
                cbBook.Items.AddRange(list.Data.ToArray());
                cbBook.SelectedIndex = 0;
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
                LessonService lessonService = new LessonService();
                cbBook.ForeColor = Color.Black;
                cbLesson.Enabled = true;
                var list = await lessonService.SelectAsync(cbBook.SelectedItem.ToString());
                cbLesson.Items.Clear();
                cbLesson.Items.Add("درس را انتخاب کنید");
                cbLesson.Items.AddRange(list.Data.ToArray());
                cbLesson.SelectedIndex = 0;
            }
        }

        private void cbLesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLesson.SelectedIndex == 0)
            {
                cbLesson.ForeColor = Color.Gray;
            }
            else
            {
                cbLesson.ForeColor = Color.Black;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillDGV(txtSearch.Text);
            btnDeleteFilter.Enabled = true;
        }

        private void cbQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbQuestionType.SelectedIndex == 0)
            {
                cbQuestionType.ForeColor = Color.Gray;
            }
            else
            {
                cbQuestionType.ForeColor = Color.Black;
                switch (cbQuestionType.SelectedItem.ToString())
                {
                    case Messages.Descriptive:
                        selectDTO = new DescriptiveService();
                        break;
                    case Messages.ShortAnswer:
                        selectDTO = new ShortAnswerService();
                        break;
                    case Messages.Optional:
                        selectDTO = new OptionalService();
                        break;
                    case Messages.TrueFalse:
                        selectDTO = new TrueFalseService();
                        break;
                    case Messages.Matching:
                        selectDTO = new MatchingService();
                        break;
                    case Messages.FillInBlank:
                        selectDTO = new FillInBlankService();
                        break;
                }
            }
        }

        private void btnDeleteFilter_Click(object sender, EventArgs e)
        {
            btnDeleteFilter.Enabled = false;
            cbLesson.SelectedIndex = 0;
            cbBook.SelectedIndex = 0;
            cbGrade.SelectedIndex = 0;
            cbQuestionType.SelectedIndex = 0;
            txtSearch.Text = string.Empty;
            FillDGV();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panelDisplayItems.Visible = false;
        }

        private void flpDisplayItem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDisplayItems_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
