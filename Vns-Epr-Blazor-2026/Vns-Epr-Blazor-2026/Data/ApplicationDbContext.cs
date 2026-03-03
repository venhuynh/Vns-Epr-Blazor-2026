// Re-export ApplicationDbContext from Infrastructure layer for backward compatibility.
// All new code should use Vns.Erp.Infrastructure.Persistence.ApplicationDbContext directly.
global using ApplicationDbContext = Vns.Erp.Infrastructure.Persistence.ApplicationDbContext;

namespace Vns_Epr_Blazor_2026.Data;

// This file is kept for backward compatibility with existing Account components and Migrations.
// The actual ApplicationDbContext class is defined in Vns.Erp.Infrastructure.Persistence.
