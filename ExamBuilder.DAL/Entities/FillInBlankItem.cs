using System.ComponentModel.DataAnnotations;

namespace ExamBuilder.DAL.Entities
{
    public class FillInBlankItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Text { get; set; }
        public int FillInBlankQuestionId { get; set; }
        public virtual FillInBlankQuestion FillInBlankQuestion { get; set; }
    }
}
