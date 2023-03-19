using Microsoft.AspNetCore.Mvc;

namespace GoCamping.WebAdmin.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
