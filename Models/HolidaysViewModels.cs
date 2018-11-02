using System;
using System.Collections.Generic;

using dotnet_webapp.Entities;

namespace dotnet_webapp.Models
{
    public class HolidaysIndexViewModel
    {
        public int Year { get; set; }
        public IEnumerable<Holiday> Holidays { get; set; }
    }
}
