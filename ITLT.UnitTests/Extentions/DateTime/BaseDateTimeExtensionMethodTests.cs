namespace ITLT.UnitTests.Extentions
{
    using ITLT.ExtentionMethods;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Test for class DateTimeOffsetExtentions
    /// </summary>
    public abstract class BaseDateTimeExtensionMethodTests : NUnitBaseTests
    {
        #region Protected Fields 

        private Assembly thisAssembly;

        private Type extendedType;

        protected virtual IList<string> ExtentionMethods => this.GetExtensionMethods(thisAssembly, extendedType);

        protected readonly IList<string> commonMethods = new List<string>()
        {
            "DayStart",
            "DayStartAt",
            "DayStartPrev",
            "DayStartNext",

            "DayEnd",
            "DayEndAt",
            "DayEndPrev",
            "DayEndNext",

            "WeekStart",
            "WeekStartAt",
            "WeekStartPrev",
            "WeekStartNext",

            "WeekEnd",
            "WeekEndAt",
            "WeekEndPrev",
            "WeekEndNext",

            "MonthStart",
            "MonthStartAt",
            "MonthStartPrev",
            "MonthStartNext",

            "MonthEnd",
            "MonthEndAt",
            "MonthEndPrev",
            "MonthEndNext",

            "QuarterStart",
            "QuarterStartAt",
            "QuarterStartPrev",
            "QuarterStartNext",

            "QuarterEnd",
            "QuarterEndAt",
            "QuarterEndPrev",
            "QuarterEndNext",

            "YearStart",
            "YearStartAt",
            "YearStartPrev",
            "YearStartNext",

            "YearEnd",
            "YearEndAt",
            "YearEndPrev",
            "YearEndNext",

            "IsMonday",
            "IsTuesday",
            "IsWednesday",
            "IsThursday",
            "IsFriday",
            "IsSaturday",
            "IsSunday",

            "IsDayStart",
            "IsWeekStart",
            "IsMonthStart",
            "IsQuarterStart",
            "IsYearStart",

            "MondayAt",
            "TuesdayAt",
            "WednesdayAt",
            "ThursdayAt",
            "FridayAt",
            "SaturdayAt",
            "SundayAt",
            "IsHoliday",
            "CopyTime",
            "TotalMinutes",
            "TotalSeconds",
            "TotalMilliseconds",
            "IsAM",
            "IsPM"
        };

        protected readonly IList<string> dateTimeMethods = null;

        protected readonly IList<string> dateTimeNullMethods = null;

        protected readonly IList<string> dateTimeOffsetMethods = null;

        protected readonly IList<string> dateTimeOffsetNullMethods = null;

        #endregion

        #region Constructors 

        public BaseDateTimeExtensionMethodTests(Assembly thisAssembly, Type extendedType)
        {
            this.thisAssembly = thisAssembly;
            this.extendedType = extendedType;
            this.dateTimeMethods = new List<string>(commonMethods);
            this.dateTimeNullMethods = new List<string>(commonMethods);
            this.dateTimeOffsetMethods = new List<string>(commonMethods);
            this.dateTimeOffsetNullMethods = new List<string>(commonMethods);
        }

        #endregion

        #region Protected Methods 

        protected IList<string> GetExtensionMethods(Assembly assembly, Type extendedType)
        {
            if (extendedType == null) 
            {
                throw new ArgumentNullException();
            }

            var query = from type in assembly.GetTypes()
                        where type.IsSealed && !type.IsGenericType && !type.IsNested
                        from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                        where method.IsDefined(typeof(ExtensionAttribute), false)
                        where method.GetParameters()[0].ParameterType == extendedType
                        select method.Name;
            return query.ToList();
        }

        protected DateTime GetStartOfQuarter(DateTime value)
        {
            switch (value.Month)
            {
                case 1:
                case 2:
                case 3:
                    return new DateTime(value.Year, 1, 1, 0, 0, 0);
                case 4:
                case 5:
                case 6:
                    return new DateTime(value.Year, 4, 1, 0, 0, 0);
                case 7:
                case 8:
                case 9:
                    return new DateTime(value.Year, 7, 1, 0, 0, 0);
                case 10:
                case 11:
                case 12:
                    return new DateTime(value.Year, 10, 1, 0, 0, 0);
                default:
                    throw new Exception(@"¯\_(ツ)_/¯");
            }
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
                    return new DateTimeOffset(value.Year, 4, 1, 0, 0, 0, value.Offset);
                case 7:
                case 8:
                case 9:
                    return new DateTimeOffset(value.Year, 7, 1, 0, 0, 0, value.Offset);
                case 10:
                case 11:
                case 12:
                    return new DateTimeOffset(value.Year, 10, 1, 0, 0, 0, value.Offset);
                default:
                    throw new Exception(@"¯\_(ツ)_/¯");
            }
        }

        #endregion
    }
}
