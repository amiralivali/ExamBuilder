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
        public async Task<OprationResult<List<BookInfo>>> SelectAsync()
        {
            var data = await repository.SelectAsync();
            if (data != null)
            {
                return OprationResult<List<BookInfo>>.Success(data);
            }
            else
            {
                return OprationResult<List<BookInfo>>.RunTimeError();
            }
        }
        public async Task<OprationResult> InsertAsync(BookInfo info)
        {
            //////////////////////////////////////////////////////
            var entity = info.MapToBook();
            var check = await repository.InsertAsync(entity);
            if (check)
            {
                return OprationResult.Success(Messages.Insert);
            }
            else
            { 
            return OprationResult.RunTimeError();
            }
        }
        public async Task<OprationResult> UpdateAsync(BookInfo info)
        {
            var entity = info.MapToBook();
            var check = await repository.UpdateAsync(entity);
            if (check)
            {
                return OprationResult.Success(Messages.Update);
            }
            else
            {
                return OprationResult.RunTimeError();
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
    }
}
