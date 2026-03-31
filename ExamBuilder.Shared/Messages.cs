using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.Shared
{
    public static class Messages
    {
        public const string RunTimeError = "مشکلی پیش آمده است.با پشتیبانی تماس بگیرید";
        public const string Success = "با موفقیت {0} شد";
        public const string Insert = "ذخیره";
        public const string Update = "ویرایش";
        public const string Delete = "حذف";
        public const string Duplicate = "{0} وارد شده با این اطلاعات قبلا ذخیره شده است";
        public const string FalseValidation = "{0} وارد شده اشتباه است";
        public const string Required = "وارد کردن {0} اجباری است";
        public const string Elementary = "ابتدایی";
        public const string MiddleSchool = "متوسطه اول";
        public const string HighSchool = "متوسطه دوم";
        public const string University = "دانشگاه";
        public const string More = "سایر";
        public const string Book="کتاب";
        public const string Lesson = "درس";
        public const string Descriptive = "تشریحی";
        public const string ShortAnswer = "کوتاه پاسخ";
        public const string DifficultyLevel = "سطح سوال";
        public const string QuestionText = "متن سوال";
        public const string Option1 = "گزینه 1";
        public const string Option2 = "گزینه 2";
        public const string Option3 = "گزینه 3";
        public const string Option4 = "گزینه 4";
        public const string RightItem = "آیتم راست";
        public const string LeftItem = "آیتم چپ";
        public const string Item = "آیتم";
        public const string BookName = "نام کتاب";
        public const string Grade = "مقطع تحصیلی";
        public const string LessonName = "نام درس";
        public const string Blank_Marker = "#BLANK#"; // نشانگر کوتاه برای جاخالی
    }
}
