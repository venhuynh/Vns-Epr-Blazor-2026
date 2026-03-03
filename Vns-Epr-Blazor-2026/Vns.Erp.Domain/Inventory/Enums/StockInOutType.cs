namespace Vns.Erp.Domain.Inventory.Enums;

/// <summary>
/// Defines the type of inventory stock transaction.
/// </summary>
public enum StockInOutType
{
    /// <summary>Goods received into warehouse.</summary>
    StockIn = 1,

    /// <summary>Goods issued out of warehouse.</summary>
    StockOut = 2,

    /// <summary>Transfer between warehouses.</summary>
    Transfer = 3,

    /// <summary>Stock adjustment (count correction, damage write-off, etc.).</summary>
    Adjustment = 4
}
