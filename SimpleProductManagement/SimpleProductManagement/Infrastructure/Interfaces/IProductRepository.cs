namespace SimpleProductManagement.Infrastructure.Interfaces;

using SimpleProductManagement.Models;

public interface IProductRepository
{
    Task<List<ProductModel>> GetProducts();

    void CreateProduct(ProductModel product);
}
