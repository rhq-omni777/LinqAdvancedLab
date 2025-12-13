\# Diario de Aprendizaje – Andrés Saltos – Dia 1



\## 1. Objetivos del día

\- \[x] Clonar el repositorio del proyecto LinqAdvancedLab

\- \[x] Crear rama personal de trabajo

\- \[x] Implementar entidades de dominio

\- \[x] Crear DTOs usando `record`



\## 2. Lo que logré

\- Cloné correctamente el repositorio y actualicé la rama `develop`.

\- Creé mi rama personal `feature/andres-entidades`.

\- Implementé las entidades `Category` y `Product` dentro del proyecto Domain.

\- Creé el DTO `ProductDto` utilizando `record` como lo exige el PDF.

\- Realicé commit y push exitoso y abrí el Pull Request en GitHub.



\## 3. Dificultades

\- Al inicio tuve dudas sobre en qué proyecto crear las carpetas de Entities y DTOs, pero se resolvió revisando la estructura del proyecto Domain.



\## 4. Próximo paso

\- Apoyar en la implementación de queries LINQ y revisar la integración de las entidades con el DbContext.



\## 5. Tiempo invertido

\- 2 horas (incluye configuración del entorno, desarrollo y documentación)



------------------------------------------------------------

\# Diario de Aprendizaje – Andrés Saltos – Dia 2



\## 1. Objetivos del día

\- \[x] Crear rama personal para queries básicas

\- \[x] Instalar Entity Framework Core en el proyecto Console

\- \[x] Implementar query LINQ con proyección a DTO

\- \[x] Guardar la consulta SQL generada



\## 2. Lo que logré

\- Actualicé la rama `develop` y creé la rama `feature/andres-queries1`.

\- Instalé correctamente el paquete `Microsoft.EntityFrameworkCore.SqlServer` en el proyecto Console.

\- Creé la carpeta `Consultas` y la clase `BasicQueries`.

\- Implementé una query LINQ con filtro por precio y proyección a `ProductDto`.

\- Generé y guardé el SQL resultante usando `ToQueryString()` en la carpeta `docs`.

\- Realicé commit, push y abrí el Pull Request en GitHub.



\## 3. Dificultades

\- Tuve que ajustar la ruta relativa para guardar correctamente el archivo SQL dentro de la carpeta `docs`.



\## 4. Próximo paso

\- Implementar más queries con ordenamiento, filtros adicionales y paginación.



\## 5. Tiempo invertido

\- 1 hora 50 minutos (incluye desarrollo, pruebas y documentación)

