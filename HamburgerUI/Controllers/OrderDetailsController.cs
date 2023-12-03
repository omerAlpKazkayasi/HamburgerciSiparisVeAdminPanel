using BusinessLayer.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerUI.Controllers
{
   
    public class OrderDetailsController : Controller
    {
        

        IOrderDetailService orderDetailService;
        private readonly UserManager<User> _userManager;

        public OrderDetailsController(IOrderDetailService orderDetailService, UserManager<User> userManager)
        {
            this.orderDetailService = orderDetailService;
            _userManager = userManager;
        }
        [Authorize(Roles = "User")]
        public async Task<IActionResult> OrderDetails()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            var orderDetails = orderDetailService.GetUserOrderDetailsByUserId(user.Id);


            return View(orderDetails);
        }
    }
}
