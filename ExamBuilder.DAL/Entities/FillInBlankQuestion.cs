using ExamBuilder.Shared.InformationClases;

namespace ExamBuilder.DAL.Entities
{
    public class FillInBlankQuestion : QuestionInfo
    {
        public virtual Lesson Lesson { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }
        public virtual ICollection<FillInBlankItem> Items{ get; set; }
    }
}
