using System.Threading.Tasks;
using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Models.UserData;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop.Controllers
{
    public class BillingController : Controller
    {
        private readonly UserManager<IdentityUser>_userManager;
        private readonly AddressService _addressService;

        public BillingController(AddressService addressService,UserManager<IdentityUser> userManager)
        {
            _addressService = addressService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveAddressTask(FullBillingViewModel fullBillingViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                if (user != null)
                {
                    _addressService.UpdateUserId(fullBillingViewModel,user.Id);
                    _addressService.Add(fullBillingViewModel.BillingAddress);
                    _addressService.Add(fullBillingViewModel.ShippingAddress);

                }




                return RedirectToAction("Index", "Product");
            }

            return Ok();

        }
    }
}
