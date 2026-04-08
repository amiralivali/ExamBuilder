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
    public class DescriptiveRepository
    {
        ExamBuilderDbContext db;
        public DescriptiveRepository()
        {
            db = new ExamBuilderDbContext();
        }
        public async Task<List<QuestionsDTO>> SelectAsync(string search)
        {
            try
            {
                var Descriptives = await db.DescriptiveQuestions.Include(x => x.DifficultyLevel)
                    .Include(x => x.Lesson)
                    .ThenInclude(x => x.Book)
                    .Select(x => new QuestionsDTO
                    {
                        ID = x.ID,
                        DifficultyLevel = x.DifficultyLevel.Title,
                        LessonName = x.Lesson.Title,
                        BookName = x.Lesson.Book.Title,
                        Picture = x.Picture,
                        QuestionText = x.QuestionText,
                    }).ToListAsync();
                return Descriptives.Where(x => search == "" ||
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
                var descriptive = await db.DescriptiveQuestions.Where(x => x.ID == updateDescriptive.ID).SingleAsync();
                descriptive.QuestionText = updateDescriptive.QuestionText;
                descriptive.DifficultyLevelID = updateDescriptive.DifficultyLevelID;
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
                var descriptive = await db.DescriptiveQuestions.Where(x => x.ID == id).SingleAsync();
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
                    x.ID != questionId).AnyAsync();
            }
            return duplicate;
        }
    }
}
