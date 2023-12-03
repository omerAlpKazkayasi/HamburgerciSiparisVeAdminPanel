using AutoMapper;
using BusinessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using HamburgerUI.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdditionalProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public AdditionalProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IActionResult AdditionalProductAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdditionalProductAdd(AdditionalAddDTO dto)
        {
            
            if (ModelState.IsValid)
            {
                _productService.Add(_mapper.Map<Product>(dto));
            }
          

            return View();
        }

       
        [HttpGet]
        public IActionResult AdditionalProductUpdate(int ID)
        {
            var productDetails = _productService.GetById(ID);

            return View(_mapper.Map<ProductUpdateDTO>(productDetails));
        }
        [HttpPost]
        public IActionResult AdditionalProductUpdate(ProductUpdateDTO product)
        {
    
         
            if (ModelState.IsValid)
            {
                _productService.Update(_mapper.Map<Product>(product));
                return RedirectToAction("Listeleme");
            }
            return View();

            
        }
        public IActionResult AdditionalProductDelete(int ID)
        {
            _productService.Delete(_productService.GetById(ID));
            return RedirectToAction("Listeleme");
        }
        public IActionResult Listeleme()
        {
            return View(_productService.GetAllByCategory(4));
        }
    }
}