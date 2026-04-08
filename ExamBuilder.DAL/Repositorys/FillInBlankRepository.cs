using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Entities;
using ExamBuilder.Shared.DTOClases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ExamBuilder.DAL.Repositorys
{
    public class FillInBlankRepository
    {
        ExamBuilderDbContext db;
        public FillInBlankRepository()
        {
            db = new ExamBuilderDbContext();
        }
        public async Task<List<ItemQuestionsDTO>> SelectAsync(string search)
        {
            try
            {
                var blankQuestions = await db.FillInBlankQuestions.Include(x => x.Items)
                    .Include(x => x.DifficultyLevel)
                    .Include(x => x.Lesson)
                    .ThenInclude(x => x.Book)
                    .Select(x => new ItemQuestionsDTO()
                    {
                        ID = x.ID,
                        QuestionText = x.QuestionText,
                        BookName = x.Lesson.Book.Title,
                        LessonName = x.Lesson.Title,
                        DifficultyLevel = x.DifficultyLevel.Title,
                        Items = x.Items.Where(y => y.FillInBlankQuestionID == x.ID).Select(x => x.Text).ToList(),
                    }).ToListAsync();
                return blankQuestions.Where(x => search == "" ||
                    x.QuestionText.Contains(search) ||
                    x.LessonName.Contains(search) ||
                    x.DifficultyLevel.Contains(search) ||
                    x.BookName.Contains(search) ||
                    x.Items.Contains(search)).ToList();
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
                int id = question.ID;
                foreach (FillInBlankItem item in items)
                {
                    item.FillInBlankQuestionID = id;
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
                var item = await db.FillInBlankItems.Where(x => x.ID == id).SingleAsync();
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
                var question = await db.FillInBlankQuestions.Where(x => x.ID == id).SingleAsync();
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
                var question = await db.FillInBlankQuestions.Where(x => x.ID == updateQuestion.ID).SingleAsync();
                question.QuestionText = updateQuestion.QuestionText;
                question.DifficultyLevelID = updateQuestion.DifficultyLevelID;
                question.Picture = updateQuestion.Picture;
                question.LessonID = updateQuestion.LessonID;
                var items = await db.FillInBlankItems.Where(x => x.FillInBlankQuestionID == updateQuestion.ID).ToListAsync();
                foreach (var item in items)
                {
                    foreach (var upadateItem in updateItems)
                    {
                        if (item.ID == upadateItem.ID)
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
                 .Select(q => q.ID)
                 .ToListAsync();
            }
            else //Update
            {
                 questionIds = await db.FillInBlankQuestions
                        .Where(q => q.QuestionText == questionText && q.LessonID == lessonId && q.ID != questionId)
                        .Select(q => q.ID)
                        .ToListAsync();
            }

            foreach (var qid in questionIds)
            {
                var dbTexts = await db.FillInBlankItems
                    .Where(i => i.FillInBlankQuestionID == qid)
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
