using ExamBuilder.Shared;

namespace ExamBuilder.DAL.Entities
{
    public class ShortQuestion : BaseQuestion
    {
        public virtual Lesson Lesson { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }
    }
}
