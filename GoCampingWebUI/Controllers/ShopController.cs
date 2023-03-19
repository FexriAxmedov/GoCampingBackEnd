using Microsoft.AspNetCore.Mvc;

namespace GoCamping.WebUI.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
