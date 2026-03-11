using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.DAL.Entities
{
    public class ExceptionLog
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Message { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "nvarchar(max)")] // مسیر خطا
        public string StackTrace { get; set; }

        [StringLength(200)]
        public string ExceptionType { get; set; } // SqlExeption نوع خطا مثل

        [StringLength(200)]
        public string Source { get; set; } // منبع خطا مثلاً کلاس یا لایه
    }
}
