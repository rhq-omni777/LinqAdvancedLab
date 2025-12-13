using LinqAdvancedLab.Data;
using LinqAdvancedLab.Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinqAdvancedLab.Console.Consultas
{
    public class BasicQueries
    {
        private readonly AppDbContext _ctx;
        public BasicQueries(AppDbContext ctx) => _ctx = ctx;

        /// <summary>Query 1: Proyección básica a DTO</summary>
        public void Query1_ProyeccionBasica()
        {
            var query = _ctx.Products
                .Where(p => p.Price > 500)
                .Select(p => new ProductDto(p.Name, p.Price, p.Category.Name));

            string sql = query.ToQueryString();
            SaveSQL("query1_proyeccion_basica.sql", sql);
            System.Console.WriteLine("? Query 1 ejecutada");
        }

        /// <summary>Query 2: Filtro y ordenamiento</summary>
        public void Query2_FiltroOrdenamiento()
        {
            var query = _ctx.Products
                .Where(p => p.Stock > 0 && p.Price < 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ProductDto(p.Name, p.Price, p.Category.Name));

            string sql = query.ToQueryString();
            SaveSQL("query2_filtro_ordenamiento.sql", sql);
            System.Console.WriteLine("? Query 2 ejecutada");
        }

        /// <summary>Query 3: Filtro avanzado con múltiples condiciones</summary>
        public void Query3_FiltroAvanzado()
        {
            var query = _ctx.Products
                .Where(p => (p.Price > 100 && p.Stock < 20) || p.Name.Contains("Laptop"))
                .OrderByDescending(p => p.Price)
                .Select(p => new ProductDto(p.Name, p.Price, p.Category.Name));

            string sql = query.ToQueryString();
            SaveSQL("query3_filtro_avanzado.sql", sql);
            System.Console.WriteLine("? Query 3 ejecutada");
        }

        /// <summary>Query 4: Proyección con expresión calculada</summary>
        public void Query4_ProyeccionCalculada()
        {
            var query = _ctx.Products
                .Where(p => p.Stock > 0)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Categoria = p.Category.Name,
                    PrecioConIVA = p.Price * 1.21m,
                    ValorInventario = p.Price * p.Stock
                })
                .OrderByDescending(x => x.ValorInventario);

            string sql = query.ToQueryString();
            SaveSQL("query4_proyeccion_calculada.sql", sql);
            System.Console.WriteLine("? Query 4 ejecutada");
        }

        private void SaveSQL(string fileName, string sql)
        {
            try
            {
                string projectDir = AppDomain.CurrentDomain.BaseDirectory;
                string docsPath = System.IO.Path.Combine(projectDir, "..", "..", "..", "..", "..", "docs");
                docsPath = System.IO.Path.GetFullPath(docsPath);

                if (!System.IO.Directory.Exists(docsPath))
                    System.IO.Directory.CreateDirectory(docsPath);

                string filePath = System.IO.Path.Combine(docsPath, fileName);
                System.IO.File.WriteAllText(filePath, sql);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"? Error guardando SQL: {ex.Message}");
            }
        }
    }
}
