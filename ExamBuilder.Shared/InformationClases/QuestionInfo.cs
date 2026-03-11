using System.ComponentModel.DataAnnotations;

namespace ExamBuilder.Shared.InformationClases
{
    public class QuestionInfo
    {
        [Key]
        public int ID { get; set; }
        public int LessonID { get; set; }
        [Required]
        [MaxLength(200)]
        public string QuestionText { get; set; }
        public string Picture { get; set; }
        public int DifficultyLevelID { get; set; }
    }
}
