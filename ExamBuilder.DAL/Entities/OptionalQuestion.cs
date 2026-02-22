using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.DAL.Entities
{
    public class OptionalQuestion : Question
    {
        [Required]
        [MaxLength(30)]
        public string Option1 { get; set; }
        [Required]
        [MaxLength(30)]
        public string Option2 { get; set; }
        [Required]
        [MaxLength(30)]
        public string Option3 { get; set; }
        [Required]
        [MaxLength(30)]
        public string Option4 { get; set; }
    }
}
