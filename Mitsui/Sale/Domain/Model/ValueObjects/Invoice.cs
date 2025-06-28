namespace Mitsui.Sale.Domain.Model.ValueObjects;

/// <summary>
/// Invoice number composed by serial and sequential parts.
/// </summary>
public class Invoice
{
    /// <summary>Invoice serial number.</summary>
    public string SerialNumber { get; set; } = string.Empty;

    /// <summary>Invoice sequential number.</summary>
    public string SequentialNumber { get; set; } = string.Empty;
}
