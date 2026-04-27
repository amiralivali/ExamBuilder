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
        public static OptionalItemInfo MaptoOptional(this OptionalItem info)
        {
            return new OptionalItemInfo
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
        public static List<FillInBlankItem> MapToFillInBlank(this List<FillInBlankItemInfo> items)
        {
            var list = new List<FillInBlankItem>();
            foreach (var item in items)
            {
                list.Add(new FillInBlankItem()
                {
                    Id = item.Id,
                    Text = item.Text,
                    FillInBlankQuestionId = item.QuestionId
                });
            }
            return list;
        }
        public static List<FillInBlankItemInfo> MapToFillInBlank(this List<FillInBlankItem> items)
        {
            var list = new List<FillInBlankItemInfo>();
            foreach (var item in items)
            {
                list.Add(new FillInBlankItemInfo()
                {
                    Id = item.Id,
                    Text = item.Text,
                    QuestionId = item.FillInBlankQuestionId
                });
            }
            return list;
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
        public static List<MatchingItem> MapToMatching(this List<MatchingItemInfo> items)
        {
            var list = new List<MatchingItem>();
            foreach (var item in items)
            {
                list.Add(new MatchingItem()
                {
                    Id = item.Id,
                    LeftText = item.LeftText,
                    RightText = item.RightText,
                    MatchingQuestionId = item.QuestionId
                });
            }
            return list;
        }
        public static List<MatchingItemInfo> MapToMatching(this List<MatchingItem> items)
        {
            var list = new List<MatchingItemInfo>();
            foreach (var item in items)
            {
                list.Add(new MatchingItemInfo()
                {
                    Id = item.Id,
                    LeftText = item.LeftText,
                    RightText = item.RightText,
                    QuestionId = item.MatchingQuestionId
                });
            }
            return list;
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
        public static List<TrueFalseItem> MapToTrueFalse(this List<TrueFalseItemInfo> items)
        {
            var list = new List<TrueFalseItem>();
            foreach (var item in items)
            {
                list.Add(new TrueFalseItem()
                {
                    Id = item.Id,
                    Text = item.Text,
                    TrueFalseQuestionId = item.QuestionId
                });
            }
            return list;
        }
        public static List<TrueFalseItemInfo> MapToTrueFalse(this List<TrueFalseItem> items)
        {
            var list = new List<TrueFalseItemInfo>();
            foreach (var item in items)
            {
                list.Add(new TrueFalseItemInfo()
                {
                    Id = item.Id,
                    Text = item.Text,
                    QuestionId = item.TrueFalseQuestionId
                });
            }
            return list;
        }
    }
}
