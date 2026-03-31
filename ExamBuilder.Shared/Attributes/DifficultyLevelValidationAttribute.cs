using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.Shared.Attributes
{
    public class DifficultyLevelValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int levelID = int.Parse(value.ToString());
            if (levelID == 0)
            {
                ErrorMessage = Messages.DifficultyLevel + Messages.Required;
                return false;
            }
            return true;
        }
    }
}
