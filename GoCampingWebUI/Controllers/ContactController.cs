using Microsoft.AspNetCore.Mvc;

namespace GoCamping.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
