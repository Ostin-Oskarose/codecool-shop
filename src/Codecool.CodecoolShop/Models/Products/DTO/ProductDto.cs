﻿namespace Codecool.CodecoolShop.Models.Products.DTO
{
    public class ProductDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal Subtotal { get; set; }
    }
}
