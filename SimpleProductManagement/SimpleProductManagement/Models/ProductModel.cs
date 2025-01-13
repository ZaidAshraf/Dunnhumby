namespace SimpleProductManagement.Models;

public class ProductModel
{
    public int Id { get; set; }

    public string Category { get; set; }

    public string Name { get; set; }

    public string ProductCode { get; set; }

    public double Price { get; set; }

    public int StockQuantity { get; set; }

    public DateTimeOffset DateAdded { get; set; }
}
