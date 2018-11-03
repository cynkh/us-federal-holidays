using System;
using System.Linq;

using Xunit;

using dotnet_webapp.Abstract;
using dotnet_webapp.Services;

namespace dotnet_webapp
{
    public class HolidaysTests
    {
        private readonly IHolidaysService _holidaysService;
        public HolidaysTests()
        {
            _holidaysService = new HolidaysService();
        }

        [Fact]
        public void ShouldBeTenFederalHolidaysPerYear()
        {
            const int YEAR = 2018;
            const int HOLIDAYS_PER_YEAR = 10;

            var holidays = _holidaysService.GetHolidaysByYear(YEAR);

            Assert.True(holidays.Count().Equals(HOLIDAYS_PER_YEAR));
        }

        [Fact]
        public void NewYearsDay2018ShouldBeOnMondayJanuaryFirst()
        {
            const int YEAR = 2018;
            const string NEW_YEARS_DAY = "New Year's Day";

            var holidays = _holidaysService.GetHolidaysByYear(YEAR);
            var newYearsDay = holidays.FirstOrDefault(h => h.Name.Equals(NEW_YEARS_DAY)).Date;
            var dayOfWeek = newYearsDay.DayOfWeek;
            var month = newYearsDay.Month;
            var day = newYearsDay.Day;

            Assert.True(dayOfWeek.Equals(DayOfWeek.Monday) && 
                month.Equals(1) && 
                day.Equals(1));
        }

        [Fact]
        public void YearZeroShouldThrowArgumentException()
        {
            const int YEAR = 0;

            Assert.Throws<ArgumentException>(() => _holidaysService.GetHolidaysByYear(YEAR));
        }
    }
}