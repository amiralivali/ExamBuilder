using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.Shared.Attributes
{
    public class FillInBlankItemTextValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string text = value.ToString();
            int checkingBlank = text.IndexOf(Messages.Blank_Marker);
            if (checkingBlank != -1)
            {
                return true;
            }
            ErrorMessage = Messages.SelectBlankError;
            return false;
        }
    }
}
