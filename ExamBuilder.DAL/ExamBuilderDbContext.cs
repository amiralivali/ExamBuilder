using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamBuilder.DAL
{
    public class ExamBuilderDbContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<DescriptiveQuestion> DescriptiveQuestions { get; set; }
        public virtual DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public virtual DbSet<Lessons> Lessonses { get; set; }
        public virtual DbSet<MatchingItem> MatchingItems { get; set; }
        public virtual DbSet<MatchingQuestion> MatchingQuestions { get; set; }
        public virtual DbSet<ShortQuestion> ShortQuestions { get; set; }
        public virtual DbSet<TrueFalseItem> TrueFalseItems { get; set; }
        public virtual DbSet<TrueFalseQuestion> TrueFalseQuestions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ExamBuilderDb;Integrated Security=True;Encrypt=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
