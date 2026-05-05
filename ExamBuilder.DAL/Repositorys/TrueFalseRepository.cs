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

namespace ExamBuilder.DAL.Repositorys
{
    public class TrueFalseRepository : ISelectQuestions
    {
        ExamBuilderDbContext db;
        public TrueFalseRepository()
        {
            db = new ExamBuilderDbContext();
        }

        public async Task<List<QuestionDTO>> SelectFilterQuestionsAsync(string search, string grade, string book, string lesson)
        {
            var trueFalseQuestion = await db.TrueFalseQuestions.Include(x=>x.DifficultyLevel)
                    .Include(x => x.Lesson)
                    .ThenInclude(x => x.Book)
                    .ThenInclude(x => x.Grade)
                    .Select(x => new QuestionDTO
                    {
                        Id = x.ID,
                        LessonName = Messages.Lesson + " " + x.Lesson.LessonCount + " " + x.Lesson.Title,
                        BookName = x.Lesson.Book.Title,
                        QuestionText = x.QuestionText,
                        QuestionType = Messages.TrueFalse,
                        Grade = x.Lesson.Book.Grade.Title,
                        DifficultyLevel = x.DifficultyLevel.Title,
                        Picture=x.Picture,
                    }).ToListAsync();
            var filter = trueFalseQuestion.Where(x => (grade == "" || x.Grade.Contains(grade)) &&
            (book == "" || x.BookName.Contains(book)) &&
            (lesson == "" || x.Grade.Contains(lesson)));
            return filter.Where(x => search == "" ||
            x.QuestionText.Contains(search)).ToList();
        }
        public async Task<QuestionDTO> SelectQuestionAsync(int id)
        {
            try
            {
                var descriptive = await db.TrueFalseQuestions.Include(x => x.DifficultyLevel)
                    .Include(x => x.Lesson)
                    .ThenInclude(x => x.Book)
                    .ThenInclude(x => x.Grade)
                    .Where(x => x.ID == id)
                    .Select(x => new QuestionDTO
                    {
                        Id = x.ID,
                        LessonName = Messages.Lesson + " " + x.Lesson.LessonCount + " " + x.Lesson.Title,
                        BookName = x.Lesson.Book.Title,
                        QuestionText = x.QuestionText,
                        QuestionType = Messages.TrueFalse,
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
        public async Task<List<TrueFalseItem>> SelectItemsAsync(int questionId)
        {
            try
            {
                var items = await db.TrueFalseItems.Where(x => x.TrueFalseQuestionId == questionId).ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return null;
            }
        }

        public async Task<bool> InsertAsync(TrueFalseQuestion question, List<TrueFalseItem> items)
        {
            try
            {
                await db.TrueFalseQuestions.AddAsync(question);
                await db.SaveChangesAsync();
                int id = question.ID;
                foreach (TrueFalseItem item in items)
                {
                    item.TrueFalseQuestionId = id;
                    await db.TrueFalseItems.AddAsync(item);
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
                var item = await db.TrueFalseItems.Where(x => x.Id == id).SingleAsync();
                db.TrueFalseItems.Remove(item);
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
                var question = await db.TrueFalseQuestions.Where(x => x.ID == id).SingleAsync();
                db.TrueFalseQuestions.Remove(question);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return false;
            }
        }
        public async Task<bool> UpdateAsync(TrueFalseQuestion updateQuestion, List<TrueFalseItem> updateItems)
        {
            try
            {
                var question = await db.TrueFalseQuestions.Where(x => x.ID == updateQuestion.ID).SingleAsync();
                question.QuestionText = updateQuestion.QuestionText;
                question.DifficultyLevelId = updateQuestion.DifficultyLevelId;
                question.Picture = updateQuestion.Picture;
                question.LessonId = updateQuestion.LessonId;
                var items = await db.TrueFalseItems.Where(x => x.TrueFalseQuestionId == updateQuestion.ID).ToListAsync();
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
        public async Task<bool> CheckDuplicateAsync(string questionText, int lessonId, List<TrueFalseItem> trueFalseItems, int questionId = 0)
        {
            var inputTexts = trueFalseItems
                .Select(x => x.Text.Trim().ToLower())
                .OrderBy(x => x)
                .ToList();
            List<int> questionIds;
            if (questionId == 0) //Insert
            {
                questionIds = await db.TrueFalseQuestions
                    .Where(q => q.QuestionText == questionText && q.LessonId == lessonId)
                    .Select(q => q.ID)
                    .ToListAsync();
            }
            else //Update
            {
                questionIds = await db.TrueFalseQuestions
                    .Where(q => q.QuestionText == questionText && q.LessonId == lessonId && q.ID != questionId)
                    .Select(q => q.ID)
                    .ToListAsync();
            }
            foreach (var qid in questionIds)
            {
                var dbTexts = await db.TrueFalseItems
                    .Where(i => i.TrueFalseQuestionId == qid)
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
