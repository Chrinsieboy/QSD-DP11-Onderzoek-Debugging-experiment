using DebuggingExperiment.Models;

namespace DebuggingExperiment.BusinessLayer;

public class OrderProcessor
{
    public decimal CalculateTotal(Order order)
    {
        decimal total = 0m;

        foreach (var item in order.Items)
        {
            Console.WriteLine(item.InStock);
            if (!item.InStock)
            {
                break;
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