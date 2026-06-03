# EVALUACIÓN TÉCNICA NUXIBA

Prueba: **DESARROLLADOR JR**

Deadline: **1 día**

Nombre: Aldo ivan Bernal Mercado 

---

## Clona y crea tu repositorio para la evaluación

1. Clona este repositorio en tu máquina local.
2. Crea un repositorio público en tu cuenta personal de GitHub, BitBucket o Gitlab.
3. Cambia el origen remoto para que apunte al repositorio público que acabas de crear en tu cuenta.
4. Coloca tu nombre en este archivo README.md y realiza un push al repositorio remoto.

---

## Instrucciones Generales

1. Cada pregunta tiene un valor asignado. Asegúrate de explicar tus respuestas y mostrar las consultas o procedimientos que utilizaste.
2. Se evaluará la claridad de las explicaciones, el pensamiento crítico, y la eficiencia de las consultas.
3. Utiliza **SQL Server** para realizar todas las pruebas y asegúrate de que las consultas funcionen correctamente antes de entregar.
4. Justifica tu enfoque cuando encuentres una pregunta sin una única respuesta correcta.
5. Configura un Contenedor de **SQL Server con Docker** utilizando los siguientes pasos:

### Pasos para ejecutar el contenedor de SQL Server

Asegúrate de tener Docker instalado y corriendo en tu máquina. Luego, ejecuta el siguiente comando para levantar un contenedor con SQL Server:

```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrong!Passw0rd'    -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
```

6. Conéctate al servidor de SQL con cualquier herramienta como **SQL Server Management Studio** o **Azure Data Studio** utilizando las siguientes credenciales:
   - **Servidor**: localhost, puerto 1433
   - **Usuario**: sa
   - **Contraseña**: YourStrong!Passw0rd

---

# Examen Práctico para Desarrollador Junior en .NET 8 y SQL Server

**Tiempo estimado:** 1 día  
**Total de puntos:** 100

---

## Instrucciones Generales:

El examen está compuesto por tres ejercicios prácticos. Sigue las indicaciones en cada uno y asegúrate de entregar el código limpio y funcional.

Además, se proporciona un archivo **CCenterRIA.xlsx** para que te bases en la estructura de las tablas y datos proporcionados.

[Descargar archivo de ejemplo](CCenterRIA.xlsx)

---

## Ejercicio 1: API RESTful con ASP.NET Core y Entity Framework (40 puntos)

**Instrucciones:**  
Desarrolla una API RESTful con ASP.NET Core y Entity Framework que permita gestionar el acceso de usuarios.

1. **Creación de endpoints**:
   - **GET /logins**: Devuelve todos los registros de logins y logouts de la tabla `ccloglogin`. (5 puntos)
   - **POST /logins**: Permite registrar un nuevo login/logout. (5 puntos)
   - **PUT /logins/{id}**: Permite actualizar un registro de login/logout. (5 puntos)
   - **DELETE /logins/{id}**: Elimina un registro de login/logout. (5 puntos)

2. **Modelo de la entidad**:  
   Crea el modelo `Login` basado en los datos de la tabla `ccloglogin`:
   - `User_id` (int)
   - `Extension` (int)
   - `TipoMov` (int) → 1 es login, 0 es logout
   - `fecha` (datetime)

3. **Base de datos**:  
   Utiliza **Entity Framework Core** para crear la tabla en una base de datos SQL Server basada en este modelo. Aplica migraciones para crear la tabla en la base de datos. (10 puntos)

4. **Validaciones**:  
   Implementa las validaciones necesarias para asegurar que las fechas sean válidas y que el `User_id` esté presente en la tabla `ccUsers`. Además, maneja errores como intentar registrar un login sin un logout anterior. (10 puntos)

5. **Pruebas Unitarias** (Opcional):  
   Se valorará si incluyes pruebas unitarias para los endpoints de tu API utilizando un framework como **xUnit** o **NUnit**. (Puntos extra)

---

## Ejercicio 2: Consultas SQL y Optimización (30 puntos)

**Instrucciones:**

Trabaja en SQL Server y realiza las siguientes consultas basadas en la tabla `ccloglogin`:

1. **Consulta del usuario que más tiempo ha estado logueado** (10 puntos):
   - Escribe una consulta que devuelva el usuario que ha pasado más tiempo logueado. Para calcular el tiempo de logueo, empareja cada "login" (TipoMov = 1) con su correspondiente "logout" (TipoMov = 0) y suma el tiempo total por usuario.

   Ejemplo de respuesta:  
   - `User_id`: 92  
   - Tiempo total: 361 días, 12 horas, 51 minutos, 8 segundos

2. **Consulta del usuario que menos tiempo ha estado logueado** (10 puntos):
   - Escribe una consulta similar a la anterior, pero que devuelva el usuario que ha pasado menos tiempo logueado.

   Ejemplo de respuesta:  
   - `User_id`: 90  
   - Tiempo total: 244 días, 43 minutos, 15 segundos

