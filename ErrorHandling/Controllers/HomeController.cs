using ErrorHandling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace ErrorHandling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public class AboutModel : PageModel
        {
            private readonly ILogger _logger;

            public AboutModel(ILogger<AboutModel> logger)
            {
                _logger = logger;
            }
            public string? Message { get; set; }

            public void OnGet()
            {
                Message = $"About page visited at {DateTime.UtcNow.ToLongTimeString()}";
                _logger.LogInformation(Message);
            }
        }
    }
}