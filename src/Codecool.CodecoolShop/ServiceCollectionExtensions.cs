using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Codecool.CodecoolShop
{
	public static class ServiceCollectionExtensions
	{

		public static IServiceCollection AddSeeds(this IServiceCollection services)
		{
			services.AddScoped<CodeCoolShopSeed>();

			return services;
		}
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			AddShop(services);
			AddEmailHandling(services);

			return services;
		}

		private static void AddShop(IServiceCollection services)
		{
			services.AddScoped<ProductService>();
			services.AddScoped<CartService>();
			services.AddScoped<SupplierService>();
			services.AddScoped<AddressService>();
		}

		private static void AddEmailHandling(IServiceCollection services)
		{
		}
	}
}
