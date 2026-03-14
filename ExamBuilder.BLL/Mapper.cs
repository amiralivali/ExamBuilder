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
                ID = info.ID,
                Title = info.Title,
                GradeID = info.GradeID,
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
                    ID = lesson.ID,
                    Title = lesson.Title,
                    LessonCount = lesson.LessonCount,
                    BookID = lesson.BookID,
                });
            }
            return list;
        }
        public static Lesson MapToLesson(this LessonInfo info)
        {
            return new Lesson() 
            {
                ID = info.ID,
                Title = info.Title,
                LessonCount = info.LessonCount,
                BookID = info.BookID,
            };
        }
        public static DescriptiveQuestion MapToDescriptive(this QuestionInfo info)
        {
            return new DescriptiveQuestion
            {
                ID = info.ID,
                DifficultyLevelID = info.DifficultyLevelID,
                LessonID = info.LessonID,
                Picture=info.Picture,
                QuestionText = info.QuestionText,
            };
        }
        public static ShortQuestion MapToShortAnswer(this QuestionInfo info)
        {
            return new ShortQuestion
            {
                ID = info.ID,
                DifficultyLevelID = info.DifficultyLevelID,
                LessonID = info.LessonID,
                Picture = info.Picture,
                QuestionText = info.QuestionText,
            };
        }
        public static OptionalQuestion MapToOptional(this OptionalInfo info)
        {
            return new OptionalQuestion
            {
                ID = info.ID,
                DifficultyLevelID = info.DifficultyLevelID,
                LessonID = info.LessonID,
                Picture = info.Picture,
                QuestionText = info.QuestionText,
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
                ID = info.ID,
                DifficultyLevelID = info.DifficultyLevelID,
                LessonID = info.LessonID,
                Picture = info.Picture,
                QuestionText = info.QuestionText,
            };
        }
        public static FillInBlankItem MapToFillInBlank(this ItemQuestionInfo info)
        {
            return new FillInBlankItem
            {
                ID = info.ID,
                Text = info.Text,
                FillInBlankQuestionID = info.QuestionID,
            };
        }
        public static MatchingQuestion MapToMatching(this QuestionInfo info)
        {
            return new MatchingQuestion
            {
                ID = info.ID,
                DifficultyLevelID = info.DifficultyLevelID,
                LessonID = info.LessonID,
                Picture = info.Picture,
                QuestionText = info.QuestionText,
            };
        }
        public static MatchingItem MapToMatching(this MatchingItemInfo info)
        {
            return new MatchingItem
            {
                ID = info.ID,
                MatchingQuestionID = info.QuestionID,
                RightText = info.RightText,
                LeftText = info.LeftText,
            };
        }
        public static TrueFalseQuestion MapToTrueFalse(this QuestionInfo info)
        {
            return new TrueFalseQuestion
            {
                ID = info.ID,
                LessonID = info.LessonID,
                Picture = info.Picture,
                DifficultyLevelID = info.DifficultyLevelID,
                QuestionText = info.QuestionText,
            };
        }
        public static TrueFalseItem MapToTrueFalse(this ItemQuestionInfo info)
        {
            return new TrueFalseItem
            {
                ID = info.ID,
                Text = info.Text,
                TrueFalseQuestionID = info.QuestionID
            };
        }
    }
}
