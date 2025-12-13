# ?? INSTRUCCIONES PARA EL EQUIPO - PRÓXIMOS PASOS

**Versión:** 1.0-ready  
**Estado:** ? Código listo, documentación pendiente  
**Fecha:** 13/12/2025

---

## ?? QUÉ ESTÁ LISTO (No tocar)

```
? 13 Queries LINQ (básicas + avanzadas)
? 15 Tests pasando (ProductTests + CategoryTests)
? DbContext configurado con relaciones e índices
? Repository genérico + Specification pattern
? AppDbContext con constructores y Fluent API
? Compilación sin errores críticos
? GitHub Actions workflow
? README, rúbricas, guía Git, plantillas
```

---

## ?? QUÉ DEBEN HACER USTEDES (Tareas Pendientes)

### 1?? COMPLETAR DIARIOS DE APRENDIZAJE (Por cada integrante)

**Archivo:** `/docs/diario-<nombre>.md`

Usar plantilla en `/docs/PLANTILLA-DIARIO.md` y rellenar:

```markdown
# Diario de Aprendizaje – [Andrés / Carlos] – Semana [1/2/3/4]

## 1. Objetivos del día
- [ ] Objetivo 1
- [ ] Objetivo 2

## 2. Lo que logré
- Describir concretamente qué hicieron
- Aprendizajes específicos

## 3. Dificultades encontradas
- Problema ? Solución ? Tiempo

## 4. Próximo paso
- Qué sigue

## 5. Tiempo invertido
- X horas (desglose por actividades)

## 6. Conceptos aprendidos
- Código de ejemplo

## 7. Referencias

## 8. Auto-evaluación (0-4)
| Criterio | Puntuación | Comentario |
|----------|-----------|-----------|
| Cumplimiento de objetivos | X | |
| Calidad del código | X | |
| Documentación | X | |
| Aprendizaje | X | |
```

**Recomendación:** Llenar después de cada sesión (5 min)

---

### 2?? GRABAR VÍDEO-DEMO (2 minutos)

**Qué mostrar:**
1. Ejecutar: `dotnet run --project src/LinqAdvancedLab.Console`
2. Mostrar output de las 13 queries
3. Abrir archivo SQL generado (en `/docs`)
4. Mostrar tests pasando: `dotnet test`
5. Hablar sobre lo que aprendieron (30 seg)

**Cómo grabar:**
- OBS, Camtasia, o ScreenFlow
- Audio claro + pantalla en HD
- Subir a Google Drive y compartir enlace

**Lugar del enlace:** En `README.md` bajo `## ?? Demo`

---

### 3?? COMPLETAR AUTO-RÚBRICAS (Individual en Google Forms)

**Crear Google Form con:**

1. **LINQ Complejo (0-4)**
   - [ ] Sin LINQ (0-1)
   - [ ] 1-3 queries (2)
   - [ ] 4-5 queries (3)
   - [ ] ?6 queries + optimización (4)

2. **Trabajo en Equipo (0-4)**
   - [ ] No participé (0-1)
   - [ ] Participación parcial (2)
   - [ ] Buena participación (3)
   - [ ] Excelente: PRs + reviews (4)

3. **Tests (0-4)**
   - [ ] Sin tests (0-1)
   - [ ] 21-50% cobertura (2)
   - [ ] 51-79% cobertura (3)
   - [ ] ?80% + [Theory] (4)

4. **Documentación (0-4)**
   - [ ] Nada (0-1)
   - [ ] Solo diario (2)
   - [ ] Diario + vídeo (3)
   - [ ] Todo completo (4)

5. **Pregunta abierta:** "¿Qué mejorarías?"

**Enlace del Form:** En `README.md` bajo `## ?? Auto-Evaluación`

---

### 4?? CODE REVIEW MUTUO (Entre compañeros)

**Procedi miento:**

1. **Crear rama develop:**
   ```bash
   git checkout -b develop origin/develop
   git pull origin develop
   ```

2. **Crear PR a develop:**
   ```bash
   git checkout -b feature/revision-entrega develop
   git add docs/diario-*.md
   git commit -m "docs: diarios de aprendizaje completos"
   git push origin feature/revision-entrega
   # Crear PR en GitHub
   ```

3. **Revisar PR del compañero:**
   - Abrir PR en GitHub
   - Click "Files changed"
   - Agregar comentarios
   - Click "Approve"

4. **Mergear PR a develop:**
   - Después de 1 approval
   - Click "Merge pull request"

---

### 5?? CREAR TAG v1.0 (Cuando esté todo listo)

```bash
# En rama main
git checkout main
git pull origin main

# Crear tag
git tag -a v1.0 -m "Version 1.0 - Proyecto completo"

# Subir tag
git push origin v1.0

# Crear release en GitHub (opcional pero recomendado)
# Ir a GitHub ? Releases ? Create a new release
```