3. **Promedio de logueo por mes** (10 puntos):
   - Escribe una consulta que calcule el tiempo promedio de logueo por usuario en cada mes.

   Ejemplo de respuesta:  
   - Usuario 70 en enero 2023: 3 días, 14 horas, 1 minuto, 16 segundos

---

## Ejercicio 3: API RESTful para generación de CSV (30 puntos)

**Instrucciones:**

1. **Generación de CSV**:  
   Crea un endpoint adicional en tu API que permita generar un archivo CSV con los siguientes datos:
   - Nombre de usuario (`Login` de la tabla `ccUsers`)
   - Nombre completo (combinación de `Nombres`, `ApellidoPaterno`, y `ApellidoMaterno` de la tabla `ccUsers`)
   - Área (tomado de la tabla `ccRIACat_Areas`)
   - Total de horas trabajadas (basado en los registros de login y logout de la tabla `ccloglogin`)

   El CSV debe calcular el total de horas trabajadas por usuario sumando el tiempo entre logins y logouts.

2. **Formato y Entrega**:
   - El CSV debe ser descargable a través del endpoint de la API.
   - Asegúrate de probar este endpoint utilizando herramientas como **Postman** o **curl** y documenta los pasos en el archivo README.md.

---

## Entrega

1. Sube tu código a un repositorio en GitHub o Bitbucket y proporciona el enlace para revisión.
2. El repositorio debe contener las instrucciones necesarias en el archivo **README.md** para:
   - Levantar el contenedor de SQL Server.
   - Conectar la base de datos.
   - Ejecutar la API y sus endpoints.
   - Descargar el CSV generado.
3. **Opcional**: Si incluiste pruebas unitarias, indica en el README cómo ejecutarlas.

---

Este examen evalúa tu capacidad para desarrollar APIs RESTful, realizar consultas avanzadas en SQL Server y generar reportes en formato CSV. Se valorará la organización del código, las mejores prácticas y cualquier documentación adicional que proporciones.



Explicacion  Levantar SQL Server con Docker

Para ejecutar la base de datos del proyecto se utiliza un contenedor de SQL Server en Docker.

### 🔹 Comando de ejecución

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=StrongPassw0rd!123" ^
-p 1433:1433 --name sqlserver-container ^
-d mcr.microsoft.com/mssql/server:2022-latest
```
 
Conexión a la base de datos
Server: localhost,1433
Usuario: sa
Password: StrongPassw0rd!123

##  Configuración de conexión (appsettings.json)

La API se conecta a SQL Server mediante Entity Framework Core.

###  Cadena de conexión

En el archivo `appsettings.json` se debe configurar lo siguiente:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=LoginDB;User Id=sa;Password=StrongPassw0rd!123;TrustServerCertificate=True;"
  }
}
```

Restaurar dependencias del proyecto 
dotnet restore

 Compilar el proyecto
dotnet build


 Ejecutar la API
dotnet run

Resultado
Una vez ejecutado, la API queda disponible en:

http://localhost:5019/api/logins  

 Endpoints de la API

GET /api/logins

 Devuelve todos los registros ordenados por fecha (desc)

 Respuesta ejemplo:
[
 {
        "id": 101,
        "user_id": 70,
        "extension": -3,
        "tipoMov": 0,
        "fecha": "2024-05-20T17:30:46"
    },
    {
        "id": 100,
        "user_id": 70,
        "extension": -4,
        "tipoMov": 1,
        "fecha": "2024-05-20T08:29:51"
    },
    {
        "id": 99,
        "user_id": 70,
        "extension": 0,
        "tipoMov": 0,
        "fecha": "2024-05-18T14:09:49"
    },
]

POST - Crear login/logout
POST /api/logins
Body JSON
{
  "User_id": 1,
  "Extension": 1234,
  "TipoMov": 0,
  "Fecha": "2026-06-03T10:00:00"
}

Validaciones del POST

El sistema valida:

 1. Usuario no existe
"El usuario no existe"
 var userExists = await _context.Users
    .AnyAsync(u => u.User_id == login.User_id); -> Este código consulta la tabla Users y verifica si existe un usuario con el mismo User_id que viene en el login, utilizando AnyAsync que devuelve verdadero si encuentra al menos un registro.

    if (!userExists)
    return BadRequest("El usuario no existe"); -> Si la variable userExists es falsa, significa que no se encontró el usuario en la base de datos, por lo tanto se retorna un error BadRequest indicando que el usuario no existe
 
 
 
 2. Datos nulos
"Datos inválidos"
if (login == null)
    return BadRequest("Datos inválidos"); ->si no se envian datos o esta vacio   regresa  "Datos Invalidos "
 
 PUT /api/logins/{id}

 actualizar un registro existente en la tabla ccloglogin.

Este endpoint busca un registro de login/logout por su id y, si existe, actualiza sus campos:

User_id
Extension
TipoMov (0 = LOGIN, 1 = LOGOUT)
Fecha

Si el registro no existe, devuelve un error 404 NotFound.

 var existing = await _context.Logins.FindAsync(id); ->hace una busqueda por id en la tabla Logins 

    if (existing == null)   
     return NotFound();   ->si no existe ese id  regresa el error 404
