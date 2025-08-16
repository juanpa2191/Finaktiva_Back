# Event Registration API

API para gestionar y registrar eventos en la base de datos **Registration**.  
Proyecto desarrollado como prueba técnica aplicando **Clean Architecture** y principios **SOLID**.

---

##  Tecnologías usadas
- **.NET 8 / ASP.NET Core WebApi**
- **Entity Framework Core**
- **SQL Server**
- **Repository Pattern**
- **Dependency Injection**
- **Middleware personalizado para manejo de excepciones**

---

##  Estructura de la solución
- **Domain** → Entidades de negocio (`EventLog`)
- **Application** → Interfaces y lógica de aplicación (`ILoggingService`, `IEventLogRepository`)
- **Infrastructure** → Persistencia (`RegistrationDbContext`, repositorios concretos)
- **WebApi** → Endpoints REST y configuración

---

##  Base de datos
Nombre: `Registration`  
Tabla: `EventLogs`

Campos:
- **Id** (int, PK, identity)
- **EventDate** (datetime)
- **Description** (nvarchar)
- **EventType** (nvarchar)

---

##  Endpoints principales
### Registrar un evento
```http
POST https://localhost:7189/api/EventLogs
Content-Type: application/json

{
  "eventDate": "2025-08-15T10:30:00",
  "description": "Usuario inició sesión",
  "eventType": "INFO"
}
