namespace ITLT.UnitTests.Extentions
{
    using ITLT.ExtentionMethods;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Test for class DateTimeOffsetExtentions
    /// </summary>
    public class DateTimeExtention_Tests : BaseDateTimeExtensionMethodTests
    {

        #region Private Fields 

        private readonly int _year = DateTime.Now.Year;

        private readonly int _month = DateTime.Now.Month;

        private readonly int _day = DateTime.Now.Day;

        private readonly int _hour = DateTime.Now.Hour;

        private readonly int _minute = DateTime.Now.Minute;

        private readonly int _second = DateTime.Now.Second;

        TimeSpan _offset = new TimeSpan(3, 0, 0);

        TimeSpan _offsetUtc = new TimeSpan(0, 0, 0);

        #endregion

        #region Protected Properties 

        protected DateTime DateTested => new DateTime(_year, _month, _day, _hour, _minute, _second);

        protected DateTime DayStart => new DateTime(_year, _month, _day, 0, 0, 0);

        protected DateTime DayEnd => (new DateTime(_year, _month, _day, 0, 0, 0)).AddDays(1).AddTicks(-1);

        protected DateTime WeekStart => this.GetWeekStart(DateTested);

        protected DateTime WeekEnd => WeekStart.AddDays(7).AddTicks(-1);

        protected DateTime MonthStart => new DateTime(_year, _month, 1, 0, 0, 0);

        protected DateTime MonthEnd => MonthStart.AddMonths(1).AddTicks(-1);

        protected DateTime QuarterStart => this.GetStartOfQuarter(MonthStart);

        protected DateTime QuarterEnd => QuarterStart.AddMonths(3).AddTicks(-1);

        protected DateTime YearStart => new DateTime(_year, 1, 1, 0, 0, 0);

        protected DateTime YearEnd => YearStart.AddYears(1).AddTicks(-1);

        #endregion

        #region Constructors

        public DateTimeExtention_Tests() : base(typeof(DateTimeExtentions).Assembly, typeof(DateTime))
        {
        }

        #endregion

        #region Basic 

        [Test]
        public void CheckHasAllExtentionMethods()
        {
            var missing = dateTimeMethods.Except(ExtentionMethods);

            foreach (var item in missing)
            {
                Debug.WriteLine($"{item}");
            }

            Assert.IsTrue(missing.Count() == 0);
        }

        #endregion

        #region Day Method Tests 

        [Test]
        public void DayStart_Test()
        {
            this.AreEqual(DateTested.DayStart(), DayStart, "DayStart");
            this.AreEqual(DateTested.DayStartPrev(), DayStart.AddDays(-1), "DayStartPrev");
            this.AreEqual(DateTested.DayStartNext(), DayStart.AddDays(1), "DayStartNext");

            for (int i = -5; i < 5; i++)
                this.AreEqual(DateTested.DayStartAt(i), DayStart.AddDays(i), "DayStartAt");
        }

        [Test]
        public void DayEnd_Tests()
        {
            AreEqual(DateTested.DayEnd(), DayEnd, "DayEnd");
            AreEqual(DateTested.DayEndPrev(), DayEnd.AddDays(-1), "DayEndPrev");
            AreEqual(DateTested.DayEndNext(), DayEnd.AddDays(1), "DayEndNext");

            for (int i = -5; i < 5; i++)
                AreEqual(DateTested.DayEndAt(i), DayEnd.AddDays(i), "DayEndAt");
        }

        #endregion

        #region Week Method Tests

        [Test]
        public void WeekStart_Test()
        {
            AreEqual(DateTested.WeekStart(), WeekStart, "WeekStart");
            AreEqual(DateTested.WeekStartPrev(), WeekStart.AddDays(-7), "WeekStartPrev");
            AreEqual(DateTested.WeekStartNext(), WeekStart.AddDays(7), "WeekStartNext");

            for (int i = -5; i < 5; i++)
                AreEqual(DateTested.WeekStartAt(i), WeekStart.AddDays(i * 7), "WeekStartAt");
        }

