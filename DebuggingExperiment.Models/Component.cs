using System.Collections.Generic;

namespace DebuggingExperiment.Models;

public class Component
{
    public string Name { get; set; }
    public decimal BasePrice { get; set; }
    
    public List<Component> SubComponents { get; set; } = new();

    public Component(string name, decimal basePrice)
    {
        Name = name;
        BasePrice = basePrice;
    }

    public void Add(Component component)
    {
        SubComponents.Add(component);
    }
}