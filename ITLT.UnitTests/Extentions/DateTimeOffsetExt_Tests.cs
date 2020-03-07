namespace ITLT.UnitTests.Extentions
{
    using ITLT.ExtentionMethods;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Test for class DateTimeOffsetExtentions
    /// </summary>
    public class DateTimeOffsetExt_Tests : NUnitBaseTests
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

        protected DateTimeOffset DateTested => new DateTimeOffset(_year, _month, _day, _hour, _minute, _second, _offset);

        protected DateTimeOffset DateTestedUtc => new DateTimeOffset(_year, _month, _day, _hour, _minute, _second, _offsetUtc);

        protected DateTimeOffset DayStart => new DateTimeOffset(_year, _month, _day, 0, 0, 0, _offset);

        protected DateTimeOffset DayStartUtc => new DateTimeOffset(_year, _month, _day, 0, 0, 0, _offsetUtc);

        protected DateTimeOffset MonthStart => new DateTimeOffset(_year, _month, 1, 0, 0, 0, _offset);

        protected DateTimeOffset MonthStartUtc => new DateTimeOffset(_year, _month, 1, 0, 0, 0, _offsetUtc);

        protected DateTimeOffset QuarterStart => this.GetStartOfQuarter(MonthStart);

        protected DateTimeOffset QuarterStartUtc => this.GetStartOfQuarter(MonthStartUtc);

        protected DateTimeOffset YearStart => new DateTimeOffset(_year, 1, 1, 0, 0, 0, _offset);

        protected DateTimeOffset YearStartUtc => new DateTimeOffset(_year, 1, 1, 0, 0, 0, _offsetUtc);

        #endregion

        #region Day Method Tests 

        [Test]
        public void DayStart_Test()
        {
            this.AreEqual(DateTested.DayStart(), DayStart, "DayStart");
            this.AreEqual(DateTestedUtc.DayStart(), DayStartUtc, "DayStart");
        }

        [Test]
        public void DayStartAt_Test()
        {
            for (int i = -5; i < 5; i++)
            {
                this.AreEqual(DateTested.DayStartAt(i), DayStart.AddDays(i), "DayStartAt");
                this.AreEqual(DateTestedUtc.DayStartAt(i), DayStartUtc.AddDays(i), "DayStartAt");
            }
        }

        [Test]
        public void DayStartPrev_Test()
        {
            this.AreEqual(DateTested.DayStartPrev(), DayStart.AddDays(-1), "DayStartPrev");
            this.AreEqual(DateTestedUtc.DayStartPrev(), DayStartUtc.AddDays(-1), "DayStartPrev");
        }

        [Test]
        public void DayStartNext_Test()
        {
            this.AreEqual(DateTested.DayStartNext(), DayStart.AddDays(1), "DayStartNext");
            this.AreEqual(DateTestedUtc.DayStartNext(), DayStartUtc.AddDays(1), "DayStartNext");
        }

        #endregion

        #region Month Method Tests 

        [Test]
        public void MonthStart_Test()
        {
            this.AreEqual(DateTested.MonthStart(), MonthStart, "MonthStart");
            this.AreEqual(DateTestedUtc.MonthStart(), MonthStartUtc, "MonthStart");
        }

        [Test]
        public void MonthStartAt_Test()
        {
            for (int i = -5; i < 5; i++)
            {
                this.AreEqual(DateTested.MonthStartAt(i), MonthStart.AddMonths(i), "MonthStartAt");
                this.AreEqual(DateTestedUtc.MonthStartAt(i), MonthStartUtc.AddMonths(i), "MonthStartAt");
            }
        }

        [Test]
        public void MonthStartPrev_Test()
        {
            this.AreEqual(DateTested.MonthStartPrev(), MonthStart.AddMonths(-1), "MonthStartPrev");
            this.AreEqual(DateTestedUtc.MonthStartPrev(), MonthStartUtc.AddMonths(-1), "MonthStartPrev");
        }

        [Test]
        public void MonthStartNext_Test()
        {
            this.AreEqual(DateTested.MonthStartNext(), MonthStart.AddMonths(1), "MonthStartNext");
            this.AreEqual(DateTestedUtc.MonthStartNext(), MonthStartUtc.AddMonths(1), "MonthStartNext");
        }

        #endregion

        #region Quarter Method Tests

        [Test]
        public void QuarterStart_Test()
        {
            this.AreEqual(DateTested.QuarterStart(), QuarterStart, "QuarterStart");
            this.AreEqual(DateTestedUtc.QuarterStart(), QuarterStartUtc, "QuarterStart");
        }

        [Test]
        public void QuarterStartAt_Test()
        {
            for (int i = -5; i < 5; i++)
            {
                this.AreEqual(DateTested.QuarterStartAt(i), QuarterStart.AddMonths(i * 3), "QuarterStartAt");
                this.AreEqual(DateTestedUtc.QuarterStartAt(i), QuarterStartUtc.AddMonths(i * 3), "QuarterStartAt");
            }
        }

        [Test]
        public void QuarterStartPrev_Test()
        {
            this.AreEqual(DateTested.QuarterStartPrev(), QuarterStart.AddMonths(-3), "QuarterStartPrev");
            this.AreEqual(DateTestedUtc.QuarterStartPrev(), QuarterStartUtc.AddMonths(-3), "QuarterStartPrev");
        }

        [Test]
        public void QuarterStartNext_Test()
        {
            this.AreEqual(DateTested.QuarterStartNext(), QuarterStart.AddMonths(3), "QuarterStartNext");
            this.AreEqual(DateTestedUtc.QuarterStartNext(), QuarterStartUtc.AddMonths(3), "QuarterStartNext");
        }

        #endregion

        #region Year Method Tests 

        [Test]
        public void YearStart_Test()
        {
            this.AreEqual(DateTested.YearStart(), YearStart, "YearStart");
            this.AreEqual(DateTestedUtc.YearStart(), YearStartUtc, "YearStart");
        }

        [Test]
        public void YearStartAt_Test()
        {
            for (int i = -5; i < 5; i++)
            {
                this.AreEqual(DateTested.YearStartAt(i), YearStart.AddYears(i), "YearStartAt");
                this.AreEqual(DateTestedUtc.YearStartAt(i), YearStartUtc.AddYears(i), "YearStartAt");
            }
        }

        [Test]
        public void YearStartPrev_Test()
        {
            this.AreEqual(DateTested.YearStartPrev(), YearStart.AddYears(-1), "YearStartPrev");
            this.AreEqual(DateTestedUtc.YearStartPrev(), YearStartUtc.AddYears(-1), "YearStartPrev");
        }

        [Test]
        public void YearStartNext_Test()
        {
            this.AreEqual(DateTested.YearStartNext(), YearStart.AddYears(1), "YearStartNext");
            this.AreEqual(DateTestedUtc.YearStartNext(), YearStartUtc.AddYears(1), "YearStartNext");
        }

        #endregion

        #region Private Methods 

        protected void AreEqual(DateTimeOffset value1, DateTimeOffset value2, string methodName)
        {
            Assert.AreEqual(value1, value2, $"{methodName}: {value1} is not {value2}");
        }

        protected DateTimeOffset GetStartOfQuarter(DateTimeOffset value)
        {
            switch (value.Month)
            {
                case 1:
                case 2:
                case 3:
                    return new DateTimeOffset(value.Year, 1, 1, 0, 0, 0, value.Offset);
                case 4:
                case 5:
                case 6:
                    return new DateTimeOffset(value.Year, 1, 1, 0, 0, 0, value.Offset);
                case 7:
                case 8:
                case 9:
                    return new DateTimeOffset(value.Year, 1, 1, 0, 0, 0, value.Offset);
                case 10:
                case 11:
                case 12:
                    return new DateTimeOffset(value.Year, 1, 1, 0, 0, 0, value.Offset);
                default:
                    throw new Exception(@"¯\_(ツ)_/¯");
            }
        }

        #endregion
    }
}
