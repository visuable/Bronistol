using System;
using System.Collections.Generic;
using System.Text;

namespace Bronistol.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool EqualWithoutSeconds(this DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1.Year == dateTime2.Year
                && dateTime1.Month == dateTime2.Month
                && dateTime1.Day == dateTime2.Day
                && dateTime1.Hour == dateTime2.Hour
                && dateTime2.Minute == dateTime2.Minute;
        }
    }
}
