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
    public class MatchingRepository 
    {
        ExamBuilderDbContext db;
        public MatchingRepository()
        {
            db = new ExamBuilderDbContext();
        }

        public async Task<List<QuestionDTO>> SelectAsync(string search, string grade, string book, string lesson)
        {
            var matchingQuestions = await db.MatchingQuestions
                    .Include(x => x.Lesson)
                    .ThenInclude(x => x.Book)
                    .ThenInclude(x => x.Grade)
                    .Select(x => new QuestionDTO
                    {
                        Id = x.Id,
                        LessonName = x.Lesson.Title,
                        BookName = x.Lesson.Book.Title,
                        QuestionText = x.QuestionText,
                        QuestionType = Messages.Matching,
                        Grade = x.Lesson.Book.Grade.Title,

                    }).ToListAsync();
            var filter = matchingQuestions.Where(x => (grade == "" || x.Grade.Contains(grade)) &&
            (book == "" || x.BookName.Contains(book)) &&
            (lesson == "" || x.Grade.Contains(lesson)));
            return filter.Where(x => search == "" ||
            x.QuestionText.Contains(search)).ToList();
        }
        public async Task<List<MatchingItem>> SelectItemsAsync(int questionId)
        {
            try
            {
                var items = await db.MatchingItems.Where(x => x.MatchingQuestionId == questionId).ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return null;
            }
        }
        public async Task<bool> InsertAsync(MatchingQuestion question, List<MatchingItem> items)
        {
            try
            {
                await db.MatchingQuestions.AddAsync(question);
                await db.SaveChangesAsync();
                int id = question.Id;
                foreach (MatchingItem item in items)
                {
                    item.MatchingQuestionId = id;
                    await db.MatchingItems.AddAsync(item);
                }
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return false;
            }
        }
        public async Task<bool> DeleteItemAsync(int id)
        {
            try
            {
                var item = await db.MatchingItems.Where(x => x.Id == id).SingleAsync();
                db.MatchingItems.Remove(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return false;
            }
        }
        public async Task<bool> DeleteQuestionAsync(int id)
        {
            try
            {
                var question = await db.MatchingQuestions.Where(x => x.Id == id).SingleAsync();
                db.MatchingQuestions.Remove(question);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return false;
            }
        }
        public async Task<bool> UpdateAsync(MatchingQuestion updateQuestion, List<MatchingItem> updateItems)
        {
            try
            {
                var question = await db.MatchingQuestions.Where(x => x.Id == updateQuestion.Id).SingleAsync();
                question.QuestionText = updateQuestion.QuestionText;
                question.DifficultyLevelId = updateQuestion.DifficultyLevelId;
                question.Picture = updateQuestion.Picture;
                question.LessonID = updateQuestion.LessonID;
                var items = await db.MatchingItems.Where(x => x.MatchingQuestionId == updateQuestion.Id).ToListAsync();
                foreach (var item in items)
                {
                    foreach (var upadateItem in updateItems)
                    {
                        if (item.Id == upadateItem.Id)
                        {
                            item.LeftText = upadateItem.LeftText;
                            item.RightText = upadateItem.RightText;
                            break;
                        }
                    }
                }
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return false;
            }
        }
        public async Task<bool> CheckDuplicateAsync(string questionText, int lessonId, List<MatchingItem> matchingItems, int questionId = 0)
        {
            var inputTexts = matchingItems
                .SelectMany(x => new[]
                {
                    x.LeftText.Trim().ToLower(),
                    x.RightText.Trim().ToLower()
                })
                .OrderBy(x => x)
                .ToList();
            List<int> questionIds;
            if (questionId == 0) //Insert
            {
                questionIds = await db.MatchingQuestions
                    .Where(q => q.QuestionText == questionText && q.LessonID == lessonId)
                    .Select(q => q.Id)
                    .ToListAsync();
            }
            else //Update
            {
                questionIds = await db.MatchingQuestions
                        .Where(q => q.QuestionText == questionText && q.LessonID == lessonId && q.Id != questionId)
                        .Select(q => q.Id)
                        .ToListAsync();
            }

            foreach (var qid in questionIds)
            {
                var dbItems = await db.MatchingItems
                    .Where(i => i.MatchingQuestionId == qid)
                    .Select(i => new { i.LeftText, i.RightText })
                    .ToListAsync();

                var dbTexts = dbItems
                    .SelectMany(x => new[]
                    {
                       x.LeftText.Trim().ToLower(),
                       x.RightText.Trim().ToLower()
                    })
                    .OrderBy(x => x)
                    .ToList();

                if (dbTexts.Count != inputTexts.Count)
                    continue;

                if (dbTexts.SequenceEqual(inputTexts))
                    return true; 
            }

            return false;
        }
    }
}
