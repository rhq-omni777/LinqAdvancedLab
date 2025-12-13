using Xunit;
using Microsoft.EntityFrameworkCore;
using LinqAdvancedLab.Data;
using LinqAdvancedLab.Domain.Entities;
using System;
using System.Linq;

namespace LinqAdvancedLab.Tests
{
    public class ProductTests
    {
        private DbContextOptions<AppDbContext> CreateInMemoryDbOptions()
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        private void SeedData(AppDbContext ctx)
        {
            var cat1 = new Category { Id = 1, Name = "Tech" };
            var cat2 = new Category { Id = 2, Name = "Muebles" };

            ctx.Categories.AddRange(cat1, cat2);
            ctx.Products.AddRange(
                new Product { Id = 1, Name = "Laptop", Price = 1200, Stock = 5, CategoryId = 1, Category = null! },
                new Product { Id = 2, Name = "Mouse", Price = 25, Stock = 50, CategoryId = 1, Category = null! },
                new Product { Id = 3, Name = "Silla", Price = 150, Stock = 3, CategoryId = 2, Category = null! }
            );
            ctx.SaveChanges();
        }

        [Fact]
        public void AgregarProducto_DebeGuardar()
        {
            var options = CreateInMemoryDbOptions();

            using (var ctx = new AppDbContext(options))
            {
                ctx.Products.Add(new Product { Name = "Test", Price = 10, Category = null! });
                ctx.SaveChanges();
            }

            using (var ctx = new AppDbContext(options))
            {
                Assert.Single(ctx.Products.Where(p => p.Name == "Test"));
            }
        }

        [Theory]
        [InlineData(1000, 1)]
        [InlineData(100, 2)]
        [InlineData(50, 2)]
        public void FiltrarPorPrecio_DebeRetornarProductosCorrectos(decimal precio, int expected)
        {
            var options = CreateInMemoryDbOptions();

            using (var ctx = new AppDbContext(options))
            {
                SeedData(ctx);
            }

            using (var ctx = new AppDbContext(options))
            {
                var result = ctx.Products.Where(p => p.Price > precio).ToList();
                Assert.Equal(expected, result.Count);
            }
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public void FiltrarPorCategoria_DebeRetornarProductosCorrectos(int categoryId, int expected)
        {
            var options = CreateInMemoryDbOptions();

            using (var ctx = new AppDbContext(options))
            {
                SeedData(ctx);
            }

            using (var ctx = new AppDbContext(options))
            {
                var result = ctx.Products.Where(p => p.CategoryId == categoryId).ToList();
                Assert.Equal(expected, result.Count);
            }
        }

        [Fact]
        public void ProductoConPocasCantidades_DebeIdentificarse()
        {
            var options = CreateInMemoryDbOptions();

            using (var ctx = new AppDbContext(options))
            {
                SeedData(ctx);
            }

            using (var ctx = new AppDbContext(options))
            {
                var result = ctx.Products.Where(p => p.Stock < 5).ToList();
                Assert.NotEmpty(result);
                Assert.All(result, p => Assert.True(p.Stock < 5));
            }
        }

        [Fact]
        public void ProductosPorCategoria_DebeAgruparCorrectamente()
        {
            var options = CreateInMemoryDbOptions();

            using (var ctx = new AppDbContext(options))
            {
                SeedData(ctx);
            }

            using (var ctx = new AppDbContext(options))
            {
                var result = ctx.Products
                    .GroupBy(p => p.CategoryId)
                    .Select(g => new { CategoryId = g.Key, Count = g.Count() })
                    .ToList();

                Assert.Equal(2, result.Count);
                Assert.Contains(result, r => r.CategoryId == 1 && r.Count == 2);
                Assert.Contains(result, r => r.CategoryId == 2 && r.Count == 1);
            }
        }

        [Theory]
        [InlineData(1, 5)]
        [InlineData(2, 1)]
        public void PaginacionProductos_DebeRetornarPaginaCorrecta(int page, int pageSize)
        {
            var options = CreateInMemoryDbOptions();

            using (var ctx = new AppDbContext(options))
            {
                SeedData(ctx);
            }

            using (var ctx = new AppDbContext(options))
            {
                var skip = (page - 1) * pageSize;
                var result = ctx.Products
                    .OrderBy(p => p.Id)
                    .Skip(skip)
                    .Take(pageSize)
                    .ToList();

                Assert.NotEmpty(result);
                Assert.True(result.Count <= pageSize);
            }
        }

        [Fact]
        public void ActualizarProducto_DebeModificarDatos()
        {
            var options = CreateInMemoryDbOptions();

            using (var ctx = new AppDbContext(options))
            {
                SeedData(ctx);
            }

            using (var ctx = new AppDbContext(options))
            {
                var product = ctx.Products.First();
                product.Price = 999;
                ctx.SaveChanges();
            }

            using (var ctx = new AppDbContext(options))
            {
                var updated = ctx.Products.First();
                Assert.Equal(999, updated.Price);
            }
        }

        [Fact]
        public void EliminarProducto_DebeRemover()
        {
            var options = CreateInMemoryDbOptions();

            using (var ctx = new AppDbContext(options))
            {
                SeedData(ctx);
            }

            using (var ctx = new AppDbContext(options))
            {
                var product = ctx.Products.First();
                ctx.Products.Remove(product);
                ctx.SaveChanges();
            }

            using (var ctx = new AppDbContext(options))
            {
                Assert.Equal(2, ctx.Products.Count());
            }
        }

        [Fact]
        public void UnionProductos_DebeRetornarProductosUnificados()
        {
            var options = CreateInMemoryDbOptions();

            using (var ctx = new AppDbContext(options))
            {
                SeedData(ctx);
            }

            using (var ctx = new AppDbContext(options))
            {
                var caros = ctx.Products.Where(p => p.Price > 500);
                var pocoStock = ctx.Products.Where(p => p.Stock < 5);
                var result = caros.Union(pocoStock).ToList();

                Assert.NotEmpty(result);
            }
        }
    }

    public class CategoryTests
    {
        private DbContextOptions<AppDbContext> CreateInMemoryDbOptions()
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public void AgregarCategoria_DebeGuardar()
        {
            var options = CreateInMemoryDbOptions();

            using (var ctx = new AppDbContext(options))
            {
                ctx.Categories.Add(new Category { Name = "Electrónica" });
                ctx.SaveChanges();
            }

            using (var ctx = new AppDbContext(options))
            {
                Assert.Single(ctx.Categories);
            }
        }

        [Fact]
        public void CategoriaConProductos_DebeRelacionarse()
        {
            var options = CreateInMemoryDbOptions();

            using (var ctx = new AppDbContext(options))
            {
                var cat = new Category { Name = "Electrónica" };
                ctx.Categories.Add(cat);
                ctx.SaveChanges();

                ctx.Products.Add(new Product { Name = "Laptop", Price = 1200, Stock = 5, CategoryId = cat.Id, Category = null! });
                ctx.SaveChanges();
            }

            using (var ctx = new AppDbContext(options))
            {
                var category = ctx.Categories.Include(c => c.Products).First();
                Assert.Single(category.Products);
            }
        }
    }
}
