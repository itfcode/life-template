namespace ITLT.ExtentionMethods
{
    using System;

    public static class DateTimeNullableExtentions
    {

        #region Helper Methods

        private static DateTime? TryValue(this DateTime? self, Func<DateTime, DateTime> func)
        {
            return self.HasValue ? func(self.Value) : self;
        }

        #endregion

        #region Day 

        public static DateTime? DayStartAt(this DateTime? self, int days = 0) => self.TryValue(x => x.DayStartAt(days));

        public static DateTime? DayStart(this DateTime? self) => self.DayStartAt(0);

        public static DateTime? DayStartPrev(this DateTime? self) => self.DayStartAt(-1);

        public static DateTime? DayStartNext(this DateTime? self) => self.DayStartAt(1);

        #endregion

        #region Week 

        public static DateTime? WeekStartAt(this DateTime? self, int weeks = 0) => self.TryValue(x => x.WeekStartAt(weeks));

        public static DateTime? WeekStart(this DateTime? self) => self.WeekStartAt(0);

        public static DateTime? WeekStartPrev(this DateTime? self) => self.WeekStartAt(-1);

        public static DateTime? WeekStartNext(this DateTime? self) => self.WeekStartAt(1);

        #endregion

        #region Month

        public static DateTime? MonthStartAt(this DateTime? self, int months = 0) => self.TryValue(x => x.MonthStartAt(months));

        public static DateTime? MonthStart(this DateTime? self) => self.MonthStartAt(0);

        public static DateTime? MonthStartPrev(this DateTime? self) => self.MonthStartAt(-1);

        public static DateTime? MonthStartNext(this DateTime? self) => self.MonthStartAt(1);

        #endregion

        #region Quarter

        public static DateTime? QuarterStartAt(this DateTime? self, int quarters) => self.TryValue(x => x.QuarterStartAt(quarters));

        public static DateTime? QuarterStart(this DateTime? self) => self.QuarterStartAt(0);

        public static DateTime? QuarterStartPrev(this DateTime? self) => self.QuarterStartAt(-1);

        public static DateTime? QuarterStartNext(this DateTime? self) => self.QuarterStartAt(1);

        #endregion

        #region Years

        public static DateTime? YearStartAt(this DateTime? self, int years = 0) => self.TryValue(x => x.YearStartAt(years));

        public static DateTime? YearStart(this DateTime? self) => self.YearStartAt(0);

        public static DateTime? YearStartPrev(this DateTime? self) => self.YearStartAt(-1);

        public static DateTime? YearStartNext(this DateTime? self) => self.YearStartAt(1);

        #endregion

    }
}
