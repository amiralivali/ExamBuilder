using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.BLL
{
    public static class ExeptionLog
    {
        public static void AddLog(this Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