ejemplo 

http://localhost:5019/api/logins/1

se envia body  
 {
    "user_id": 70,
    "extension": -100,
    "tipoMov": 1,
    "fecha": "2023-01-11T00:48:23"
  }
Me devuelve el registro actualizado después de aplicar los cambios en la base de datos

  {
    "id": 1,
    "user_id": 70,
    "extension": -100,
    "tipoMov": 1,
    "fecha": "2023-01-11T00:48:23"
}

 
DELETE /api/logins/{id}
 Permite eliminar un registro existente de la tabla ccloglogin.

Este endpoint elimina un registro de login/logout según el id proporcionado en la URL.

Si el registro existe, se elimina permanentemente de la base de datos.
Si no existe, devuelve un error 404 NotFound.


var existing = await _context.Logins.FindAsync(id);------> Busca en la tabla Logins un registro por su ID.

if (existing == null)
    return NotFound();  --->  Si no encuentra el registro 404 NotFound


__context.Logins.Remove(existing);
await _context.SaveChangesAsync(); -----> Elimina el registro de la base de datos y guarda los cambios.


DELETE http://localhost:5019/api/logins/1

devuelve 

{
    "message": "Eliminado correctamente"
}



GET /api/logins/report/csv
 Generación de reporte CSV de horas trabajadas

Este endpoint genera un archivo CSV descargable con:

Login del usuario
Nombre completo
Área
Total de horas trabajadas (calculadas con logs de login/logout)

Get  http://localhost:5019/api/logins/report/csv

la api devuelve 
user04Admin,user04Admin user04Admin user04Admin,Default,0
user05Admin,user05Admin user05Admin user05Admin,Default,0
user06Admin,user06Admin user06Admin user06Admin,Default,0
user07Admin,user07Admin user07Admin user07Admin,Default,0
user08Admin,user08Admin user08Admin user08Admin,Default,0
user09Admin,user09Admin user09Admin user09Admin,Default,0
user10Admin,user10Admin user10Admin user10Admin,Default,0
leoAdmin,leoAdmin leoAdmin leoAdmin,Default,0
adriAgent,adriAgent adriAgent adriAgent,Default,5158.94 <-------------------
agarciaAgent,agarciaAgent agarciaAgent agarciaAgent,Default,0
agonzalezAgent,agonzalezAgent agonzalezAgent agonzalezAgent,Default,0


consultas sql 

Usuario mas tiempo logueado
WITH Sesiones AS (
    SELECT
        l1.User_id,
        l1.Fecha AS LoginTime,  
        -- Selecciona el usuario y la fecha del login (inicio de sesión)

        (
            SELECT MIN(l2.Fecha)
            -- Busca la fecha más cercana de logout (la mínima fecha después del login)

            FROM ccloglogin l2
            WHERE l2.User_id = l1.User_id
              AND l2.TipoMov = 1
              AND l2.Fecha > l1.Fecha
        ) AS LogoutTime

        -- Obtiene el logout correspondiente al login (misma persona, después en el tiempo)

    FROM ccloglogin l1
    WHERE l1.TipoMov = 0
    -- Solo toma registros de LOGIN (inicio de sesión)
),
Duraciones AS (
    SELECT
        User_id,
        DATEDIFF(SECOND, LoginTime, LogoutTime) AS Segundos  
        -- Calcula la diferencia en segundos entre el login y el logout de cada sesión

    FROM Sesiones
    WHERE LogoutTime IS NOT NULL

),
Totales AS (
    SELECT
        User_id,
        SUM(Segundos) AS TotalSegundos   
        -- Suma todos los segundos de todas las sesiones del usuario

    FROM Duraciones
    GROUP BY User_id
    -- Agrupa los datos por usuario para calcular el total individual
)
SELECT TOP 1
    User_id,
    TotalSegundos
FROM Totales
ORDER BY TotalSegundos DESC;
--- los ordena los registros el que tiene mas tiempo va primero 



WITH Sesiones AS (
    SELECT
        l1.User_id,
        l1.Fecha AS LoginTime,
        (
            SELECT MIN(l2.Fecha)
            FROM ccloglogin l2
            WHERE l2.User_id = l1.User_id
              AND l2.TipoMov = 1
              AND l2.Fecha > l1.Fecha
        ) AS LogoutTime
    FROM ccloglogin l1
    WHERE l1.TipoMov = 0
),
Duraciones AS (
    SELECT
        User_id,
        DATEDIFF(SECOND, LoginTime, LogoutTime) AS Segundos
    FROM Sesiones
    WHERE LogoutTime IS NOT NULL
),
Totales AS (
    SELECT
        User_id,
        SUM(Segundos) AS TotalSegundos
    FROM Duraciones
    GROUP BY User_id
)
SELECT TOP 1
    User_id,
    TotalSegundos
FROM Totales
ORDER BY TotalSegundos ASC;----->el que tiene menos tiempo 




