using ExamBuilder.Shared.InformationClases;

namespace ExamBuilder.DAL.Entities
{
    public class TrueFalseQuestion : QuestionInfo
    {
        public virtual ICollection<TrueFalseItem> Items { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }
    }
}
