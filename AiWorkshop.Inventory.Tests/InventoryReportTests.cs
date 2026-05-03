using AiWorkshop.Inventory.Models;
using AiWorkshop.Inventory.Reports;

namespace AiWorkshop.Inventory.Tests;

public class InventoryReportTests
{
    private readonly InventoryReport _report = new();

    [Fact]
    public void GetCategoryName_ProductWithCategory_ReturnsCategoryName()
    {
        var product = new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 999m,
            Stock = 10,
            Category = new Category { Id = 1, Name = "Electronics" }
        };

        var result = _report.GetCategoryName(product);

        Assert.Equal("Electronics", result);
    }

    [Fact]
    public void GetCategoryName_ProductWithoutCategory_ReturnsUncategorized()
    {
        var product = new Product { Id = 2, Name = "Generic Item", Price = 9m, Stock = 5 };

        var result = _report.GetCategoryName(product);

        Assert.Equal("Uncategorized", result);
    }

    [Fact]
    public void GenerateSummary_ProductWithCategory_ContainsExpectedDetails()
    {
        var product = new Product
        {
            Id = 3,
            Name = "Keyboard",
            Price = 89.99m,
            Stock = 15,
            Category = new Category { Id = 2, Name = "Peripherals" }
        };

        var result = _report.GenerateSummary(product);

        Assert.Contains("[3]", result);
        Assert.Contains("Keyboard", result);
        Assert.Contains("Peripherals", result);
        Assert.Contains("15", result);
    }

    [Fact]
    public void GetProductLabel_ProductWithName_ReturnsName()
    {
        var product = new Product { Id = 1, Name = "Monitor", Price = 299m, Stock = 8 };

        var result = _report.GetProductLabel(product);

        Assert.Equal("Monitor", result);
    }

    [Fact]
    public void GetLowStockProducts_ReturnsOnlyProductsBelowThreshold()
    {
        List<Product> products =
        [
            new() { Id = 1, Name = "A", Price = 10m, Stock = 3 },
            new() { Id = 2, Name = "B", Price = 20m, Stock = 15 },
            new() { Id = 3, Name = "C", Price = 30m, Stock = 7 },
        ];

        var result = _report.GetLowStockProducts(products).ToList();

        Assert.Equal(2, result.Count);
        Assert.All(result, p => Assert.True(p.Stock < 10));
    }
}
