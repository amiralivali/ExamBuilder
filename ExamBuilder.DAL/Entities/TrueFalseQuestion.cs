using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.Shared;

namespace ExamBuilder.DAL.Entities
{
    public class TrueFalseQuestion : BaseQuestion
    {
        public virtual ICollection<TrueFalseItem> Items { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }
    }
}
