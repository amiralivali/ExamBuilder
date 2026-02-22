using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.DAL.Entities
{
    public class MatchingQuestion : Question
    {
        public virtual ICollection<MatchingItem> Items { get; set; } = new List<MatchingItem>();
    }
}
