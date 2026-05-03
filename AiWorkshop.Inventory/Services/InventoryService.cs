using AiWorkshop.Inventory.Models;

namespace AiWorkshop.Inventory.Services;

public class InventoryService
{
    private readonly List<Product> _products = [];

    public void AddProduct(Product product) => _products.Add(product);

    public void RemoveProduct(int id)
    {
        try
        {
            var product = _products.FirstOrDefault(p => p.Id == id)
                ?? throw new InvalidOperationException($"Product with id {id} not found.");
            _products.Remove(product);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void AssignCategory(Product? product, Category category) => ApplyCategory(product, category);

    private void ApplyCategory(Product product, Category category) => product.Category = category;

    public void ClearProductName(Product product) => product.Name = null;

    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public IReadOnlyCollection<Product> GetAll() => _products;
}
