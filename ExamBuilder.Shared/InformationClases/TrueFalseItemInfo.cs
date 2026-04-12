using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.Shared.Attributes;

namespace ExamBuilder.Shared.InformationClases
{
    public class TrueFalseItemInfo : BaseValidation
    {
        public int Id { get; set; }
        [RequiredStringValidation(PropertyName = Messages.Item)]
        public string Text { get; set; }
        public int QuestionId { get; set; }
    }
}
