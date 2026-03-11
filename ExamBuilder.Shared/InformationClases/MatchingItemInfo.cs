using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.Shared.InformationClases
{
    public class MatchingItemInfo : ItemQuestionInfo
    {
        //the reason that I didn`t use ItemQuestionInfo = It has special field
        public string LeftText { get; set; }
        public string RightText { get; set; }
    }
}
