using System.ComponentModel.DataAnnotations;
using ExamBuilder.Shared.InformationClases;

namespace ExamBuilder.DAL.Entities
{
    public class OptionalQuestion : QuestionInfo
    {
        [Required]
        [MaxLength(50)]
        public string Option1 { get; set; }
        [Required]
        [MaxLength(350)]
        public string Option2 { get; set; }
        [Required]
        [MaxLength(50)]
        public string Option3 { get; set; }
        [Required]
        [MaxLength(50)]
        public string Option4 { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }
    }
}
