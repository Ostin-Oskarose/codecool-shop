using Codecool.CodecoolShop.Models.Products;
using Codecool.CodecoolShop.Models.UserData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop.Data;

public class CodeCoolShopDBContext : IdentityDbContext
{
    public CodeCoolShopDBContext(DbContextOptions<CodeCoolShopDBContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<BillingAddressModel> BillingAddressModels { get; set; }
    public DbSet<ShippingAddressModel> ShippingAddressModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasOne(x => x.Supplier);
    }
}