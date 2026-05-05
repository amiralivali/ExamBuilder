using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Entities;
using ExamBuilder.DAL.Interface;
using ExamBuilder.Shared;
using ExamBuilder.Shared.DTOClases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ExamBuilder.DAL.Repositorys
{
    public class FillInBlankRepository : ISelectQuestions
    {
        ExamBuilderDbContext db;
        public FillInBlankRepository()
        {
            db = new ExamBuilderDbContext();
        }

        public async Task<List<QuestionDTO>> SelectFilterQuestionsAsync(string search, string grade, string book, string lesson)
        {
            var blankQuestions = await db.FillInBlankQuestions.Include(x=>x.DifficultyLevel)
                    .Include(x => x.Lesson)
                    .ThenInclude(x => x.Book)
                    .ThenInclude(x => x.Grade)
                    .Select(x => new QuestionDTO
                    {
                        Id = x.Id,
                        LessonName = Messages.Lesson + " " + x.Lesson.LessonCount + " " + x.Lesson.Title,
                        BookName = x.Lesson.Book.Title,
                        QuestionText = x.QuestionText,
                        QuestionType = Messages.FillInBlank,
                        Grade = x.Lesson.Book.Grade.Title,
                        DifficultyLevel = x.DifficultyLevel.Title,
                        Picture = x.Picture,
                    }).ToListAsync();
            var filter = blankQuestions.Where(x => (grade == "" || x.Grade.Contains(grade)) &&
            (book == "" || x.BookName.Contains(book)) &&
            (lesson == "" || x.Grade.Contains(lesson)));
            return filter.Where(x => search == "" ||
            x.QuestionText.Contains(search)).ToList();
        }
        public async Task<QuestionDTO> SelectQuestionAsync(int id)
        {
            try
            {
                var descriptive = await db.FillInBlankQuestions.Include(x => x.DifficultyLevel)
                    .Include(x => x.Lesson)
                    .ThenInclude(x => x.Book)
                    .ThenInclude(x => x.Grade)
                    .Where(x => x.Id == id)
                    .Select(x => new QuestionDTO
                    {
                        Id = x.Id,
                        LessonName = Messages.Lesson + " " + x.Lesson.LessonCount + " " + x.Lesson.Title,
                        BookName = x.Lesson.Book.Title,
                        QuestionText = x.QuestionText,
                        QuestionType = Messages.FillInBlank,
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
        public async Task<List<FillInBlankItem>> SelectItemsAsync(int questionId)
        {
            try
            {
                var items = await db.FillInBlankItems.Where(x=>x.FillInBlankQuestionId == questionId).ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return null;
            }
        }
        public async Task<bool> InsertAsync(FillInBlankQuestion question, List<FillInBlankItem> items)
        {
            try
            {
                await db.FillInBlankQuestions.AddAsync(question);
                await db.SaveChangesAsync();
                int id = question.Id;
                foreach (FillInBlankItem item in items)
                {
                    item.FillInBlankQuestionId = id;
                    await db.FillInBlankItems.AddAsync(item);
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
                var item = await db.FillInBlankItems.Where(x => x.Id == id).SingleAsync();
                db.FillInBlankItems.Remove(item);
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
                var question = await db.FillInBlankQuestions.Where(x => x.Id == id).SingleAsync();
                db.FillInBlankQuestions.Remove(question);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return false;
            }
        }
        public async Task<bool> UpdateAsync(FillInBlankQuestion updateQuestion, List<FillInBlankItem> updateItems)
        {
            try
            {
                var question = await db.FillInBlankQuestions.Where(x => x.Id == updateQuestion.Id).SingleAsync();
                question.QuestionText = updateQuestion.QuestionText;
                question.DifficultyLevelId = updateQuestion.DifficultyLevelId;
                question.Picture = updateQuestion.Picture;
                question.LessonID = updateQuestion.LessonID;
                var items = await db.FillInBlankItems.Where(x => x.FillInBlankQuestionId == updateQuestion.Id).ToListAsync();
                foreach (var item in items)
                {
                    foreach (var upadateItem in updateItems)
                    {
                        if (item.Id == upadateItem.Id)
                        {
                            item.Text = upadateItem.Text;
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
        public async Task<bool> CheckDuplicateAsync(string questionText, int lessonId, List<FillInBlankItem> fillInBlankItems, int questionId = 0)
        {
            var inputTexts = fillInBlankItems
                .Select(x => x.Text.Trim().ToLower())
                .OrderBy(x => x)
                .ToList();
            List<int> questionIds;
            if (questionId == 0) //Insert
            {
                 questionIds = await db.FillInBlankQuestions
                 .Where(q => q.QuestionText == questionText && q.LessonID == lessonId)
                 .Select(q => q.Id)
                 .ToListAsync();
            }
            else //Update
            {
                 questionIds = await db.FillInBlankQuestions
                        .Where(q => q.QuestionText == questionText && q.LessonID == lessonId && q.Id != questionId)
                        .Select(q => q.Id)
                        .ToListAsync();
            }

            foreach (var qid in questionIds)
            {
                var dbTexts = await db.FillInBlankItems
                    .Where(i => i.FillInBlankQuestionId == qid)
                    .Select(i => i.Text.Trim().ToLower())
                    .OrderBy(x => x)
                    .ToListAsync();

                if (dbTexts.Count != inputTexts.Count)
                    continue;

                if (dbTexts.SequenceEqual(inputTexts))
                    return true; 
            }

            return false;
        }
    }
}
