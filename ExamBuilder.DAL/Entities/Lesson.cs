using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.DAL.Entities
{
    public class Lesson
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(30)]
        public string Title { get; set; }
        public int LessonCount { get; set; }
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
        public virtual ICollection<DescriptiveQuestion> DescriptiveQuestions { get; set; }
        public virtual ICollection<MatchingQuestion> MatchingQuestions { get; set; }
        public virtual ICollection<OptionalQuestion> OptionalQuestions { get; set; }
        public virtual ICollection<ShortQuestion> ShortQuestions { get; set; }
        public virtual ICollection<TrueFalseQuestion> TrueFalseQuestions { get; set; }
        public virtual ICollection<FillInBlankQuestion> FillInBlankQuestions { get; set; }
    }
}
