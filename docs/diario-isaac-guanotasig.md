# Diario de Aprendizaje – Isaac Guanotasig – Día 1

## 1. Objetivos del día
- [ ] Actualizar la rama develop con los cambios del equipo
- [ ] Crear rama personal de trabajo para el contexto de base de datos
- [ ] Instalar Entity Framework Core SQL Server
- [ ] Implementar AppDbContext con LocalDB
- [ ] Crear el seeder de datos iniciales

## 2. Lo que logré
- Actualicé correctamente la rama `develop` y creé mi rama personal `feature/isaac-contexto`.
- Instalé el paquete `Microsoft.EntityFrameworkCore.SqlServer` en el proyecto Data (tuve que editar manualmente el .csproj).
- Creé la clase `AppDbContext` con configuración de LocalDB y conexión a SQL Server.
- Implementé el índice en la propiedad `Stock` de la entidad `Product` como lo requiere el PDF.
- Creé la carpeta `Seeding` y la clase `DbSeeder` con datos iniciales de categorías y productos.
- Configuré el método `OnModelCreating` para hacer el seed automático de datos.
- Realicé commit, push exitoso y abrí el Pull Request en GitHub.

## 3. Dificultades
- Al principio tuve problemas para instalar el paquete NuGet desde la interfaz de Visual Studio.
- La solución fue agregar manualmente la referencia en el archivo `.csproj` y ejecutar `dotnet restore`.
- Tuve que asegurarme de que la configuración de LocalDB estuviera correcta en la cadena de conexión.

## 4. Próximo paso
- Implementar queries avanzadas con paginación, union y queries compiladas.

## 5. Tiempo invertido
- 2 horas 30 minutos (incluye resolución de problemas con NuGet, desarrollo y documentación)

# Diario de Aprendizaje – Isaac Guanotasig – Día 2

## 1. Objetivos del día
- [ ] Crear rama personal para queries avanzadas
- [ ] Implementar paginación con Skip y Take
- [ ] Implementar operador Union
- [ ] Crear una query compilada con EF.CompileQuery

## 2. Lo que logré
- Actualicé la rama `develop` y creé la rama `feature/isaac-advanced`.
- Creé la clase `AdvancedQueries` dentro de la carpeta `Consultas`.
- Implementé el método `Paginacion()` usando `OrderBy`, `Skip` y `Take` para obtener resultados paginados.
- Implementé el método `Union()` para combinar dos consultas (productos caros y productos con poco stock).
- Creé una query compilada usando `EF.CompileQuery` para mejorar el rendimiento en consultas repetitivas.
- Agregué outputs a consola para visualizar los resultados de cada query.
- Realicé commit, push exitoso y abrí el Pull Request en GitHub.

## 3. Dificultades
- Entender la sintaxis de `EF.CompileQuery` fue un desafío inicial.
- Tuve que investigar cuándo es apropiado usar queries compiladas vs queries normales.
- Me aseguré de que las queries funcionaran correctamente con el contexto de base de datos.

## 4. Próximo paso
- Esperar la aprobación de los Pull Requests por parte del equipo.
- Apoyar en las pruebas unitarias si es necesario.

## 5. Tiempo invertido
- 2 horas (incluye investigación sobre queries compiladas, desarrollo y documentación)

## Reflexión final del proyecto
Este proyecto me permitió profundizar en Entity Framework Core y LINQ. Aprendí a:
- Configurar correctamente un DbContext con LocalDB
- Crear índices para optimizar consultas
- Implementar seeding de datos de forma automática
- Usar técnicas avanzadas como paginación, union y queries compiladas
- Trabajar con Git Flow usando ramas feature y Pull Requests
- Colaborar en equipo siguiendo buenas prácticas de desarrollo

Las queries compiladas son especialmente útiles cuando se ejecuta la misma consulta muchas veces, ya que EF no tiene que regenerar el árbol de expresiones cada vez. La paginación es esencial para aplicaciones reales que manejan grandes volúmenes de datos.