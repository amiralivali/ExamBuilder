using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.Shared.Attributes;

namespace ExamBuilder.Shared.InformationClases
{
    public class OptionalItemInfo : BaseValidation
    {
        public int OptionalID { get; set; }
        [RequiredStringValidation(PropertyName = Messages.Option1)]
        public string Option1 {  get; set; }
        [RequiredStringValidation(PropertyName = Messages.Option2)]
        public string Option2 {  get; set; }
        [RequiredStringValidation(PropertyName = Messages.Option3)]
        public string Option3 { get; set; }
        [RequiredStringValidation(PropertyName = Messages.Option4)]
        public string Option4 { get; set; }
    }
}
