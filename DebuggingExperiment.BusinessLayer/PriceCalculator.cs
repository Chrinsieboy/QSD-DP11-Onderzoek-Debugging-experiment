using DebuggingExperiment.Models;
using System.Collections.Generic;

namespace DebuggingExperiment.BusinessLayer;

public class PriceCalculator
{
    private Dictionary<string, decimal> _priceCache = new();
    public decimal CalculateTotal(Component component)
    {
        if (_priceCache.ContainsKey(component.Name))
        {
            return _priceCache[component.Name];
        }

        decimal totalCost = component.BasePrice;

        foreach (var sub in component.SubComponents)
        {
            totalCost += CalculateTotal(sub);
            Console.WriteLine($"cost for {sub.Name}: {totalCost}");
        }
        
        _priceCache[component.Name] = totalCost; 

        return totalCost;
    }
}