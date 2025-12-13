# Rúbrica de Evaluación - LinqAdvancedLab

## Escala de Puntuación: 0-4 puntos por ítem

### 1. LINQ Complejo y Optimización SQL

| Puntuación | Criterios | Ejemplos |
|-----------|----------|----------|
| **4 - Excelente** | ?6 consultas avanzadas implementadas + SQL optimizado con índices estratégicos | - Queries con `GroupBy`, `Union`, `Intersect`, `Any`, `All`, subqueries, JOINs explícitos<br/>- Índices en columnas de filtro frecuente<br/>- Compiled queries para consultas repetidas<br/>- Análisis del plan de ejecución |
| **3 - Aceptable** | 4-5 consultas avanzadas + SQL mejorable | - Queries básicas de agregados y filtros<br/>- 1-2 índices implementados<br/>- SQL generado sin optimizaciones especiales |
| **2 - Necesita Mejora** | ?3 consultas avanzadas OR SQL sin índices | - Solo SELECT simple con WHERE<br/>- Sin agregados o grouping<br/>- Sin análisis de performance |
| **0-1 - Insuficiente** | No alcanza objetivos de LINQ | - Consultas triviales<br/>- Errores de compilación<br/>- No funciona |

**Evidencia requerida:**
- Archivos SQL en `/docs/query*.sql` con `ToQueryString()`
- Commits en rama feature con mensajes descriptivos

---

### 2. Trabajo en Equipo y Git Flow

| Puntuación | Criterios | Ejemplos |
|-----------|----------|----------|
| **4 - Excelente** | PRs diarios + code-review mutuos + sin conflictos | - Mínimo 1 PR por historia de usuario<br/>- Comentarios de revisión en cada PR<br/>- Resolución rápida de conflictos<br/>- Commits con mensajes convencionales |
| **3 - Aceptable** | Algunos PRs tardíos + code-review parciales | - 2-3 PRs en toda la semana<br/>- Comentarios superficiales<br/>- Merge sin revisar completamente |
| **2 - Necesita Mejora** | Conflictos sin resolver + PRs atrasados | - ?1 PR<br/>- Merge directo a develop<br/>- Ramas con mucho lag |
| **0-1 - Insuficiente** | No usa Git o uso incorrecto | - Commits únicos al final<br/>- Sin ramas feature<br/>- Sin documentación de cambios |

**Evidencia requerida:**
- Historial en GitHub con ramas y PRs
- Diarios de aprendizaje actualizados semanalmente

---

### 3. Testing y Cobertura

| Puntuación | Criterios | Ejemplos |
|-----------|----------|----------|
| **4 - Excelente** | ?80% cobertura + tests parametrizados `[Theory]` | - Mínimo 10 tests<br/>- `[Theory]` con `[InlineData]` variados<br/>- Tests de error y casos límite<br/>- Assert múltiples por test<br/>- InMemory database única por test |
| **3 - Aceptable** | 50-79% cobertura + algunos `[Fact]` | - 5-8 tests básicos<br/>- Mezcla de `[Fact]` y `[Theory]`<br/>- Faltan edge cases |
| **2 - Necesita Mejora** | ?49% cobertura OR solo `[Fact]` triviales | - ?4 tests<br/>- No parametrizados<br/>- Assert simple |
| **0-1 - Insuficiente** | Sin tests o fallan | - 0-1 test<br/>- Errores de compilación<br/>- No usan InMemory correctamente |

**Evidencia requerida:**
- Archivo `/tests/LinqAdvancedLab.Tests/ProductTests.cs` con múltiples tests
- Salida de `dotnet test` en README o logs

---

### 4. Documentación y Entregables

| Puntuación | Criterios | Ejemplos |
|-----------|----------|----------|
| **4 - Excelente** | Diario completo + vídeo claro + README exhaustivo | - Diario con 5+ entradas semanales<br/>- Vídeo-demo (2 min) con narración clara<br/>- README con instrucciones, ejemplos, rúbrica<br/>- Queries documentadas en `/docs`<br/>- Auto-rúbrica completada |
| **3 - Aceptable** | Diario parcial + vídeo básico | - 3-4 entradas en diario<br/>- Vídeo simple sin narración<br/>- README sin ejemplos |
| **2 - Necesita Mejora** | Diario superficial O vídeo falta | - 1-2 entradas<br/>- Vídeo incompleto<br/>- Sin README |
| **0-1 - Insuficiente** | Falta diario Y vídeo | - 0 entradas<br/>- Sin vídeo<br/>- Sin documentación |

