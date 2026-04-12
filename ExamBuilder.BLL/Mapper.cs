using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamBuilder.DAL.Entities;
using ExamBuilder.Shared.InformationClases;

namespace ExamBuilder.BLL
{
    public static class Mapper
    {
        public static Book MapToBook(this BookInfo info)
        {
            return new Book
            {
                Id = info.Id,
                Title = info.Title,
                GradeId = info.GradeId,
                GradeInfo = info.GradeInfo,
            };
        }
        public static List<Lesson> MapToLesson(this List<LessonInfo> lessons)
        {
            var list = new List<Lesson>();
            foreach (var lesson in lessons)
            {
                list.Add(new Lesson()
                {
                    Id = lesson.Id,
                    Title = lesson.Title,
                    LessonCount = lesson.LessonCount,
                    BookId = lesson.BookId,
                });
            }
            return list;
        }
        public static Lesson MapToLesson(this LessonInfo info)
        {
            return new Lesson() 
            {
                Id = info.Id,
                Title = info.Title,
                LessonCount = info.LessonCount,
                BookId = info.BookId,
            };
        }
        public static DescriptiveQuestion MapToDescriptive(this QuestionInfo info)
        {
            return new DescriptiveQuestion
            {
                Id = info.ID,
                DifficultyLevelId = info.DifficultyLevelId,
                LessonID = info.LessonId,
                Picture=info.Picture,
                QuestionText = info.QuestionText,
            };
        }
        public static ShortQuestion MapToShortAnswer(this QuestionInfo info)
        {
            return new ShortQuestion
            {
                Id = info.ID,
                DifficultyLevelId = info.DifficultyLevelId,
                LessonID = info.LessonId,
                Picture = info.Picture,
                QuestionText = info.QuestionText,
            };
        }
        public static OptionalQuestion MapToOptional(this QuestionInfo info)
        {
            return new OptionalQuestion
            {
                Id = info.ID,
                DifficultyLevelId = info.DifficultyLevelId,
                LessonID = info.LessonId,
                Picture = info.Picture,
                QuestionText = info.QuestionText,
            };
        }
        public static OptionalItem MaptoOptional(this OptionalItemInfo info)
        {
            return new OptionalItem
            {
                OptionalId = info.OptionalId,
                Option1 = info.Option1,
                Option2 = info.Option2,
                Option3 = info.Option3,
                Option4 = info.Option4,
            };
        }
        public static FillInBlankQuestion MapToFillInBlank(this QuestionInfo info)
        {
            return new FillInBlankQuestion
            {
                Id = info.ID,
                DifficultyLevelId = info.DifficultyLevelId,
                LessonID = info.LessonId,
                Picture = info.Picture,
                QuestionText = info.QuestionText,
            };
        }
        public static FillInBlankItem MapToFillInBlank(this FillInBlankItemInfo info)
        {
            return new FillInBlankItem
            {
                Id = info.Id,
                Text = info.Text,
                FillInBlankQuestionId = info.QuestionId,
            };
        }
        public static MatchingQuestion MapToMatching(this QuestionInfo info)
        {
            return new MatchingQuestion
            {
                Id = info.ID,
                DifficultyLevelId = info.DifficultyLevelId,
                LessonID = info.LessonId,
                Picture = info.Picture,
                QuestionText = info.QuestionText,
            };
        }
        public static MatchingItem MapToMatching(this MatchingItemInfo info)
        {
            return new MatchingItem
            {
                Id = info.Id,
                MatchingQuestionId = info.MatchingQuestionId,
                RightText = info.RightText,
                LeftText = info.LeftText,
            };
        }
        public static TrueFalseQuestion MapToTrueFalse(this QuestionInfo info)
        {
            return new TrueFalseQuestion
            {
                ID = info.ID,
                LessonId = info.LessonId,
                Picture = info.Picture,
                DifficultyLevelId = info.DifficultyLevelId,
                QuestionText = info.QuestionText,
            };
        }
        public static TrueFalseItem MapToTrueFalse(this TrueFalseItemInfo info)
        {
            return new TrueFalseItem
            {
                Id = info.Id,
                Text = info.Text,
                TrueFalseQuestionId = info.QuestionId
            };
        }
    }
}
