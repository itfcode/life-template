namespace ITF.ExtentionMethods
{
    using System;

    public static class DateTimeExtetions
    {

        #region Consts

        private static readonly DateTime quarterFirstStart = new DateTime(DateTime.Now.Year, 1, 1);

        private static readonly DateTime quarterSecondStart = new DateTime(DateTime.Now.Year, 4, 1);

        private static readonly DateTime quarterThirdStart = new DateTime(DateTime.Now.Year, 7, 1);

        private static readonly DateTime quarterFourthStart = new DateTime(DateTime.Now.Year, 10, 1);

        #endregion

        #region Day 

        /// <summary>
        /// Start of Day.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns> Beginning of date </returns>
        public static DateTime DayStart(this DateTime self) => new DateTime(self.Year, self.Month, self.Day);

        public static DateTime DayStartAt(this DateTime self, int days = 0) => self.DayStart().AddDays(days);

        public static DateTime DayStartPrev(this DateTime self) => self.DayStartAt(-1);

        public static DateTime DayStartNext(this DateTime self) => self.DayStartAt(1);

        #endregion

        #region Week

        public static DateTime WeekStart(this DateTime self)
        {
            int dayOfWeek = (int)self.DayOfWeek;
            var daysMinus = dayOfWeek == 0 ? 6 : (dayOfWeek - 1);
            return self.DayStart().AddDays(-daysMinus);
        }

        public static DateTime WeekStartAt(this DateTime self, int weeks = 0) => self.WeekStart().AddDays(weeks * 7);

        public static DateTime WeekStartPrev(this DateTime self) => self.WeekStartAt(-1);

        public static DateTime WeekStartNext(this DateTime self) => self.WeekStartAt(1);

        #endregion

        #region Month

        public static DateTime MonthStart(this DateTime self) => new DateTime(self.Year, self.Month, 1);

        public static DateTime MonthStartAt(this DateTime self, int months = 0) => self.MonthStart().AddMonths(months);

        public static DateTime MonthStartPrev(this DateTime self) => self.MonthStartAt(-1);

        public static DateTime MonthStartNext(this DateTime self) => self.MonthStartAt(1);

        #endregion

        #region Quarter

        public static DateTime QuarterStart(this DateTime self)
        {
            var month = self.Month;

            if (month <= 3) month = 1;
            else if (month <= 6) month = 4;
            else if (month <= 9) month = 7;
            else month = 10;

            return new DateTime(self.Year, month, 1);
        }

        public static DateTime QuarterStartAt(this DateTime self, int quarters) => self.QuarterStart().AddMonths(quarters * 3);

        public static DateTime QuarterStartPrev(this DateTime self) => self.QuarterStartAt(-1);

        public static DateTime QuarterStartNext(this DateTime self) => self.QuarterStartAt(1);

        #endregion

        #region Year

        public static DateTime YearStart(this DateTime self) => new DateTime(self.Year, 1, 1);

        public static DateTime YearStartAt(this DateTime self, int years = 0) => self.YearStart().AddYears(years);

        public static DateTime YearStartPrev(this DateTime self) => self.YearStartAt(-1);

        public static DateTime YearStartNext(this DateTime self) => self.YearStartAt(1);

        #endregion

        #region Checking of Day Name 

        /// <summary>
        /// Determines whether this is monday.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if the specified self is monday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMonday(this DateTime self) => self.DayOfWeek == DayOfWeek.Monday;

        /// <summary>
        /// Determines whether this is tuesday.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if the specified self is tuesday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsTuesday(this DateTime self) => self.DayOfWeek == DayOfWeek.Tuesday;

        /// <summary>
        /// Determines whether this is wednesday.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if the specified self is wednesday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWednesday(this DateTime self) => self.DayOfWeek == DayOfWeek.Wednesday;

        /// <summary>
        /// Determines whether this is thursday.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if the specified self is thursday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsThursday(this DateTime self) => self.DayOfWeek == DayOfWeek.Thursday;

        /// <summary>
        /// Determines whether this is friday.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if the specified self is friday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFriday(this DateTime self) => self.DayOfWeek == DayOfWeek.Friday;

        /// <summary>
        /// Determines whether this is saturday.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if the specified self is saturday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSaturday(this DateTime self) => self.DayOfWeek == DayOfWeek.Saturday;

        /// <summary>
        /// Determines whether this is sunday.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>
        ///   <c>true</c> if the specified self is sunday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSunday(this DateTime self) => self.DayOfWeek == DayOfWeek.Sunday;

        #endregion

        #region MyRegion

        public static DateTime MondayAt(this DateTime self, int weeks = 0) => self.WeekStart().AddDays(weeks * 7);

        public static DateTime TuesdayAt(this DateTime self, int weeks = 0) => self.MondayAt(weeks).AddDays(1);

        public static DateTime WednesdayAt(this DateTime self, int weeks = 0) => self.MondayAt(weeks).AddDays(2);

        public static DateTime ThursdayAt(this DateTime self, int weeks = 0) => self.MondayAt(weeks).AddDays(3);

        /// <summary>
        /// Determines Friday Date 
        /// </summary>
        /// <param name="self">The self.</param>
        /// <param name="weekNumber"></param>
        /// <returns>Date of needed Friday</returns>
        public static DateTime FridayAt(this DateTime self, int weeks = 0) => self.MondayAt(weeks).AddDays(4);

        public static DateTime SaturdayAt(this DateTime self, int weeks = 0) => self.MondayAt(weeks).AddDays(5);

        public static DateTime SundayAt(this DateTime self, int weeks = 0) => self.MondayAt(weeks).AddDays(6);

        #endregion

        #region Other Helpful Methods

        public static DateTime CopyTime(this DateTime self, DateTime source)
        {
            return new DateTime(self.Year, self.Month, self.Day, source.Hour, source.Minute, source.Second);
        }

        public static int TotalMinutes(this DateTime self) => self.Minute + self.Hour * 60;

        public static int TotalSeconds(this DateTime self) => self.TotalMinutes() * 60 + self.Second;

        public static int TotalMilliseconds(this DateTime self) => self.TotalSeconds() * 1000 + self.Millisecond;

        #endregion
    }
}
