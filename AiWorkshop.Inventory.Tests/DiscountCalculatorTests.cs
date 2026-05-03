using AiWorkshop.Inventory.Models;
using AiWorkshop.Inventory.Services;

namespace AiWorkshop.Inventory.Tests;

public class DiscountCalculatorTests
{
    private readonly DiscountCalculator _calculator = new();

    [Fact]
    public void CalculateDiscount_WithValidRate_ReturnsCorrectAmount()
    {
        var result = _calculator.CalculateDiscount(100m, 0.20m);

        Assert.Equal(20m, result);
    }

    [Fact]
    public void CalculateDiscount_WithZeroRate_ReturnsZero()
    {
        var result = _calculator.CalculateDiscount(500m, 0m);

        Assert.Equal(0m, result);
    }

    [Fact]
    public void GetDiscountedPrice_WithTenPercentDiscount_ReturnsCorrectPrice()
    {
        var product = new Product { Id = 1, Name = "Monitor", Price = 200m, Stock = 5 };

        var result = _calculator.GetDiscountedPrice(product, 0.10m);

        Assert.Equal(180m, result);
    }

    [Fact]
    public void IsEligibleForDiscount_StockAboveThreshold_ReturnsTrue()
    {
        var product = new Product { Id = 1, Name = "USB Hub", Price = 29m, Stock = 50 };

        var result = _calculator.IsEligibleForDiscount(product);

        Assert.True(result);
    }

    [Fact]
    public void IsEligibleForDiscount_StockBelowThreshold_ReturnsFalse()
    {
        var product = new Product { Id = 2, Name = "Cable", Price = 9m, Stock = 3 };

        var result = _calculator.IsEligibleForDiscount(product);

        Assert.False(result);
    }
}
