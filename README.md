# BackEndVirONet8

## 📋 Índice

- [Descripción](#descripción)
- [Características principales](#características-principales)
- [Requisitos previos](#requisitos-previos)
- [Configuración y ejecución](#configuración-y-ejecución)
- [Endpoints principales](#endpoints-principales)
- [Validaciones](#validaciones)
- [Manejo de errores](#manejo-de-errores)
- [Estructura del proyecto](#estructura-del-proyecto)
- [URLs de la aplicación](#urls-de-la-aplicación)
- [Notas adicionales](#notas-adicionales)
- [Solución de problemas](#solución-de-problemas)

---

## Descripción

BackEndVirONet8 es una API RESTful desarrollada en ASP.NET Core (.NET 8) que gestiona un catálogo de personas y deportes, siguiendo una arquitectura en n-capas. Utiliza Entity Framework Core (Code-First) y SQLite como base de datos por defecto. El backend está preparado para ser consumido por un frontend Blazor WebAssembly.

---

## Características principales

- CRUD completo para la entidad **Persona**.
- CRUD y consulta para la entidad **Deporte**.
- Relación muchos-a-muchos entre personas y deportes.
- Validaciones robustas con DataAnnotations y lógica de negocio.
- Paginación y filtrado en el listado de personas.
- Manejo global de errores y mensajes claros.
- Documentación automática con Swagger.
- CORS habilitado para integración con Blazor WASM.

---

## Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQLite](https://www.sqlite.org/download.html) (opcional, la base se crea automáticamente)
- (Opcional) [Visual Studio 2022](https://visualstudio.microsoft.com/es/vs/)

---

## Configuración y ejecución

### 1. Clonar el repositorio
```bash
git clone https://github.com/Chexfor/BackEndVirONet8.git
cd BackEndVirONet8
```

### 2. Configurar la cadena de conexión
Edita el archivo `appsettings.json` y verifica que tenga la siguiente configuración:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=MiCatalogoDb.sqlite"
  }
}
```

### 3. Restaurar paquetes NuGet
```bash
dotnet restore
```

### 4. Crear migraciones (si es necesario)
Si necesitas crear nuevas migraciones:
```bash
dotnet ef migrations add NombreDeLaMigracion
```

### 5. Aplicar migraciones y crear la base de datos
```bash
dotnet ef database update
```

### 6. Ejecutar la API
```bash
dotnet run --project BackEndVirONet8
```

### 7. Acceder a la aplicación
- **Backend (API):** `https://localhost:7298`
- **Documentación Swagger:** `https://localhost:7298/swagger/index.html`
- **Frontend (Blazor):** `https://localhost:7144`

---

## Endpoints principales

### 📊 Deportes
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/Deportes` | Obtener todos los deportes |
| `POST` | `/api/Deportes` | Crear un nuevo deporte |
| `GET` | `/api/Deportes/{id}` | Obtener un deporte por ID |
| `PUT` | `/api/Deportes/{id}` | Actualizar un deporte |
| `DELETE` | `/api/Deportes/{id}` | Eliminar un deporte |

### 👥 Personas
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/Personas` | Obtener todas las personas (con paginación) |
| `POST` | `/api/Personas` | Crear una nueva persona |
| `GET` | `/api/Personas/{id}` | Obtener una persona por ID |
| `PUT` | `/api/Personas/{id}` | Actualizar una persona |
| `DELETE` | `/api/Personas/{id}` | Eliminar una persona |
| `POST` | `/api/Personas/{id}/deportes` | Asignar deportes a una persona |
    
## Validaciones

- **Persona:**
  - Nombre y PrimerApellido: Obligatorio, 2–100 caracteres.
  - SegundoApellido: Opcional, máximo 100 caracteres.
  - FechaNacimiento: Entre 1900 y hoy.
  - Sexo: Obligatorio (Masculino, Femenino, Otro).
  - Deportes: Selección múltiple.

- **Deporte:**
  - Nombre: Obligatorio, único, 2–100 caracteres.

---

## Manejo de errores

- Los errores de validación y de negocio retornan mensajes claros en formato JSON.
- Existe un middleware para manejo global de excepciones.

---

## Estructura del proyecto

```
BackEndVirONet8/
├── BackEndVirONet8/           # Proyecto principal (API)
├── Application/               # Capa de aplicación (DTOs, Services)
├── Domain/                   # Capa de dominio (Entities, Interfaces)
├── Infrastructure/           # Capa de infraestructura (EF Core, Migrations)
└── Shared/                  # Componentes compartidos
```

## URLs de la aplicación

- **🌐 Backend API:** [https://localhost:7298](https://localhost:7298)
- **📚 Swagger UI:** [https://localhost:7298/swagger/index.html](https://localhost:7298/swagger/index.html)
- **💻 Frontend Blazor:** [https://localhost:7144](https://localhost:7144)

## Notas adicionales

- ✅ El backend está preparado para ser consumido por un frontend Blazor WASM (ver proyecto FrontEndVirOBlazor).
- 🔧 Puedes modificar la cadena de conexión en `appsettings.json` para usar SQL Server si lo prefieres.
- 📖 Para desarrollo, Swagger está habilitado por defecto y documenta automáticamente todos los endpoints.
- 🗄️ La base de datos SQLite se crea automáticamente al ejecutar las migraciones.
- 🔄 Si cambias el modelo de datos, recuerda crear una nueva migración con `dotnet ef migrations add NombreDeLaMigracion`.

---

## Solución de problemas

### Error: "No se puede encontrar el proyecto o la solución"
```bash
# Asegúrate de estar en el directorio correcto
cd BackEndVirONet8
```

### Error: "dotnet ef no se reconoce como comando"
```bash
# Instala las herramientas de Entity Framework
dotnet tool install --global dotnet-ef
```

### Error de conexión a la base de datos
- Verifica que el archivo `appsettings.json` tenga la cadena de conexión correcta
- Asegúrate de que no haya otro proceso usando el puerto 7298

### Error al crear migraciones
```bash
# Si tienes problemas con las migraciones, elimina la carpeta Migrations y vuelve a crear
rm -rf Migrations
dotnet ef migrations add InitialCreate
```

---

## Licencia

Este proyecto es de uso académico, demostrativo y para el solicitante.
