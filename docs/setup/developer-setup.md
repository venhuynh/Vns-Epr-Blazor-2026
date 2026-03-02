# Developer Setup — VNS ERP 2026

Hướng dẫn cài đặt môi trường phát triển.

## Prerequisites

### 1. .NET 10 SDK

Download và cài đặt [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).

```bash
# Kiểm tra version
dotnet --version
# Expected: 10.0.x
```

### 2. IDE

Chọn một trong hai:

- **Visual Studio 2022** (17.12+) — Recommended
  - Workloads: ASP.NET, .NET MAUI
- **VS Code** + C# Dev Kit extension

### 3. DevExpress License

Yêu cầu **DevExpress Universal Subscription** (v25.2).

#### Cấu hình NuGet Feed

```bash
# Thêm DevExpress NuGet source
dotnet nuget add source "https://nuget.devexpress.com/api" \
  --name "DevExpress" \
  --username "DevExpress" \
  --password "<YOUR_NUGET_KEY>"
```

> **Lấy NuGet Key**: Đăng nhập [devexpress.com](https://www.devexpress.com/) → My Account → Download → NuGet Feed URL.

### 4. Git

```bash
# Cấu hình Git
git config --global user.name "Your Name"
git config --global user.email "your.email@company.com"
```

## Clone & Run

```bash
# Clone repository
git clone https://github.com/venhuynh/Vns-Epr-Blazor-2026.git
cd Vns-Epr-Blazor-2026

# Restore packages
dotnet restore Vns-Epr-Blazor-2026/Vns-Epr-Blazor-2026.sln

# Run Web app
dotnet run --project Vns-Epr-Blazor-2026/Vns-Epr-Blazor-2026.Web
```

Mở browser tại `https://localhost:5001` (hoặc port hiển thị trong terminal).

## Project Structure Overview

```
Vns-Epr-Blazor-2026/
├── .editorconfig               # Code style rules
├── Directory.Build.props        # Shared MSBuild properties
├── docs/                        # Tài liệu dự án
├── .github/                     # GitHub templates & CI/CD
└── Vns-Epr-Blazor-2026/        # Source code
    ├── Vns-Epr-Blazor-2026.sln
    ├── *.Shared/                # Shared UI (Razor Class Library)
    ├── *.Web/                   # ASP.NET Core Server
    ├── *.Web.Client/            # Blazor WebAssembly
    └── Vns-Epr-Blazor-2026/    # .NET MAUI Hybrid
```

## Troubleshooting

### DevExpress packages not found
Kiểm tra NuGet source đã được cấu hình đúng:
```bash
dotnet nuget list source
```

### MAUI build fails
Cài đặt MAUI workload:
```bash
dotnet workload install maui
```

### Port conflicts
Thay đổi port trong `Properties/launchSettings.json` của project Web.
