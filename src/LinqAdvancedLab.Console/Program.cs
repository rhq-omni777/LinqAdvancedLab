using LinqAdvancedLab.Data;
using LinqAdvancedLab.Console.Consultas;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
Console.WriteLine("║      LinqAdvancedLab - Demonstración de Queries LINQ       ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");

try
{
    // Detectar flag para recrear la base de datos
    bool recreate = args.Contains("--recreate") || Environment.GetEnvironmentVariable("RECREATE_DB") == "1";

    // Crear contexto
    var options = new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LinqAdvancedLab;Trusted_Connection=True;")
        .Options;

    using (var context = new AppDbContext(options))
    {
        if (recreate)
        {
            Console.WriteLine("→ RECREATE MODE: Eliminando y recreando la base de datos...");
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        else
        {
            // Crear base de datos si no existe
            context.Database.EnsureCreated();
        }

        Console.WriteLine("✓ Base de datos lista\n");

        // Mostrar todos los productos (detalle) para la demo
        var todos = context.Products.Include(p => p.Category).OrderBy(p => p.Id).ToList();
        Console.WriteLine("=== TODOS LOS PRODUCTOS ===");
        foreach (var p in todos)
        {
            Console.WriteLine($"[{p.Id}] {p.Name} | Categoria: {p.Category?.Name ?? "N/A"} | Precio: {p.Price:C} | Stock: {p.Stock}");
        }
        Console.WriteLine();

        // Ejecutar queries básicas
        Console.WriteLine("═══ QUERIES BÁSICAS (1-4) ═══\n");
        var basicQueries = new BasicQueries(context);
        basicQueries.Query1_ProyeccionBasica();
        basicQueries.Query2_FiltroOrdenamiento();
        basicQueries.Query3_FiltroAvanzado();
        basicQueries.Query4_ProyeccionCalculada();

        // Ejecutar queries avanzadas
        Console.WriteLine("\n═══ QUERIES AVANZADAS (5-13) ═══\n");
        var advQueries = new AdvancedQueries(context);

        // Query 5: Paginación
        Console.WriteLine("Query 5: Paginación (página 1, 5 productos por página)");
        var paginated = advQueries.GetPaginado(1, 5);
        Console.WriteLine($"  Total: {paginated.Total}, Página: {paginated.Page}, Items: {paginated.Items.Count}\n");
        foreach (var it in paginated.Items)
        {
            Console.WriteLine($"  - {it.Name} | {it.CategoryName} | {it.Price:C}");
        }
        Console.WriteLine();

        // Query 6: Agregados
        Console.WriteLine("Query 6: Agregados y Grouping");
        var agregados = advQueries.AgregatosYGrouping();
        foreach (var agg in agregados)
        {
            Console.WriteLine($"  {agg.NombreCategoria}: {agg.Cantidad} productos, Promedio: {agg.PrecioPromedio:C}");
        }
        Console.WriteLine();

        // Query 7: Union
        Console.WriteLine("Query 7: Union (productos caros O poco stock)");
        var union = advQueries.Union();
        Console.WriteLine($"  Resultados: {union.Count} productos");
        foreach (var u in union)
            Console.WriteLine($"  - {u.Name} | {u.CategoryName} | {u.Price:C}");
        Console.WriteLine();

        // Query 8: Intersect
        Console.WriteLine("Query 8: Intersect (productos caros Y poco stock)");
        var intersect = advQueries.Intersect();
        Console.WriteLine($"  Resultados: {intersect.Count} productos");
        foreach (var i in intersect)
            Console.WriteLine($"  - {i.Name} | {i.CategoryName} | {i.Price:C}");
        Console.WriteLine();

        // Query 9: Except
        Console.WriteLine("Query 9: Except (productos caros pero NO poco stock)");
        var except = advQueries.Except();
        Console.WriteLine($"  Resultados: {except.Count} productos");
        foreach (var e in except)
            Console.WriteLine($"  - {e.Name} | {e.CategoryName} | {e.Price:C}");
        Console.WriteLine();

        // Query 10: Subquery Any
        Console.WriteLine("Query 10: Subquery with Any (categorías con productos >500)");
        var any = advQueries.SubqueryAny();
        Console.WriteLine($"  Categorías encontradas: {any.Count}");
        foreach (var c in any)
            Console.WriteLine($"  - {c.Name} (Productos: {context.Products.Count(p => p.CategoryId == c.Id)})");
        Console.WriteLine();

        // Query 11: Subquery All
        Console.WriteLine("Query 11: Subquery with All (categorías donde TODOS los productos >20)");
        var all = advQueries.SubqueryAll();
        Console.WriteLine($"  Categorías encontradas: {all.Count}");
        foreach (var c in all)
            Console.WriteLine($"  - {c.Name} (Productos: {context.Products.Count(p => p.CategoryId == c.Id)})");
        Console.WriteLine();

        // Query 12: JOIN explícito
        Console.WriteLine("Query 12: JOIN Explícito");
        var joinResult = advQueries.JoinExplicito();
        Console.WriteLine($"  Resultados: {joinResult.Count} filas");
        foreach (var j in joinResult)
            Console.WriteLine($"  - {j.NombreProducto} | {j.NombreCategoria} | {j.Precio:C} | Stock: {j.Stock}");
        Console.WriteLine();

        // Query 13: Búsqueda avanzada
        Console.WriteLine("Query 13: Búsqueda Avanzada con múltiples filtros");
        var search = advQueries.BusquedaAvanzada("Laptop", null, 100, 1, 10);
        Console.WriteLine($"  Resultados encontrados: {search.Total}\n");
        foreach (var s in search.Items)
            Console.WriteLine($"  - {s.Name} | {s.CategoryName} | {s.Price:C}");
        Console.WriteLine();

        // Compilada (ejemplo)
        Console.WriteLine("Query Compilada: filtro precio > 100");
        var compilada = advQueries.CompiladaFiltro(100);
        foreach (var c in compilada)
            Console.WriteLine($"  - {c.Name} | {c.CategoryName} | {c.Price:C}");
        Console.WriteLine();

        Console.WriteLine("═════════════════════════════════════════════════════════\n");
        Console.WriteLine("✓ Todas las queries ejecutadas exitosamente");
        Console.WriteLine("✓ Archivos SQL guardados en /docs\n");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"✗ Error: {ex.Message}");
    Console.WriteLine($"Detalles: {ex.InnerException?.Message}");
}

Console.WriteLine("Presiona cualquier tecla para salir...");
Console.ReadKey();
