using Microsoft.EntityFrameworkCore;
using LinqAdvancedLab.Domain.Entities;
using LinqAdvancedLab.Data.Seeding;

namespace LinqAdvancedLab.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Fallback para desarrollo local. Preferible configurar desde DI/Startup en la aplicación de host.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LinqAdvancedLab;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            // Configuración de relaciones
            model.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Índices para optimización (Requisito PDF)
            model.Entity<Product>().HasIndex(p => p.Stock);
            model.Entity<Product>().HasIndex(p => p.Price);

            // Seed de datos
            model.Entity<Category>().HasData(DbSeeder.GetCategories());
            model.Entity<Product>().HasData(DbSeeder.GetProducts());
        }
    }
}
