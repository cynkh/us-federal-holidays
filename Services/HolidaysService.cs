using System;
using System.Collections.Generic;
using System.Linq;

using dotnet_webapp.Entities;

namespace dotnet_webapp.Services
{
    public class HolidaysService
    {
        /*
            2018 USPS holidays

            Monday, January 1 New Year’s Day                        // calculated
            Monday, January 15 Martin Luther King Jr. birthday      // nth weekday, 3rd Mon of Jan
            Monday, February 19 Washington’s Birthday (observed)    // nth weekday, 3rd Mon of Feb
            Monday, May 28 Memorial Day                             // nth weekday, -1st Mon of May
            Wednesday, July 4 Independence Day                      // calculated
            Monday, September 3 Labor Day                           // nth weekday, 
            Monday, October 8 Columbus Day                          // nth weekday, 2nd Mon of Oct
            Monday, November 12 Veterans Day (observed)             // calculated
            Thursday, November 22 Thanksgiving Day                  // nth weekday, 4th Thu of Nov
            Tuesday, December 25 Christmas Day                      // calculated
         */
        public IEnumerable<Holiday> GetHolidaysByYear(int year)
        {
            var constantHolidays = getConstantHolidays(year);
            var nthWeekdayHolidays = getNthWeekdayHolidays(year);
            var holidaysByYear = constantHolidays.Concat(nthWeekdayHolidays);

            return holidaysByYear.OrderBy(h => h.Date);
        }
        // list of holidays which fall on a specific month and day every year
        private IEnumerable<Holiday> getConstantHolidays(int year)
        {
            return new List<Holiday>
            {
                closestWeekdayToDate("New Year's Day", year, 1, 1),
                closestWeekdayToDate("Independence Day", year, 7, 4),
                closestWeekdayToDate("Veterans Day", year, 11, 11),
                closestWeekdayToDate("Christmas Day", year, 12, 25),
            };
        }
        private IEnumerable<Holiday> getNthWeekdayHolidays(int year)
        {
            return new List<Holiday>
            {
                nthWeekdayOfMonth("Martin Luther King, Jr. Day", year, 1, 2, DayOfWeek.Monday),
                nthWeekdayOfMonth("Washington's Birthday", year, 2, 2, DayOfWeek.Monday),
                nthWeekdayOfMonth("Memorial Day", year, 5, -1, DayOfWeek.Monday),
                nthWeekdayOfMonth("Labor Day", year, 9, 0, DayOfWeek.Monday),
                nthWeekdayOfMonth("Columbus Day", year, 10, 1, DayOfWeek.Monday),
                nthWeekdayOfMonth("Thanksgiving Day", year, 11, 3, DayOfWeek.Thursday),
            };
        }
        /// <summary>
        /// Returns a new Holiday of type NthWeekdayOfMonth for the month, ordinal and weekday supplied
        /// <param name="name">Full name/description of holiday</param>
        /// <param name="year">Year which the holiday occurs in</param>
        /// <param name="month">Month number from 1-12</param>
        /// <param name="nthWeekday">The ordinal count of weekday or -1 for last, 0 is first</param>
        /// <param name="weekday">The weekday number, 0 = Sunday</param>
        /// <returns>New Holiday of type NthWeekdayOfMonth</returns>
        /// </summary>
        private Holiday nthWeekdayOfMonth(string name, int year, int month, int nthWeekday, DayOfWeek weekday)
        {
            // move to next month if we're search for the last weekday of the month
            // this will allow us to simply add -1 weeks to the firstMatchingWeekday
            if (nthWeekday == -1) month++;
            // start by determining the date of the first weekday of value weekday
            // add nthWeekday weeks to this date (nthWeekday * 7 days)
            // bounds checking?
            var firstOfMonth = new DateTime(year, month, 1);
            // what day of the week is the first day of the month?
            var dayOfWeek = (int)firstOfMonth.DayOfWeek;
            // if first weekday equals our desired weekday, we can go to the nthWeekday
            // otherwise we'll need to move forward to the desired day
            var daysToAdd = ((int)weekday - dayOfWeek + 7) % 7 + 1;
            var firstMatchingWeekday = new DateTime(
                year, 
                month, 
                daysToAdd);

            var holiday = firstMatchingWeekday.AddDays(nthWeekday * 7);

            return new Holiday
            {
                Name = name,
                DateType = DateType.NthWeekdayOfMonth,
                Date = holiday,
            };
        }
        /// <summary>
        /// Calculates the closest weekday to the desired date
        /// </summary>
        /// <param name="name">Name or description of the holiday</param>
        /// <param name="year">The year the holiday occurs in</param>
        /// <param name="month">The month the holiday occurs in</param>
        /// <param name="day">The day of the month of the actual holiday</param>
        /// <returns>A Holiday object with DateType.ClosestWeekdayToDate</returns>
        private Holiday closestWeekdayToDate(string name, int year, int month, int day)
        {
            var holiday = new DateTime(year, month, day);

            if (holiday.DayOfWeek.Equals(DayOfWeek.Saturday))
            {
                holiday = holiday.AddDays(-1);
            }
            else if (holiday.DayOfWeek.Equals(DayOfWeek.Sunday))
            {
                holiday = holiday.AddDays(1);
            }

            return new Holiday
            {
                Name = name,
                DateType = DateType.ClosestWeekdayToDate,
                Date = holiday,
            };
        }
    }
}
