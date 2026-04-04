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
                var optional = await db.OptionalQuestions.Include(x=>x.OptionalItem)
                    .Include(x => x.DifficultyLevel)
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
                        Option1 = x.OptionalItem.Option1,
                        Option2 = x.OptionalItem.Option2,
                        Option3 = x.OptionalItem.Option3,
                        Option4 = x.OptionalItem.Option4,
                    }).ToListAsync();
                return optional.Where(x => search == "" ||
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
        public async Task<bool> InsertAsync(OptionalQuestion optional,OptionalItem item)
        {
            try
            {
                await db.OptionalQuestions.AddAsync(optional);
                await db.SaveChangesAsync();
                item.OptionalID = optional.ID;
                await db.OptionalItems.AddAsync(item);
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
                var optionalQ = await db.OptionalQuestions.Where(x => x.ID == id).SingleAsync();
                db.OptionalQuestions.Remove(optionalQ);
                var optionalItem = await db.OptionalItems.Where(x => x.OptionalID == id).SingleAsync();
                db.OptionalItems.Remove(optionalItem);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return false;
            }
        }
        public async Task<bool> UpdateAsync(OptionalQuestion optionalQUpdate, OptionalItem optionalItemUpdate)
        {
            try
            {
                var optionalQ = await db.OptionalQuestions.Where(x => x.ID == optionalQUpdate.ID).SingleAsync();
                optionalQ.QuestionText = optionalQUpdate.QuestionText;
                optionalQ.Picture = optionalQUpdate.Picture;
                optionalQ.DifficultyLevelID = optionalQUpdate.DifficultyLevelID;
                optionalQ.LessonID = optionalQUpdate.LessonID;
                var optionalItem = await db.OptionalItems.Where(x => x.OptionalID == optionalItemUpdate.OptionalID).SingleAsync();
                optionalItem.Option1 = optionalItemUpdate.Option1;
                optionalItem.Option2 = optionalItemUpdate.Option2;
                optionalItem.Option3 = optionalItemUpdate.Option3;
                optionalItem.Option4 = optionalItemUpdate.Option4;
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return false;
            }
        }
    }
}
