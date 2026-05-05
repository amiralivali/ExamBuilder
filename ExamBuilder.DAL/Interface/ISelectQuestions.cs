using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.Shared.DTOClases;

namespace ExamBuilder.DAL.Interface
{
    internal interface ISelectQuestions
    {
        Task<List<QuestionDTO>> SelectFilterQuestionsAsync(string search, string grade, string book, string lesson);
        Task<QuestionDTO> SelectQuestionAsync(int id);
    }
}
