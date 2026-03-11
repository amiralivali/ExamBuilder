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
    public class MatchingService
    {
        MatchingRepository repository;
        public MatchingService()
        {
            repository = new MatchingRepository();
        }
        public async Task<OprationResult<List<MatchingDTO>>> SelectAsync(string search)
        {
            var data = await repository.SelectAsync(search);
            if (data != null)
            {
                return OprationResult<List<MatchingDTO>>.Success(data);
            }
            else
            {
                return OprationResult<List<MatchingDTO>>.RunTimeError();
            }
        }
        public async Task<OprationResult> InsertAsync(QuestionInfo info, List<MatchingItemInfo> items)
        {
            var newQuestion = info.MapToMatching();
            List<MatchingItem> newItems = new List<MatchingItem>();
            foreach (var item in items)
            {
                newItems.Add(item.MapToMatching());
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
        public async Task<OprationResult> UpdateAsync(QuestionInfo info, List<MatchingItemInfo> items)
        {
            var newQuestion = info.MapToMatching();
            List<MatchingItem> newItems = new List<MatchingItem>();
            foreach (var item in items)
            {
                newItems.Add(item.MapToMatching());
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
