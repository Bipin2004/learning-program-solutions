using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        // Retrieve all products
        var products = await context.Products.ToListAsync();
        Console.WriteLine("All Products:");
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - ₹{p.Price}");

        // Find by ID
        var product = await context.Products.FindAsync(1);
        Console.WriteLine($"Found: {product?.Name}");

        // FirstOrDefault with condition
        var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"Expensive: {expensive?.Name}");
    }
}
