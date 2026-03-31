using System.ComponentModel.DataAnnotations;
using ExamBuilder.Shared.InformationClases;

namespace ExamBuilder.DAL.Entities
{
    public class OptionalQuestion : QuestionInfo
    {
        public virtual Lesson Lesson { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }
        public virtual OptionalItem OptionalItem { get; set; }
    }
}
