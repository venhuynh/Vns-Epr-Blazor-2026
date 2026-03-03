# Vns-Epr-Blazor-2026: Implementation Plan & State Tracker

## Current Context
We are migrating from a Monolith architecture to a Clean Architecture multi-project solution. 
- **Current Phase:** Phase 2 — Identity & Security

## Task Checklist

### Phase 1 — Foundation (COMPLETED)
- [x] 1.1. Create multi-project structure (6 projects) and `.slnx` file.
- [x] 1.2. Setup central configuration files: `Directory.Build.props`, `Directory.Packages.props`, and `global.json`.
- [x] 1.3. Setup Base Entities (`BaseEntity`, `AuditableEntity`) and `ApplicationUser` in Domain Layer.
- [x] 1.4. Setup Dependency Injection (`AddApplication`, `AddInfrastructure`) and EF Core Context.
- [x] 1.5. Configure backward compatibility for existing Account Identity pages using global aliases.
- [x] 1.6. Resolved 14 BL0008 warnings in Identity pages — replaced `= new()` with `= default!` on `[SupplyParameterFromForm]` properties. Build now pristine: 0 warnings, 0 errors.
- [x] 1.7. Codebase pushed to GitHub: https://github.com/venhuynh/Vns-Epr-Blazor-2026 (branch: `main`).
- [x] 1.8. Exported Phase 1 session artifacts to `docs/` folder (`architecture/`, `changelog/`, `tasks/`).
- [x] 1.9. Fixed EditForm null Model runtime exception in Identity pages — added `Input ??= new();` in lifecycle methods before any `await` calls.

### Phase 2 — Identity & Security (Pending)
- [x] 2.1. Define ApplicationRole and extend ApplicationUser (if needed) in Domain.
- [x] 2.2. Configure Role-Based Access Control (RBAC) and Claims in Infrastructure.
- [x] 2.3. Create DbSeeders for default Admin user and base roles (e.g., SuperAdmin, WarehouseManager).
- [ ] 2.4. Finalize Blazor Identity UI and ensure AuthenticationStateProvider is fully functional.

### Phase 3 — Master Data Module (Pending)
- [ ] 3.1. Build Domain entities for Master Data (e.g., Warehouse, UnitOfMeasure, ItemCategory, Product).
- [ ] 3.2. Create Application layer MediatR Commands/Queries and DTOs for Master Data.
- [ ] 3.3. Implement EF Core Configurations and build DevExpress CRUD UIs for Master Data.

### Phase 4 — Inventory Module (Pending)
- [ ] 4.1. Build Domain entities (StockInOutMaster, StockInOutDetail, InventoryBalance) linked to Master Data. *(Early domain entities already created in `Vns.Erp.Domain/Inventory/`)*
- [ ] 4.2. Implement Inventory Application logic (CQRS) and Domain Events.
- [ ] 4.3. Build DevExpress Blazor UI (DxGrid, DxFormLayout) for Stock Operations.

- [x] 1.10. Created `docs/TROUBLESHOOTING.md` to document PostgreSQL port conflicts and authentication fixes.
- [x] 1.11. Fixed Identity routing and sign-in by forcing Static SSR on Shared Account components.

> **Note:** Updated roadmap to Identity → Master Data → Inventory per Solution Architect review (2026-03-03).

## AI Agent Instructions
Before starting a new prompt, read this file to understand the current progress. When a sub-task is successfully completed and verified, check the box [x] and write a brief 1-sentence summary of the implementation here.
