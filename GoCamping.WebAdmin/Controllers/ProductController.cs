using AutoMapper;
using GoCamping.DAL.DBModel;
using Microsoft.AspNetCore.Mvc;
using GoCamping.BLL.Services.Interface;
using GoCamping.WebAdmin.Models;
using GoCamping.DAL.Dtos;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace GoCamping.WebAdmin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGenericService<ProductDto, Product> _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imgPath = @"img/";

        public ProductController(IGenericService<ProductDto, Product> productService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetListAsync();

            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto product, IFormFile imageFile)
        {

            //if (ModelState.IsValid)
            //{

            if (imageFile != null && imageFile.Length > 0)
            {
                var imagePath = _imgPath + imageFile.FileName;
                var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                    product.Img = imagePath;
                }
            }



            await _productService.AddAsync(product);


            return RedirectToAction("Index");
            //}

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            ProductDto model = new()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
              Price= product.Price,
              Img= product.Img,
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, ProductDto product, IFormFile imageFile)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{

            if (imageFile != null && imageFile.Length > 0)
            {
                var imagePath = _imgPath + imageFile.FileName;
                var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                    product.Img = imagePath;
                }
            }

     

            _productService.Update(product);
            TempData["success"] = "Movie have been successfully changed.";
            return RedirectToAction("Index");
            //}


            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
