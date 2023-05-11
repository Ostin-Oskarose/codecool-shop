using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Controllers
{
    public class OrderHistoryController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly OrderHistoryService _orderHistoryService;

        public OrderHistoryController(UserManager<IdentityUser> userManager, OrderHistoryService orderHistoryService)
        {
            _userManager = userManager;
            _orderHistoryService = orderHistoryService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                var orderHistory = _orderHistoryService.GetOrderHistoryForUser(user.Id);
                return View(orderHistory);
            }

            return RedirectToAction("Index", "Product");
        }
    }
}
