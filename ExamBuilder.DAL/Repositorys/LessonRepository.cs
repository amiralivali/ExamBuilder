using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public async Task<List<string>> SelectAsync(string bookName)
        {
            try
            {
                var lessons = await db.Lessons.Include(x => x.Book).Where(x => x.Book.Title == bookName)
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
                var lesson = await db.Lessons.Where(x => x.ID == updateLesson.ID).SingleAsync();
                lesson.Title = updateLesson.Title;
                lesson.BookID = updateLesson.BookID;
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
                var lesson = await db.Lessons.Where(x => x.ID == id).SingleAsync();
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
    }
}
