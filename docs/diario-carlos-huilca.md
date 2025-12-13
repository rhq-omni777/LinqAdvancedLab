# Diario de Aprendizaje – Carlos Huilca – Sesión 0

## 1. Objetivos del día

- [x] Iniciar el repositorio en GitHub
- [x] Crear la solución y la estructura física (src / tests / docs)
- [x] Añadir proyectos: Domain, Data, Console, Tests
- [x] Inicializar Git, subir ramas `main` y `develop`

## 2. Lo que hice (resumen rápido)

- Creé el repositorio `LinqAdvancedLab` en GitHub y la estructura inicial desde Visual Studio.
- Organicé las carpetas físicas (`src`, `tests`, `docs`) y añadí los cuatro proyectos requeridos.
- Realicé el primer commit con la estructura y subí las ramas `main` y `develop`.

## 3. Dificultades

- Ajustes iniciales con rutas y ubicación de proyectos en la solución.
- Configuración inicial de Git remotes y autenticación en GitHub.

## 4. Tiempo invertido

- 3 horas

---

# Diario de Aprendizaje – Carlos Huilca – Día 2

## 1. Objetivos del día

- [x] Implementar el patrón Specification (mi responsabilidad principal en esta sesión)
- [x] Crear repositorio genérico en Data
- [x] Abrir PR hacia `develop`

## 2. Pasos realizados (Guía paso a paso)

**CARLOS HUILCA (Patrón Specification)**

- Paso 1: Preparar rama
  - `git checkout develop` → `git pull` → `git checkout -b feature/carlos-spec`

- Paso 2: Interfaces
  - En `Domain`, creé la carpeta `Specifications` y añadí `ISpecification.cs`:

```csharp
using System;
using System.Linq.Expressions;
namespace LinqAdvancedLab.Domain.Specifications {
    public interface ISpecification<T> {
        Expression<Func<T, bool>> Criteria { get; }
    }
}
```

- Paso 3: Repositorio genérico
  - En `Data`, creé la carpeta `Repositories` y añadí `Repository.cs`:

```csharp
using System.Collections.Generic;
using System.Linq;
using LinqAdvancedLab.Domain.Specifications;
namespace LinqAdvancedLab.Data.Repositories {
    public class Repository<T> where T : class {
        protected readonly AppDbContext _context;
        public Repository(AppDbContext context) => _context = context;

        public IEnumerable<T> Find(ISpecification<T> spec) {
            return _context.Set<T>().Where(spec.Criteria).ToList();
        }
    }
}
```

- Paso 4: Git
  - `git add .`
  - `git commit -m "feat: specification pattern"`
  - `git push origin feature/carlos-spec`
  - Creé el Pull Request hacia `develop` y solicité revisión.

## 3. Lo que logré

- Implementé la interfaz `ISpecification<T>` y el repositorio genérico `Repository<T>`.
- Subí los cambios en la rama `feature/carlos-spec` y abrí PR hacia `develop`.

## 4. Tiempo invertido

- 2 horas

---

# Diario de Aprendizaje – Carlos Huilca – Día 3

## 1. Objetivos del día

- Revisar PRs y colaborar en las correcciones de integración
- Verificar tests y documentación

## 2. Trabajo realizado (resumen de integración y correcciones)

Durante la sesión 3 trabajé en revisión e integración; el desarrollo principal de algunas correcciones fue colaborativo entre los integrantes (Andrés e Isaac implementaron varias partes). Mis aportes principales fueron:

- Revisar y aprobar PRs relacionados con entities, queries y DbContext.
- Aclarar y ajustar la implementación del patrón Specification para que funcione con el repositorio genérico.
- Verificar que los tests de integración funcionaran con InMemory provider y reportar fallos para su corrección.

Tareas de integración/corrección aplicadas en equipo (resumen):
- Añadido el constructor `AppDbContext(DbContextOptions<AppDbContext> options)` para soporte de DI y tests.
- Configuración de la relación `Product` ↔ `Category` y navegación inversa `Category.Products`.
- Ajuste de índices en `OnModelCreating` (Stock, Price) y seed de datos.
- Correcciones en `AdvancedQueries` y `BasicQueries` (compiladas y guardado de SQL en `/docs`).
- Actualización de tests para usar `UseInMemoryDatabase(Guid.NewGuid().ToString())` y correcciones a `[Theory]` donde hacía falta.
- Actualización de `.csproj` y dependencias (InMemory en Tests, referencias entre proyectos).

> Nota: muchas de estas modificaciones fueron implementadas por el equipo durante la revisión conjunta; yo participé en la revisión, pruebas y en adaptar la especificación para integrarla correctamente.

## 3. Resultado

- Verifiqué localmente: `dotnet build`, `dotnet test` (todos los tests pasan), y `dotnet run` para comprobar las queries y el guardado de SQL.
- Dejé comentarios en PRs y aprobé cambios cuando correspondía.

## 4. Tiempo invertido

- 3 horas

---

> Firma: Carlos Huilca
> Fecha: actualización final



