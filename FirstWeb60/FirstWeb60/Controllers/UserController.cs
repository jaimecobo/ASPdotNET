using Microsoft.AspNetCore.Mvc;

namespace FirstWeb60.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult privacy()
        {
            return View();
        }

        public IActionResult test()
        {
            return View();
        }
    }
}
