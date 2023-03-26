using GoCamping.BLL.Services.Interface;
using GoCamping.DAL.DBModel;
using GoCamping.DAL.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoCamping.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly IGenericService<ContactDto, Contact> _service;
        public ContactController(IGenericService<ContactDto, Contact> service)
        {
            _service = service;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactDto itemDto)
        {

            if (ModelState.IsValid)
            {
                var category = await _service.AddAsync(itemDto);

                if (category != null)
                {
                    return RedirectToAction("Create");
                }
            }
            return View(itemDto);






        }
    }
}
