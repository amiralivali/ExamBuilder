using ExamBuilder.Shared;

namespace ExamBuilder.DAL.Entities
{
    public class MatchingQuestion : BaseQuestion
    {
        public virtual ICollection<MatchingItem> Items { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }
    }
}