**Evidencia requerida:**
- `/docs/diario-<nombre>.md` (uno por integrante)
- Vídeo en Google Drive con enlace en README
- Tag `v1.0` en GitHub
- Auto-rúbricas en Google Forms

---

## Escala Final: Conversión de Puntos a Nota

**Puntos totales:** 0-16 (4 ítems × 4 puntos máx)

**Conversión a nota sobre 10:**

| Puntos | Nota | Rango |
|--------|------|-------|
| 14-16 | 8.75 - 10 | Excelente ????? |
| 11-13 | 6.88 - 8.1 | Bueno ???? |
| 8-10 | 5 - 6.25 | Aceptable ??? |
| 5-7 | 3.1 - 4.4 | Necesita mejora ?? |
| 0-4 | 0 - 2.5 | Insuficiente ? |

**Fórmula:** `(Puntos totales ÷ 16) × 10`

---

## Auto-evaluación Individual (Google Forms)

Cada integrante debe completar esta auto-evaluación:

### 1. Competencia LINQ Complejo (0-4)
> ¿Cuántas queries avanzadas implementaste? ¿El SQL está optimizado?

- [ ] 0-1 (Insuficiente)
- [ ] 2-3 (Necesita mejora)
- [ ] 4-5 (Aceptable)
- [ ] ?6 (Excelente)

### 2. Trabajo en Equipo (0-4)
> ¿Participaste en PRs y code-reviews? ¿Usaste Git Flow?

- [ ] No participé o no usé Git (0-1)
- [ ] Participación parcial, algunos conflictos (2)
- [ ] Buena participación, PRs ordenados (3)
- [ ] Excelente: PRs diarios + reviews completos (4)

### 3. Testing (0-4)
> ¿Qué cobertura alcanzaste? ¿Usaste tests parametrizados?

- [ ] Sin tests o ?20% (0-1)
- [ ] 21-50% sin parametrización (2)
- [ ] 51-79% con algunos `[Theory]` (3)
- [ ] ?80% con `[Theory]` variados (4)

### 4. Documentación (0-4)
> ¿Completaste diario, vídeo y README?

- [ ] Falta todo (0-1)
- [ ] Solo diario parcial (2)
- [ ] Diario + vídeo básico (3)
- [ ] Todo completo: diario, vídeo narrado, README (4)

### Pregunta abierta:
> ¿Qué mejorarías en próximas sesiones? Describe dificultades y lecciones aprendidas.

---

## Checklist para Instructor

- [ ] Todos los PR aprobados y mergeados a `main`
- [ ] Pipeline GitHub Actions corriendo exitosamente (verde)
- [ ] Vídeo-demo (2 min) subido a Google Drive
  - [ ] Con enlace en `README.md`
  - [ ] Con narración clara
  - [ ] Muestra todas las queries funcionando
- [ ] Diarios combinados en `/docs/diarios-equipo.pdf`
- [ ] Tag `v1.0` creado en rama `main`
- [ ] Auto-rúbricas completadas en Google Forms (100% respuestas)
- [ ] Notas cargadas en LMS con rúbrica
- [ ] Feedback dejado en PRs dentro de 24h

---

## Ejemplos de Nota Final

### Equipo 1: 15/16 ? 9.4/10 ?????
- LINQ: 4 (6 queries avanzadas + SQL optimizado)
- Equipo: 4 (PRs diarios, reviews mutuos)
- Tests: 4 (85% cobertura, 12 tests parametrizados)
- Docs: 3 (Diario completo, vídeo pero sin narración)

### Equipo 2: 10/16 ? 6.25/10 ???
- LINQ: 3 (4 queries, SQL mejorable)
- Equipo: 2 (Algunos PR tardíos)
- Tests: 2 (55% cobertura, solo `[Fact]`)
- Docs: 3 (Diario parcial, vídeo básico)

### Equipo 3: 5/16 ? 3.1/10 ?
- LINQ: 1 (Solo SELECT simple)
- Equipo: 1 (Sin Git Flow)
- Tests: 1 (20% cobertura, errores)
- Docs: 2 (Diario sin completar)

---

**Última actualización:** 13/12/2025
