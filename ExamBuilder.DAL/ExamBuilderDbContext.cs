using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public virtual DbSet<Lesson> Lessons { get; set; }
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
            modelBuilder.Entity<DifficultyLevel>()
                .HasData(
                new DifficultyLevel()
                {
                    ID = 1,
                    Title = "آسان"
                },
                new DifficultyLevel()
                {
                    ID = 2,
                    Title = "متوسط"
                },
                new DifficultyLevel()
                {
                    ID = 3,
                    Title = "سخت"
                }
            );
            modelBuilder.Entity<Lesson>()
                .HasOne(x => x.Book)
                .WithMany(x => x.Lessons)
                .HasForeignKey(x => x.BookID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DescriptiveQuestion>()
                .HasOne(q => q.Lesson)
                .WithMany(l => l.DescriptiveQuestions)
                .HasForeignKey(q => q.LessonID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MatchingQuestion>()
                .HasOne(q => q.Lesson)
                .WithMany(l => l.MatchingQuestions)
                .HasForeignKey(q => q.LessonID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShortQuestion>()
                .HasOne(q => q.Lesson)
                .WithMany(l => l.ShortQuestions)
                .HasForeignKey(q => q.LessonID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TrueFalseQuestion>()
                .HasOne(q => q.Lesson)
                .WithMany(l => l.TrueFalseQuestions)
                .HasForeignKey(q => q.LessonID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OptionalQuestion>()
                .HasOne(q => q.Lesson)
                .WithMany(l => l.OptionalQuestions)
                .HasForeignKey(q => q.LessonID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
