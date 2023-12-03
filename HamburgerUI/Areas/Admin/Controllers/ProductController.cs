using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using HamburgerUI.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HamburgerUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IIngredientService _ıngredientService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IIngredientService ıngredientService, IProductService productService, IMapper mapper)
        {
            _ıngredientService = ıngredientService;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult HamburgerAdd()
        {
            HamburgerCreateVM vm = new HamburgerCreateVM();
            vm.Ingredients = Fill();
            vm.Product.CategoryId = 1;
            return View(vm);
        }
        [HttpPost]
        public IActionResult HamburgerAdd(HamburgerCreateVM VM)
        {
            if (ModelState.IsValid)
            {
                Product hamburger = _mapper.Map<Product>(VM.Product);


                //hamburger.CategoryId = 1;
                List<ProductIngredient> ıngredient = new List<ProductIngredient>();
                foreach (var item in VM.SelectedIngredients)
                {
                    ıngredient.Add(new ProductIngredient { IngredientId = item, });
                };
                hamburger.ProductIngredients = ıngredient;

                _productService.Add(hamburger);
                return RedirectToAction("HamburgerListele");
            }
            

            return View();

        }
        public IActionResult HamburgerListele()
        {

            return View(_productService.GetDetail(2));
        }
        [HttpGet]
        public IActionResult HamburgerUpdate(int ID)
        {
            HamburgerUpdateVM vm = new HamburgerUpdateVM();
            vm.Ingredients = Fill();
            vm.ProductDetails = _productService.GetProductWithDetails(ID);
            return View(vm);
        }
        [HttpPost]
        public IActionResult HamburgerUpdate(HamburgerUpdateVM VM, int ID)
        {

            _productService.RemoveAllIngredientsFromProduct(ID);
            var hamburger = _productService.GetProductIngredientsByProductId(ID);
            hamburger.ProductName = VM.ProductDetails.ProductName;
            hamburger.Price = VM.ProductDetails.ProductPrice;
            List<ProductIngredient> ıngredient = new List<ProductIngredient>();
            foreach (var item in VM.SelectedIngredients)
            {
                ıngredient.Add(new ProductIngredient { IngredientId = item });
            };
            hamburger.ProductIngredients = ıngredient;
            _productService.Update(hamburger);
            return RedirectToAction("HamburgerListele", "Product");
        }


        private List<SelectListItem> Fill()
        {

            return _ıngredientService.GetAll().Select(x => new SelectListItem()
            {
                Text = x.IngredientName,
                Value = x.IngredientId.ToString()
            }).ToList();
        }

    }
}