using AiWorkshop.Inventory.Models;

namespace AiWorkshop.Inventory.Reports;

public class InventoryReport
{
    public string GetCategoryName(Product product)
    {
        string? categoryName = product.Category?.Name;
        return categoryName ?? "Uncategorized";
    }

    public string GenerateSummary(Product product)
    {
        var categoryName = product.Category?.Name ?? "Uncategorized";
        return $"[{product.Id}] {product.Name} - {categoryName} (Stock: {product.Stock}, Price: {product.Price:C})";
    }

    public string? GetProductLabel(Product? product) => product?.Name;

    public IEnumerable<Product> GetLowStockProducts(IEnumerable<Product> products, int threshold = 10) =>
        products.Where(p => p.Stock < threshold);
}
