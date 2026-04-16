using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.Shared
{
    public class QuestionTypes
    {
        public enum QuestionType
        {
           DescriptiveQuestion,FillInBlankQuestion,MatchingQuestion,OptionalQuestion,ShortQuestion,TrueFalseQuestion
        }
        public enum PersianQuestionType
        {
            تشریحی, جاخالی, وصل‌کردنی, تستی, کوتاه‌پاسخ, صحیح‌غلط
        }
    }
}
