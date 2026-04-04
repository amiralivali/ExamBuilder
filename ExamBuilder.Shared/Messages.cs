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
        public const string SelectItemError = "لطفا آیتم های سوال را ایجاد کنید";
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
        public static List<string> TrueFalseText_Suggestions = new List<string>()
        {
              "درستی یا نادرستی هر یک از گزاره‌های زیر را با علامت (ص) برای صحیح و (غ) برای غلط مشخص کنید.",
              "لطفاً تعیین کنید که آیا هر جمله زیر درست است یا نادرست.",
              "برای هر مورد، مشخص کنید که گزاره بیان شده صحیح است یا خیر.",
              "با توجه به اطلاعات داده شده، موارد زیر را به عنوان درست یا نادرست طبقه‌بندی کنید.",
              "درستی عبارات زیر را بسنجید و پاسخ خود را (درست/نادرست) مشخص نمایید."
        };
        public static List<string> FillInBlankText_Suggestions = new List<string>()
        {
              "جاهای خالی مشخص شده در جملات زیر را با کلمه یا عبارت مناسب پر کنید.",
              "جملات زیر را با استفاده از واژگان مناسب تکمیل نمایید.",
              "کلمه یا عبارتی را که جمله زیر را به درستی کامل می‌کند، بنویسید.",
              "لطفاً جمله زیر را با انتخاب بهترین گزینه از بین گزینه‌های پیشنهادی (در صورت وجود) یا با نوشتن پاسخ مناسب، کامل کنید.",
              "برای هر جای خالی، مناسب‌ترین کلمه را انتخاب یا بنویسید."
        };
        public static List<string> MatchingText_Suggestions = new List<string>()
        {
              "ستون الف را با توجه به معانی و توضیحات ارائه شده در ستون ب، به درستی وصل کنید.",
              "مفاهیم موجود در ستون سمت چپ را به موارد متناظرشان در ستون سمت راست متصل نمایید.",
              "لطفاً موارد زیر را با گزینه‌های صحیحشان تطبیق دهید.",
              "بین موارد ستون الف و ستون ب، ارتباط منطقی برقرار کنید.",
              "هر مورد در ستون ‘الف’ را به مورد صحیح و متناظر آن در ستون ‘ب’ وصل کنید."
        };
        public static List<string> AllQuestionText_Suggestions =
               TrueFalseText_Suggestions
               .Concat(FillInBlankText_Suggestions)
               .Concat(MatchingText_Suggestions)
               .ToList();
        public const string Blank_Marker = "#BLANK#"; // نشانگر کوتاه برای جاخالی
    }
}
