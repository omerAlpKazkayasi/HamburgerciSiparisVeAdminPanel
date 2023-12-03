using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entitiess.Concrete.DBcontext;
using HamburgerUI.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;

namespace HamburgerUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        ICartItemService _cartItemService;
        IOrderDetailService _orderDetailService;
        IOrderService _orderService;
        IIngredientService _ingredientService;
        ICartService _cartService;
        private readonly UserManager<User> _userManager;

        public ProductController(IProductService productService, ICartItemService cartItemService, IOrderDetailService orderDetailService, IOrderService orderService, IIngredientService ingredientService, UserManager<User> userManager, ICartService cartService)
        {
            _productService = productService;
            _cartItemService = cartItemService;
            _orderDetailService = orderDetailService;
            _orderService = orderService;
            _ingredientService = ingredientService;
            _userManager = userManager;
            _cartService = cartService;
        }


        public IActionResult Index()
        {
            var productsWithCategory = _productService.GetProductsWithCategory();
            return View(productsWithCategory);
        }


        public async Task<IActionResult> SepeteEkle(int? id)
        {

            if (User.Identity.IsAuthenticated)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                var cart = _cartService.GetCartByUserId(user.Id);

                if (id is not null)
                {
                    var cartItem = new List<CartItem>()
                           {
                                  new CartItem()                  //todo new'lenmenin önüne geçilecek
                                  {
                                                       ProductId = id.Value,
                                                       Quantity = 1,
                                                       CartId = cart.CartId,
                                                       TotalPrice = _productService.GetById(id.Value).Price
                                  }
                           };

                    _cartItemService.AddRange(cartItem);
                }


                return RedirectToAction("CreateCart");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }


        public  async Task<IActionResult> CreateCart()
        {
            if (User.Identity.IsAuthenticated)
            {
                var cartIngredientVM = await GetCartItems();
                return View(cartIngredientVM);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        private async Task<CartIngredientVM> GetCartItems()
        {

            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            var cart = _cartService.GetCartByUserId(user.Id);

            var cartItems = _cartItemService.GetByCartIdWithProducts(cart.CartId);
            List<ProductDetailsDTO> products = new List<ProductDetailsDTO>();
            foreach (var item in cartItems)
            {
                products.Add(_productService.GetProductWithDetails(item.ProductId));
            }
            CartIngredientVM cartIngredientVM = new CartIngredientVM();
            cartIngredientVM.CartItems = cartItems;
            cartIngredientVM.ProductDetailsDTOs = products;
            return cartIngredientVM;

        }



        [HttpPost]
        public async Task<IActionResult> SiparisiOnayla(CartIngredientVM model, Dictionary<int, List<int>> selectedIngredients)
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            var cart = _cartService.GetCartByUserId(user.Id);
            //_orderService.Add(new Order()
            //{
            //    UserId = user.Id,
            //});
            var order = (new Order()
            {
                UserId = user.Id,
            });
            order.TotalPrice = _orderDetailService.GetTotalPriceByCartId(cart.CartId);
            order.OrderDate = DateTime.Now;
            _orderService.Add(order);



            string text = "";

                foreach (var cartItemId in selectedIngredients.Keys)
                {
                    var selectedIngredientIds = selectedIngredients[cartItemId];
                    foreach (var item in selectedIngredientIds)
                    {
                        text += _ingredientService.GetById(item).IngredientName + " yok, ".TrimEnd(',');
                    }
                    var CartItemDetails = _cartItemService.GetById(cartItemId);
                    _orderDetailService.Add(new OrderDetail()
                    {

                        ProductId = CartItemDetails.ProductId,
                        Quantity = CartItemDetails.Quantity,
                        OrderId = order.OrderId,
                        RemovedIngredients = text
                    });
                }

            
            foreach (var cartItem in model.CartItems)
            {
                if (selectedIngredients.ContainsKey(cartItem.CartItemId))
                {

                }
                else
                {
                    _orderDetailService.Add(new OrderDetail()
                    {
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity,
                        OrderId = order.OrderId,
                    });
                }

            }
            var cartItemsOrder = _cartItemService.GetCartItemsByCartId(cart.CartId);
            //_orderService.Update(order);
            foreach (var item in cartItemsOrder)
            {
                _cartItemService.Delete(item);
            }
            return RedirectToAction("Index");
        }



        /// <summary>
        /// Quantity degistiginde tetiklenecek ve fiyatı güncellenecek
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("product/{productId}/price")]
        public IActionResult GetPriceByProductId(int productId)
        {
            decimal price = _productService.GetPriceByProductId(productId);
            if (price > 0)
            {
                return Ok(price);
            }
            return NotFound();
        }



        public IActionResult Arttir(int? id) //CartItemId Id gelecek
        {
            _cartItemService.QuantityIncrease(id.Value);
            return RedirectToAction("SepeteEkle");
        }


        public IActionResult Azalt(int? id) //CartItemId Id gelecek
        {
            var result = _cartItemService.QuantityDecrease(id.Value);
            if (result is null)
            {
                TempData["result"] = "Ürün Sepetinizden Silindi";
            }
            return RedirectToAction("SepeteEkle");
        }

    }
}