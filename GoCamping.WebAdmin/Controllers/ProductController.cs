using Microsoft.AspNetCore.Mvc;

namespace GoCamping.WebAdmin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
