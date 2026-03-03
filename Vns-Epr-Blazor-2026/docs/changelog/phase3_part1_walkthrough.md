# Walkthrough: Phase 3 Part 1 — Domain Entities + Initial CQRS

## Task 3.1: Translate XAF Master Data to Clean Architecture ✅

Translated 18 legacy XPO classes into 16 pure C# entities + 3 enums in `Vns.Erp.Domain/MasterData/`.

### Entities Created
- **Enums**: Gender, PartnerType, SiteType
- **Company**: Company, CompanyBranch, Department, Employee, Position
- **Partner**: BusinessPartner, BusinessPartnerCategory, BusinessPartnerContact, BusinessPartnerSite
- **ProductService**: ProductService, ProductServiceCategory, UnitOfMeasure, ProductAttribute, ProductAttributeValue, ProductVariant, VariantAttributeLink

### Transformation Rules
- All inherit from `AuditableEntity`; removed XPO attributes, `OnSaving()`, `ITreeNode`, computed properties
- `MediaDataObject` → `byte[]`, `ObservableCollection` → `List<T>`, explicit FK properties added

## Task 3.2 Part 1: CQRS for Company & UnitOfMeasure ✅

- Added MediatR + AutoMapper packages
- Extended `IApplicationDbContext` with 16 Master Data DbSets
- Created DTOs: `CompanyDto`, `UnitOfMeasureDto`
- Created `MasterDataMappingProfile` (AutoMapper)
- Implemented List queries + Create/Update commands for Company and UnitOfMeasure
- `DependencyInjection.cs` wired with assembly scanning
- Full solution build: 0 errors, 0 warnings
