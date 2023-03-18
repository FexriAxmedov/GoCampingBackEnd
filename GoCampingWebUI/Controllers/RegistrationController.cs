using Microsoft.AspNetCore.Mvc;

namespace GoCamping.WebUI.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
