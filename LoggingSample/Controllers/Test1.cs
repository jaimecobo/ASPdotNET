using Microsoft.AspNetCore.Mvc;

namespace LoggingSample.Controllers
{
    public class Test1 : Controller
    {
        //ILogger<Test1> logger;
        //public Test1( ILogger<Test1>loggerTest1 )
        //{
        //    logger = loggerTest1;
        //}
        ILogger logger;
        public Test1(ILoggerFactory loggerTest1)
        {
            logger = loggerTest1.CreateLogger("xxx");
        }
        public IActionResult Index()
        {
            logger.Log(LogLevel.Information, "This is the method I'm calling the index");
            return View();
        }
    }
}
