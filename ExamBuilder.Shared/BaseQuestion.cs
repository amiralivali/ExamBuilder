using System.ComponentModel.DataAnnotations;

namespace ExamBuilder.Shared
{
    public class BaseQuestion
    {
        [Key]
        public int Id { get; set; }
        public int LessonID { get; set; }
        [Required]
        [MaxLength(200)]
        public string QuestionText { get; set; }
        public string Picture { get; set; }
        public int DifficultyLevelId { get; set; }
    }
}
