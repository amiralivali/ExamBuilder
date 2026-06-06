using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Entities;
using ExamBuilder.DAL.Interface;
using ExamBuilder.Shared;
using ExamBuilder.Shared.DTOClases;
using Microsoft.EntityFrameworkCore;
using static ExamBuilder.Shared.QuestionTypes;

namespace ExamBuilder.DAL.Repositorys
{
    public class DescriptiveRepository : ISelectQuestions
    {
        ExamBuilderDbContext db;
        public DescriptiveRepository()
        {
            db = new ExamBuilderDbContext();
        }

        public async Task<List<QuestionDTO>> SelectFilterQuestionsAsync(string search, string grade, string book, string lesson)
        {
            try
            {
                var descriptives = await db.DescriptiveQuestions.Include(x=>x.DifficultyLevel)
                    .Include(x => x.Lesson)
                    .ThenInclude(x => x.Book)
                    .ThenInclude(x => x.Grade)
                    .Select(x => new QuestionDTO
                    {
                        Id = x.Id,
                        LessonName = Messages.Lesson + " " + x.Lesson.LessonCount + " " + x.Lesson.Title,
                        BookName = x.Lesson.Book.Title,
                        QuestionText = x.QuestionText,
                        QuestionType = Messages.Descriptive,
                        Grade = x.Lesson.Book.Grade.Title,
                        DifficultyLevel = x.DifficultyLevel.Title,
                        Picture = x.Picture,    
                    }).ToListAsync();
                var filter = descriptives.Where(x => (grade == "" || x.Grade.Contains(grade)) &&
                (book == "" || x.BookName.Contains(book)) &&
                (lesson == "" || x.Grade.Contains(lesson)));
                return filter.Where(x => search == "" ||
                x.QuestionText.Contains(search)).ToList();
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return null;
            }
        }
        public async Task<List<QuestionDTO>> SelectQuestionsFromLessonAsync(List<int> lessonIds)
        {
            try
            {
                List<QuestionDTO> list = new List<QuestionDTO>();
                foreach (int id in lessonIds)
                {
                    var descriptives = await db.DescriptiveQuestions.Include(x => x.DifficultyLevel).Where(x => x.LessonID == id)
                        .Select(x => new QuestionDTO
                        {
                            Id = x.Id,
                            QuestionText = x.QuestionText,
                            QuestionType = Messages.Descriptive,
                            DifficultyLevel = x.DifficultyLevel.Title,
                        }).ToListAsync();
                    foreach (var descriptive in descriptives)
                    {
                        list.Add(descriptive);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return null;
            }
        }
        public async Task<QuestionDTO> SelectQuestionAsync(int id)
        {
            try
            {
                var descriptive = await db.DescriptiveQuestions.Include(x => x.DifficultyLevel)
                    .Include(x => x.Lesson)
                    .ThenInclude(x => x.Book)
                    .ThenInclude(x => x.Grade)
                    .Where(x=>x.Id == id)
                    .Select(x => new QuestionDTO
                    {
                        Id = x.Id,
                        LessonName = Messages.Lesson + " " + x.Lesson.LessonCount + " " + x.Lesson.Title,
                        BookName = x.Lesson.Book.Title,
                        QuestionText = x.QuestionText,
                        QuestionType = Messages.Descriptive,
                        Grade = x.Lesson.Book.Grade.Title,
                        DifficultyLevel = x.DifficultyLevel.Title,
                        Picture = x.Picture,
                    }).SingleOrDefaultAsync();
                return descriptive;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return null;
            }
        }
        public async Task<bool> InsertAsync(DescriptiveQuestion descriptive)
        {
            try
            {
                await db.DescriptiveQuestions.AddAsync(descriptive);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();    
                return false;
            }
        }
        public async Task<bool> UpdateAsync(DescriptiveQuestion updateDescriptive)
        {
            try
            {
                var descriptive = await db.DescriptiveQuestions.Where(x => x.Id == updateDescriptive.Id).SingleAsync();
                descriptive.QuestionText = updateDescriptive.QuestionText;
                descriptive.DifficultyLevelId = updateDescriptive.DifficultyLevelId;
                descriptive.Picture = updateDescriptive.Picture;
                descriptive.LessonID = updateDescriptive.LessonID;
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var descriptive = await db.DescriptiveQuestions.Where(x => x.Id == id).SingleAsync();
                db.DescriptiveQuestions.Remove(descriptive);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return false;
            }
        }
        public async Task<bool> CheckDuplicateAsync(string questionText, int lessonId, int questionId = 0)
        {
            bool duplicate;
            if (questionId == 0) //Insert
            {
                duplicate = await db.DescriptiveQuestions.Where(x => x.QuestionText == questionText && x.LessonID == lessonId).AnyAsync();
            }
            else //Update
            {
                duplicate = await db.DescriptiveQuestions.Where(x => x.QuestionText == questionText && 
                    x.LessonID == lessonId && 
                    x.Id != questionId).AnyAsync();
            }
            return duplicate;
        }
    }
}
