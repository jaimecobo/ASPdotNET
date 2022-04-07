using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityFromScratch.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult RequiredAuthenticated()
        {
            return View("Success");
        }

        [Authorize(Roles = "Super")]
        public IActionResult RequiredSuper()
        {
            return View("Success");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult RequiredAdmin()
        {
            return View("Success");
        }

        public IActionResult RequiredUser()
        {
            return View("Success");
        }

        [Authorize(Policy = "Required18orOlder")]
        public IActionResult Required18()
        {
            return View("Success");
        }

        [Authorize(Policy = "Required21orOlder")]
        public IActionResult Required21()
        {
            return View("Success");
        }
        
        [Authorize(Policy = "RequiredCalifornia")]
        public IActionResult RequiredCA()
        {
            return View("Success");
        }
        
        [Authorize(Policy = "RequiredTexas")]
        public IActionResult RequiredTX()
        {
            return View("Success");
        }
        
        

    }
}
