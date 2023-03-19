using Microsoft.AspNetCore.Mvc;

namespace GoCamping.WebAdmin.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
