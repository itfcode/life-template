namespace ITLT.ExtentionMethods
{
    using System;

    public static class DateTimeOffsetNullExtentions
    {

        #region Helper Methods

        private static DateTimeOffset? TryValue(this DateTimeOffset? self, Func<DateTimeOffset, DateTimeOffset> func)
        {
            return self.HasValue ? func(self.Value) : self;
        }

        #endregion

        #region Day 

        public static DateTimeOffset? DayStartAt(this DateTimeOffset? self, int days = 0) => self.TryValue(x => x.DayStartAt(days));

        public static DateTimeOffset? DayStart(this DateTimeOffset? self) => self.DayStartAt(0);

        public static DateTimeOffset? DayStartPrev(this DateTimeOffset? self) => self.DayStartAt(-1);

        public static DateTimeOffset? DayStartNext(this DateTimeOffset? self) => self.DayStartAt(1);

        #endregion

        #region Week 

        public static DateTimeOffset? WeekStartAt(this DateTimeOffset? self, int weeks = 0) => self.TryValue(x => x.WeekStartAt(weeks));

        public static DateTimeOffset? WeekStart(this DateTimeOffset? self) => self.WeekStartAt(0);

        public static DateTimeOffset? WeekStartPrev(this DateTimeOffset? self) => self.WeekStartAt(-1);

        public static DateTimeOffset? WeekStartNext(this DateTimeOffset? self) => self.WeekStartAt(1);

        #endregion

        #region Month

        public static DateTimeOffset? MonthStartAt(this DateTimeOffset? self, int months = 0) => self.TryValue(x => x.MonthStartAt(months));

        public static DateTimeOffset? MonthStart(this DateTimeOffset? self) => self.MonthStartAt(0);

        public static DateTimeOffset? MonthStartPrev(this DateTimeOffset? self) => self.MonthStartAt(-1);

        public static DateTimeOffset? MonthStartNext(this DateTimeOffset? self) => self.MonthStartAt(1);

        #endregion

        #region Quarter

        public static DateTimeOffset? QuarterStartAt(this DateTimeOffset? self, int quarters) => self.TryValue(x => x.QuarterStartAt(quarters));

        public static DateTimeOffset? QuarterStart(this DateTimeOffset? self) => self.QuarterStartAt(0);

        public static DateTimeOffset? QuarterStartPrev(this DateTimeOffset? self) => self.QuarterStartAt(-1);

        public static DateTimeOffset? QuarterStartNext(this DateTimeOffset? self) => self.QuarterStartAt(1);

        #endregion

        #region Years

        public static DateTimeOffset? YearStartAt(this DateTimeOffset? self, int years = 0) => self.TryValue(x => x.YearStartAt(years));

        public static DateTimeOffset? YearStart(this DateTimeOffset? self) => self.YearStartAt(0);

        public static DateTimeOffset? YearStartPrev(this DateTimeOffset? self) => self.YearStartAt(-1);

        public static DateTimeOffset? YearStartNext(this DateTimeOffset? self) => self.YearStartAt(1);

        #endregion
    }
}
