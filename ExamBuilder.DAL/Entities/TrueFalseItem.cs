using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.DAL.Entities
{
    public class TrueFalseItem
    {
        [Key]
        public int ID { get; set; }
        public int TrueFalseQuestionID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Text { get; set; }
        public virtual TrueFalseQuestion TrueFalseQuestion { get; set; }
    }
}
