using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Entities;
using ExamBuilder.Shared.InformationClases;
using Microsoft.EntityFrameworkCore;

namespace ExamBuilder.DAL.Repositorys
{
    public class BookRepository
    {
        ExamBuilderDbContext db;
        public BookRepository()
        {
            db = new ExamBuilderDbContext();
        }
        public async Task<List<string>> SelectAsync(string grade)
        {
            try
            {
                var books = await db.Books.Include(x => x.Grade).Where(x => x.Grade.Title == grade).Select(x => x.Title).ToListAsync();
                return books;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return null;
            }
        }
        public async Task<bool> InsertAsync(Book book)
        {
            try
            {
                await db.Books.AddAsync(book);
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
                var book = await db.Books.Where(x => x.Id == id).SingleAsync();
                db.Books.Remove(book);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return false;
            }
        }
        public async Task<bool> UpdateAsync(Book updateBook)
        {
            try
            {
                var book = await db.Books.Where(x => x.Id == updateBook.Id).SingleAsync();
                book.Title = updateBook.Title;
                book.Grade = updateBook.Grade;
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return false;
            }
        }
        public async Task<int> GetLastIdAsync(string name,int gradeID,string gradeInfo)
        {
            try
            {
                var id = await db.Books.Where(x => x.Title == name && x.GradeId == gradeID && x.GradeInfo==gradeInfo).Select(x=>x.Id).SingleAsync();
                return id;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return -1;
            }
        }
        public async Task<bool> CheckDuplicateAsync(string name, int gradeID, string gradeInfo, int bookId=0)
        {
            bool duplicate;
            if (bookId == 0)
            {
                duplicate = await db.Books.Where(x => x.Title == name && x.GradeId == gradeID && x.GradeInfo == gradeInfo).AnyAsync();
            }
            else 
            {
                duplicate = await db.Books.Where(x => x.Title == name && x.GradeId == gradeID && x.GradeInfo == gradeInfo && x.Id != bookId).AnyAsync();
            }
            return duplicate;
        }
        public async Task<List<string>> SelectAvailableGrades()
        {
            try
            {
                var availableGrades = db.Books.Include(x => x.Grade).ToList().DistinctBy(x => x.GradeId).Select(x => x.Grade.Title).ToList();
                return availableGrades;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return null;
            }
        }
    }
}
