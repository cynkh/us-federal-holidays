using System.Collections.Generic;

using dotnet_webapp.Entities;

namespace dotnet_webapp.Abstract
{
    public interface IHolidaysService
    {
        /// <summary>
         /// Returns a list of entity type Holiday for the year requested
         /// </summary>
         /// <param name="year">The year for which the holiday list is being requested</param>
         /// <returns>IEnumerable of entity type Holiday for the specified year</returns>
        IEnumerable<Holiday> GetHolidaysByYear(int year);
    }
}
