# Architecture Overview — VNS ERP 2026

## Render Mode: Blazor Interactive Auto

Dự án sử dụng mô hình **Interactive Auto**, kết hợp cả Server-Side Rendering và WebAssembly:

```
Lần đầu truy cập:
  Client → Server renders HTML (nhanh, không cần tải WASM)

Lần sau:
  Client → WebAssembly chạy trực tiếp (giảm tải server)
```

## Solution Architecture

```
┌─────────────────────────────────────────────────┐
│                   Solution                       │
├─────────────────────────────────────────────────┤
│                                                  │
│  ┌──────────────────────────────────────────┐   │
│  │        Vns-Epr-Blazor-2026.Shared        │   │
│  │         (Razor Class Library)             │   │
│  │  • Pages, Layouts, Components            │   │
│  │  • Services interfaces                   │   │
│  │  • DevExpress Blazor 25.2                │   │
│  └────────────┬──────────────┬──────────────┘   │
│               │              │                   │
│    ┌──────────▼───┐   ┌──────▼──────────┐       │
│    │   .Web       │   │   MAUI Hybrid   │       │
│    │  (Server)    │   │  (Mobile App)   │       │
│    │              │   │                 │       │
│    │ ASP.NET Core │   │ Android + iOS   │       │
│    │ Host WASM    │   │ BlazorWebView   │       │
│    └──────┬───────┘   │ DX MAUI 25.2    │       │
│           │           └─────────────────┘       │
│    ┌──────▼───────┐                              │
│    │ .Web.Client  │                              │
│    │  (WASM)      │                              │
│    │ Runs in      │                              │
│    │ Browser      │                              │
│    └──────────────┘                              │
└─────────────────────────────────────────────────┘
```

## Project Dependencies

| Project | References | Vai trò |
|---------|-----------|---------|
| **Shared** | — | UI components dùng chung |
| **Web** | → Web.Client | ASP.NET Core server host |
| **Web.Client** | → Shared | Blazor WASM client |
| **MAUI** | → Shared | Native mobile shell |

## Key Conventions

### Component Organization (Shared project)

```
Vns-Epr-Blazor-2026.Shared/
├── Layout/           # MainLayout, NavMenu
├── Pages/            # Route-able pages
├── Components/       # Reusable UI components (future)
│   ├── Common/       # Buttons, inputs, dialogs
│   └── [Module]/     # Module-specific components
├── Services/         # Service interfaces & shared impl
└── wwwroot/          # Static assets (CSS, images, fonts)
```

### Service Registration Pattern

```csharp
// Server-side service (Web/Program.cs)
builder.Services.AddScoped<IMyService, ServerMyService>();

// Client-side service (Web.Client/Program.cs)
builder.Services.AddScoped<IMyService, ClientMyService>();

// Interface defined in Shared project
public interface IMyService { ... }
```

## Technology Decisions

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Render Mode | Interactive Auto | Tốc độ load nhanh + giảm tải server |
| UI Components | DevExpress 25.2 | Enterprise-grade, rich features |
| Mobile | MAUI Hybrid | Share UI code with Web |
| State Management | TBD | Sẽ quyết định khi có business logic |
| Database | TBD | Sẽ quyết định dựa trên yêu cầu |
| Authentication | TBD | ASP.NET Core Identity hoặc External |
