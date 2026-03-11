using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.Shared.InformationClases
{
    public class LessonInfo
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int LessonCount { get; set; }
        public int BookID { get; set; }
    }
}
