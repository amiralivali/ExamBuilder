using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.DAL.Entities
{
    public class MatchingItem
    {
        [Key]
        public int ID { get; set; }
        public int MatchingQuestionID { get; set; }
        [Required]
        [MaxLength(30)]
        public string LeftText { get; set; }
        [Required]
        [MaxLength(30)]
        public string RightText { get; set; }
        public virtual MatchingQuestion matchingQuestion { get; set; }
    }
}
