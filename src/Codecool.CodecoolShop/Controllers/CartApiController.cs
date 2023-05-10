using Codecool.CodecoolShop.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using Codecool.CodecoolShop.Models.API;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Codecool.CodecoolShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
        private readonly ShoppingCartLogic _shoppingCartLogic;
        private readonly CartService _cartService;

        public CartApiController(CartService cartService)
        {
            _shoppingCartLogic = new ShoppingCartLogic();
            _cartService = cartService;
        }

        [HttpPost]
        public HttpResponseMessage SaveCart()
        {
            if (!HttpContext.User.Identity.IsAuthenticated) return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var cart = _shoppingCartLogic.GetCart(HttpContext);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _cartService.SaveCart(userId, cart);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public void AdjustCartQuantity(AdjustCartQuantityParameters parameters)
        {
            var cart = _shoppingCartLogic.GetCart(HttpContext);
            cart.Items[parameters.productId] = parameters.quantity;
            _shoppingCartLogic.SaveCart(cart, HttpContext);
        }

        [HttpPost]
        public void RemoveFromCart(RemoveFromCartParameters parameters)
        {
            var cart = _shoppingCartLogic.GetCart(HttpContext);
            cart.Items.Remove(parameters.productId);
            _shoppingCartLogic.SaveCart(cart, HttpContext);
        }
    }
}
