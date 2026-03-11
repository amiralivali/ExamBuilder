using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Repositorys;
using ExamBuilder.Shared.DTOClases;
using ExamBuilder.Shared.InformationClases;
using ExamBuilder.Shared;

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

        public async Task<OprationResult> InsertAsync(OptionalInfo info)
        {
            var data = info.MapToOptional();
            var check = await repository.InsertAsync(data);
            if (check)
            {
                return OprationResult.Success(Messages.Insert);
            }
            else
            {
                return OprationResult.RunTimeError();
            }
        }

        public async Task<OprationResult> UpdateAsync(OptionalInfo info)
        {
            var data = info.MapToOptional();
            var check = await repository.UpdateAsync(data);
            if (check)
            {
                return OprationResult.Success(Messages.Update);
            }
            else
            {
                return OprationResult.RunTimeError();
            }
        }
    }
}
