# Diario de Aprendizaje – [NOMBRE] – Semana [N]

## 1. Objetivos del día

- [ ] Objetivo 1
- [ ] Objetivo 2
- [ ] Objetivo 3

## 2. Lo que logré

- Describir logro 1 en detalle
- Describir logro 2 en detalle
- Describir logro 3 en detalle

**Ejemplos:**
- Implementé Query 5 con paginación usando `Skip` y `Take`
- El SQL generado include `OFFSET X ROWS FETCH NEXT Y ROWS ONLY`
- Aprendí a usar `let` para evitar calcular expresiones múltiples veces

## 3. Dificultades encontradas

### Dificultad 1: Error "More than one DbContext"
**Síntoma:** Error de compilación al compilar proyecto Tests  
**Causa:** Faltaba especificar `-Context` en comando EF  
**Solución:** Usar `dotnet ef migrations add --context LinqAdvancedLab.Data.AppDbContext`  
**Tiempo para resolver:** 15 minutos

### Dificultad 2: Ruta relativa de archivos SQL
**Síntoma:** Archivos SQL no se guardaban en `/docs`  
**Causa:** Ruta relativa dependía de dónde se ejecutaba la consola  
**Solución:** Usar `AppDomain.CurrentDomain.BaseDirectory` y `Path.GetFullPath`  
**Tiempo para resolver:** 20 minutos

## 4. Próximo paso

- [ ] Implementar patrón Specification
- [ ] Crear tests parametrizados con `[Theory]`
- [ ] Optimizar índices en base de datos
- [ ] Grabar video-demo

## 5. Tiempo invertido

**Total:** 2 horas 30 minutos

**Desglose:**
- Análisis y diseño: 30 min
- Desarrollo: 1 h 30 min
- Testing: 20 min
- Documentación: 10 min

## 6. Conceptos aprendidos

### LINQ to SQL - Compiled Queries
```csharp
// Las compiled queries se cachean para mejor performance
private static readonly Func<AppDbContext, decimal, IQueryable<Product>> _filtro =
    EF.CompileQuery((AppDbContext db, decimal p) => db.Products.Where(x => x.Price > p));
```

### GroupBy y Agregados
```csharp
var resultado = _ctx.Products
    .GroupBy(p => p.Category.Name)
    .Select(g => new 
    { 
        Categoria = g.Key,
        Cantidad = g.Count(),
        Promedio = g.Average(p => p.Price)
    })
    .ToList();
```

### Union, Intersect, Except
```csharp
var caros = _ctx.Products.Where(p => p.Price > 500);
var pocoStock = _ctx.Products.Where(p => p.Stock < 5);

var union = caros.Union(pocoStock);      // Combinación
var intersect = caros.Intersect(pocoStock);  // Ambas condiciones
var except = caros.Except(pocoStock);    // Caros pero no poco stock
```

## 7. Referencias y recursos

- [LINQ to SQL Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/linq/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [Query operators](https://learn.microsoft.com/en-us/dotnet/csharp/linq/query-expression-basics)

## 8. Auto-evaluación (0-4 puntos)

| Criterio | Puntuación | Comentario |
|----------|-----------|-----------|
| Cumplimiento de objetivos | 4 | Logré todos los objetivos planificados |
| Calidad del código | 3 | Código funciona pero podría optimizarse |
| Documentación | 4 | Documenté bien las dificultades |
| Aprendizaje | 4 | Aprendí conceptos nuevos importantes |

**Nota total:** 15/16 = 9.4/10

## 9. Feedback y mejoras para la próxima sesión

- Necesito practicar más con subqueries complejas
- Debo revisar planes de ejecución SQL con más cuidado
- Debería usar más `[Theory]` en tests parametrizados
- Mejorar la velocidad de desarrollo

---

**Firma:** [NOMBRE]  
**Fecha:** [YYYY-MM-DD]  
**Rama utilizada:** feature/[tema]  
**PR número:** #[N]
