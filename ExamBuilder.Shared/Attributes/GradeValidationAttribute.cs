using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.Shared.Attributes
{
    public class GradeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int gradeID = int.Parse(value.ToString());
            if (gradeID == -1)
            {
                ErrorMessage = Messages.Grade + Messages.Required;
                return false;
            }
            return true;
        }
    }
}
