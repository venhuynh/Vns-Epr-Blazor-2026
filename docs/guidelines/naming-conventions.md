# Naming Conventions — VNS ERP 2026

## C# Naming

| Element | Style | Ví dụ |
|---------|-------|-------|
| **Namespace** | PascalCase | `Vns.Erp.Inventory` |
| **Class / Struct** | PascalCase | `StockInOutMaster` |
| **Interface** | I + PascalCase | `IProductService` |
| **Method** | PascalCase | `GetProductsAsync()` |
| **Property** | PascalCase | `VoucherNumber` |
| **Public field** | PascalCase | `MaxRetryCount` |
| **Private field** | _camelCase | `_productService` |
| **Parameter** | camelCase | `productId` |
| **Local variable** | camelCase | `totalAmount` |
| **Constant** | PascalCase | `DefaultPageSize` |
| **Enum** | PascalCase | `StockInOutType.Purchase` |
| **Async method** | PascalCase + Async | `SaveOrderAsync()` |

## Blazor Components

| Element | Convention | Ví dụ |
|---------|-----------|-------|
| **Component file** | PascalCase.razor | `ProductList.razor` |
| **Code-behind** | PascalCase.razor.cs | `ProductList.razor.cs` |
| **CSS isolation** | PascalCase.razor.css | `ProductList.razor.css` |
| **Page route** | kebab-case | `@page "/stock-in-out"` |
| **Parameter** | PascalCase | `[Parameter] public int ProductId` |
| **EventCallback** | On + Event | `OnProductSelected` |

## Project & Namespace Structure

```
Vns.Erp.[Module].[Layer]

Ví dụ:
Vns.Erp.Inventory.Models
Vns.Erp.Inventory.Services
Vns.Erp.Inventory.Components
Vns.Erp.HumanResources.Models
```

## File & Folder Naming

| Element | Convention | Ví dụ |
|---------|-----------|-------|
| **Folder** | PascalCase | `StockInOut/`, `Components/` |
| **C# file** | PascalCase (match class) | `ProductService.cs` |
| **Razor file** | PascalCase | `ProductGrid.razor` |
| **CSS file** | kebab-case | `main-layout.css` |
| **JSON file** | kebab-case | `app-settings.json` |
| **Markdown** | kebab-case | `coding-standards.md` |

## Database Naming (Future)

| Element | Convention | Ví dụ |
|---------|-----------|-------|
| **Table** | PascalCase (plural) | `Products`, `StockInOutMasters` |
| **Column** | PascalCase | `VoucherNumber`, `CreatedAt` |
| **Primary Key** | Id | `Id` |
| **Foreign Key** | Entity + Id | `ProductId`, `WarehouseId` |
| **Index** | IX_{Table}_{Column} | `IX_Products_Code` |

## Common Abbreviations

| Viết tắt | Đầy đủ | Ghi chú |
|----------|--------|---------|
| `Dto` | Data Transfer Object | Dùng cho API models |
| `Bll` | Business Logic Layer | Dùng cho service classes |
| `Repo` | Repository | Dùng cho data access |
| `Vm` | ViewModel | Dùng cho UI binding |
