# Prerequisitos para poder compilar el proyecto.
+ [Visual Studio 2019 16.8 o posterior](https://visualstudio.microsoft.com/es/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) con ASP.NET y la carga de trabajo de desarrollo web.
+ [.NET 3.1 SDK o posterior](https://dotnet.microsoft.com/download/dotnet/3.1)
+ En caso que quieras trabajar con el [Visual Studio Code](https://code.visualstudio.com/download) tienes que tener [dotnet](https://dotnet.microsoft.com/download/dotnet/3.1) para poder ejecutar los comandos desde la terminal

##  Creacion de base de datos
+ Crear una base de datos con el nombre que gusten ejemplo: ``test``
+ Copiar y pegar el contenido del archivo ``TABLAS`` Es desir ejecutarlos escriptenla bd recien creada y nos crearia 4 Tablas
## Datos del login
+ Usuario: ``supervisor``
+ Password: ``SUPERvisor1.``
##  Pre configuraciones para poder ejecutar el proyecto.

### Configuraciones para la carpeta proyecto es desir el proyecto sin compilar
+ Buscar dentro de la caperta proyecto el archivo ``appsettings.json`` que contiene lo siguiente
```JSON
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ProyectoCTX": "Server=DESKTOP-U4IFPH3;Database=prueba;User Id=snaven;Password=snaven"
  }
}
```
+ Modificar la cadena de conexion nos que daria asi siendo que tenemos como ``Servidor: DESKTOP-U4IFPH3``, ``Base de datos: test``, ``Usuario: snaven``, ``Password: snaven``
```JSON
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ProyectoCTX": "Server=DESKTOP-U4IFPH3;Database=test;User Id=snaven;Password=snaven"
  }
}
```
### Configuraciones para la carpeta publicado es desir el proyecto ya compilado
+ Buscar dentro de la caperta publicado el archivo ``appsettings.json`` que contiene lo siguiente
```JSON
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ProyectoCTX": "Server=DESKTOP-U4IFPH3;Database=prueba;User Id=snaven;Password=snaven"
  }
}
```
+ Modificar la cadena de conexion nos que daria asi siendo que tenemos como ``Servidor: DESKTOP-U4IFPH3``, ``Base de datos: test``, ``Usuario: snaven``, ``Password: snaven``
```JSON
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ProyectoCTX": "Server=DESKTOP-U4IFPH3;Database=test;User Id=snaven;Password=snaven"
  }
}
```
## Para poder ejecutar el proyecto tenemos varias opciones.

+ Podemos ejecutarlo desde el visual estudio.
+ Desde la terminal usando el comando ``dotnet run``
+ O desde la carpeta publicado quetiene el proyecto ya compilado solo es de buscar el ``proyecto.exe``

Anexo un video explicativo de como funciona el proyecto y las configuraciones nesesarias para poder ejecutar el mimos.
[Prueba Tecnica .NET CORE](https://youtu.be/O4_oQYbebtA)
