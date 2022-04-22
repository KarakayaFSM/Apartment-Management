using Microsoft.AspNetCore.Mvc;

namespace Apartment_Management.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
