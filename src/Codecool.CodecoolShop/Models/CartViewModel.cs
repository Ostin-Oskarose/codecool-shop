using System.Collections.Generic;
using Codecool.CodecoolShop.Models.Products;

namespace Codecool.CodecoolShop.Models
{
    public class CartViewModel
    {
        public ShoppingCart Cart { get; set; }
        public List<Product> Products { get; set; }
    }
}