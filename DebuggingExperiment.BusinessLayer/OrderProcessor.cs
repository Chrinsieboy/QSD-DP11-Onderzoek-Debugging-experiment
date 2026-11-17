using DebuggingExperiment.Models;

namespace DebuggingExperiment.BusinessLayer;

public class OrderProcessor
{
    public decimal CalculateTotal(Order order)
    {
        decimal total = 0m;

        foreach (var item in order.Items)
        {
            if (!item.InStock)
            {
                continue;
            }

            total += item.Price;
        }

        if (total > 0 && total < 50.00m)
        {
            total += 5.00m;
        }

        return total;
    }
}