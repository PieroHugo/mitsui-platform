using CrewWeb.VehixPlatform.API.Sale.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Sale.Domain.Model.Enumerations;

namespace CrewWeb.VehixPlatform.API.Sale.Application.Internals.DTOs;

/// <summary>
/// Resource returned in API responses.
/// </summary>
public class BillResource
{
    /// <summary>Generated bill number.</summary>
    public int BillNumber { get; set; }
    /// <summary>Customer name.</summary>
    public string Customer { get; set; } = string.Empty;
    /// <summary>Service identifier.</summary>
    public EService ServiceId { get; set; }
    /// <summary>Emission date.</summary>
    public DateTime Emission { get; set; }
    /// <summary>Invoice serial number.</summary>
    public string SerialNumber { get; set; } = string.Empty;
    /// <summary>Invoice sequential number.</summary>
    public string SequentialNumber { get; set; } = string.Empty;
    /// <summary>Amount.</summary>
    public double Amount { get; set; }
}
