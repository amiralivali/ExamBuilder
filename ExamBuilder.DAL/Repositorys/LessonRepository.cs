using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Entities;
using ExamBuilder.Shared;
using ExamBuilder.Shared.InformationClases;
using Microsoft.EntityFrameworkCore;

namespace ExamBuilder.DAL.Repositorys
{
    public class LessonRepository
    {
        ExamBuilderDbContext db;
        public LessonRepository()
        {
            db = new ExamBuilderDbContext();
        }
        public async Task<List<string>> SelectAsync(string bookName,string gradeInfo)
        {
            try
            {
                var lessons = await db.Lessons.Include(x => x.Book).ThenInclude(x => x.Grade).Where(x => x.Book.Title == bookName
                && x.Book.Grade.Title == gradeInfo)
                    .Select(x => Messages.Lesson + " " + x.LessonCount + " " + x.Title).ToListAsync();
                return lessons;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return null;
            }
        }
        public async Task<bool> InsertAsync(List<Lesson> lessons)
        {
            try
            {
                foreach (var lesson in lessons)
                {
                    await db.Lessons.AddAsync(lesson);
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
        public async Task<bool> UpdateAsync(Lesson updateLesson)
        {
            try
            {
                var lesson = await db.Lessons.Where(x => x.Id == updateLesson.Id).SingleAsync();
                lesson.Title = updateLesson.Title;
                lesson.BookId = updateLesson.BookId;
                lesson.LessonCount = updateLesson.LessonCount;
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
                var lesson = await db.Lessons.Where(x => x.Id == id).SingleAsync();
                db.Lessons.Remove(lesson);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return false;
            }
        }
        public async Task<int> GetLessonIdAsync(int lessonCount, string bookName,string gradeName)
        {
            try
            {
                var lesson = await db.Lessons.Include(x => x.Book).ThenInclude(x=>x.Grade).Where(x => x.LessonCount == lessonCount && x.Book.Title == bookName && x.Book.Grade.Title == gradeName).SingleAsync();
                return lesson.Id;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();   
                return -1;
            }
        }
        public async Task<int> GetCountQuestionsInLessonsAsync(List<int> lessonIds)
        {
            try
            {
                int count = 0;
                foreach (var lessonId in lessonIds)
                {
                    count += await db.DescriptiveQuestions.Where(x => x.LessonID == lessonId).CountAsync();
                    count += await db.TrueFalseQuestions.Where(x => x.LessonId == lessonId).CountAsync();
                    count += await db.ShortQuestions.Where(x => x.LessonID == lessonId).CountAsync();
                    count += await db.OptionalQuestions.Where(x => x.LessonID == lessonId).CountAsync();
                    count += await db.MatchingQuestions.Where(x => x.LessonID == lessonId).CountAsync();
                    count += await db.FillInBlankQuestions.Where(x => x.LessonID == lessonId).CountAsync();
                }
                return count;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return -1;
            }
        }
        public async Task<List<int>> GetLessonsId(List<int> lessonCounts, string bookName, string gradeName)
        {
            try
            {
                List<int> lessonsIds = new List<int>();
                foreach (var lessonCount in lessonCounts)
                {
                    var lesson = await db.Lessons.Include(x => x.Book).ThenInclude(x=>x.Grade).Where(x => x.LessonCount == lessonCount && x.Book.Title == bookName && x.Book.Grade.Title == gradeName).SingleAsync();
                    lessonsIds.Add(lesson.Id);
                }
                return lessonsIds;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return null;
            }
        }
    }
}
