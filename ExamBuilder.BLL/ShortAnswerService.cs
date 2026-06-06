using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Repositorys;
using ExamBuilder.Shared.DTOClases;
using ExamBuilder.Shared.InformationClases;
using ExamBuilder.Shared;
using ExamBuilder.BLL.Interface;

namespace ExamBuilder.BLL
{
    public class ShortAnswerService : ISelectQuestions, IDeleteQuestion
    {
        ShortAnswerRepository repository;
        public ShortAnswerService()
        {
            repository = new ShortAnswerRepository();
        }

        public async Task<OprationResult<List<QuestionDTO>>> SelectFilterQuestionsAsync(string search, string grade, string book, string lesson)
        {
            var data = await repository.SelectFilterQuestionsAsync(search,grade,book,lesson);
            if (data != null)
            {
                return OprationResult<List<QuestionDTO>>.Success(data);
            }
            else
            {
                return OprationResult<List<QuestionDTO>>.RunTimeError();
            }
        }
        public async Task<OprationResult<QuestionDTO>> SelectQuestionAsync(int id)
        {
            var data = await repository.SelectQuestionAsync(id);
            if (data != null)
            {
                return OprationResult<QuestionDTO>.Success(data);
            }
            else
            {
                return OprationResult<QuestionDTO>.RunTimeError();
            }
        }

        public async Task<OprationResult> DeleteQuestionAsync(int id)
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

        public async Task<OprationResult> InsertAsync(QuestionInfo info)
        {
            var data = info.MapToShortAnswer();
            var checkData = await CheckDuplicateAsync(info.QuestionText, info.LessonId);
            if (checkData.IsSuccess)
            {
                var checkInsert = await repository.InsertAsync(data);
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

        public async Task<OprationResult> UpdateAsync(QuestionInfo info)
        {
            var data = info.MapToShortAnswer();
            var checkData = await CheckDuplicateAsync(info.QuestionText, info.LessonId, info.ID);
            if (checkData.IsSuccess)
            {
                var checkUpdate = await repository.UpdateAsync(data);
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
        public async Task<OprationResult> CheckDuplicateAsync(string questionText, int lessonId, int questionId = 0)
        {
            bool duplicate;
            if (questionId == 0)
            {
                duplicate = await repository.CheckDuplicateAsync(questionText, lessonId);
            }
            else
            {
                duplicate = await repository.CheckDuplicateAsync(questionText, lessonId, questionId);
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

        public async Task<OprationResult<List<QuestionDTO>>> SelectQuestionsFromLessonAsync(List<int> lessonIds)
        {
            var data = await repository.SelectQuestionsFromLessonAsync(lessonIds);
            if (data != null)
            {
                return OprationResult<List<QuestionDTO>>.Success(data);
            }
            else
            {
                return OprationResult<List<QuestionDTO>>.RunTimeError();
            }
        }
    }
}
