using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.Shared;

namespace ExamBuilder.BLL.Interface
{
    public interface IDeleteQuestion
    {
        Task<OprationResult> DeleteQuestionAsync(int questionId);
    }
}
