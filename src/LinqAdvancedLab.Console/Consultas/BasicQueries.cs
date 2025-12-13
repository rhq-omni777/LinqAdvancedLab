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

        public void Ejecutar()
        {
            // Proyección a DTO
            var query = _ctx.Products
                .Where(p => p.Price > 500)
                .Select(p => new ProductDto(p.Name, p.Price, p.Category.Name));

            // Guardar SQL (Requisito PDF)
            string sql = query.ToQueryString();
            string path = "../../../../../docs/query1.sql"; // Ruta relativa a docs
            System.IO.File.WriteAllText(path, sql);
            System.Console.WriteLine("SQL guardado en docs/query1.sql");
        }
    }
}
