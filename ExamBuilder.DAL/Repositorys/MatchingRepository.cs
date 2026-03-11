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
    public class MatchingRepository
    {
        ExamBuilderDbContext db;
        public MatchingRepository()
        {
            db = new ExamBuilderDbContext();
        }
        public async Task<List<MatchingDTO>> SelectAsync(string search)
        {
            try
            {
                var matchingQuestions = await db.MatchingQuestions.Include(x => x.Items)
                    .Include(x => x.DifficultyLevel)
                    .Include(x => x.Lesson)
                    .ThenInclude(x => x.Book)
                    .Select(x => new MatchingDTO()
                    {
                        ID = x.ID,
                        QuestionText = x.QuestionText,
                        BookName = x.Lesson.Book.Title,
                        LessonName = x.Lesson.Title,
                        DifficultyLevel = x.DifficultyLevel.Title,
                        LeftTexts = x.Items.Where(y => y.MatchingQuestionID == x.ID).Select(x => x.LeftText).ToList(),
                        RightTexts = x.Items.Where(y => y.MatchingQuestionID == x.ID).Select(x => x.RightText).ToList()
                    }).ToListAsync();
                return matchingQuestions.Where(x => search == "" ||
                    x.QuestionText.Contains(search) ||
                    x.LessonName.Contains(search) ||
                    x.DifficultyLevel.Contains(search) ||
                    x.BookName.Contains(search) ||
                    x.RightTexts.Contains(search) ||
                    x.LeftTexts.Contains(search)).ToList();
            }
            catch (Exception ex)
            {
                ex.AddLog();
                return null;
            }
        }
        public async Task<bool> InsertAsync(MatchingQuestion question, List<MatchingItem> items)
        {
            try
            {
                await db.MatchingQuestions.AddAsync(question);
                await db.SaveChangesAsync();
                int id = db.MatchingQuestions.Last().ID;
                foreach (MatchingItem item in items)
                {
                    item.MatchingQuestionID = id;
                    await db.MatchingItems.AddAsync(item);
                }
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                ex.AddLog();
                return false;
            }
        }
        public async Task<bool> DeleteItemAsync(int id)
        {
            try
            {
                var item = await db.MatchingItems.Where(x => x.ID == id).SingleAsync();
                db.MatchingItems.Remove(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                ex.AddLog();
                return false;
            }
        }
        public async Task<bool> DeleteQuestionAsync(int id)
        {
            try
            {
                var question = await db.MatchingQuestions.Where(x => x.ID == id).SingleAsync();
                db.MatchingQuestions.Remove(question);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                ex.AddLog();
                return false;
            }
        }
        public async Task<bool> UpdateAsync(MatchingQuestion updateQuestion, List<MatchingItem> updateItems)
        {
            try
            {
                var question = await db.MatchingQuestions.Where(x => x.ID == updateQuestion.ID).SingleAsync();
                question.QuestionText = updateQuestion.QuestionText;
                question.DifficultyLevelID = updateQuestion.DifficultyLevelID;
                question.Picture = updateQuestion.Picture;
                question.LessonID = updateQuestion.LessonID;
                var items = await db.MatchingItems.Where(x => x.MatchingQuestionID == updateQuestion.ID).ToListAsync();
                foreach (var item in items)
                {
                    foreach (var upadateItem in updateItems)
                    {
                        if (item.ID == upadateItem.ID)
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
                ex.AddLog();
                return false;
            }
        }
    }
}
