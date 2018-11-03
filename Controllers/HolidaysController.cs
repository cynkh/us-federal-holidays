using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using dotnet_webapp.Abstract;
using dotnet_webapp.Entities;
using dotnet_webapp.Models;
using dotnet_webapp.Services;

namespace dotnet_webapp.Controllers
{
    public class HolidaysController : ControllerBase
    {
        private IHolidaysService _holidaysService;
        public HolidaysController(IHolidaysService holidaysService)
        {
            _holidaysService = holidaysService;
        }        
        
        [Route("Holidays/{year?}")]
        public IActionResult Index(int? year)
        {
            IEnumerable<Holiday> holidays;
            var model = new HolidaysIndexViewModel();

            if (!year.HasValue)
            {
                year = DateTime.UtcNow.Year;
            }

            try
            {
                holidays = _holidaysService.GetHolidaysByYear(year.Value);
            }
            catch (ArgumentException argEx)
            {
                model.Error = argEx.Message;
                holidays = new List<Holiday>();
            }

            model.Year = year.Value;
            model.Holidays = holidays;

            return View(model);
        }
    }
}