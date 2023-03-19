using Microsoft.AspNetCore.Mvc;

namespace GoCamping.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
