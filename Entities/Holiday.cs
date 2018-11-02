using System;

namespace dotnet_webapp.Entities
{
    public class Holiday
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateType DateType { get; set; }
    }
    public enum DateType
    {
        NthWeekdayOfMonth,  // the nth weekday, e.g. the 2nd Tuesday of the month
        ClosestWeekdayToDate,  // the closest weekday to a specific date
    }
}
