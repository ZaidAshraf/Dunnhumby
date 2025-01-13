using Microsoft.EntityFrameworkCore;
using SimpleProductManagement.Infrastructure.Interfaces;

namespace SimpleProductManagement.Infrastructure;

public static class ProductDbConfig
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ProductContext>(options =>
        {
            options.UseSqlServer(connectionString);
        })
            .AddScoped<IProductRepository, ProductRepository>();
    }
}
