using Microsoft.EntityFrameworkCore;
using SimpleProductManagement.Models;

namespace SimpleProductManagement.Infrastructure;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options) {}

    public DbSet<ProductModel> Products {  get; set; } 
}
