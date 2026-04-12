using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Repositorys;
using ExamBuilder.Shared;
using ExamBuilder.Shared.InformationClases;

namespace ExamBuilder.BLL
{
    public class BookService
    {
        BookRepository repository;
        public BookService()
        {
            repository = new BookRepository();
        }
        public async Task<OprationResult<List<string>>> SelectAsync(string grade)
        {
            var data = await repository.SelectAsync(grade);
            if (data != null)
            {
                return OprationResult<List<string>>.Success(data);
            }
            else
            {
                return OprationResult<List<string>>.RunTimeError();
            }
        }
        public async Task<OprationResult> InsertAsync(BookInfo info)
        {
            var entity = info.MapToBook();
            var checkData = await CheckDuplicateAsync(info.Title,info.GradeId,info.GradeInfo);
            if (checkData.IsSuccess)
            {
                var checkInsert = await repository.InsertAsync(entity);
                if (checkInsert)
                {
                    return OprationResult.Success(Messages.Insert);
                }
                else
                {
                    return OprationResult.RunTimeError();
                }
            }
            else
            {
                return checkData;
            }
        }
        public async Task<OprationResult> UpdateAsync(BookInfo info)
        {
            var entity = info.MapToBook();
            var checkData = await CheckDuplicateAsync(info.Title, info.GradeId, info.GradeInfo, info.Id);
            if (checkData.IsSuccess)
            {
                var checkUpdate = await repository.UpdateAsync(entity);
                if (checkUpdate)
                {
                    return OprationResult.Success(Messages.Update);
                }
                else
                {
                    return OprationResult.RunTimeError();
                }
            }
            else
            {
                return checkData;
            }
        }
        public async Task<OprationResult> DeleteAsync(int id)
        {
            var check = await repository.DeleteAsync(id);
            if (check)
            {
                return OprationResult.Success(Messages.Delete);
            }
            else
            {
                return OprationResult.RunTimeError();
            }
        }
        public async Task<OprationResult<int>> GetLastIdAsync(string name,int gradeID,string gradeInfo)
        {
            int id=await repository.GetLastIdAsync(name,gradeID,gradeInfo);
            if (id != -1)
            {
                return OprationResult<int>.Success(id);
            }
            else
            {
                return OprationResult<int>.RunTimeError();
            }
        }
        public async Task<OprationResult<List<string>>> SelectAvailableGrades()
        {
            var availableGrades = await repository.SelectAvailableGrades();
            if (availableGrades != null)
            {
                return OprationResult<List<string>>.Success(availableGrades);
            }
            else
            { 
                return OprationResult<List<string>>.RunTimeError();
            }
        }
        public async Task<OprationResult> CheckDuplicateAsync(string title, int gradeID, string gradeInfo, int bookId = 0)
        {
            bool duplicate;
            if (bookId == 0)
            {
                duplicate = await repository.CheckDuplicateAsync(title, gradeID, gradeInfo);
            }
            else
            { 
                duplicate = await repository.CheckDuplicateAsync(title, gradeID, gradeInfo,bookId);
            }
            if (duplicate)
            {
                return OprationResult.Duplicate(Messages.Book);
            }
            else
            {
                return OprationResult.Success();
            }
        }
    }
}
