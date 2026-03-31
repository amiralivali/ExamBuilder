using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.Shared.Attributes
{
    public class RequiredStringValidationAttribute : ValidationAttribute
    {
        public string PropertyName { get; set; }
        public override bool IsValid(object value)
        {
            string temp = value.ToString();
            if (string.IsNullOrEmpty(temp))
            {
                ErrorMessage = string.Format(Messages.Required, PropertyName);
                return false;
            }
            return true;
        }
    }
}
