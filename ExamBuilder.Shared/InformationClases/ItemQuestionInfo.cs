using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.Shared.Attributes;


namespace ExamBuilder.Shared.InformationClases
{
    public class ItemQuestionInfo:BaseValidation 
    {
        public int ID { get; set; }
        [RequiredStringValidation(PropertyName = Messages.Item)]
        public string Text { get; set; }
        public int QuestionID { get; set; }
    }
}
