using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamBuilder.BLL.Interface;
using ExamBuilder.BLL;
using ExamBuilder.DAL.Entities;
using ExamBuilder.Shared.DTOClases;
using ExamBuilder.Shared;

namespace ExamBuilder.UI
{
    public partial class UC_ManualQuestionSelection : UserControl
    {
        [DefaultValue("")]
        public List<int> LessonsIds {  get; set; }
        private List<QuestionDTO> _questionDtos { get; set; }
        public UC_ManualQuestionSelection()
        {
            InitializeComponent();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public List<QuestionDTO> GetSelectedQuestions()
        {
            List<QuestionDTO> questions = new List<QuestionDTO>();
            if (dgvData.Rows.Count > 0)
            {
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    bool check = (bool)dgvData.Rows[i].Cells[dgvData.Columns["Select"].Index].Value;
                    if (check)
                    {
                        int id = int.Parse(dgvData.Rows[i].Cells[dgvData.Columns["Id"].Index].Value.ToString());
                        questions.Add(_questionDtos.Where(x => x.Id == id).Single());
                    }    
                }
            }
            return questions;
        }
        private async void UC_ManualQuestionSelection_Load(object sender, EventArgs e)
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
                var result = await service.SelectQuestionsFromLessonAsync(LessonsIds);
                if (!result.IsSuccess)
                {
                    frmStyle frmStyle = new frmStyle();
                    frmStyle.ShowError(result.Message);
                }
                questionDTOs.AddRange(result.Data);
            }
            dgvData.DataSource = questionDTOs;
            _questionDtos = questionDTOs;
        }
    }
}
