using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.DAL.Entities
{
    public class Question
    {
        [Key]
        public int ID { get; set; }
        public int BookID { get; set; }
        public int LessonID { get; set; }
        [Required]
        [MaxLength(100)]
        public string QuestionText { get; set; }
        public string Picture { get; set; }
        public int DifficultyLevelID {  get; set; }
        public virtual Lessons Lessons { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }
    }
}
