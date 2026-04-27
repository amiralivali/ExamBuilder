using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Entities;
using ExamBuilder.DAL.Repositorys;
using ExamBuilder.Shared.DTOClases;
using ExamBuilder.Shared.InformationClases;
using ExamBuilder.Shared;

namespace ExamBuilder.BLL
{
    public class MatchingService : ISelectDTO
    {
        MatchingRepository repository;
        public MatchingService()
        {
            repository = new MatchingRepository();
        }

        public async Task<OprationResult<List<QuestionDTO>>> SelectAsync(string search, string grade, string bookName, string lessonName)
        {
            var data = await repository.SelectAsync(search,grade,bookName,lessonName);
            if (data != null)
            {
                return OprationResult<List<QuestionDTO>>.Success(data);
            }
            else
            {
                return OprationResult<List<QuestionDTO>>.RunTimeError();
            }
        }
        public async Task<OprationResult<List<MatchingItemInfo>>> SelectItemAsync(int questionId)
        {
            var data = await repository.SelectItemsAsync(questionId);
            if (data != null)
            {
                return OprationResult<List<MatchingItemInfo>>.Success(data.MapToMatching());
            }
            else
            {
                return OprationResult<List<MatchingItemInfo>>.RunTimeError();
            }
        }

        public async Task<OprationResult> InsertAsync(QuestionInfo info, List<MatchingItemInfo> items)
        {
            var newQuestion = info.MapToMatching();
            var newItems = items.MapToMatching();
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
        public async Task<OprationResult> UpdateAsync(QuestionInfo info, List<MatchingItemInfo> items)
        {
            var newQuestion = info.MapToMatching();
            var newItems = items.MapToMatching();
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
        public async Task<OprationResult> CheckDuplicateAsync(string questionText, int lessonId, List<MatchingItem> items, int questionId = 0)
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
