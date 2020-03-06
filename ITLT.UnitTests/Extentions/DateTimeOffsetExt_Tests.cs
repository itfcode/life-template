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

        protected DateTimeOffset DateTimeOffsetTested => new DateTimeOffset(_year, _month, _day, _hour, _minute, _second, _offset);

        protected DateTimeOffset DateTimeOffsetUtcTested => new DateTimeOffset(_year, _month, _day, _hour, _minute, _second, _offsetUtc);

        protected DateTimeOffset DayStart => new DateTimeOffset(_year, _month, _day, 0, 0, 0, _offset);
        
        protected DateTimeOffset DayStartUtc => new DateTimeOffset(_year, _month, _day, 0, 0, 0, _offsetUtc);

        protected DateTimeOffset MonthStart => new DateTimeOffset(_year, _month, 1, 0, 0, 0, _offset);

        protected DateTimeOffset MonthStartUtc => new DateTimeOffset(_year, _month, 1, 0, 0, 0, _offsetUtc);

        protected DateTimeOffset YearStart => new DateTimeOffset(_year, 1, 1, 0, 0, 0, _offset);

        protected DateTimeOffset YearStartUtc => new DateTimeOffset(_year, 1, 1, 0, 0, 0, _offsetUtc);

        #endregion

        #region Day Method Tests 

        [Test]
        public void DayStart_Test()
        {
            var dayStartCalculated = DateTimeOffsetTested.DayStart();
            var dayStartUtcCalculated = DateTimeOffsetUtcTested.DayStart();

            Assert.IsTrue(dayStartCalculated == DayStart, $"DayStart: {dayStartCalculated} is not {DayStart}");
            Assert.IsTrue(dayStartUtcCalculated == DayStartUtc, $"DayStart: {dayStartUtcCalculated} is not {DayStartUtc}");
        }

        [Test]
        public void DayStartAt_Test()
        {
            for (int i = 0; i < 10; i++)
            {
                var dayCalculated = DateTimeOffsetTested.DayStartAt(i);
                var dayUtcCalculated = DateTimeOffsetUtcTested.DayStartAt(i);
                var dayStart = DayStart.AddDays(i);
                var dayStartUtc = DayStartUtc.AddDays(i);

                Assert.IsTrue(dayCalculated == dayStart, $"DayStartAt: {dayCalculated} is not {dayStart}");
                Assert.IsTrue(dayUtcCalculated == dayStartUtc, $"DayStartAt: {dayUtcCalculated} is not {dayStartUtc}");
            }
        }

        [Test]
        public void DayStartPrev_Test()
        {
            var dayCalculated = DateTimeOffsetTested.DayStartPrev();
            var dayUtcCalculated = DateTimeOffsetUtcTested.DayStartPrev();
            var dayStart = DayStart.AddDays(-1);
            var dayStartUtc = DayStartUtc.AddDays(-1);

            Assert.IsTrue(dayCalculated == dayStart, $"DayStartPrev: {dayCalculated} is not {dayStart}");
            Assert.IsTrue(dayUtcCalculated == dayStartUtc, $"DayStartPrev: {dayUtcCalculated} is not {dayStartUtc}");
        }

        [Test]
        public void DayStartNext_Test()
        {
            var dayCalculated = DateTimeOffsetTested.DayStartNext();
            var dayUtcCalculated = DateTimeOffsetUtcTested.DayStartNext();
            var dayStart = DayStart.AddDays(1);
            var dayStartUtc = DayStartUtc.AddDays(1);

            Assert.IsTrue(dayCalculated == dayStart, $"DayStartPrev: {dayCalculated} is not {dayStart}");
            Assert.IsTrue(dayUtcCalculated == dayStartUtc, $"DayStartPrev: {dayUtcCalculated} is not {dayStartUtc}");
        }

        #endregion

        #region Month Method Tests 

        [Test]
        public void MonthStart_Test() 
        {
            var monthStartCalculated = DateTimeOffsetTested.MonthStart();
            var monthStartCalculatedUtc = DateTimeOffsetUtcTested.MonthStart();

            Assert.IsTrue(monthStartCalculated == MonthStart, $"MonthStart : {monthStartCalculated} is not {MonthStart}");
            Assert.IsTrue(monthStartCalculatedUtc == MonthStartUtc, $"MonthStart : {monthStartCalculatedUtc} is not {MonthStartUtc}");
        }

        [Test]
        public void MonthStartAt_Test()
        {
            for (int i = 0; i < 10; i++)
            {
                var monthStartCalculated = DateTimeOffsetTested.MonthStartAt(i);
                var monthStartCalculatedUtc = DateTimeOffsetUtcTested.MonthStartAt(i);
                var monthStart = MonthStart.AddMonths(i);
                var monthStartUtc = MonthStartUtc.AddMonths(i);

                Assert.IsTrue(monthStartCalculated == monthStart, $"MonthStartAt: {monthStartCalculated} is not {monthStart}");
                Assert.IsTrue(monthStartCalculatedUtc == monthStartUtc, $"MonthStartAt: {monthStartCalculatedUtc} is not {monthStartUtc}");
            }
        }

        [Test]
        public void MonthStartPrev_Test()
        {

        }

        [Test]
        public void MonthStartNext_Test()
        {

        }

        #endregion
    }
}
