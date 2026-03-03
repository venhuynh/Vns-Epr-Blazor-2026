using Vns.Erp.Domain.Common;

namespace Vns.Erp.Domain.Inventory.Entities;

/// <summary>
/// Line item entity for an inventory transaction.
/// Represents a single item movement (quantity, unit price) within a <see cref="StockInOutMaster"/>.
/// </summary>
public class StockInOutDetail : AuditableEntity
{
    /// <summary>Foreign key to the parent transaction header.</summary>
    public Guid StockInOutMasterId { get; set; }

    /// <summary>Item/product code.</summary>
    public string ItemCode { get; set; } = string.Empty;

    /// <summary>Descriptive name of the item.</summary>
    public string ItemName { get; set; } = string.Empty;

    /// <summary>Unit of measure (e.g., PCS, KG, BOX).</summary>
    public string? UnitOfMeasure { get; set; }

    /// <summary>Quantity of items in this line.</summary>
    public decimal Quantity { get; set; }

    /// <summary>Unit price per item.</summary>
    public decimal UnitPrice { get; set; }

    /// <summary>Total amount for this line (Quantity × UnitPrice).</summary>
    public decimal TotalAmount => Quantity * UnitPrice;

    /// <summary>Batch or lot number for traceability.</summary>
    public string? BatchNumber { get; set; }

    /// <summary>Optional remarks for this line item.</summary>
    public string? Remarks { get; set; }

    // Navigation property
    /// <summary>Parent transaction header.</summary>
    public StockInOutMaster? StockInOutMaster { get; set; }
}
