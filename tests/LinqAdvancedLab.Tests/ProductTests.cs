using Xunit;
using Microsoft.EntityFrameworkCore;
using LinqAdvancedLab.Data;
using LinqAdvancedLab.Domain.Entities;
using System.Linq;

namespace LinqAdvancedLab.Tests
{
    public class ProductTests
    {
        [Fact]
        public void AgregarProducto_DebeGuardar()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            using (var ctx = new AppDbContext())
            {
                // Truco: EnsureCreated usará InMemory aquí
                ctx.Database.EnsureCreated();
                ctx.Products.Add(new Product { Name = "Test", Price = 10 });
                ctx.SaveChanges();
            }

            using (var ctx = new AppDbContext())
            {
                Assert.Equal(1, ctx.Products.Count(p => p.Name == "Test"));
            }
        }
    }
}
