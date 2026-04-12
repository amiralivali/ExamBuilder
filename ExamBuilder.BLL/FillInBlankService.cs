using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Entities;
using ExamBuilder.DAL.Repositorys;
using ExamBuilder.Shared;
using ExamBuilder.Shared.DTOClases;
using ExamBuilder.Shared.InformationClases;

namespace ExamBuilder.BLL
{
    public class FillInBlankService
    {
        FillInBlankRepository repository;
        public FillInBlankService()
        {
            repository = new FillInBlankRepository();
        }
        public async Task<OprationResult<List<ItemQuestionsDTO>>> SelectAsync(string search)
        {
            var data = await repository.SelectAsync(search);
            if (data != null)
            {
                return OprationResult<List<ItemQuestionsDTO>>.Success(data);
            }
            else
            {
                return OprationResult<List<ItemQuestionsDTO>>.RunTimeError();
            }
        }
        public async Task<OprationResult> InsertAsync(QuestionInfo info, List<FillInBlankItemInfo> items)
        {
            var newQuestion = info.MapToFillInBlank();
            var newItems = new List<FillInBlankItem>();
            foreach (var item in items)
            {
                newItems.Add(item.MapToFillInBlank());
            }
            var checkData = await CheckDuplicateAsync(info.QuestionText, info.LessonId, newItems);
            if (checkData.IsSuccess)
            {
                var checkInsert = await repository.InsertAsync(newQuestion, newItems);
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
        public async Task<OprationResult> UpdateAsync(QuestionInfo info, List<FillInBlankItemInfo> items)
        {
            var newQuestion = info.MapToFillInBlank();
            var newItems = new List<FillInBlankItem>();
            foreach (var item in items)
            {
                newItems.Add(item.MapToFillInBlank());
            }
            var checkData = await CheckDuplicateAsync(info.QuestionText, info.LessonId, newItems, info.ID);
            if (checkData.IsSuccess)
            {
                var checkUpdate = await repository.UpdateAsync(newQuestion, newItems);
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
            var check = await repository.DeleteItemAsync(id);
            if (check)
            {
                return OprationResult.Success(Messages.Delete);
            }
            else
            {
                return OprationResult.RunTimeError();
            }
        }
        public async Task<OprationResult> CheckDuplicateAsync(string questionText, int lessonId, List<FillInBlankItem> items, int questionId = 0)
        {
            bool duplicate;
            if (questionId == 0)
            {
                duplicate = await repository.CheckDuplicateAsync(questionText, lessonId, items);
            }
            else
            {
                duplicate = await repository.CheckDuplicateAsync(questionText, lessonId, items, questionId);
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
