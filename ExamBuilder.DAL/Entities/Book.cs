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
        [MaxLength(30)]
        public string Title { get; set; }
        [Required]
        [MaxLength(20)]
        public int GradeID { get; set; }
        [MaxLength(40)]
        public string GradeInfo {  get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual Grade Grade  { get; set; }
    }
}
