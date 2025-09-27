# BackEndVirONet8

## Descripci�n

BackEndVirONet8 es una API RESTful desarrollada en ASP.NET Core (.NET 8) que gestiona un cat�logo de personas y deportes, siguiendo una arquitectura en n-capas. Utiliza Entity Framework Core (Code-First) y SQLite como base de datos por defecto. El backend est� preparado para ser consumido por un frontend Blazor WebAssembly.

---

## Caracter�sticas principales

- CRUD completo para la entidad **Persona**.
- CRUD y consulta para la entidad **Deporte**.
- Relaci�n muchos-a-muchos entre personas y deportes.
- Validaciones robustas con DataAnnotations y l�gica de negocio.
- Paginaci�n y filtrado en el listado de personas.
- Manejo global de errores y mensajes claros.
- Documentaci�n autom�tica con Swagger.
- CORS habilitado para integraci�n con Blazor WASM.

---

## Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQLite](https://www.sqlite.org/download.html) (opcional, la base se crea autom�ticamente)
- (Opcional) [Visual Studio 2022](https://visualstudio.microsoft.com/es/vs/)

---

## Configuraci�n y ejecuci�n

1. **Clona el repositorio:** : git clone https://github.com/Chexfor/BackEndVirONet8.git cd BackEndVirONet8
2. **Configura la cadena de conexi�n en `appsettings.json`:** : "ConnectionStrings": { "DefaultConnection": "Data Source=MiCatalogoDb.sqlite" }
3. **Restaura los paquetes NuGet:** : dotnet restore
4. **Aplica las migraciones y crea la base de datos:** : dotnet ef database update -p Infrastructure -s .
5. **Ejecuta la API:** : dotnet run --project BackEndVirONet8
6. **Accede a la documentaci�n Swagger:**
   - Navega a `https://localhost:xxxx/swagger` (el puerto se muestra en consola).

---

## Endpoints principales

- `GET    /api/personas` � Listar personas (con paginaci�n y filtro)
- `GET    /api/personas/{id}` � Obtener persona por ID
- `POST   /api/personas` � Crear persona
- `PUT    /api/personas/{id}` � Actualizar persona
- `DELETE /api/personas/{id}` � Eliminar persona

- `GET    /api/deportes` � Listar deportes
- `GET    /api/deportes/{id}` � Obtener deporte por ID
- `POST   /api/deportes` � Crear deporte
- `PUT    /api/deportes/{id}` � Actualizar deporte
- `DELETE /api/deportes/{id}` � Eliminar deporte

---

## Validaciones

- **Persona:**
  - Nombre y PrimerApellido: Obligatorio, 2�100 caracteres.
  - SegundoApellido: Opcional, m�ximo 100 caracteres.
  - FechaNacimiento: Entre 1900 y hoy.
  - Sexo: Obligatorio (Masculino, Femenino, Otro).
  - Deportes: Selecci�n m�ltiple.

- **Deporte:**
  - Nombre: Obligatorio, �nico, 2�100 caracteres.

---

## Manejo de errores

- Los errores de validaci�n y de negocio retornan mensajes claros en formato JSON.
- Existe un middleware para manejo global de excepciones.

---

## Notas adicionales

- El backend est� preparado para ser consumido por un frontend Blazor WASM (ver proyecto FrontEndVirOBlazor).
- Puedes modificar la cadena de conexi�n para usar SQL Server si lo prefieres.
- Para desarrollo, Swagger est� habilitado por defecto.

---

## Licencia

Este proyecto es de uso acad�mico, demostrativo y para el solicitante.