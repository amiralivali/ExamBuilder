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
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<OptionalQuestion> OptionalQuestions { get; set; }
        public virtual DbSet<OptionalItem> OptionalItems { get; set; }
        public virtual DbSet<DescriptiveQuestion> DescriptiveQuestions { get; set; }
        public virtual DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<MatchingItem> MatchingItems { get; set; }
        public virtual DbSet<MatchingQuestion> MatchingQuestions { get; set; }
        public virtual DbSet<ShortQuestion> ShortQuestions { get; set; }
        public virtual DbSet<TrueFalseItem> TrueFalseItems { get; set; }
        public virtual DbSet<TrueFalseQuestion> TrueFalseQuestions { get; set; }
        public virtual DbSet<FillInBlankItem> FillInBlankItems { get; set; }
        public virtual DbSet<FillInBlankQuestion> FillInBlankQuestions { get; set; }
        public virtual DbSet<ExceptionLog> ExceptionLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ExamBuilderDb;Integrated Security=True;Encrypt=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Grade>()
                .HasData(new Grade()
                {
                    Id = 1,
                    Title = "ابتدایی-اول"
                },
                new Grade()
                {
                    Id = 2,
                    Title = "ابتدایی-دوم"
                },
                new Grade()
                {
                    Id = 3,
                    Title = "ابتدایی-سوم"
                },
                new Grade()
                {
                    Id = 4,
                    Title = "ابتدایی-چهارم"
                }, new Grade()
                {
                    Id = 5,
                    Title = "ابتدایی-پنجم"
                }, new Grade()
                {
                    Id = 6,
                    Title = "ابتدایی-ششم"
                }, new Grade()
                {
                    Id = 7,
                    Title = "متوسطه اول-هفتم"
                },
                new Grade()
                {
                    Id = 8,
                    Title = "متوسطه اول-هشتم"
                },
                new Grade()
                {
                    Id = 9,
                    Title = "متوسطه اول-نهم"
                },
                new Grade()
                {
                    Id = 10,
                    Title = "متوسطه دوم-دهم"
                },
                new Grade()
                {
                    Id = 11,
                    Title = "متوسطه دوم-یازدهم"
                },
                new Grade()
                {
                    Id = 12,
                    Title = "متوسطه دوم-دوازدهم"
                },
                new Grade()
                { 
                Id=13,
                Title="دانشگاه"
                },
                new Grade()
                { 
                Id=14,
                Title="سایر"
                }
                );
            modelBuilder.Entity<DifficultyLevel>()
                .HasData(
                new DifficultyLevel()
                {
                    Id = 1,
                    Title = "آسان"
                },
                new DifficultyLevel()
                {
                    Id = 2,
                    Title = "متوسط"
                },
                new DifficultyLevel()
                {
                    Id = 3,
                    Title = "سخت"
                }
            );
            modelBuilder.Entity<Lesson>()
                .HasOne(x => x.Book)
                .WithMany(x => x.Lessons)
                .HasForeignKey(x => x.BookId)
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
                .HasForeignKey(q => q.LessonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OptionalQuestion>()
                .HasOne(q => q.Lesson)
                .WithMany(l => l.OptionalQuestions)
                .HasForeignKey(q => q.LessonID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FillInBlankQuestion>()
                .HasOne(x => x.Lesson)
                .WithMany(x => x.FillInBlankQuestions)
                .HasForeignKey(x => x.LessonID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TrueFalseItem>()
                .HasOne(x => x.TrueFalseQuestion)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.TrueFalseQuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MatchingItem>()
                .HasOne(x => x.MatchingQuestion)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.MatchingQuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FillInBlankItem>()
                .HasOne(x => x.FillInBlankQuestion)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.FillInBlankQuestionId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<OptionalItem>()
                .HasOne(x=>x.OptionalQuestion)
                .WithOne(x=>x.OptionalItem)
                .HasForeignKey<OptionalItem>(x=>x.OptionalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