        [Test]
        public void WeekEnd_Test()
        {
            AreEqual(DateTested.WeekEnd(), WeekEnd, "WeekEnd");
            AreEqual(DateTested.WeekEndPrev(), WeekEnd.AddDays(-7), "WeekEndPrev");
            AreEqual(DateTested.WeekEndNext(), WeekEnd.AddDays(7), "WeekEndNext");

            for (int i = -5; i < 5; i++)
                AreEqual(DateTested.WeekEndAt(i), WeekEnd.AddDays(i * 7), "WeekEndAt");
        }

        #endregion

        #region Month Method Tests 

        [Test]
        public void MonthStart_Test()
        {
            AreEqual(DateTested.MonthStart(), MonthStart, "MonthStart");
            AreEqual(DateTested.MonthStartPrev(), MonthStart.AddMonths(-1), "MonthStartPrev");
            AreEqual(DateTested.MonthStartNext(), MonthStart.AddMonths(1), "MonthStartNext");

            for (int i = -5; i < 5; i++)
                AreEqual(DateTested.MonthStartAt(i), MonthStart.AddMonths(i), "MonthStartAt");
        }

        [Test]
        public void MonthEnd_Test()
        {
            AreEqual(DateTested.MonthEnd(), MonthEnd, "MonthEnd");
            AreEqual(DateTested.MonthEndPrev(), MonthEnd.AddMonths(-1), "MonthEndPrev");
            AreEqual(DateTested.MonthEndNext(), MonthEnd.AddMonths(1), "MonthEndNext");

            for (int i = -5; i < 5; i++)
                AreEqual(DateTested.MonthEndAt(i), MonthEnd.AddMonths(i), "MonthEndAt");
        }

        #endregion

        #region Quarter Method Tests

        [Test]
        public void QuarterStart_Test()
        {
            AreEqual(DateTested.QuarterStart(), QuarterStart, "QuarterStart");
            AreEqual(DateTested.QuarterStartPrev(), QuarterStart.AddMonths(-3), "QuarterStartPrev");
            AreEqual(DateTested.QuarterStartNext(), QuarterStart.AddMonths(3), "QuarterStartNext");

            for (int i = -5; i < 5; i++)
            {
                AreEqual(DateTested.QuarterStartAt(i), QuarterStart.AddMonths(i * 3), "QuarterStartAt");
            }
        }

        [Test]
        public void QuarterEnd_Test()
        {
            AreEqual(DateTested.QuarterEnd(), QuarterEnd, "QuarterEnd");
            AreEqual(DateTested.QuarterEndPrev(), QuarterEnd.AddMonths(-3), "QuarterEndPrev");
            AreEqual(DateTested.QuarterEndNext(), QuarterStart.AddMonths(6).AddTicks(-1), "QuarterEndNext");

            for (int i = -5; i < 5; i++)
            {
                AreEqual(DateTested.QuarterStartAt(i), QuarterStart.AddMonths(i * 3), "QuarterStartAt");
            }
        }

        #endregion

        #region Year Method Tests 

        [Test]
        public void YearStart_Test()
        {
            AreEqual(DateTested.YearStart(), YearStart, "YearStart");
            AreEqual(DateTested.YearStartPrev(), YearStart.AddYears(-1), "YearStartPrev");
            AreEqual(DateTested.YearStartNext(), YearStart.AddYears(1), "YearStartNext");

            for (int i = -5; i < 5; i++)
            {
                AreEqual(DateTested.YearStartAt(i), YearStart.AddYears(i), "YearStartAt");
            }
        }

        [Test]
        public void YearStartEnd_Test()
        {

        }

        #endregion

        #region Private Methods 

        private DateTime GetWeekStart(DateTime date)
        {
            var dayStart = date.Date;
            var dayNumber = (int)dayStart.DayOfWeek;
            return dayStart.AddDays(1 - (dayNumber > 0 ? dayNumber : 7));
        }

        #endregion
    }
}
