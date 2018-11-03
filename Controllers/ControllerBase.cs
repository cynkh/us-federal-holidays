using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapp
{
    public class ControllerBase : Controller
    {
        public override ViewResult View()
        {
            return View(new ViewModelBase());
        }
        public override ViewResult View(string viewName)
        {
            return View(viewName, new ViewModelBase());
        }
    }
}