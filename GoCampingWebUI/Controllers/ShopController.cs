using Microsoft.AspNetCore.Mvc;

namespace GoCamping.WebUI.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index(int price, string? name)
        {
            ViewBag.Name = name;
            ViewBag.Price = price;          
            return View();
        }
    }
}
