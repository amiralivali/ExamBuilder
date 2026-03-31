using System.ComponentModel.DataAnnotations;
using ExamBuilder.Shared.Attributes;

namespace ExamBuilder.Shared.InformationClases
{
    public class QuestionInfo : BaseValidation
    {
        [Key]
        public int ID { get; set; }
        public int LessonID { get; set; }
        [RequiredStringValidation(PropertyName = Messages.QuestionText)]
        [MaxLength(200)]
        public string QuestionText { get; set; }
        public string Picture { get; set; }
        [DifficultyLevelValidation]
        public int DifficultyLevelID { get; set; }
    }
}
