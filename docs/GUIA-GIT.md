# Guía de Git Workflow - LinqAdvancedLab

## ?? Estructura de Ramas

```
main (protegida)
 ?
 ?? develop
 ?   ?? feature/andres-entidades
 ?   ?? feature/andres-queries1
 ?   ?? feature/carlos-repositorio
 ?   ?? feature/[historia-usuario]
 ?
 ?? hotfix/[bug-crítico]
```

---

## ?? Inicio de Sesión

### Paso 1: Sincronizar main
```bash
git checkout main
git pull origin main
```

### Paso 2: Sincronizar develop
```bash
git checkout develop
git pull origin develop
```

### Paso 3: Crear rama feature
```bash
git checkout -b feature/query-5-paginacion develop
```

**Nomenclatura:**
- `feature/andres-entidades` (por persona + historia)
- `feature/query-5-paginacion` (más descriptivo)
- `hotfix/bug-comprobante` (para bugs críticos)

---

## ?? Hacer Cambios

### Editar código
```bash
# Editar archivos en Visual Studio o editor
```

### Ver cambios
```bash
git status
git diff src/LinqAdvancedLab.Console/Consultas/AdvancedQueries.cs
```

### Agregar cambios
```bash
# Agregar archivo específico
git add src/LinqAdvancedLab.Console/Consultas/AdvancedQueries.cs

# Agregar todos los cambios
git add .

# Ver cambios staged
git diff --cached
```

---

## ?? Hacer Commits

### Mensajes convencionales (Conventional Commits)

```
<tipo>(<scope>): <descripción corta>

<cuerpo detallado - opcional>

<referencias a issues - opcional>
```

**Tipos:**
- `feat` - Nueva característica
- `fix` - Corrección de bug
- `refactor` - Cambio sin nueva funcionalidad
- `test` - Tests nuevos o actualizados
- `docs` - Documentación
- `chore` - Mantenimiento (dependencias, configs)

**Scopes:**
- `console` - Cambios en el proyecto Console
- `data` - Cambios en DbContext, repositorios
- `domain` - Entidades, DTOs
- `tests` - Tests

### Ejemplos de commits

```bash
# Query nueva
git commit -m "feat(console): implementar query 5 con paginacion

- Agregar metodo GetPaginado() en AdvancedQueries
- Soportar parametros page y pageSize
- Retornar PaginatedResult con Items y Total"

# Bug fix
git commit -m "fix(data): corregir relacion Product-Category

OnDelete(DeleteBehavior.Cascade) ahora funciona correctamente"

# Tests
git commit -m "test(console): agregar 8 tests parametrizados

[Theory] para filtrar por precio, categoria, paginacion"

# Diario
git commit -m "docs: actualizar diario de aprendizaje semana 2"
```

---

## ?? Enviar cambios

### Push a rama feature
```bash
git push origin feature/query-5-paginacion
```

### Primera vez (crear rama remota)
```bash
git push -u origin feature/query-5-paginacion
```

### Si hay cambios en remoto
```bash
git pull origin feature/query-5-paginacion
# ... resolver conflictos si hay
git push origin feature/query-5-paginacion
```

---

## ?? Crear Pull Request (PR)

### Opción 1: GitHub.com
1. Ir a https://github.com/rhq-omni777/LinqAdvancedLab
2. Hacer click en "Pull requests"
3. Click "New pull request"
4. `base: develop` ? `compare: feature/query-5-paginacion`
5. Título: `feat: implementar query 5 con paginacion`
6. Descripción:
   ```
   ## Descripción
   Implementé la query 5 que muestra paginación con Skip/Take

   ## Cambios
   - Agregar metodo GetPaginado() en AdvancedQueries.cs
   - Crear clase PaginatedResult<T> para resultado
   - Tests parametrizados en ProductTests.cs

   ## Tipo de cambio
   - [x] Nueva feature
   - [ ] Bug fix
   - [ ] Breaking change

   ## Checklist
   - [x] Mi código sigue las convenciones del proyecto
   - [x] He actualizado mi diario de aprendizaje
   - [x] Los tests pasan localmente
   - [x] No hay conflictos con develop

   Closes #5
   ```

### Opción 2: Línea de comandos
```bash
# Crear PR automáticamente (requiere GitHub CLI)
gh pr create --base develop --title "feat: query 5 con paginacion" --body "Descripción..."
```

---

## ?? Code Review (Revisión de Código)

### Para el autor (espera revisión)
1. Esperar a que otro integrante revise
2. Responder comentarios
3. Si pide cambios: hacer commits, no force-push
4. Marcar como "Resolved" cuando resuelves comentario

### Para el revisor (revisa código ajeno)
1. Ir a PR ? "Files changed"
2. Hover sobre línea ? click "+"
3. Escribir comentario o sugerencia:
   ```
   ¿Por qué usaste IQueryable aquí en lugar de IEnumerable?
   ```
4. Click "Approve" si todo está bien
5. Click "Request changes" si necesita fixes

