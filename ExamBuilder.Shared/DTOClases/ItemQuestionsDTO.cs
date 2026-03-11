using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.Shared.DTOClases
{
    public class ItemQuestionsDTO : QuestionsDTO
    {
        //this class is for Questions With Item
        //TrueFalse FillInBlank
        public List<string> Items { get; set; }
    }
}
