using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.Shared;

namespace ExamBuilder.DAL.Entities
{
    public class OptionalItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OptionalId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Option1 { get; set; }
        [Required]
        [MaxLength(350)]
        public string Option2 { get; set; }
        [Required]
        [MaxLength(50)]
        public string Option3 { get; set; }
        [Required]
        [MaxLength(50)]
        public string Option4 { get; set; }
        public virtual OptionalQuestion OptionalQuestion { get; set; }
    }
}
