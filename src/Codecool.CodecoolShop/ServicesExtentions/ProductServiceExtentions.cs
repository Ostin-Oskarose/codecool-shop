using Codecool.CodecoolShop.Models.Products;

namespace Codecool.CodecoolShop.ServicesExtentions
{
	public static class ProductServiceExtentions
	{
		public static decimal CalculateDiscount(this Product product, decimal discount)
		{
			product.DefaultPrice = product.DefaultPrice < discount ? 0 : product.DefaultPrice;
			return product.DefaultPrice - discount;
		}
	}
}
