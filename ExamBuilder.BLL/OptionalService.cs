using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Repositorys;
using ExamBuilder.Shared.DTOClases;
using ExamBuilder.Shared.InformationClases;
using ExamBuilder.Shared;
using ExamBuilder.DAL.Entities;

namespace ExamBuilder.BLL
{
    public class OptionalService
    {
        OptionalRepository repository;
        public OptionalService()
        {
            repository = new OptionalRepository();
        }

        public async Task<OprationResult<List<OptionalDTO>>> SelectAsync(string search)
        {
            var data = await repository.SelectAsync(search);
            if (data != null)
            {
                return OprationResult<List<OptionalDTO>>.Success(data);
            }
            else
            {
                return OprationResult<List<OptionalDTO>>.RunTimeError();
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

        public async Task<OprationResult> InsertAsync(QuestionInfo questionInfo,OptionalItemInfo itemInfo)
        {
            var question = questionInfo.MapToOptional();
            var item = itemInfo.MaptoOptional();
            var checkData = await CheckDuplicateAsync(questionInfo.QuestionText, questionInfo.LessonId, item);
            if (checkData.IsSuccess)
            {
                var checkInsert = await repository.InsertAsync(question, item);
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

        public async Task<OprationResult> UpdateAsync(QuestionInfo questionInfo, OptionalItemInfo itemInfo)
        {
            var question = questionInfo.MapToOptional();
            var item = itemInfo.MaptoOptional();
            var checkData = await CheckDuplicateAsync(questionInfo.QuestionText, questionInfo.LessonId, item, questionInfo.ID);
            if (checkData.IsSuccess)
            {
                var checkUpdate = await repository.UpdateAsync(question, item);
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

        public async Task<OprationResult> CheckDuplicateAsync(string questionText, int lessonId, OptionalItem item, int questionId = 0)
        {
            bool duplicate;
            if (questionId == 0)
            {
                duplicate = await repository.CheckDuplicateAsync(questionText, lessonId, item);
            }
            else
            {
                duplicate = await repository.CheckDuplicateAsync(questionText, lessonId, item, questionId);
            }
            if (duplicate)
            {
                return OprationResult.Duplicate(Messages.Question);
            }
            else
            {
                return OprationResult.Success();
            }
        }
    }
}
