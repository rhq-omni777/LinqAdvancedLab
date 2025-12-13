using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LinqAdvancedLab.Data;
using LinqAdvancedLab.Domain.Entities;
using LinqAdvancedLab.Domain.DTOs;

namespace LinqAdvancedLab.Console.Consultas
{
    public class AdvancedQueries
    {
        private readonly AppDbContext _ctx;
        private static readonly Func<AppDbContext, decimal, IEnumerable<Product>> _filtro =
            EF.CompileQuery((AppDbContext db, decimal p) => db.Products.Where(x => x.Price > p).AsEnumerable());

        public AdvancedQueries(AppDbContext ctx) => _ctx = ctx;

        /// <summary>Query 5: Paginación avanzada</summary>
        public PaginatedResult<ProductDto> GetPaginado(int page = 1, int pageSize = 5)
        {
            var query = _ctx.Products.AsQueryable();
            var total = query.Count();
            var items = query
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductDto(p.Name, p.Price, p.Category.Name))
                .ToList();

            return new PaginatedResult<ProductDto>
            {
                Items = items,
                Total = total,
                Page = page,
                PageSize = pageSize
            };
        }

        /// <summary>Query 6: Agregados y Grouping</summary>
        public List<ProductosPorCategoria> AgregatosYGrouping()
        {
            var resultado = _ctx.Products
                .GroupBy(p => p.Category.Name)
                .Select(g => new ProductosPorCategoria
                {
                    NombreCategoria = g.Key,
                    Cantidad = g.Count(),
                    PrecioPromedio = g.Average(p => p.Price),
                    PrecioMaximo = g.Max(p => p.Price),
                    PrecioMinimo = g.Min(p => p.Price)
                })
                .OrderByDescending(x => x.Cantidad)
                .ToList();

            return resultado;
        }

        /// <summary>Query 7: Union de consultas</summary>
        public List<Product> Union()
        {
            var productosCaros = _ctx.Products.Where(p => p.Price > 500);
            var productosPocoStock = _ctx.Products.Where(p => p.Stock < 5);
            var union = productosCaros.Union(productosPocoStock).ToList();

            return union;
        }

        /// <summary>Query 8: Intersect (productos con ambas condiciones)</summary>
        public List<Product> Intersect()
        {
            var productosCaros = _ctx.Products.Where(p => p.Price > 500);
            var productosPocoStock = _ctx.Products.Where(p => p.Stock < 5);
            var interseccion = productosCaros.Intersect(productosPocoStock).ToList();

            return interseccion;
        }

        /// <summary>Query 9: Except (productos caros que NO tienen poco stock)</summary>
        public List<Product> Except()
        {
            var productosCaros = _ctx.Products.Where(p => p.Price > 500);
            var productosPocoStock = _ctx.Products.Where(p => p.Stock < 5);
            var diferencia = productosCaros.Except(productosPocoStock).ToList();

            return diferencia;
        }

        /// <summary>Query 10: Subquery con Any (categorías con productos por encima de precio)</summary>
        public List<Category> SubqueryAny()
        {
            var categoriasConProductosCaro = _ctx.Categories
                .Where(c => c.Products.Any(p => p.Price > 500))
                .OrderBy(c => c.Name)
                .ToList();

            return categoriasConProductosCaro;
        }

        /// <summary>Query 11: Subquery con All (categorías donde TODOS los productos cuestan más de X)</summary>
        public List<Category> SubqueryAll()
        {
            var categoriasConTodosCaros = _ctx.Categories
                .Where(c => c.Products.Count > 0 && c.Products.All(p => p.Price > 20))
                .ToList();

            return categoriasConTodosCaros;
        }

        /// <summary>Query 12: JOIN explícito y proyección compleja</summary>
        public List<ProductoConDetallesDto> JoinExplicito()
        {
            var resultado = _ctx.Products
                .Join(_ctx.Categories,
                    p => p.CategoryId,
                    c => c.Id,
                    (p, c) => new ProductoConDetallesDto
                    {
                        NombreProducto = p.Name,
                        NombreCategoria = c.Name,
                        Precio = p.Price,
                        Stock = p.Stock,
                        PrecioConIVA = p.Price * 1.21m
                    })
                .OrderBy(x => x.NombreCategoria)
                .ThenBy(x => x.NombreProducto)
                .ToList();

            return resultado;
        }

        /// <summary>Query compilada para filtro por precio (requisito PDF)</summary>
        public List<Product> CompiladaFiltro(decimal precioMinimo)
        {
            var res = _filtro(_ctx, precioMinimo).ToList();
            return res;
        }

        /// <summary>Query 13: Paginación con búsqueda y filtros múltiples</summary>
        public PaginatedResult<ProductDto> BusquedaAvanzada(string busqueda, int? categoryId, decimal? precioMin, int page = 1, int pageSize = 5)
        {
            var query = _ctx.Products.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
                query = query.Where(p => p.Name.Contains(busqueda));

            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId.Value);

            if (precioMin.HasValue)
                query = query.Where(p => p.Price >= precioMin.Value);

            var total = query.Count();
            var items = query
                .OrderBy(p => p.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductDto(p.Name, p.Price, p.Category.Name))
                .ToList();

            return new PaginatedResult<ProductDto>
            {
                Items = items,
                Total = total,
                Page = page,
                PageSize = pageSize
            };
        }
    }

    public class PaginatedResult<T>
    {
        public required List<T> Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class ProductosPorCategoria
    {
        public required string NombreCategoria { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioPromedio { get; set; }
        public decimal PrecioMaximo { get; set; }
        public decimal PrecioMinimo { get; set; }
    }

    public class ProductoConDetallesDto
    {
        public required string NombreProducto { get; set; }
        public required string NombreCategoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public decimal PrecioConIVA { get; set; }
    }
}