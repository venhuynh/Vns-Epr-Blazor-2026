# VNS ERP Blazor 2026

[![Build Status](https://github.com/venhuynh/Vns-Epr-Blazor-2026/actions/workflows/build.yml/badge.svg)](https://github.com/venhuynh/Vns-Epr-Blazor-2026/actions)
[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4)](https://dotnet.microsoft.com/)
[![DevExpress](https://img.shields.io/badge/DevExpress-25.2-FF7200)](https://www.devexpress.com/)
[![License](https://img.shields.io/badge/License-Proprietary-red)](LICENSE)

> Hệ thống quản lý doanh nghiệp (ERP) đa nền tảng được xây dựng trên .NET 10, Blazor và .NET MAUI.

## 🏗️ Tech Stack

| Layer | Technology |
|-------|-----------|
| **Framework** | .NET 10.0 |
| **Web UI** | Blazor Interactive Auto (Server + WebAssembly) |
| **Mobile** | .NET MAUI Hybrid (Android + iOS) |
| **UI Components** | DevExpress Blazor 25.2 / DevExpress MAUI 25.2 |

## 📁 Solution Structure

```
Vns-Epr-Blazor-2026/
├── Vns-Epr-Blazor-2026.Shared       # Razor Class Library (shared UI)
├── Vns-Epr-Blazor-2026.Web           # ASP.NET Core Server
├── Vns-Epr-Blazor-2026.Web.Client    # Blazor WebAssembly Client
└── Vns-Epr-Blazor-2026                # .NET MAUI Hybrid App
```

## 🚀 Quick Start

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Visual Studio 2022 17.12+](https://visualstudio.microsoft.com/) hoặc [VS Code](https://code.visualstudio.com/)
- [DevExpress Universal Subscription](https://www.devexpress.com/) (v25.2)
- DevExpress NuGet Feed configured

### Run the Web App

```bash
cd Vns-Epr-Blazor-2026
dotnet run --project Vns-Epr-Blazor-2026.Web
```

### Run the MAUI App

```bash
cd Vns-Epr-Blazor-2026
dotnet build Vns-Epr-Blazor-2026/Vns-Epr-Blazor-2026.csproj -f net10.0-android
```

## 📖 Documentation

Xem thêm tại thư mục [`docs/`](docs/README.md):

- [Architecture Overview](docs/architecture/overview.md)
- [Developer Setup](docs/setup/developer-setup.md)
- [Coding Standards](docs/guidelines/coding-standards.md)
- [Git Workflow](docs/guidelines/git-workflow.md)
- [Naming Conventions](docs/guidelines/naming-conventions.md)

## 📋 Changelog

Xem [CHANGELOG.md](CHANGELOG.md) để theo dõi lịch sử thay đổi.

## 👥 Team

- **VNS Technology** — Development & Maintenance

## 📄 License

Proprietary — © VNS Technology 2024-2026. All rights reserved.
