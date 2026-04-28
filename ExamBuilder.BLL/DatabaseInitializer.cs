using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL;
using ExamBuilder.Shared;
using Microsoft.EntityFrameworkCore;

namespace ExamBuilder.BLL
{
    public class DatabaseInitializer
    {
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<ExamBuilderDbContext>()
                .UseSqlServer(DatabaseInformation.ConnectionString)
                .Options;
            var db = new ExamBuilderDbContext();
            db.Database.Migrate();
        }
    }
}
