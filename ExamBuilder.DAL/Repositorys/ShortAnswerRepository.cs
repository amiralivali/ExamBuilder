using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Entities;
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
        public async Task<List<QuestionsDTO>> SelectAsync(string search)
        {
            try
            {
                var shortAnswer = await db.ShortQuestions.Include(x => x.DifficultyLevel)
                    .Include(x => x.Lesson)
                    .ThenInclude(x => x.Book)
                    .Select(x => new QuestionsDTO
                    {
                        Id = x.Id,
                        BookName = x.Lesson.Book.Title,
                        LessonName = x.Lesson.Title,
                        QuestionText = x.QuestionText,
                        Picture = x.Picture,
                        DifficultyLevel = x.DifficultyLevel.Title,
                    }).ToListAsync();
                return shortAnswer.Where(x => search == "" ||
                x.QuestionText.Contains(search) ||
                x.DifficultyLevel.Contains(search) ||
                x.LessonName.Contains(search) ||
                x.BookName.Contains(search)).ToList();
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
