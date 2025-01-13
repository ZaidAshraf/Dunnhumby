namespace SimpleProductManagement.Controllers;

using Microsoft.AspNetCore.Mvc;
using SimpleProductManagement.Infrastructure.Interfaces;
using SimpleProductManagement.Models;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IProductRepository productRepository;

    public ProductController(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    [HttpPost]
    public IActionResult CreateProduct(ProductModel product)
    {
        try
        {
            if (product == null)
            {
                return BadRequest("Product data is required");
            }
            productRepository.CreateProduct(product);
            return Ok();
        }
        catch (Exception ex) 
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await productRepository.GetProducts();
        return Ok(products);
    }
}
