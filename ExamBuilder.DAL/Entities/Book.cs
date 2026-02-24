using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.DAL.Entities
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        public int Grade { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
