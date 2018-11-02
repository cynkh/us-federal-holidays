using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using dotnet_webapp.Models;
using dotnet_webapp.Services;

// TODO ControllerBase and ViewModelBase
// TODO Put currently hard-coded app name value into a view model/controller
namespace dotnet_webapp.Controllers
{
    public class HolidaysController : Controller
    {
        public HolidaysController()
        {
            _holidaysService = new HolidaysService();
        }
        private HolidaysService _holidaysService;
        
        [Route("Holidays/{year?}")]
        public IActionResult Index(int? year)
        {
            if (!year.HasValue)
            {
                year = DateTime.UtcNow.Year;
            }
            var model = new HolidaysIndexViewModel
            {
                Year = year.Value,
                Holidays = _holidaysService.GetHolidaysByYear(year.Value),
            };

            return View(model);
        }
    }
}