using ExamBuilder.Shared;

namespace ExamBuilder.DAL.Entities
{
    public class FillInBlankQuestion : BaseQuestion
    {
        public virtual Lesson Lesson { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }
        public virtual ICollection<FillInBlankItem> FillInBlankItems{ get; set; }
    }
}
