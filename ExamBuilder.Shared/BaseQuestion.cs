using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.Shared
{
    public class BaseQuestion
    {
        [Key]
        public int ID { get; set; }
        public int LessonID { get; set; }
        [Required]
        [MaxLength(100)]
        public string QuestionText { get; set; }
        public string Picture { get; set; }
        public int DifficultyLevelID { get; set; }
    }
}
