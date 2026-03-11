using ExamBuilder.Shared.InformationClases;

namespace ExamBuilder.DAL.Entities
{
    public class DescriptiveQuestion : QuestionInfo
    {
        public virtual Lesson Lesson { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }
    }
}
