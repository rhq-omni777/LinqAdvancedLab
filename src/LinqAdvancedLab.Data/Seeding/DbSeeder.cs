using LinqAdvancedLab.Domain.Entities;
using System.Collections.Generic;

namespace LinqAdvancedLab.Data.Seeding
{
    public static class DbSeeder
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 1200m, Stock = 5, CategoryId = 1, Category = null! },
                new Product { Id = 2, Name = "Mouse", Price = 25m, Stock = 50, CategoryId = 1, Category = null! },
                new Product { Id = 3, Name = "Silla", Price = 150m, Stock = 3, CategoryId = 2, Category = null! },
                new Product { Id = 4, Name = "Monitor", Price = 600m, Stock = 2, CategoryId = 1, Category = null! },
                new Product { Id = 5, Name = "Teclado", Price = 45m, Stock = 30, CategoryId = 1, Category = null! },
                new Product { Id = 6, Name = "Impresora", Price = 250m, Stock = 8, CategoryId = 1, Category = null! },
                new Product { Id = 7, Name = "Tablet", Price = 700m, Stock = 1, CategoryId = 1, Category = null! },
                new Product { Id = 8, Name = "Smartphone", Price = 800m, Stock = 10, CategoryId = 1, Category = null! },
                new Product { Id = 9, Name = "Mesa", Price = 200m, Stock = 7, CategoryId = 2, Category = null! },
                new Product { Id = 10, Name = "Lámpara", Price = 40m, Stock = 25, CategoryId = 2, Category = null! },
                new Product { Id = 11, Name = "Auriculares", Price = 120m, Stock = 15, CategoryId = 1, Category = null! },
                new Product { Id = 12, Name = "Webcam", Price = 85m, Stock = 12, CategoryId = 1, Category = null! },
                new Product { Id = 13, Name = "Escritorio", Price = 450m, Stock = 4, CategoryId = 2, Category = null! },
                new Product { Id = 14, Name = "Sofá", Price = 900m, Stock = 2, CategoryId = 2, Category = null! }
            };
        }

        public static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Tech" },
                new Category { Id = 2, Name = "Muebles" }
            };
        }
    }
}