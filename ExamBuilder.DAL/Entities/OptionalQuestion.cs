using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.Shared;

namespace ExamBuilder.DAL.Entities
{
    public class OptionalQuestion : BaseQuestion
    {
        [Required]
        [MaxLength(30)]
        public string Option1 { get; set; }
        [Required]
        [MaxLength(30)]
        public string Option2 { get; set; }
        [Required]
        [MaxLength(30)]
        public string Option3 { get; set; }
        [Required]
        [MaxLength(30)]
        public string Option4 { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }
    }
}
