using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LinqAdvancedLab.Data;
using LinqAdvancedLab.Domain.Entities;

namespace LinqAdvancedLab.Console.Consultas
{
    public class AdvancedQueries
    {
        private readonly AppDbContext _ctx;
        // Query Compilada (Requisito PDF)
        private static readonly Func<AppDbContext, decimal, IEnumerable<Product>> _filtro =
            EF.CompileQuery((AppDbContext db, decimal p) => db.Products.Where(x => x.Price > p));

        public AdvancedQueries(AppDbContext ctx) => _ctx = ctx;

        public void Paginacion()
        {
            var lista = _ctx.Products.OrderBy(p => p.Name).Skip(0).Take(2).ToList();
        }
        public void Union()
        {
            var q1 = _ctx.Products.Where(p => p.Price > 500);
            var q2 = _ctx.Products.Where(p => p.Stock < 5);
            var union = q1.Union(q2).ToList();
        }
        public void Compilada()
        {
            var res = _filtro(_ctx, 100).ToList();
        }
    }
}