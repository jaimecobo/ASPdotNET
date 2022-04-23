using Microsoft.AspNetCore.Mvc;

namespace L08SecurityFromScratch.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
