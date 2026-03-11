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
    public class OptionalRepository
    {
        ExamBuilderDbContext db;
        public OptionalRepository()
        {
            db = new ExamBuilderDbContext();
        }
        public async Task<List<OptionalDTO>> SelectAsync(string search)
        {
            try
            {
                var optional = await db.OptionalQuestions.Include(x => x.DifficultyLevel)
                    .Include(x => x.Lesson)
                    .ThenInclude(x => x.Book)
                    .Select(x => new OptionalDTO
                    {
                        ID = x.ID,
                        BookName = x.Lesson.Book.Title,
                        LessonName = x.Lesson.Title,
                        QuestionText = x.QuestionText,
                        Picture = x.Picture,
                        DifficultyLevel = x.DifficultyLevel.Title,
                        Option1 = x.Option1,
                        Option2 = x.Option2,
                        Option3 = x.Option3,
                        Option4 = x.Option4,
                    }).ToListAsync();
                return optional.Where(x => search == "" ||
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
        public async Task<bool> InsertAsync(OptionalQuestion optional)
        {
            try
            {
                await db.OptionalQuestions.AddAsync(optional);
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
                var optional = await db.OptionalQuestions.Where(x => x.ID == id).SingleAsync();
                db.OptionalQuestions.Remove(optional);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                ex.AddLog();
                return false;
            }
        }
        public async Task<bool> UpdateAsync(OptionalQuestion optionalUpdate)
        {
            try
            {
                var optional = await db.OptionalQuestions.Where(x => x.ID == optionalUpdate.ID).SingleAsync();
                optional.QuestionText = optionalUpdate.QuestionText;
                optional.Picture = optionalUpdate.Picture;
                optional.DifficultyLevelID = optionalUpdate.DifficultyLevelID;
                optional.LessonID = optionalUpdate.LessonID;
                optional.Option1 = optionalUpdate.Option1;
                optional.Option2 = optionalUpdate.Option2;
                optional.Option3 = optionalUpdate.Option3;
                optional.Option4 = optionalUpdate.Option4;
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
