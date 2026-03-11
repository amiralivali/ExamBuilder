using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.BLL;
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
                        ID = x.ID,
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
                ex.AddLog();
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
                ex.AddLog();
                return false;
            }
        }
        public async Task<bool> UpdateAsync(ShortQuestion updateShortQuestion)
        {
            try
            {
                var shortQuestion = await db.ShortQuestions.Where(x => x.ID == updateShortQuestion.ID).SingleAsync();
                shortQuestion.QuestionText = updateShortQuestion.QuestionText;
                shortQuestion.DifficultyLevelID = updateShortQuestion.DifficultyLevelID;
                shortQuestion.Picture = updateShortQuestion.Picture;
                shortQuestion.LessonID = updateShortQuestion.LessonID;
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                ex.AddLog();
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var shortQuestion = await db.ShortQuestions.Where(x => x.ID == id).SingleAsync();
                db.ShortQuestions.Remove(shortQuestion);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                ex.AddLog();
                return false;
            }
        }
    }
}
