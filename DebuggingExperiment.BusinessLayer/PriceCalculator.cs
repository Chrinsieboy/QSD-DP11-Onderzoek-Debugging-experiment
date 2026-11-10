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
        }

        // BUG: Hier wordt de verkeerde waarde in de cache opgeslagen.
        // FIX: Sla de totale kosten op in de cache.
        _priceCache[component.Name] = component.BasePrice;
        // _priceCache[component.Name] = totalCost;

        return totalCost;
    }
}