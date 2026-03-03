using Vns.Erp.Domain.Common;

namespace Vns.Erp.Domain.Inventory.Entities;

/// <summary>
/// Represents the current stock balance of a specific item in a specific warehouse.
/// Updated whenever a stock transaction is posted.
/// </summary>
public class InventoryBalance : BaseEntity
{
    /// <summary>Warehouse code where this balance applies.</summary>
    public string WarehouseCode { get; set; } = string.Empty;

    /// <summary>Item/product code.</summary>
    public string ItemCode { get; set; } = string.Empty;

    /// <summary>Descriptive name of the item (denormalized for query performance).</summary>
    public string ItemName { get; set; } = string.Empty;

    /// <summary>Current quantity on hand.</summary>
    public decimal QuantityOnHand { get; set; }

    /// <summary>Average cost per unit.</summary>
    public decimal AverageCost { get; set; }

    /// <summary>Total inventory value (QuantityOnHand × AverageCost).</summary>
    public decimal TotalValue => QuantityOnHand * AverageCost;

    /// <summary>Timestamp of the last stock movement affecting this balance.</summary>
    public DateTime? LastMovementDate { get; set; }
}
