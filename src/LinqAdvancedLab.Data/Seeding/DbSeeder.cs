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
                new Product { Id=1, Name="Laptop", Price=1200, Stock=5, CategoryId=1 },
                new Product { Id=2, Name="Mouse", Price=25, Stock=50, CategoryId=1 },
                new Product { Id=3, Name="Silla", Price=150, Stock=3, CategoryId=2 }
            };
        }

        public static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Id=1, Name="Tech" },
                new Category { Id=2, Name="Muebles" }
            };
        }
    }
}