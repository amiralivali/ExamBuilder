using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.DAL.Entities
{
    public class TrueFalseQuestion : Question
    {
        public virtual ICollection<TrueFalseItem> Items { get; set; } = new List<TrueFalseItem>();
    }
}
