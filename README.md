# PruebaTecnica
Backend

Como iniciar el proyecto:
1. Configurar cadena de conexion ubicada en la ruta PruebaTecnica\Backend\ApiWeb\appsettings.json

{
  "ConnectionStrings": {
    "DefaultConnection": "" -> Informacion de tu cadena de conexion (nombre de base de datos, tipo de autenticacion y credenciales).
  },

  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}

2. Realizar migraciones de entity framework: En una terminal de comandos situarse en la ruta C:\Users\User\source\repos\stefanfayadp\PruebaTecnica\Backend\  y ejecutar el comando dotnet ef migrations add MigrationName -p BusinessLogic -s ApiWeb -o Data/Migrations

Frontend

1. npm install en el directorio raiz PruebaTecnica\Frontend\pruebatecnica para descargar depedencias
2. npm run start para iniciar el proyecto en ambiente de desarrollo el cual correra sobre la url http://localhost:4200