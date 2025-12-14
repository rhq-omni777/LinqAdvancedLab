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

## ?? OPCIONES ADICIONALES (RECREAR BASE)

Si quieres forzar recreación de la base (elimina y vuelve a aplicar el seed):

PowerShell:
```powershell
# Opción 1: flag --recreate
dotnet run --project src\LinqAdvancedLab.Console -- --recreate

# Opción 2: variable de entorno
$env:RECREATE_DB = "1"
dotnet run --project src\LinqAdvancedLab.Console
Remove-Item Env:\RECREATE_DB
```

CMD:
```cmd
set RECREATE_DB=1 && dotnet run --project src\LinqAdvancedLab.Console
```

**Uso recomendado para demo:** usar `--recreate` para garantizar que el seed actualizado se carga.

---

## ? RESULTADO ESPERADO (ACTUALIZADO)

Cuando ejecutes con `--recreate` verás ahora un listado completo de productos seguido de resultados detallados por query. Ejemplo resumido de salida:

```
??????????????????????????????????????????????????????????????
?      LinqAdvancedLab - Demonstración de Queries LINQ       ?
??????????????????????????????????????????????????????????????

? Base de datos lista

=== TODOS LOS PRODUCTOS ===
[1] Laptop | Categoria: Tech | Precio: $1,200.00 | Stock: 5
[2] Mouse  | Categoria: Tech | Precio: $25.00    | Stock: 50
[3] Silla  | Categoria: Muebles | Precio: $150.00 | Stock: 3
[4] Monitor| Categoria: Tech | Precio: $600.00  | Stock: 2
... (más filas)

??? QUERIES BÁSICAS (1-4) ???
? Query 1 ejecutada  (SQL guardado en docs/query1_proyeccion_basica.sql)
? Query 2 ejecutada  (SQL guardado en docs/query2_filtro_ordenamiento.sql)
? Query 3 ejecutada  (SQL guardado en docs/query3_filtro_avanzado.sql)
? Query 4 ejecutada  (SQL guardado en docs/query4_proyeccion_calculada.sql)

??? QUERIES AVANZADAS (5-13) ???
Query 5: Paginación (página 1, 5 productos por página)
  Total: 14, Página: 1, Items: 5
  - Laptop | Tech | $1,200.00
  - Mouse  | Tech | $25.00
  - Silla  | Muebles | $150.00
  ...

Query 7: Union (productos caros O poco stock)
  Resultados: 3 productos
  - Laptop | Tech | $1,200.00
  - Monitor| Tech | $600.00
  - Tablet | Tech | $700.00

Query 12: JOIN Explícito
  Resultados: 14 filas
  - Laptop | Tech | $1,200.00 | Stock: 5
  ...

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

Después de ejecutar el programa (especialmente con `--recreate`), puedes ver los datos en SQL Server:

### Con SQL Server Management Studio (SSMS):
1. Abre SSMS
2. Conecta a: `(localdb)\mssqllocaldb`
3. Ve a: `Databases ? LinqAdvancedLab`
4. Expande `Tables` para ver:
   - `Products` (varias filas)
   - `Categories` (2 filas)

### Ver datos de ejemplo:
```
SELECT TOP 1000 Id, Name, Price, Stock, CategoryId FROM Products;
```

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

Puedes ejecutar estos comandos EN DIRECTO:

```bash
# 1. Clonar
git clone https://github.com/rhq-omni777/LinqAdvancedLab.git
cd LinqAdvancedLab

# 2. Compilar
dotnet build

# 3. Tests
dotnet test tests/LinqAdvancedLab.Tests --verbosity normal

# 4. Ejecutar (recrear DB para demo garantizada)
dotnet run --project src/LinqAdvancedLab.Console -- --recreate
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

---

## ? ¡LISTO!

Con estos comandos tienes todo lo que necesitas para ejecutar el proyecto en cualquier PC. 

**¿Alguna duda?** Revisa los archivos en `/docs` o la documentación principal en `README.md`.

---

**Última actualización:** 13/12/2025  
**Estado:** ? LISTO PARA PRODUCCIÓN  
**Versión:** 1.0-ready
