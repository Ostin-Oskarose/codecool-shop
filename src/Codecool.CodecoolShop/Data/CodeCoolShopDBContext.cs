using System.Security.Cryptography.X509Certificates;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Models.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Supplier = Codecool.CodecoolShop.Models.Products.Supplier;

namespace Codecool.CodecoolShop.Data;

public class CodeCoolShopDBContext : IdentityDbContext
{
    public CodeCoolShopDBContext(DbContextOptions<CodeCoolShopDBContext> options) : base(options)
    {

    }

    public virtual DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<DatabaseCart> Carts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasOne(x => x.Supplier);
        //modelBuilder.Entity<DatabaseCart>().HasOne(x => x.UserId);
    }
}