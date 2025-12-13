using Microsoft.EntityFrameworkCore;
using LinqAdvancedLab.Domain.Entities;
using LinqAdvancedLab.Data.Seeding;

namespace LinqAdvancedLab.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LinqAdvancedLab;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Product>().HasIndex(p => p.Stock); // Requisito PDF
            model.Entity<Category>().HasData(DbSeeder.GetCategories());
            model.Entity<Product>().HasData(DbSeeder.GetProducts());
        }
    }
}
