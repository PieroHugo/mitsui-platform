using Cortex.Mediator.Commands;
using Mitsui.Sale.Application.Internals.DTOs;
using Mitsui.Sale.Domain.Model.Enumerations;

namespace Mitsui.Sale.Application.Internals.Commands;

/// <summary>
/// Command to create a bill.
/// </summary>
public class CreateBillCommand : ICommand<BillResource>
{
    /// <summary>Customer name.</summary>
    public string Customer { get; init; } = string.Empty;
    /// <summary>Service identifier.</summary>
    public EService ServiceId { get; init; }
    /// <summary>Plate number.</summary>
    public string? Plate { get; init; }
    /// <summary>Emission date.</summary>
    public DateTime Emission { get; init; }
    /// <summary>Invoice serial number.</summary>
    public string SerialNumber { get; init; } = string.Empty;
    /// <summary>Invoice sequential number.</summary>
    public string SequentialNumber { get; init; } = string.Empty;
    /// <summary>Bill amount.</summary>
    public double Amount { get; init; }
}
