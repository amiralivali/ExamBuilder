using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.Shared
{
    public class BaseValidation
    {
        public bool IsValid 
        {
            get
            {
                List<ValidationResult> validationResults = new List<ValidationResult>();
                var check = Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true);
                if (!check)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var res in validationResults)
                    {
                        sb.AppendLine(res.ErrorMessage);
                    }
                    ErrorMessage = sb.ToString();
                }
                return check;
            }
        }
        public string ErrorMessage { get; private set; }
    }
}
