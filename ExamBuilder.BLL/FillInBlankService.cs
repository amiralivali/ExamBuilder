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
        public async Task<OprationResult> InsertAsync(QuestionInfo info, List<ItemQuestionInfo> items)
        {
            var newQuestion = info.MapToFillInBlank();
            List<FillInBlankItem> newItems = new List<FillInBlankItem>();
            foreach (var item in items)
            {
                newItems.Add(item.MapToFillInBlank());
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
        public async Task<OprationResult> UpdateAsync(QuestionInfo info, List<ItemQuestionInfo> items)
        {
            var newQuestion = info.MapToFillInBlank();
            List<FillInBlankItem> newItems = new List<FillInBlankItem>();
            foreach (var item in items)
            {
                newItems.Add(item.MapToFillInBlank());
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
