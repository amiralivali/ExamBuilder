using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.Shared.DTOClases
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Grade { get; set; }
        public string BookName { get; set; }
        public string LessonName { get; set; }
        public string QuestionType { get; set; }
    }
}
