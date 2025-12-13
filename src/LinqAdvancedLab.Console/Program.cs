using LinqAdvancedLab.Data;
using LinqAdvancedLab.Console.Consultas;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
Console.WriteLine("║      LinqAdvancedLab - Demonstración de Queries LINQ       ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");

try
{
    // Crear contexto
    var options = new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LinqAdvancedLab;Trusted_Connection=True;")
        .Options;

    using (var context = new AppDbContext(options))
    {
        // Crear base de datos si no existe
        context.Database.EnsureCreated();
        Console.WriteLine("✓ Base de datos lista\n");

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
        Console.WriteLine($"  Resultados: {union.Count} productos\n");

        // Query 8: Intersect
        Console.WriteLine("Query 8: Intersect (productos caros Y poco stock)");
        var intersect = advQueries.Intersect();
        Console.WriteLine($"  Resultados: {intersect.Count} productos\n");

        // Query 9: Except
        Console.WriteLine("Query 9: Except (productos caros pero NO poco stock)");
        var except = advQueries.Except();
        Console.WriteLine($"  Resultados: {except.Count} productos\n");

        // Query 10: Subquery Any
        Console.WriteLine("Query 10: Subquery with Any (categorías con productos >500)");
        var any = advQueries.SubqueryAny();
        Console.WriteLine($"  Categorías encontradas: {any.Count}\n");

        // Query 11: Subquery All
        Console.WriteLine("Query 11: Subquery with All (categorías donde TODOS los productos >20)");
        var all = advQueries.SubqueryAll();
        Console.WriteLine($"  Categorías encontradas: {all.Count}\n");

        // Query 12: JOIN explícito
        Console.WriteLine("Query 12: JOIN Explícito");
        var joinResult = advQueries.JoinExplicito();
        Console.WriteLine($"  Resultados: {joinResult.Count} filas\n");

        // Query 13: Búsqueda avanzada
        Console.WriteLine("Query 13: Búsqueda Avanzada con múltiples filtros");
        var search = advQueries.BusquedaAvanzada("Laptop", null, 100, 1, 10);
        Console.WriteLine($"  Resultados encontrados: {search.Total}\n");

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
