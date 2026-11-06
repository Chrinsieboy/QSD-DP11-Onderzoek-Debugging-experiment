namespace DebuggingExperiment.Models;
using System.Collections.Generic;

public class Order
{
    public Customer Customer { get; }
    public List<OrderItem> Items { get; } = new();

    public Order(Customer customer)
    {
        Customer = customer;
    }

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
    }
}