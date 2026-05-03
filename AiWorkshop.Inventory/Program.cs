using AiWorkshop.Inventory.Models;
using AiWorkshop.Inventory.Reports;
using AiWorkshop.Inventory.Services;

var service = new InventoryService();
var calculator = new DiscountCalculator();
var report = new InventoryReport();

var electronics = new Category { Id = 1, Name = "Electronics", Description = "Electronic devices and accessories" };
var furniture = new Category { Id = 2, Name = "Furniture", Description = "Home and office furniture" };

service.AddProduct(new Product { Id = 1, Name = "Laptop", Description = "15-inch business laptop", Price = 1299.99m, Stock = 25, Category = electronics });
service.AddProduct(new Product { Id = 2, Name = "Mechanical Keyboard", Price = 89.99m, Stock = 8, Category = electronics });
service.AddProduct(new Product { Id = 3, Name = "Standing Desk", Description = "Height-adjustable standing desk", Price = 449.00m, Stock = 12, Category = furniture });
service.AddProduct(new Product { Id = 4, Name = "Monitor Stand", Price = 34.99m, Stock = 3, Category = furniture });
service.AddProduct(new Product { Id = 5, Name = "USB Hub", Price = 29.99m, Stock = 50, Category = electronics });

Console.WriteLine("=== Inventory System ===");
Console.WriteLine();

Console.WriteLine("All products:");
foreach (var product in service.GetAll())
{
    Console.WriteLine($"  {report.GenerateSummary(product)}");
}

Console.WriteLine();
Console.WriteLine("Low stock products (< 10 units):");
foreach (var product in report.GetLowStockProducts(service.GetAll()))
{
    Console.WriteLine($"  {product.Name} — {product.Stock} left");
}

Console.WriteLine();
Console.WriteLine("Discounts on Electronics (10%):");
foreach (var product in service.GetAll().Where(p => p.Category?.Name == "Electronics"))
{
    var discounted = calculator.GetDiscountedPrice(product, 0.10m);
    Console.WriteLine($"  {product.Name}: {product.Price:C} → {discounted:C}");
}
