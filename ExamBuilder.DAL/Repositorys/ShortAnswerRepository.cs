using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Entities;
using ExamBuilder.Shared;
using ExamBuilder.Shared.DTOClases;
using Microsoft.EntityFrameworkCore;

namespace ExamBuilder.DAL.Repositorys
{
    public class ShortAnswerRepository
    {
        ExamBuilderDbContext db;
        public ShortAnswerRepository()
        {
            db = new ExamBuilderDbContext();
        }
        public async Task<List<QuestionDTO>> SelectAsync(string search, string grade, string book, string lesson)
        {
            try
            {
                var shortQuestions = await db.ShortQuestions
                    .Include(x => x.Lesson)
                    .ThenInclude(x => x.Book)
                    .ThenInclude(x => x.Grade)
                    .Select(x => new QuestionDTO
                    {
                        Id = x.Id,
                        LessonName = x.Lesson.Title,
                        BookName = x.Lesson.Book.Title,
                        QuestionText = x.QuestionText,
                        QuestionType = Messages.ShortAnswer,
                        Grade = x.Lesson.Book.Grade.Title,

                    }).ToListAsync();
                var filter = shortQuestions.Where(x => (grade == "" || x.Grade.Contains(grade)) &&
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
        public async Task<bool> InsertAsync(ShortQuestion shortQuestion)
        {
            try
            {
                await db.ShortQuestions.AddAsync(shortQuestion);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return false;
            }
        }
        public async Task<bool> UpdateAsync(ShortQuestion updateShortQuestion)
        {
            try
            {
                var shortQuestion = await db.ShortQuestions.Where(x => x.Id == updateShortQuestion.Id).SingleAsync();
                shortQuestion.QuestionText = updateShortQuestion.QuestionText;
                shortQuestion.DifficultyLevelId = updateShortQuestion.DifficultyLevelId;
                shortQuestion.Picture = updateShortQuestion.Picture;
                shortQuestion.LessonID = updateShortQuestion.LessonID;
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
                var shortQuestion = await db.ShortQuestions.Where(x => x.Id == id).SingleAsync();
                db.ShortQuestions.Remove(shortQuestion);
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
                duplicate = await db.ShortQuestions.Where(x => x.QuestionText == questionText && x.LessonID == lessonId).AnyAsync();
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
