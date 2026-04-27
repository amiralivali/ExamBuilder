using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Entities;
using ExamBuilder.Shared;
using ExamBuilder.Shared.DTOClases;
using ExamBuilder.Shared.InformationClases;
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
        public async Task<List<QuestionDTO>> SelectAsync(string search, string grade, string book, string lesson)
        {
            try
            {
                var optionals = await db.OptionalQuestions
                    .Include(x => x.Lesson)
                    .ThenInclude(x => x.Book)
                    .ThenInclude(x => x.Grade)
                    .Select(x => new QuestionDTO
                    {
                        Id = x.Id,
                        BookName = x.Lesson.Book.Title,
                        LessonName = x.Lesson.Title,
                        QuestionText = x.QuestionText,
                        QuestionType = Messages.Optional,
                        Grade = x.Lesson.Book.Grade.Title,
                    }).ToListAsync();
                var filter = optionals.Where(x => (grade == "" || x.Grade.Contains(grade)) &&
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
        public async Task<OptionalItem> SelectItemsAsync(int questionId)
        {
            try
            {
                var items = await db.OptionalItems.Where(x => x.OptionalId == questionId).SingleAsync();
                return items;
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
                item.OptionalId = optional.Id;
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
                var optionalQ = await db.OptionalQuestions.Where(x => x.Id == id).SingleAsync();
                db.OptionalQuestions.Remove(optionalQ);
                var optionalItem = await db.OptionalItems.Where(x => x.OptionalId == id).SingleAsync();
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
                var optionalQ = await db.OptionalQuestions.Where(x => x.Id == optionalQUpdate.Id).SingleAsync();
                optionalQ.QuestionText = optionalQUpdate.QuestionText;
                optionalQ.Picture = optionalQUpdate.Picture;
                optionalQ.DifficultyLevelId = optionalQUpdate.DifficultyLevelId;
                optionalQ.LessonID = optionalQUpdate.LessonID;
                var optionalItem = await db.OptionalItems.Where(x => x.OptionalId == optionalItemUpdate.OptionalId).SingleAsync();
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
        public async Task<bool> CheckDuplicateAsync(string questionText, int lessonId, OptionalItem optionalItem, int questionId = 0)
        {
            List<int> questionIds;

            if (questionId == 0) // Insert
            {
                questionIds = await db.OptionalQuestions
                    .Where(x => x.QuestionText == questionText && x.LessonID == lessonId)
                    .Select(x => x.Id)
                    .ToListAsync();
            }
            else // Update
            {
                questionIds = await db.OptionalQuestions
                    .Where(x => x.QuestionText == questionText && x.LessonID == lessonId && x.Id != questionId)
                    .Select(x => x.Id)
                    .ToListAsync();
            }

            var inputItems = new[]
            {
                optionalItem.Option1.Trim().ToLower(),
                optionalItem.Option2.Trim().ToLower(),
                optionalItem.Option3.Trim().ToLower(),
                optionalItem.Option4.Trim().ToLower(),
            }        
            .OrderBy(x => x)
            .ToList();

            foreach (var id in questionIds)
            {
                var dbItemRows = await db.OptionalItems
                    .Where(x => x.OptionalId == id)
                    .Select(x => new { x.Option1, x.Option2, x.Option3, x.Option4 })
                    .ToListAsync();

                var dbItem = dbItemRows.FirstOrDefault();
                if (dbItem == null)
                    continue;

                var dbItems = new[]
                {
                   dbItem.Option1.Trim().ToLower(),
                   dbItem.Option2.Trim().ToLower(),
                   dbItem.Option3.Trim().ToLower(),
                   dbItem.Option4.Trim().ToLower(),
                }
                .OrderBy(x => x)
                .ToList();

                if (dbItems.SequenceEqual(inputItems))
                    return true;
            }

            return false;
        }
    }
}
