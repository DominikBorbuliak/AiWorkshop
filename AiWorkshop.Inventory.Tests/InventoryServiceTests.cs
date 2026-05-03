using AiWorkshop.Inventory.Models;
using AiWorkshop.Inventory.Services;

namespace AiWorkshop.Inventory.Tests;

public class InventoryServiceTests
{
    private readonly InventoryService _service = new();

    [Fact]
    public void AddProduct_ValidProduct_AddsToCollection()
    {
        var product = new Product { Id = 1, Name = "Laptop", Price = 999m, Stock = 10 };

        _service.AddProduct(product);

        Assert.Single(_service.GetAll());
    }

    [Fact]
    public void GetById_ExistingId_ReturnsCorrectProduct()
    {
        var product = new Product { Id = 42, Name = "Keyboard", Price = 59m, Stock = 5 };
        _service.AddProduct(product);

        var result = _service.GetById(42);

        Assert.NotNull(result);
        Assert.Equal("Keyboard", result.Name);
    }

    [Fact]
    public void GetById_NonExistingId_ReturnsNull()
    {
        var result = _service.GetById(999);

        Assert.Null(result);
    }

    [Fact]
    public void GetAll_ReturnsAllAddedProducts()
    {
        _service.AddProduct(new Product { Id = 1, Name = "Mouse", Price = 29m, Stock = 20 });
        _service.AddProduct(new Product { Id = 2, Name = "Monitor", Price = 299m, Stock = 7 });
        _service.AddProduct(new Product { Id = 3, Name = "Webcam", Price = 79m, Stock = 15 });

        var all = _service.GetAll().ToList();

        Assert.Equal(3, all.Count);
    }

    [Fact]
    public void RemoveProduct_ExistingId_RemovesFromCollection()
    {
        _service.AddProduct(new Product { Id = 1, Name = "Headset", Price = 149m, Stock = 4 });
        _service.AddProduct(new Product { Id = 2, Name = "Speaker", Price = 199m, Stock = 6 });

        _service.RemoveProduct(1);

        Assert.Single(_service.GetAll());
        Assert.Null(_service.GetById(1));
    }

    [Fact]
    public void AssignCategory_AssignsCategoryToProduct()
    {
        var product = new Product { Id = 1, Name = "Tablet", Price = 499m, Stock = 12 };
        var category = new Category { Id = 1, Name = "Electronics" };
        _service.AddProduct(product);

        _service.AssignCategory(product, category);

        Assert.Equal("Electronics", product.Category?.Name);
    }
}
