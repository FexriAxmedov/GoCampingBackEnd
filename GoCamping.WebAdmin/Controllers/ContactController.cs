using GoCamping.BLL.Services.Interface;
using GoCamping.DAL.DBModel;
using GoCamping.DAL.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GoCamping.WebAdmin.Controllers
{
    public class ContactController : Controller
    {
        private readonly IGenericService<ContactDto, Contact> _service;
        public ContactController(IGenericService<ContactDto, Contact> service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {

            var contact = await _service.GetListAsync();
            return View(contact);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            return RedirectToAction("Index");
        }



    }
}
