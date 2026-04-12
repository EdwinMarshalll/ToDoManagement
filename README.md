# ToDoManagement.Api
Administrador basico de tareas.

## Features
Este administrador consta de las iguientes funciones
- Listado de todas las tareas
- Filtrado de tareas
- Detalle de una tarea
- Eliminacion de tarea
- Creacion de nueva tarea

---
## Modelos
### Tarea
- Nombre
- Notas
- Fecha de vencimiento
- Adjunto
- Completada
- Categoria

### Categoria
- Nombre

---

## Arquitectura
### Capa de Dominio
- Entities
- ValueObjects
- Exceptions

### Capa de Aplicacion
- Casos de Uso
- Interfaces

### Capa de Infraestructura
- Implementaciones
- Persistencia

### Capa de Presentacion
- API
	- Controllers
	- DTOs
	- Middlewares