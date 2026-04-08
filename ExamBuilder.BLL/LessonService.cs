using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Repositorys;
using ExamBuilder.Shared;
using ExamBuilder.Shared.InformationClases;

namespace ExamBuilder.BLL
{
    public class LessonService
    {
        LessonRepository repository;
        public LessonService()
        {
            repository = new LessonRepository();
        }
        public async Task<OprationResult<List<string>>> SelectAsync(string bookName)
        {
            var data = await repository.SelectAsync(bookName);
            if (data != null)
            {
                return OprationResult<List<string>>.Success(data);
            }
            else
            {
                return OprationResult<List<string>>.RunTimeError();
            }
        }
        public async Task<OprationResult> InsertAsync(List<LessonInfo> info)
        {
            var entity = info.MapToLesson();
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
        public async Task<OprationResult> UpdateAsync(LessonInfo info)
        {
            var entity = info.MapToLesson();
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
        public async Task<OprationResult<int>> GetLessonIDAsync(int lessonCount,string bookName)
        {
            int id = await repository.GetLessonIDAsync(lessonCount, bookName);
            if (id != -1)
            {
                return OprationResult<int>.Success(id);
            }
            else
            {
                return OprationResult<int>.RunTimeError();
            }
        }
    }
}
