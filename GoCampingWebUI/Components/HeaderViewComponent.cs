using GoCamping.DAL.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoCamping.WebUI.Components
{
    public class HeaderViewComponent:ViewComponent
    {
        readonly AppDbContext db;
        public HeaderViewComponent(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View();
        }
    }
}
