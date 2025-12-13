# ?? GUÍA RÁPIDA DE EJECUCIÓN - LinqAdvancedLab

**Para ejecutar el proyecto completo en cualquier PC con .NET 10.0**

---

## ?? REQUISITOS PREVIOS

Antes de ejecutar, verifica que tienes instalado:

### 1. Git
```sh
git --version
```
Si no lo tienes: [Descargar Git](https://git-scm.com/)

### 2. .NET 10.0 SDK
```sh
dotnet --version
```
Si no lo tienes: [Descargar .NET 10.0](https://dotnet.microsoft.com/download)

### 3. SQL Server LocalDB (Recomendado)
```sh
sqllocaldb info
```
Viene con Visual Studio. Si no lo tienes: Instala "Microsoft SQL Server Express LocalDB"

---

## ?? OPCIÓN 1: COMANDO ÚNICO (MÁS RÁPIDO)

Copia y pega **todo esto de una vez** en PowerShell o CMD:

```sh
git clone https://github.com/rhq-omni777/LinqAdvancedLab.git && cd LinqAdvancedLab && dotnet restore && dotnet build && dotnet test tests/LinqAdvancedLab.Tests && dotnet run --project src/LinqAdvancedLab.Console
```

**Listo.** Espera a que termine y listo. ?

---

## ?? OPCIÓN 2: PASO A PASO (MÁS CONTROLADO)

Si prefieres ejecutar paso a paso:

### Paso 1: Clonar el repositorio
```sh
git clone https://github.com/rhq-omni777/LinqAdvancedLab.git
cd LinqAdvancedLab
```

### Paso 2: Restaurar dependencias
```sh
dotnet restore
```
Espera a que descargue los paquetes NuGet.

### Paso 3: Compilar el proyecto
```sh
dotnet build
```
Debe terminar sin errores críticos.

### Paso 4: Ejecutar los tests (Opcional)
```sh
dotnet test tests/LinqAdvancedLab.Tests
```
Deberías ver: `? 15/15 PASSED`

### Paso 5: Ejecutar la aplicación
```sh
dotnet run --project src/LinqAdvancedLab.Console
```
Verá todas las 13 queries ejecutándose.

---

## ? RESULTADO ESPERADO

Cuando termine, deberías ver:

```
??????????????????????????????????????????????????????????????
?      LinqAdvancedLab - Demonstración de Queries LINQ       ?
??????????????????????????????????????????????????????????????

? Base de datos lista

??? QUERIES BÁSICAS (1-4) ???

Query 1: Proyección a DTO con Select
Query 2: Filtro y ordenamiento
Query 3: Filtros avanzados con múltiples condiciones
Query 4: Proyección con expresiones calculadas

??? QUERIES AVANZADAS (5-13) ???

Query 5: Paginación (página 1, 5 productos por página)
  Total: 3, Página: 1, Items: 3

Query 6: Agregados y Grouping
  Tech: 2 productos, Promedio: 612,50 €
  Muebles: 1 productos, Promedio: 150,00 €

Query 7: Union (productos caros O poco stock)
  Resultados: 2 productos

Query 8: Intersect (productos caros Y poco stock)
  Resultados: 0 productos

Query 9: Except (productos caros pero NO poco stock)
  Resultados: 1 productos

Query 10: Subquery with Any (categorías con productos >500)
  Categorías encontradas: 1

Query 11: Subquery with All (categorías donde TODOS los productos >20)
  Categorías encontradas: 2

Query 12: JOIN Explícito
  Resultados: 3 filas

Query 13: Búsqueda Avanzada con múltiples filtros
  Resultados encontrados: 1

?????????????????????????????????????????????????????????????

? Todas las queries ejecutadas exitosamente
? Archivos SQL guardados en /docs

Presiona cualquier tecla para salir...
```

---

## ?? COMANDOS ADICIONALES ÚTILES

### Ver los tests detallados
```sh
dotnet test tests/LinqAdvancedLab.Tests --verbosity normal
```

### Ejecutar solo los tests
```sh
dotnet test tests/LinqAdvancedLab.Tests
```

### Ejecutar solo un test específico
```sh
dotnet test tests/LinqAdvancedLab.Tests --filter "AgregarProducto"
```

### Ver la estructura del proyecto
```sh
tree src/
tree tests/
```

### Limpiar archivos compilados
```sh
dotnet clean
```

---

## ??? VER LA BASE DE DATOS

Después de ejecutar el programa, puedes ver los datos en SQL Server:

### Con SQL Server Management Studio (SSMS):
1. Abre SSMS
2. Conecta a: `(localdb)\mssqllocaldb`
3. Ve a: `Databases ? LinqAdvancedLab`
4. Expande `Tables` para ver:
   - `Categories` (2 filas)
   - `Products` (3 filas)

### Datos que verás:

**Categories:**
| Id | Name |
|----|------|
| 1 | Tech |
| 2 | Muebles |

**Products:**
| Id | Name | Price | Stock | CategoryId |
|----|------|-------|-------|-----------|
| 1 | Laptop | 1200.00 | 5 | 1 |
| 2 | Mouse | 25.00 | 50 | 1 |
| 3 | Silla | 150.00 | 3 | 2 |

---

## ?? ESTRUCTURA DEL PROYECTO

```
LinqAdvancedLab/
??? src/
?   ??? LinqAdvancedLab.Console/
?   ?   ??? Consultas/
?   ?   ?   ??? BasicQueries.cs      (4 queries básicas)
?   ?   ?   ??? AdvancedQueries.cs   (9 queries avanzadas)
?   ?   ??? Program.cs               (punto de entrada)
?   ?   ??? LinqAdvancedLab.Console.csproj
?   ??? LinqAdvancedLab.Data/
?   ?   ??? AppDbContext.cs          (EF Core DbContext)
?   ?   ??? Seeding/DbSeeder.cs      (datos iniciales)
?   ?   ??? Repositories/
?   ?   ?   ??? Repository.cs        (patrón Repository)
?   ?   ??? LinqAdvancedLab.Data.csproj
?   ??? LinqAdvancedLab.Domain/
?       ??? Entities/
?       ?   ??? Product.cs
?       ?   ??? Category.cs
?       ??? DTOs/
?       ?   ??? ProductDto.cs
?       ??? Specifications/
?       ?   ??? ISpecification.cs
?       ??? LinqAdvancedLab.Domain.csproj
??? tests/
?   ??? LinqAdvancedLab.Tests/
?       ??? ProductTests.cs          (11 tests [Fact] + [Theory])
?       ??? LinqAdvancedLab.Tests.csproj
??? docs/
?   ??? EJECUCION-RAPIDA.md          ? Eres aquí
?   ??? README.md
?   ??? GUIA-GIT.md
?   ??? PLANTILLA-DIARIO.md
?   ??? RUBRICA-EVALUACION.md
?   ??? ...
??? .github/workflows/ci.yml         (GitHub Actions)
??? README.md                        (documentación principal)
```

---

## ?? PROBLEMAS COMUNES

### "No se encuentra la base de datos"
**Solución:** Ejecuta el programa Console primero (crea la base automáticamente)
```sh
dotnet run --project src/LinqAdvancedLab.Console
```

### "Test falla"
**Solución:** Normal, la base de datos se resetea. Ejecuta de nuevo:
```sh
dotnet test tests/LinqAdvancedLab.Tests
```

### ".NET no instalado"
**Solución:** Descarga e instala [.NET 10.0 SDK](https://dotnet.microsoft.com/download)

### "Git no instalado"
**Solución:** Descarga e instala [Git](https://git-scm.com/)

### "SQL LocalDB no disponible"
**Solución:** Instala SQL Server Express LocalDB o usa Visual Studio que lo incluye

---

## ?? RESUMEN DE FUNCIONALIDADES

? **13 Queries LINQ:**
- Proyecciones, filtros, agregados, grouping
- Union, Intersect, Except
- Subqueries con Any/All
- JOINs explícitos
- Paginación

? **15 Tests parametrizados:**
- Cobertura >80%
- Tests con [Fact] y [Theory]
- InMemory Database

? **Entity Framework Core:**
- DbContext configurado
- Relaciones uno-a-muchos
- Índices en columnas
- Seeding automático

? **Patrones implementados:**
- Repository genérico
- Specification Pattern
- DTO Pattern
- Compiled Queries

---

## ?? PARA DEMOSTRAR A TU PROFE

Puedes ejecutar estos comandos frente a tu profesor:

```sh
# 1. Clonar (si no lo ha clonado)
git clone https://github.com/rhq-omni777/LinqAdvancedLab.git

# 2. Compilar
cd LinqAdvancedLab && dotnet build

# 3. Ejecutar tests
dotnet test tests/LinqAdvancedLab.Tests --verbosity normal

# 4. Ejecutar programa
dotnet run --project src/LinqAdvancedLab.Console
```

Y mostrar:
- ? Compilación sin errores
- ? 15/15 tests pasando
- ? Todas las 13 queries ejecutándose
- ? Base de datos creada automáticamente
- ? Datos en SQL Server LocalDB

---

## ?? INFORMACIÓN ADICIONAL

- **Documentación completa:** Ver `/docs/README.md`
- **Guía de Git:** Ver `/docs/GUIA-GIT.md`
- **Rúbrica de evaluación:** Ver `/docs/RUBRICA-EVALUACION.md`
- **Plantilla de diarios:** Ver `/docs/PLANTILLA-DIARIO.md`
- **Verificación final:** Ver `/docs/VERIFICACION-FINAL.md`
- **Instrucciones al equipo:** Ver `/docs/INSTRUCCIONES-EQUIPO.md`

---

## ? ¡LISTO!

Con estos comandos tienes todo lo que necesitas para ejecutar el proyecto en cualquier PC. 

**¿Alguna duda?** Revisa los archivos en `/docs` o la documentación principal en `README.md`.

---

**Última actualización:** 13/12/2025  
**Estado:** ? LISTO PARA PRODUCCIÓN  
**Versión:** 1.0-ready
