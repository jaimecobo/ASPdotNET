using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SecurityTesting.Controllers
{
    public class SecretsController : Controller
    {
        IConfigurationRoot ConfigRoot;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SecretsController(IConfiguration InjectedConfig)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            ConfigRoot = InjectedConfig as IConfigurationRoot;
#pragma warning restore CS8601 // Possible null reference assignment.
        }
        public IActionResult Index()
        {
            var one = ConfigRoot.GetSection("MySecrets");
            var secrets = one.Get<Models.SecretModel>();
            secrets.configRoot = ConfigRoot;

            //ApplicationName comes from the "ChainedValue Provider"
            secrets.ChainedValue1 = ConfigRoot.GetValue<string>("ApplicationName");

            return View(secrets);
        }
    }
}
