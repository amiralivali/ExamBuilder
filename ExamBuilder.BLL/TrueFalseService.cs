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
    public class TrueFalseService : ISelectDTO
    {
        TrueFalseRepository repository;
        public TrueFalseService()
        {
            repository = new TrueFalseRepository();
        }

        public async Task<OprationResult<List<QuestionDTO>>> SelectAsync(string search, string grade, string bookName, string lessonName)
        {
            var data = await repository.SelectAsync(search, grade, bookName, lessonName);
            if (data != null)
            {
                return OprationResult<List<QuestionDTO>>.Success(data);
            }
            else
            {
                return OprationResult<List<QuestionDTO>>.RunTimeError();
            }
        }
        public async Task<OprationResult<List<TrueFalseItemInfo>>> SelectItemAsync(int questionId)
        {
            var data = await repository.SelectItemsAsync(questionId);
            if (data != null)
            {
                return OprationResult<List<TrueFalseItemInfo>>.Success(data.MapToTrueFalse());
            }
            else
            {
                return OprationResult<List<TrueFalseItemInfo>>.RunTimeError();
            }
        }
        public async Task<OprationResult> InsertAsync(QuestionInfo question,List<TrueFalseItemInfo> items)
        { 
            var newQuestion = question.MapToTrueFalse();
            var newItems = items.MapToTrueFalse();
            var checkData = await CheckDuplicateAsync(question.QuestionText, question.LessonId, newItems);
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
        public async Task<OprationResult> UpdateAsync(QuestionInfo question, List<TrueFalseItemInfo> items)
        {
            var newQuestion = question.MapToTrueFalse();
            var newItems = items.MapToTrueFalse();
            var checkData = await CheckDuplicateAsync(question.QuestionText, question.LessonId, newItems, question.ID);
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
        public async Task<OprationResult> CheckDuplicateAsync(string questionText, int lessonId, List<TrueFalseItem> items, int questionId = 0)
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
