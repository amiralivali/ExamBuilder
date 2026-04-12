using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.DAL.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
