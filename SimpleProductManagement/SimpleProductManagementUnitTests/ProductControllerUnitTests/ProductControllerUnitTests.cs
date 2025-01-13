namespace SimpleProductManagementUnitTests.ProductControllerUnitTests;

using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SimpleProductManagement.Controllers;
using SimpleProductManagement.Infrastructure.Interfaces;
using SimpleProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[TestFixture, Category("UnitTest")]
public class ProductControllerUnitTests
{
    private Mock<IProductRepository> productRepositoryMock;

    private ProductController productController;

    [SetUp]
    public void Setup()
    {
        productRepositoryMock = new Mock<IProductRepository>();

        productController = new ProductController(productRepositoryMock.Object);
    }

    [Test]
    public async Task ProductController_GetProducts_ShouldReturnProducts()
    {
        // Arrange
        var testProduct = new List<ProductModel>()
        {
            new()
            {
                Name = "Test",
                Category = "Clothes",
                ProductCode = "au2",
                Price = 2.8,
                StockQuantity = 4,
                DateAdded = DateTime.Now,
            }
        };

        productRepositoryMock.Setup(mock => mock.GetProducts()).ReturnsAsync(testProduct);

        // Act
        var response = await productController.GetProducts();

        // Assert
        ((OkObjectResult)response).Value.Should().Be(testProduct);
    }

    [Test]
    public async Task ProductController_GetProducts_ShouldReturnEmptyProductList()
    {
        // Arrange
        var testProduct = new List<ProductModel>();

        productRepositoryMock.Setup(mock => mock.GetProducts()).ReturnsAsync(testProduct);

        // Act
        var response = await productController.GetProducts();

        // Assert
        ((OkObjectResult)response).Value.Should().Be(testProduct);
    }

    [Test]
    public void ProductController_CreateProduct_ShouldCreateProduct()
    {
        // Arrange
        var testProduct = new ProductModel()
        {
            Name = "Testing",
            Category = "food",
            ProductCode = "12u9",
            Price = 5,
            StockQuantity = 9,
            DateAdded = DateTime.Now,
        };

        // Act
        var response = productController.CreateProduct(testProduct);

        // Assert
        response.Should().BeOfType<OkResult>();
        productRepositoryMock.Verify(mock => mock.CreateProduct(It.Is<ProductModel>(pm => pm.Name == testProduct.Name && pm.Category == testProduct.Category)));
    }

    [Test]
    public void ProductController_CreateProduct_WithNullProductModel_ShouldReturnBadRequest()
    {
        // Arrange
        var testProduct = (ProductModel)null;

        // Act
        var response = productController.CreateProduct(testProduct);

        // Assert
        response.Should().BeOfType<BadRequestObjectResult>();
    }
}
