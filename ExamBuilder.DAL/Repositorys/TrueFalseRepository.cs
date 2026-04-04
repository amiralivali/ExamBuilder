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
    public class TrueFalseRepository
    {
        ExamBuilderDbContext db;
        public TrueFalseRepository()
        {
            db = new ExamBuilderDbContext();
        }
        public async Task<List<ItemQuestionsDTO>> SelectAsync(string search)
        {
            try
            {
                var trueFalseQuestion = await db.TrueFalseQuestions.Include(x => x.Items)
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
                        Items = x.Items.Where(y => y.TrueFalseQuestionID == x.ID).Select(x => x.Text).ToList(),
                    }).ToListAsync();
                return trueFalseQuestion.Where(x => search == "" ||
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
        public async Task<bool> InsertAsync(TrueFalseQuestion question, List<TrueFalseItem> items)
        {
            try
            {
                await db.TrueFalseQuestions.AddAsync(question);
                await db.SaveChangesAsync();
                int id = question.ID;
                foreach (TrueFalseItem item in items)
                {
                    item.TrueFalseQuestionID = id;
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
                var item = await db.TrueFalseItems.Where(x => x.ID == id).SingleAsync();
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
                question.DifficultyLevelID = updateQuestion.DifficultyLevelID;
                question.Picture = updateQuestion.Picture;
                question.LessonID = updateQuestion.LessonID;
                var items = await db.TrueFalseItems.Where(x => x.TrueFalseQuestionID == updateQuestion.ID).ToListAsync();
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
    }
}
