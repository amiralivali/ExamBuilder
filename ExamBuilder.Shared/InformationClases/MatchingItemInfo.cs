using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ExamBuilder.Shared.Attributes;
using System.Threading.Tasks;

namespace ExamBuilder.Shared.InformationClases
{
    public class MatchingItemInfo : ItemQuestionInfo
    {
        //the reason that I didn`t use ItemQuestionInfo = It has special field
        [RequiredStringValidation(PropertyName = Messages.LeftItem)]
        public string LeftText { get; set; }
        [RequiredStringValidation(PropertyName = Messages.RightItem)]
        public string RightText { get; set; }
    }
}
