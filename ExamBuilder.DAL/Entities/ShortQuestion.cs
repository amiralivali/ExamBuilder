using ExamBuilder.Shared.InformationClases;

namespace ExamBuilder.DAL.Entities
{
    public class ShortQuestion : QuestionInfo
    {
        public virtual Lesson Lesson { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }
    }
}
