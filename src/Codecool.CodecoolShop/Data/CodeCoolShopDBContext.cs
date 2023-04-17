﻿using Codecool.CodecoolShop.Models;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop.Data;

public class CodeCoolShopDBContext : DbContext
{
    public CodeCoolShopDBContext(DbContextOptions<CodeCoolShopDBContext> options): base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
}