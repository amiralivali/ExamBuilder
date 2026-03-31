using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.Shared.Attributes;

namespace ExamBuilder.Shared.InformationClases
{
    public class BookInfo:BaseValidation
    {
        public int ID { get; set; }
        [RequiredStringValidation(PropertyName = Messages.BookName)]
        public string Title { get; set; }
        [GradeValidation]
        public int GradeID { get; set; }
        public string GradeInfo {  get; set; }
    }
}
