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
    public class TrueFalseService
    {
        TrueFalseRepository repository;
        public TrueFalseService()
        {
            repository = new TrueFalseRepository();
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
        public async Task<OprationResult> InsertAsync(QuestionInfo question,List<ItemQuestionInfo> items)
        { 
            var newQuestion=question.MapToTrueFalse();
            List<TrueFalseItem> newItems=new List<TrueFalseItem>();
            foreach (var item in items)
            {
                newItems.Add(item.MapToTrueFalse());
            }
            var check = await repository.InsertAsync(newQuestion, newItems);
            if (check)
            {
                return OprationResult.Success(Messages.Insert);
            }
            else
            {
                return OprationResult.RunTimeError();
            }
        }
        public async Task<OprationResult> UpdateAsync(QuestionInfo question, List<ItemQuestionInfo> items)
        {
            var newQuestion = question.MapToTrueFalse();
            List<TrueFalseItem> newItems = new List<TrueFalseItem>();
            foreach (var item in items)
            {
                newItems.Add(item.MapToTrueFalse());
            }
            var check = await repository.UpdateAsync(newQuestion, newItems);
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
    }
}
