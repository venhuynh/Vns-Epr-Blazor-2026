# Task 3.2 (Part 1): CQRS for Company & UnitOfMeasure — COMPLETED

## Checklist

- [x] Explore existing Application layer structure and dependencies
- [x] Add MediatR + AutoMapper packages (`Directory.Packages.props`, `Application.csproj`)
- [x] Extend `IApplicationDbContext` with 16 Master Data DbSets
- [x] Update `ApplicationDbContext` to implement new DbSets
- [x] Create DTOs: `CompanyDto`, `UnitOfMeasureDto`
- [x] Create `MasterDataMappingProfile` (AutoMapper)
- [x] Implement CQRS for `UnitOfMeasure` (List, Create, Update)
- [x] Implement CQRS for `Company` (List, Create, Update)
- [x] Update `DependencyInjection.cs` with MediatR + AutoMapper registration
- [x] Full solution build: 0 errors, 0 warnings
- [x] Update `IMPLEMENTATION_PLAN.md`
