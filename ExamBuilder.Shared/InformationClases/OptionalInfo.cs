using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.Shared.InformationClases
{
    public class OptionalInfo : QuestionInfo
    {
        //the reason that I didn`t use QuestionInfo = It has special field
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
    }
}
