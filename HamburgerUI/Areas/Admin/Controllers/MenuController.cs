using AutoMapper;
using BusinessLayer.Abstract;
using Entities.Concrete;
using HamburgerUI.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HamburgerUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MenuController : Controller
    {
        private readonly IIngredientService _ıngredientService;
        private readonly IProductService _productService;
        private readonly ISizeService _sizeService;
        private readonly IMapper _mapper;
        public MenuController(IProductService productService, ISizeService sizeService, IIngredientService ıngredientService, IMapper mapper)
        {
            _productService = productService;
            _sizeService = sizeService;
            _ıngredientService = ıngredientService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MenuAdd()
        {
            MenuCreateVM vm = new MenuCreateVM();
            vm.Ingredients = FillIngredients();
            vm.Sizes = FillSizes();
            return View(vm);
        }
        [HttpPost]
        public IActionResult MenuAdd(MenuCreateVM VM)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in FillSizes())
                {
                    Product Menu = _mapper.Map<Product>(item);
                    
                    List<ProductIngredient> ıngredient = new List<ProductIngredient>();
                    foreach (var item2 in VM.SelectedIngredients)
                    {
                        ıngredient.Add(new ProductIngredient { IngredientId = item2 });
                    };
                    Menu.ProductIngredients = ıngredient;
                    Menu.SizeId = int.Parse(item.Value);

                    _productService.Add(Menu);
                }
                return View();
            }
            return View();

        }
        public IActionResult MenuListele()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.mesaj = $"Hoşgeldin {User.Identity.Name}";
            }
            
            return View(_productService.GetDetail(1));
        }

        public IActionResult MenuUpdate(int ID)
        {
            MenuUpdateVM vm = new MenuUpdateVM();
            vm.Ingredients = FillIngredients();
            vm.ProductDetails = _productService.GetProductWithDetails(ID);
            
            return View(vm);
        }
        [HttpPost]
        public IActionResult MenuUpdate(MenuUpdateVM VM, int ID)
        {
            if (ModelState.IsValid)
            {
                _productService.RemoveAllIngredientsFromProduct(ID);
                var Menu = _productService.GetProductIngredientsByProductId(ID);
                Menu.ProductName = VM.ProductDetails.ProductName;
                Menu.Price = VM.ProductDetails.ProductPrice;
                List<ProductIngredient> ıngredient = new List<ProductIngredient>();
                foreach (var item in VM.SelectedIngredients)
                {
                    ıngredient.Add(new ProductIngredient { IngredientId = item });
                };
                Menu.ProductIngredients = ıngredient;
                _productService.Update(Menu);
                return RedirectToAction("MenuListele", "Menu");
            }
            TempData["message"] = "LütfenTekrar Deneyiniz";
            return RedirectToAction("MenuListele", "Menu");
        }
        private List<SelectListItem> FillIngredients()
        {

            return _ıngredientService.GetAll().Select(x => new SelectListItem()
            {
                Text = x.IngredientName,
                Value = x.IngredientId.ToString()
            }).ToList();
        }
        private List<SelectListItem> FillSizes()
        {

            return _sizeService.GetAll().Select(x => new SelectListItem()
            {
                Text = x.SizeName,
                Value = x.SizeId.ToString()
            }).ToList();
        }
    }
}