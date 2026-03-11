using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Entities;

namespace ExamBuilder.DAL.Repositorys
{
    public static class ErrorExceptionRepository
    {
        public static async Task AddLogAsync(this Exception ex)
        {
            var dateTime = DateTime.Now;
            try
            {
                using (var db = new ExamBuilderDbContext())
                {
                    var exception = new ExceptionLog()
                    {
                        Message = ex.Message,
                        CreatedAt = dateTime,
                        StackTrace = ex.StackTrace,
                        ExceptionType = ex.GetType().Name,
                        Source = ex.Source,
                    };

                    await db.ExceptionLogs.AddAsync(exception);
                    await db.SaveChangesAsync();
                }
            }
            catch
            {
                var logText =
                    $"[{dateTime}] | {ex.GetType().Name} | {ex.Message}\n{ex.StackTrace}\n";

                if (File.Exists("ErrorException.txt"))
                {
                    File.AppendAllText("ErrorException.txt", logText + Environment.NewLine);
                }
                else
                {
                    File.WriteAllText("ErrorException.txt", logText + Environment.NewLine);
                }
            }
        }
    }
}
