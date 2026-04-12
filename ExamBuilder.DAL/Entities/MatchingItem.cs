using System.ComponentModel.DataAnnotations;

namespace ExamBuilder.DAL.Entities
{
    public class MatchingItem
    {
        [Key]
        public int Id { get; set; }
        public int MatchingQuestionId { get; set; }
        [Required]
        [MaxLength(30)]
        public string LeftText { get; set; }
        [Required]
        [MaxLength(30)]
        public string RightText { get; set; }
        public virtual MatchingQuestion MatchingQuestion { get; set; }
    }
}
