using GoCamping.DAL.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoCamping.WebUI.Controllers
{
    public class ProductController : Controller
    {
        readonly AppDbContext db;
        public ProductController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }
    }
}
