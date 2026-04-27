using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ExamBuilder.Shared.Attributes;
using System.Threading.Tasks;

namespace ExamBuilder.Shared.InformationClases
{
    public class MatchingItemInfo : BaseValidation
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        //the reason that I didn`t use ItemQuestionInfo = It has special field
        [RequiredStringValidation(PropertyName = Messages.LeftItem)]
        public string LeftText { get; set; }
        [RequiredStringValidation(PropertyName = Messages.RightItem)]
        public string RightText { get; set; }
    }
}
