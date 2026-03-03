using Vns.Erp.Domain.Common;
using Vns.Erp.Domain.Inventory.Enums;

namespace Vns.Erp.Domain.Inventory.Entities;

/// <summary>
/// Header entity for an inventory transaction (stock-in, stock-out, transfer, adjustment).
/// Contains voucher-level information and owns a collection of <see cref="StockInOutDetail"/> line items.
/// </summary>
public class StockInOutMaster : AuditableEntity
{
    /// <summary>Auto-generated voucher number (e.g., SI-20260301-001).</summary>
    public string VoucherNumber { get; set; } = string.Empty;

    /// <summary>Date of the inventory transaction.</summary>
    public DateTime StockInOutDate { get; set; }

    /// <summary>Type of inventory transaction.</summary>
    public StockInOutType StockInOutType { get; set; }

    /// <summary>Source warehouse code (origin for transfers/stock-out).</summary>
    public string WarehouseCode { get; set; } = string.Empty;

    /// <summary>Destination warehouse code (for transfers only).</summary>
    public string? DestinationWarehouseCode { get; set; }

    /// <summary>Free-text description or notes for this transaction.</summary>
    public string? Description { get; set; }

    /// <summary>Reference document number (e.g., PO number, SO number).</summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>Whether this transaction has been approved/posted.</summary>
    public bool IsPosted { get; set; }

    /// <summary>Date when the transaction was posted.</summary>
    public DateTime? PostedDate { get; set; }

    // Navigation properties
    private readonly List<StockInOutDetail> _details = [];

    /// <summary>Line items belonging to this transaction.</summary>
    public IReadOnlyCollection<StockInOutDetail> Details => _details.AsReadOnly();

    /// <summary>Adds a detail line to this master transaction.</summary>
    public void AddDetail(StockInOutDetail detail)
    {
        detail.StockInOutMasterId = Id;
        _details.Add(detail);
    }

    /// <summary>Removes a detail line from this master transaction.</summary>
    public void RemoveDetail(StockInOutDetail detail)
    {
        _details.Remove(detail);
    }
}
