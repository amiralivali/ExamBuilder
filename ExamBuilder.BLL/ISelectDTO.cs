using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.Shared;
using ExamBuilder.Shared.DTOClases;

namespace ExamBuilder.BLL
{
    public interface ISelectDTO
    {
        public Task<OprationResult<List<QuestionDTO>>> SelectAsync(string search, string grade, string bookName, string lessonName);
    }
}
