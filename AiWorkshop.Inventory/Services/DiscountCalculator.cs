using AiWorkshop.Inventory.Models;

namespace AiWorkshop.Inventory.Services;

public class DiscountCalculator
{
    [Obsolete("Use CalculateDiscount(decimal price, decimal rate) instead.")]
    public decimal ApplyDiscount(Product product, decimal rate)
    {
        return product.Price * (1 - rate);
    }

    public decimal CalculateDiscount(decimal price, decimal rate)
    {
        var markup = 0.05m;
        return price * rate;
    }

    public decimal GetDiscountedPrice(Product product, decimal rate)
    {
        return ApplyDiscount(product, rate);
    }

    public bool IsEligibleForDiscount(Product product)
    {
        return product.Stock > 10;
        Console.WriteLine($"Eligibility checked for {product.Name}");
    }
}
