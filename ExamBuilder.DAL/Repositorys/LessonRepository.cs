using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.BLL;
using ExamBuilder.DAL.Entities;
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
        public async Task<List<LessonInfo>> SelectAsync(int bookID)
        {
            try
            {
                var lessons = await db.Lessons.Where(x => x.BookID == bookID).Select(x => new LessonInfo
                {
                    BookID = bookID,
                    ID = x.ID,
                    LessonCount = x.LessonCount,
                    Title = x.Title
                }).ToListAsync();
                return lessons;
            }
            catch (Exception ex)
            {
                ex.AddLog();
                return null;
            }
        }
        public async Task<bool> InsertAsync(Lesson lesson)
        {
            try
            {
                await db.Lessons.AddAsync(lesson);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                ex.AddLog();
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
                ex.AddLog();
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
                ex.AddLog();
                return false;
            }
        }
    }
}
