namespace SimpleProductManagement.Infrastructure;

using Microsoft.EntityFrameworkCore;
using SimpleProductManagement.Infrastructure.Interfaces;
using SimpleProductManagement.Models;

public class ProductRepository : IProductRepository
{
    private readonly ProductContext productContext;

    public ProductRepository(ProductContext productContext)
    {
        this.productContext = productContext;
    }

    public async Task<List<ProductModel>> GetProducts()
    {
        var products = await productContext.Products.ToListAsync();
        return products;
    }

    public void CreateProduct(ProductModel product)
    {
        var newProduct = new ProductModel()
        {
            Name = product.Name,
            Category = product.Category,
            ProductCode = product.ProductCode,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            DateAdded = DateTimeOffset.Now,
        };

        productContext.Products.Add(newProduct);
        productContext.SaveChanges();
    }
}
