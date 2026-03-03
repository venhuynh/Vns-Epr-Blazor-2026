// Re-export ApplicationUser from Domain layer for backward compatibility.
// All new code should use Vns.Erp.Domain.Identity.ApplicationUser directly.
global using ApplicationUser = Vns.Erp.Domain.Identity.ApplicationUser;

namespace Vns_Epr_Blazor_2026.Data;

// This file is kept for backward compatibility with existing Account components.
// The actual ApplicationUser class is defined in Vns.Erp.Domain.Identity.