---

## ?? WORKFLOW RECOMENDADO

```
Día 1 (Sesión de cierre):
?? 15 min: Revisar código compilado ?
?? 30 min: Cada uno llena su diario
?? 15 min: Revisar diarios mútuamente
?? 15 min: Commit: "docs: diarios completados"

Día 2 (Después de clase):
?? 15 min: Grabar vídeo-demo
?? 15 min: Subirlo a Google Drive
?? 10 min: Actualizar README con enlace
?? 10 min: Commit: "docs: video-demo agregado"

Día 3 (Final):
?? 10 min: Completar auto-rúbrica (Form)
?? 10 min: Crear PR a develop
?? 10 min: Code-review mutuos
?? 10 min: Mergear a develop
?? 5 min: Mergear develop a main
?? 5 min: Crear tag v1.0
```

---

## ?? CHECKLIST FINAL

- [ ] Diarios completos (`/docs/diario-*.md`)
- [ ] Vídeo-demo grabado (2 min)
- [ ] Vídeo subido a Google Drive
- [ ] Enlace vídeo en `README.md`
- [ ] Auto-rúbricas completadas (Google Forms)
- [ ] PR con diarios + vídeo ? develop
- [ ] Code-review mutuos hechos
- [ ] Mergeado a develop
- [ ] Mergeado a main
- [ ] Tag `v1.0` creado
- [ ] Release publicada (opcional)

---

## ?? RESULTADO ESPERADO

Cuando terminen, deberían tener:

### En GitHub
```
main
  ?? tag: v1.0 ?
  ?? Commit: "merge: revision completa"

develop
  ?? Commit: "docs: diarios + video"
  ?? PR aprobado #X
```

### En `/docs`
```
diario-andres-saltos.md     ? Completado
diario-carlos-huilca.md     ? Completado
RESUMEN-IMPLEMENTACION.md   ? Existente
RUBRICA-EVALUACION.md       ? Existente
VERIFICACION-FINAL.md       ? Existente
```

### En Google Forms
```
Auto-rúbricas: 2 respuestas (1 por integrante)
```

### En README.md
```
## ?? Vídeo-Demo
[Ver demo en Google Drive](https://drive.google.com/...)

## ?? Auto-Evaluación
[Completar auto-rúbrica](https://forms.gle/...)
```

---

## ? VERIFICACIÓN ANTES DE ENTREGAR

```bash
# 1. Tests deben pasar
dotnet test tests/LinqAdvancedLab.Tests
# ? 15/15 PASSED

# 2. Código debe compilar
dotnet build
# ? SIN ERRORES

# 3. Diarios deben estar en /docs
ls docs/diario-*.md
# ? Mínimo 2 archivos

# 4. README debe tener enlaces
grep -i "video\|demo\|evaluacion" README.md
# ? Enlaces presentes

# 5. Git debe tener v1.0
git tag -l
# ? v1.0 presente
```

---

## ?? DUDAS FRECUENTES

**P: ¿Cuánto debe durar el vídeo?**  
R: 2 minutos aproximadamente (mínimo 1 min 30 seg)

**P: ¿Qué si el vídeo no se carga a Google Drive?**  
R: Usar OneDrive, YouTube (privado) o Mega como alternativa

**P: ¿Cuándo debo llenar el diario?**  
R: Idealmente al final de cada sesión (5 minutos)

**P: ¿Qué pasa si no hago todo?**  
R: La nota será proporcional al cumplimiento (14/16 = 8.75 ? 13/16 = 8.1, etc)

**P: ¿Puedo editar el código base?**  
R: Solo si hay bugs. El código está listo. Mejor documenta lo que se hizo.

**P: ¿Cómo hago code-review?**  
R: Ver `/docs/GUIA-GIT.md` sección "Code Review"

---

## ?? IMPORTANTE

> El código está **100% funcional y listo**. 
> Lo que falta es **documentación personal de ustedes**:
> - Diarios (aprendizaje individual)
> - Vídeo (demo del trabajo)
> - Auto-rúbricas (autoevaluación)

Esto es lo que el instructor va a evaluar:
? ¿Aprendieron LINQ?
? ¿Pueden explicarlo?
? ¿Saben usar Git?
? ¿Documentan su proceso?

---

## ?? ¡ADELANTE!

El proyecto está listo. Ahora es cosa de documentar lo que hicieron y aprendieron.

**Tiempo estimado:** 3-4 horas en total (diarios + vídeo + rúbricas)

**Plazo recomendado:** 3-5 días después de la última sesión de código

**Entrega:** Main branch con tag v1.0 + diarios en `/docs` + enlaces en README

---

**Preguntas?** Ver `/docs/GUIA-GIT.md` o preguntar al instructor

¡Buena suerte! ??
