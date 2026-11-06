namespace DebuggingExperiment.Models;

public class OrderItem
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public bool InStock { get; set; }

    public OrderItem(string productName, decimal price, bool inStock)
    {
        ProductName = productName;
        Price = price;
        InStock = inStock;
    }
}