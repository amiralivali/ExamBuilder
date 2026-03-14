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
        public async Task<List<BookInfo>> SelectAsync()
        {
            try
            {
                var books = await db.Books.Select(x => new BookInfo
                {
                    ID = x.ID,
                    GradeID = x.GradeID,
                    Title = x.Title,
                }).ToListAsync();
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
                var book = await db.Books.Where(x => x.ID == id).SingleAsync();
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
                var book = await db.Books.Where(x => x.ID == updateBook.ID).SingleAsync();
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
        public async Task<int> GetLastIDAsync(string name,int gradeID,string gradeInfo)
        {
            try
            {
                var id = await db.Books.Where(x => x.Title == name && x.GradeID == gradeID && x.GradeInfo==gradeInfo).Select(x=>x.ID).SingleAsync();
                return id;
            }
            catch (Exception ex)
            {
                await ex.AddLogAsync();
                return -1;
            }
        }
        public async Task<bool> CheckDuplicate(string name, int gradeID, string gradeInfo)
        {
            bool duplicate = await db.Books.Where(x => x.Title == name && x.GradeID == gradeID && x.GradeInfo == gradeInfo).AnyAsync();
            return duplicate;
        }
    }
}
