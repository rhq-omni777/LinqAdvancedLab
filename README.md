# LinqAdvancedLab

**Video Demo**

```bash
https://drive.google.com/file/d/1PNxQb4eJVNIEmNqskGVdWl542xwrpqjY/view?usp=drive_link
```

**Proyecto de aprendizaje: LINQ to SQL con Entity Framework Core**

Un proyecto educativo completo que demuestra:
- Modelado de dominio y DbContext
- LINQ to SQL con sintaxis de métodos y expresiones lambda
- Consultas complejas: filtros, agregados, joins, grouping, paginación
- Optimización de SQL y uso de índices
- Trabajo en equipo con Git Flow
- Testing con xUnit y EF In-Memory

---

## ?? Estructura del Proyecto

```
??? src/
?   ??? LinqAdvancedLab.Console     (Entry point - Aplicación consolarm)
?   ??? LinqAdvancedLab.Data        (DbContext, Repositorios, Seeding)
?   ??? LinqAdvancedLab.Domain      (Entidades, DTOs, Especificaciones)
??? tests/
?   ??? LinqAdvancedLab.Tests       (Tests con xUnit + EF In-Memory)
??? docs/                            (Diarios de aprendizaje, SQL generado)
```

---

## ?? Requisitos Previos

- **Visual Studio 2022** con carga de trabajo "Desarrollo de ASP.NET y web"
- **.NET 10.0** SDK
- **SQL Server LocalDB** (incluido con Visual Studio)
- **Git** para control de versiones

---

## ?? Instalación y Uso

### 1. Clonar el repositorio
```bash
git clone https://github.com/rhq-omni777/LinqAdvancedLab.git
cd LinqAdvancedLab
```

### 2. Restaurar dependencias
```bash
dotnet restore
```

### 3. Crear la base de datos
```bash
dotnet ef database update --project src/LinqAdvancedLab.Data
```

O ejecutar la aplicación Console (que crea la BD automáticamente):
```bash
dotnet run --project src/LinqAdvancedLab.Console
```

### 4. Ejecutar tests
```bash
dotnet test tests/LinqAdvancedLab.Tests
```

---

## ?? Queries Implementadas

### Queries Básicas (1-4)
- **Query 1:** Proyección a DTO con `Select`
- **Query 2:** Filtro y ordenamiento
- **Query 3:** Filtros avanzados con múltiples condiciones
- **Query 4:** Proyección con expresiones calculadas

### Queries Avanzadas (5-13)
- **Query 5:** Paginación con `Skip` y `Take`
- **Query 6:** Agregados (`GroupBy`, `Count`, `Average`, `Max`, `Min`)
- **Query 7:** `Union` (productos caros O poco stock)
- **Query 8:** `Intersect` (productos caros Y poco stock)
- **Query 9:** `Except` (diferencia de conjuntos)
- **Query 10:** Subqueries con `Any`
- **Query 11:** Subqueries con `All`
- **Query 12:** `JOIN` explícito con proyección
- **Query 13:** Búsqueda avanzada con múltiples filtros

---

## ?? Tests

**Cobertura:** >80%

**Suites de tests:**
- `ProductTests`: 11 tests parametrizados (filtros, paginación, CRUD, uniones)
- `CategoryTests`: 2 tests (inserción, relaciones)

**Ejecutar tests con cobertura:**
```bash
dotnet test tests/LinqAdvancedLab.Tests /p:CollectCoverage=true
```

---

## ?? SQL Generado

Todos los archivos SQL generados por `ToQueryString()` se guardan en la carpeta `/docs`:
- `query1_proyeccion_basica.sql`
- `query2_filtro_ordenamiento.sql`
- `query3_filtro_avanzado.sql`
- `query4_proyeccion_calculada.sql`

---

## ?? Entidades

### Product
```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
```

### Category
```csharp
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
```

### ProductDto (Record)
```csharp
public record ProductDto(string Name, decimal Price, string CategoryName);
```

---

## ??? Patrones Implementados

- **Specification Pattern**: Interface `ISpecification<T>` con criterios LINQ
- **Repository Pattern**: Clase genérica `Repository<T>` con métodos `Find` y `FindAsQueryable`
- **DTO Pattern**: Proyecciones automáticas con `Select`
- **Seeding**: Datos iniciales en `DbSeeder`

---

## ?? Documentación

Cada integrante del equipo debe mantener un diario de aprendizaje en `/docs/diario-<nombre>.md`:

```markdown
# Diario de Aprendizaje – <nombre> – Semana <n>

## 1. Objetivos del día
- [ ] Query 5 (paginación)
- [ ] Subquery con `Any`

## 2. Lo que logré
- Terminé query 5, SQL tiene `OFFSET-FETCH`
- Aprendí a usar `let` para evitar repetir cálculo

## 3. Dificultades
- Error: "More than one DbContext" ? solución: `-Context`

## 4. Próximo paso
- Implementar patrón Specification

## 5. Tiempo invertido
- 1 h 45 min (15 min documentando)
```

---

## ?? Git Workflow

**Ramas:**
- `main` (protegida) - Versión estable
- `develop` - Rama de integración
- `feature/<historia>` - Una rama por historia de usuario

**Ejemplo:**
```bash
git checkout develop
git pull origin develop
git checkout -b feature/query-5-paginacion
# ... hacer cambios ...
git commit -m "feat: implementar query 5 con paginacion"
git push origin feature/query-5-paginacion
# ? Crear PR hacia develop
```

---

## ?? Rúbrica de Evaluación (0-4 puntos cada ítem)

| Competencia | Excelente (4) | Aceptable (3) | Necesita mejora (2) | Insuficiente (0-1) |
|---|---|---|---|---|
| **LINQ Complejo** | ?6 consultas + SQL optimizado | 4-5 consultas | ?3 consultas | Sin consultas |
| **Trabajo en Equipo** | PRs diarios, code-review mutuos | Algunos PRs tardíos | Conflictos sin resolver | No usa Git |
| **Tests** | ?80% cobertura, parametrizados | 50-79% cobertura | ?49% cobertura | Sin tests |
| **Documentación** | Diario completo, vídeo claro | Diario parcial | Falta contenido | No documentado |

**Nota total:** `/16 ? convertir a 10**

---

## ? Checklist Final

- [ ] Todos los PR aprobados y mergeados a `main`
- [ ] Pipeline GitHub Actions verde ?
- [ ] Vídeo-demo (2 min) subido a Google Drive
- [ ] Diarios combinados en `docs/diarios-equipo.pdf`
- [ ] Tag `v1.0` creado en `main`
- [ ] Auto-rúbrica completada en Google Forms

---

## ?? Contacto

**Equipo:** Carlos Huilca, Andrés Saltos  
**Repositorio:** https://github.com/rhq-omni777/LinqAdvancedLab  
**Issues:** Reportar en GitHub Issues

---

## ?? Licencia

Este proyecto es de código abierto bajo licencia MIT.

---

**Última actualización:** 13/12/2025
