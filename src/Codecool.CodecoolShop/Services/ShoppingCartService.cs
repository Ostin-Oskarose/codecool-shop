using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using Codecool.CodecoolShop.Models.Cart;
using Microsoft.AspNetCore.Http;

namespace Codecool.CodecoolShop.Services;

public class ShoppingCartService
{

    public ShoppingCart GetCart(HttpContext httpContext)
    {
        ShoppingCart cart;
        if (httpContext.Session.Get("Cart") != null)
        {
            Debug.WriteLine("Found existing cart");
            cart = JsonSerializer.Deserialize<ShoppingCart>(httpContext.Session.Get("Cart"));
        }
        else
        {
            Debug.WriteLine("Created new cart");
            cart = new ShoppingCart();
            SaveCart(cart, httpContext);
        }

        return cart;
    }

    public void SaveCart(ShoppingCart cart, HttpContext httpContext)
    {
        Debug.WriteLine("Saved cart");
        foreach (var item in cart.Items.Keys.ToList().Where(key => cart.Items[key] == 0))
        {
            cart.Items.Remove(item);
        }
        httpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
    }

    public int GetAmountOfCartItems(HttpContext httpContext)
    {
        return JsonSerializer.Deserialize<ShoppingCart>(httpContext.Session.Get("Cart")).Items.Count;
    }
}