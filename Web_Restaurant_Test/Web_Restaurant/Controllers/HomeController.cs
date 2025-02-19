using Microsoft.AspNetCore.Mvc;

namespace WebRestaurant.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Main()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
