using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.Shared.DTOClases
{
    public class QuestionsDTO
    {
        //this class is for Questions Without Item
        //Descriptive ShortAnswer 
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public string BookName { get; set; }
        public string LessonName { get; set; }
        public string DifficultyLevel { get; set; }
        public string Picture { get; set; }
    }
}
