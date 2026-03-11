using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.Shared.DTOClases
{
    public class MatchingDTO :  QuestionsDTO
    {
        //the reason that I didn`t use ItemQuestionDTO = It has special field
        public List<string> LeftTexts { get; set; }
        public List<string> RightTexts { get; set; }
    }
}
