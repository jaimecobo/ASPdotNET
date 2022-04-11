using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SecurityTesting.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize]
        //[Authorize(Roles = "Super, Admin")]
        [Authorize(Roles = "Super")]
        [Authorize(Roles = "Admin")]
        public IActionResult Secured()
        {
            return View();
        }

        public async Task<IActionResult> LoginJaime()
        {
            var claims = new List<Claim>
            {
                new Claim("name", "Jaime"),
                new Claim("role", "Admin"),
                new Claim("role", "Super"),
                new Claim("xxx", "yyy"),
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            //Task t = HttpContext.SignInAsync(principal);
            //t.Wait();                                     //Instead of using lines 29 & 30 is better ti use line 31
            await HttpContext.SignInAsync(principal);
            return RedirectToAction("Index");
           
        }

        public async Task<IActionResult> LoginJose()
        {
            var claims = new List<Claim>
            {
                new Claim("name", "Jose"),
                new Claim("role", "Admin"),
                new Claim("xxx", "yyy"),
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            //Task t = HttpContext.SignInAsync(principal);
            //t.Wait();                                     //Instead of using lines 29 & 30 is better ti use line 31
            await HttpContext.SignInAsync(principal);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
