# Phase 1 — Scaffolding Multi-Project Structure

## Setup Foundation Files
- [x] Create `Directory.Build.props` (shared MSBuild properties)
- [x] Create `Directory.Packages.props` (central package management)
- [x] Create `global.json` (SDK pinning)
- [x] Create `.editorconfig`
- [x] Create `nuget.config` (with DevExpress authenticated feed + source mapping)

## Create Project Files
- [x] Create `Vns.Erp.Domain` project
- [x] Create `Vns.Erp.Application` project
- [x] Create `Vns.Erp.Infrastructure` project
- [x] Create `Vns.Erp.Blazor.Shared` project
- [x] Update existing project as `Vns-Epr-Blazor-2026` (Web host)
- [x] Create `Vns.Erp.Tests.Unit` project

## Migrate Existing Code
- [x] Move `ApplicationUser` → Domain/Identity (with backward-compat alias in Data)
- [x] Move `ApplicationDbContext` → Infrastructure/Persistence (with backward-compat alias in Data)
- [x] Move `OpenAIServiceSettings` → Infrastructure/ExternalServices/OpenAI
- [x] Create `DrawerStateComponentBase` in Blazor.Shared
- [x] Create `Drawer` component in Blazor.Shared/Layout

## Update Solution & Composition Root
- [x] Update `.slnx` with all projects + solution folders
- [x] Update `Program.cs` with `AddApplication()` / `AddInfrastructure()` DI
- [x] Create `DependencyInjection.cs` in Application & Infrastructure

## Verification
- [x] Build solution successfully (0 errors, 14 pre-existing BL0008 warnings)
- [x] All project references resolve
