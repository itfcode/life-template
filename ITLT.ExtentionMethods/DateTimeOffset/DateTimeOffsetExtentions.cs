namespace ITLT.ExtentionMethods
{
    using System;

    public static class DateTimeOffsetExtentions
    {

        #region Day 

        /// <summary>
        /// Start of Day.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns> Beginning of date </returns>
        public static DateTimeOffset DayStart(this DateTimeOffset self) => new DateTimeOffset(self.Date, self.Offset);

        public static DateTimeOffset DayStartAt(this DateTimeOffset self, int days = 0) => self.DayStart().AddDays(days);

        public static DateTimeOffset DayStartPrev(this DateTimeOffset self) => self.DayStartAt(-1);

        public static DateTimeOffset DayStartNext(this DateTimeOffset self) => self.DayStartAt(1);

        #endregion

        #region Week

        public static DateTimeOffset WeekStart(this DateTimeOffset self)
        {
            int dayOfWeek = (int)self.DayOfWeek;
            var daysMinus = dayOfWeek == 0 ? 6 : (dayOfWeek - 1);
            return self.DayStart().AddDays(-daysMinus);
        }

        public static DateTimeOffset WeekStartAt(this DateTimeOffset self, int weeks = 0) => self.WeekStart().AddDays(weeks * 7);

        public static DateTimeOffset WeekStartPrev(this DateTimeOffset self) => self.WeekStartAt(-1);

        public static DateTimeOffset WeekStartNext(this DateTimeOffset self) => self.WeekStartAt(1);

        #endregion

        #region Month

        public static DateTimeOffset MonthStart(this DateTimeOffset self) => new DateTimeOffset (new DateTime(self.Year, self.Month, 1), self.Offset);

        public static DateTimeOffset MonthStartAt(this DateTimeOffset self, int months = 0) => self.MonthStart().AddMonths(months);

        public static DateTimeOffset MonthStartPrev(this DateTimeOffset self) => self.MonthStartAt(-1);

        public static DateTimeOffset MonthStartNext(this DateTimeOffset self) => self.MonthStartAt(1);

        #endregion

        #region Quarter

        public static DateTimeOffset QuarterStart(this DateTimeOffset self)
        {
            var month = self.Month;

            if (month <= 3) month = 1;
            else if (month <= 6) month = 4;
            else if (month <= 9) month = 7;
            else month = 10;

            return new DateTimeOffset(new DateTime(self.Year, month, 1), self.Offset);
        }

        public static DateTimeOffset QuarterStartAt(this DateTimeOffset self, int quarters) => self.QuarterStart().AddMonths(quarters * 3);

        public static DateTimeOffset QuarterStartPrev(this DateTimeOffset self) => self.QuarterStartAt(-1);

        public static DateTimeOffset QuarterStartNext(this DateTimeOffset self) => self.QuarterStartAt(1);

        #endregion

        #region Year

        public static DateTimeOffset YearStart(this DateTimeOffset self) => new DateTimeOffset(new DateTime(self.Year, 1, 1), self.Offset);

        public static DateTimeOffset YearStartAt(this DateTimeOffset self, int years = 0) => self.YearStart().AddYears(years);

        public static DateTimeOffset YearStartPrev(this DateTimeOffset self) => self.YearStartAt(-1);

        public static DateTimeOffset YearStartNext(this DateTimeOffset self) => self.YearStartAt(1);

        #endregion

        #region Checking of Day Name 

        /// <summary>
        /// Determines whether this is monday.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if the specified self is monday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMonday(this DateTimeOffset self) => self.DayOfWeek == DayOfWeek.Monday;

        /// <summary>
        /// Determines whether this is tuesday.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if the specified self is tuesday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsTuesday(this DateTimeOffset self) => self.DayOfWeek == DayOfWeek.Tuesday;

        /// <summary>
        /// Determines whether this is wednesday.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if the specified self is wednesday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWednesday(this DateTimeOffset self) => self.DayOfWeek == DayOfWeek.Wednesday;

        /// <summary>
        /// Determines whether this is thursday.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if the specified self is thursday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsThursday(this DateTimeOffset self) => self.DayOfWeek == DayOfWeek.Thursday;

        /// <summary>
        /// Determines whether this is friday.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if the specified self is friday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFriday(this DateTimeOffset self) => self.DayOfWeek == DayOfWeek.Friday;

        /// <summary>
        /// Determines whether this is saturday.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if the specified self is saturday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSaturday(this DateTimeOffset self) => self.DayOfWeek == DayOfWeek.Saturday;

        /// <summary>
        /// Determines whether this is sunday.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if the specified self is sunday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSunday(this DateTimeOffset self) => self.DayOfWeek == DayOfWeek.Sunday;

        #endregion

        #region MyRegion

        public static DateTimeOffset MondayAt(this DateTimeOffset self, int weeks = 0) => self.WeekStart().AddDays(weeks * 7);

        public static DateTimeOffset TuesdayAt(this DateTimeOffset self, int weeks = 0) => self.MondayAt(weeks).AddDays(1);

        public static DateTimeOffset WednesdayAt(this DateTimeOffset self, int weeks = 0) => self.MondayAt(weeks).AddDays(2);

        public static DateTimeOffset ThursdayAt(this DateTimeOffset self, int weeks = 0) => self.MondayAt(weeks).AddDays(3);

        /// <summary>
        /// Determines Friday Date 
        /// </summary>
        /// <param name="self">The self.</param>
        /// <param name="weekNumber"></param>
        /// <returns>Date of needed Friday</returns>
        public static DateTimeOffset FridayAt(this DateTimeOffset self, int weeks = 0) => self.MondayAt(weeks).AddDays(4);

        public static DateTimeOffset SaturdayAt(this DateTimeOffset self, int weeks = 0) => self.MondayAt(weeks).AddDays(5);

        public static DateTimeOffset SundayAt(this DateTimeOffset self, int weeks = 0) => self.MondayAt(weeks).AddDays(6);

        #endregion

        #region Other Helpful Methods

        public static int TotalMinutes(this DateTimeOffset self) => self.Minute + self.Hour * 60;

        public static int TotalSeconds(this DateTimeOffset self) => self.TotalMinutes() * 60 + self.Second;

        public static int TotalMilliseconds(this DateTimeOffset self) => self.TotalSeconds() * 1000 + self.Millisecond;

        #endregion
    }
}