**Cosas a revisar:**
- ? ¿El código compila?
- ? ¿Los tests pasan?
- ? ¿Sigue las convenciones del proyecto?
- ? ¿El SQL generado está optimizado?
- ? ¿El diario está actualizado?
- ? ¿Hay consultas duplicadas?

---

## ? Aprobar y Mergear

### Cuando está listo para mergear
1. ?1 approval de otro integrante
2. Todos los tests pasan (GitHub Actions ?)
3. Sin conflictos con develop
4. Diario actualizado

### Mergear en GitHub
1. Click "Squash and merge" (recomendado para features pequeñas)
   ```
   feat: implementar query 5 con paginacion
   
   - Agregar GetPaginado() con Skip/Take
   - Crear PaginatedResult<T>
   - Tests parametrizados
   ```

2. O click "Merge pull request" (mantiene todos los commits)

3. Click "Delete branch" (limpiar rama)

### Después del merge
```bash
git checkout develop
git pull origin develop
git branch -d feature/query-5-paginacion
```

---

## ?? Resolver Conflictos

### Cuando hay conflicto
```bash
git pull origin develop
# Dice: "CONFLICT (content): Merge conflict in src/..."
```

### Ver conflictos
```bash
git status
```

### Resolver manualmente
```csharp
// Archivo con conflicto
<<<<<<< HEAD (tu rama feature)
var resultado = _ctx.Products.Where(p => p.Price > 500);
=======  (develop)
var resultado = _ctx.Products.Where(p => p.Price > 500).ToList();
>>>>>>> develop
```

**Elegir uno y borrár marcas:**
```csharp
var resultado = _ctx.Products.Where(p => p.Price > 500).ToList();
```

### Completar merge
```bash
git add src/...
git commit -m "merge: resolver conflicto con develop"
git push origin feature/query-5-paginacion
```

---

## ?? Ver Historial

### Log de commits
```bash
git log --oneline -10
# ej: abc1234 feat: query 5 paginacion
#     def5678 fix: resolver bug en DbContext
#     ghi9012 docs: actualizar readme
```

### Ver cambios específicos
```bash
git show abc1234
git diff develop feature/query-5-paginacion
```

### Contribuciones por persona
```bash
git log --author="Andrés" --oneline
git shortlog -s -n  # resumen por autor
```

---

## ??? Tags (Versiones)

### Crear tag (al terminar, en main)
```bash
git checkout main
git pull origin main
git tag -a v1.0 -m "Versión 1.0 - Proyecto completo"
git push origin v1.0
```

### Ver tags
```bash
git tag -l
```

### Crear release en GitHub
1. Ir a "Releases"
2. Click "Create a new release"
3. Tag: `v1.0`
4. Title: `Version 1.0 - LinqAdvancedLab Completo`
5. Description:
   ```
   ## Cambios en v1.0
   - 13 queries LINQ (4 básicas + 9 avanzadas)
   - Tests parametrizados con 85%+ cobertura
   - Repositorio genérico + Specification pattern
   - Documentación completa + video-demo
   
   ## Estadísticas
   - 42 commits
   - 8 PRs mergeados
   - 12 tests verdes
   ```

---

## ?? Hotfix (Para bugs críticos)

### Crear hotfix
```bash
git checkout -b hotfix/bug-paginacion main
# Hacer fix
git commit -m "fix: corregir paginacion que mostraba duplicados"
git push origin hotfix/bug-paginacion
```

### Mergear hotfix
1. Crear PR `hotfix/bug-paginacion` ? `main`
2. Mergear en `main`
3. Sincronizar `develop`: `git merge main`

---

## ?? Checklist Diario (5 min al final de clase)

- [ ] **Pull:** `git pull origin develop` (traer cambios)
- [ ] **Status:** `git status` (ver cambios pendientes)
- [ ] **Commit:** Hacer commits descriptivos antes de irse
- [ ] **Push:** `git push origin feature/mi-rama`
- [ ] **PR:** Crear/revisar PRs de compañeros
- [ ] **Diario:** Actualizar `/docs/diario-<nombre>.md`
- [ ] **Trello:** Mover tarjeta a "Done"

---

## ?? Errores Comunes

### Error: "Your branch is behind 'origin/develop'"
```bash
git pull origin develop
```

### Error: "Please commit your changes before merging"
```bash
git add .
git commit -m "wip: trabajo en progreso"
# o descartar:
git checkout -- src/...
```

### Error: "CONFLICT: Merge conflict"
```bash
# Ver conflictos
git status
# Editar archivos conflictivos
# Completar merge
git add .
git commit -m "merge: resolver conflictos"
```

### "Accidentalmente en wrong branch"
```bash
git stash                    # guardar cambios temporalmente
git checkout feature/correcta
git stash pop                # restaurar cambios
```

### "Commit al branch incorrecto"
```bash
git reset HEAD~1             # deshacer último commit
git checkout feature/correcta
git commit -m "mensaje"
```

---

## ?? Recursos

- [Git Official](https://git-scm.com/doc)
- [GitHub Docs](https://docs.github.com)
- [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/)
- [Git Flow](https://nvie.com/posts/a-successful-git-branching-model/)

---

**Última actualización:** 13/12/2025
