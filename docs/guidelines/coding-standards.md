# Coding Standards — VNS ERP 2026

## Ngôn ngữ & Framework

- **C# 13** (latest) / **.NET 10**
- **Blazor** Razor components
- **DevExpress Blazor 25.2**

## C# Conventions

### General

- Sử dụng `file-scoped namespace` declarations
- Sử dụng `var` khi type rõ ràng từ context
- Luôn dùng braces `{}` cho `if`, `for`, `while` (kể cả 1 dòng)
- Prefer `switch expressions` over `switch statements`
- Sử dụng `string interpolation` thay vì `string.Format` hoặc concatenation

### Async/Await

```csharp
// ✅ Good — suffix Async, return Task
public async Task<List<Product>> GetProductsAsync()
{
    return await _repository.GetAllAsync();
}

// ❌ Bad — blocking call
public List<Product> GetProducts()
{
    return _repository.GetAllAsync().Result;
}
```

### Dependency Injection

```csharp
// ✅ Good — constructor injection
public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
}

// ✅ Also good — primary constructor (C# 12+)
public class ProductService(IProductRepository repository)
{
    public async Task<List<Product>> GetAllAsync()
        => await repository.GetAllAsync();
}
```

## Blazor Component Guidelines

### Component Structure

```razor
@* 1. Directives *@
@page "/products"
@using MyApp.Services
@inject IProductService ProductService

@* 2. Markup *@
<h1>Products</h1>
<DxGrid Data="@_products">
    ...
</DxGrid>

@* 3. Code block *@
@code {
    // 3a. Parameters
    [Parameter] public string? Category { get; set; }

    // 3b. Private fields
    private List<Product> _products = [];

    // 3c. Lifecycle methods
    protected override async Task OnInitializedAsync()
    {
        _products = await ProductService.GetAllAsync();
    }

    // 3d. Event handlers
    private async Task OnDeleteClick(Product product) { }

    // 3e. Helper methods
    private string GetStatusCss(ProductStatus status) => ...;
}
```

### DevExpress Components

- Prefer **DevExpress components** over HTML elements khi có thể
- Sử dụng `DxGrid` cho data grids, `DxFormLayout` cho forms
- Dùng `DxButton`, `DxTextBox`, v.v. thay vì HTML `<button>`, `<input>`

## File Organization

- **1 component per file** — không đặt nhiều component trong 1 file
- **Code-behind** (`*.razor.cs`) cho components phức tạp (>50 lines code)
- **CSS isolation** (`*.razor.css`) cho component-specific styles

## Error Handling

```csharp
// ✅ Good — specific exception, meaningful message
try
{
    await _service.SaveAsync(entity);
}
catch (DbUpdateException ex)
{
    Logger.LogError(ex, "Failed to save {EntityType} with ID {Id}", typeof(T).Name, entity.Id);
    throw;
}
```

## Comments

- Viết **code comments bằng tiếng Anh**
- Comment **WHY**, không comment **WHAT** (code nên tự giải thích)
- Sử dụng XML docs (`///`) cho public APIs
