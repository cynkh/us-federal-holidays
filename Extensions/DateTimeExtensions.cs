using System;

namespace dotnet_webapp
{
    public static class DateTimeExtensions
    {
        public static string ToOrdinalString(this DateTime dt)
        {
            var weekdayMonth = dt.ToString("dddd, MMMM");
            var day = dt.Day.ToOrdinal();
            var year = dt.Year.ToString();

            return $"{weekdayMonth} {day}, {year}";
        }
    }
}