using System.ComponentModel.DataAnnotations;

namespace ExamBuilder.DAL.Entities
{
    public class TrueFalseItem
    {
        [Key]
        public int Id { get; set; }
        public int TrueFalseQuestionId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Text { get; set; }
        public virtual TrueFalseQuestion TrueFalseQuestion { get; set; }
    }
}
