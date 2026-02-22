using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.DAL.Entities
{
    public class Lessons
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        public int LessonCount { get; set; }
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
        public virtual ICollection<Question> Questions { get; set; }=new List<Question>();
    }
}
