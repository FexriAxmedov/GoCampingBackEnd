using Microsoft.AspNetCore.Mvc;

namespace GoCamping.WebAdmin.Controllers
{
    public class ProductTableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
