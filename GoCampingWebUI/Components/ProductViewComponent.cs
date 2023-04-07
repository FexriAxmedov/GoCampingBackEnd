using GoCamping.DAL.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GoCamping.WebUI.Components
{
    public class ProductViewComponent : ViewComponent
    {

        readonly AppDbContext db;
        public ProductViewComponent(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<IViewComponentResult> InvokeAsync(int count, int max, string? name )
        {
            var products = db.Products.ToList();
            if(count > 0)
            {
                products = products.OrderByDescending(p=> p.Id).Take(count).ToList();
            }

            if(max > 0)
            {
                products = products.Where(p=> p.Price <= max).ToList();
            }
            if (name != null)
            {
                products = products.Where(p => p.Name.ToLower().Contains(name.ToLower()) == true).ToList();
            }

            ViewBag.Products = "";

            if(products.Count() == 0)
            {
                ViewBag.Products = "Product not found";
            }
            return View(products);
        }
        

        }
}
