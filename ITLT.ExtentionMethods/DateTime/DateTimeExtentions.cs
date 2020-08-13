namespace ITLT.ExtentionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DateTimeExtentions
    {

        #region Consts

        private static readonly DateTime quarterFirstStart = new DateTime(DateTime.Now.Year, 1, 1);

        private static readonly DateTime quarterSecondStart = new DateTime(DateTime.Now.Year, 4, 1);

        private static readonly DateTime quarterThirdStart = new DateTime(DateTime.Now.Year, 7, 1);

        private static readonly DateTime quarterFourthStart = new DateTime(DateTime.Now.Year, 10, 1);

        #endregion

        #region Day 

        public static DateTime DayStart(this DateTime self) => new DateTime(self.Year, self.Month, self.Day);

        public static DateTime DayStartAt(this DateTime self, int days = 0) => self.DayStart().AddDays(days);

        public static DateTime DayStartPrev(this DateTime self) => self.DayStartAt(-1);

        public static DateTime DayStartNext(this DateTime self) => self.DayStartAt(1);

        public static DateTime DayEnd(this DateTime self) => self.DayStartNext().AddTicks(-1);

        public static DateTime DayEndAt(this DateTime self, int days = 0) => self.DayStartAt(days + 1).AddTicks(-1);

        public static DateTime DayEndPrev(this DateTime self) => self.DayEndAt(-1);

        public static DateTime DayEndNext(this DateTime self) => self.DayEndAt(1);

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

        public static DateTime WeekEnd(this DateTime self) => self.WeekStartNext().AddTicks(-1);

        public static DateTime WeekEndAt(this DateTime self, int weeks = 0) => self.WeekStartAt(weeks + 1).AddTicks(-1);

        public static DateTime WeekEndPrev(this DateTime self) => self.WeekEndAt(-1);

        public static DateTime WeekEndNext(this DateTime self) => self.WeekEndAt(1);

        #endregion

        #region Month

        public static DateTime MonthStart(this DateTime self) => new DateTime(self.Year, self.Month, 1);

        public static DateTime MonthStartAt(this DateTime self, int months = 0) => self.MonthStart().AddMonths(months);

        public static DateTime MonthStartPrev(this DateTime self) => self.MonthStartAt(-1);

        public static DateTime MonthStartNext(this DateTime self) => self.MonthStartAt(1);

        public static DateTime MonthEnd(this DateTime self) => self.MonthEndAt();

        public static DateTime MonthEndAt(this DateTime self, int months = 0) => self.MonthStartAt(months + 1).AddTicks(-1);

        public static DateTime MonthEndPrev(this DateTime self) => self.MonthEndAt(-1);

        public static DateTime MonthEndNext(this DateTime self) => self.MonthEndAt(1);

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

        public static DateTime QuarterEnd(this DateTime self) => self.QuarterStartAt(1).AddTicks(-1);

        public static DateTime QuarterEndAt(this DateTime self, int quarters) => self.QuarterStartAt(quarters + 1).AddTicks(-1);

        public static DateTime QuarterEndPrev(this DateTime self) => self.QuarterEndAt(-1);

        public static DateTime QuarterEndNext(this DateTime self) => self.QuarterEndAt(1);

        #endregion

        #region Year

        public static DateTime YearStart(this DateTime self) => new DateTime(self.Year, 1, 1);

        public static DateTime YearStartAt(this DateTime self, int years = 0) => self.YearStart().AddYears(years);

        public static DateTime YearStartPrev(this DateTime self) => self.YearStartAt(-1);

        public static DateTime YearStartNext(this DateTime self) => self.YearStartAt(1);

        #endregion

        #region Checking of Day Name 

        public static bool IsMonday(this DateTime self) => self.DayOfWeek == DayOfWeek.Monday;

        public static bool IsTuesday(this DateTime self) => self.DayOfWeek == DayOfWeek.Tuesday;

        public static bool IsWednesday(this DateTime self) => self.DayOfWeek == DayOfWeek.Wednesday;

        public static bool IsThursday(this DateTime self) => self.DayOfWeek == DayOfWeek.Thursday;

        public static bool IsFriday(this DateTime self) => self.DayOfWeek == DayOfWeek.Friday;

        public static bool IsSaturday(this DateTime self) => self.DayOfWeek == DayOfWeek.Saturday;

        public static bool IsSunday(this DateTime self) => self.DayOfWeek == DayOfWeek.Sunday;

        #endregion

        #region Checking of Date

        public static bool IsDayStart(this DateTime self) => self == self.DayStart();

        public static bool IsWeekStart(this DateTime self) => self == self.WeekStart();

        public static bool IsMonthStart(this DateTime self) => self == self.MonthStart();

        public static bool IsQuarterStart(this DateTime self) => self == self.QuarterStart();

        public static bool IsYearStart(this DateTime self) => self == self.YearStart();

        #endregion

        #region Get 

        public static DateTime MondayAt(this DateTime self, int weeks = 0) => self.WeekStart().AddDays(weeks * 7);

        public static DateTime TuesdayAt(this DateTime self, int weeks = 0) => self.MondayAt(weeks).AddDays(1);

        public static DateTime WednesdayAt(this DateTime self, int weeks = 0) => self.MondayAt(weeks).AddDays(2);

        public static DateTime ThursdayAt(this DateTime self, int weeks = 0) => self.MondayAt(weeks).AddDays(3);

        public static DateTime FridayAt(this DateTime self, int weeks = 0) => self.MondayAt(weeks).AddDays(4);

        public static DateTime SaturdayAt(this DateTime self, int weeks = 0) => self.MondayAt(weeks).AddDays(5);

        public static DateTime SundayAt(this DateTime self, int weeks = 0) => self.MondayAt(weeks).AddDays(6);

        #endregion

        #region Other Helpful Methods

        public static bool IsHoliday(this DateTime self, IEnumerable<DateTime> holidays)
        {
            return (holidays == null) ? false : holidays.Any(x => x == self);
        }

        public static DateTime CopyTime(this DateTime self, DateTime source)
        {
            return new DateTime(self.Year, self.Month, self.Day, source.Hour, source.Minute, source.Second);
        }

        public static int TotalMinutes(this DateTime self) => self.Minute + self.Hour * 60;

        public static int TotalSeconds(this DateTime self) => self.TotalMinutes() * 60 + self.Second;

        public static int TotalMilliseconds(this DateTime self) => self.TotalSeconds() * 1000 + self.Millisecond;

        public static bool IsAM(this DateTime self) => self.TotalMinutes() < (12 * 60);

        public static bool IsPM(this DateTime self) => !self.IsAM();

        #endregion
    }
}
