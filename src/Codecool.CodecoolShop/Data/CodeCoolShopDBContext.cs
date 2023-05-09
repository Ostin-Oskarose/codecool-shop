using Codecool.CodecoolShop.Models.Products;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop.Data;

public class CodeCoolShopDBContext : IdentityDbContext
{
    public CodeCoolShopDBContext(DbContextOptions<CodeCoolShopDBContext> options) : base(options)
    {

    }

    public virtual DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasOne(x => x.Supplier);
    }
}