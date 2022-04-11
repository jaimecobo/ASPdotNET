using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using SecurityTesting.Models;

namespace SecurityTesting.Controllers
{
    public class Security : Controller
    {
        IDataProtectionProvider _Provider;
        ILogger<Security> _Logger;

        public Security(IDataProtectionProvider provider, ILogger<Security> logger)
        {
            _Provider = provider;
            _Logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Protect(SecurityModel postedData)
        {
            var protector = _Provider.CreateProtector("Confidentiality");
            postedData.MethodText = "Data is now Encrypted";
            //postedData.ProtectedText = postedData.PlainText;
            postedData.ProtectedText = protector.Protect(postedData.PlainText);
            postedData.PlainText = "Plain Text has now been Encrypted";
            _Logger.LogCritical("Protected has been called");
            return View("Index", postedData);
        }

        [HttpPost]
        public IActionResult UNProtect(SecurityModel postedData)
        {
            var protector = _Provider.CreateProtector("Confidentiality");
            try
            {
                postedData.PlainText = protector.Unprotect(postedData.ProtectedText);
            }
            catch
            {
                postedData.PlainText = "Uh oh... the protected data is invalid";
            }

            postedData.ProtectedText = "";
            postedData.MethodText = "Plain Text has now been DECRYPTED";
            _Logger.LogCritical("UnProtected has been called");
            return View("Index", postedData);

        }
    }
}
