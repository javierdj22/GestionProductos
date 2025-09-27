# Gestión de Productos - Blazor + MongoDB

## 🚀 Requisitos
- .NET 8 SDK
- MongoDB instalado y en ejecución (localhost:27017)

## ⚙️ Ejecución
1. Clonar el repositorio o copiar el proyecto.
2. Ejecutar en la raíz:
   ```bash
   dotnet build
   dotnet run --project GestionProductos
   ```
3. Abrir en el navegador: `https://localhost:50857/products`

## 💾 MongoDB
- Base de datos: `GestionProductosDb`
- Colección: `Products`
- Configuración en `appsettings.json`

## 🧪 Tests
Ejecutar:
```bash
dotnet test
```

## 📄 SQL de ejemplo
Archivo: `Scripts/query.sql`  
SELECT * FROM Productos WHERE Precio > 1000;
db.Products.find({ $expr: { $gt: [ { $toDouble: "$Price" }, 1000 ] } }).pretty()
Consulta todos los productos con precio mayor a 1000.
