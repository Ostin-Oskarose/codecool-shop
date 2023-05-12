using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models.Cart
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Dictionary<int, int> Items { get; set; }

        public ShoppingCart()
        {
            Items = new Dictionary<int, int>();
        }

    }
}
