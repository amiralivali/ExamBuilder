using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.DAL.Entities
{
    public class DifficultyLevel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(10)]
        public string Title { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
