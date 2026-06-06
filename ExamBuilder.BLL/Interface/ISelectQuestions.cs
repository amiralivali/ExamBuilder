using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.Shared.DTOClases;
using ExamBuilder.Shared;

namespace ExamBuilder.BLL.Interface
{
    public interface ISelectQuestions
    {
        Task<OprationResult<List<QuestionDTO>>> SelectFilterQuestionsAsync(string search, string grade, string book, string lesson);
        Task<OprationResult<QuestionDTO>> SelectQuestionAsync(int id);
        Task<OprationResult<List<QuestionDTO>>> SelectQuestionsFromLessonAsync(List<int> lessonIds);
    }
}
