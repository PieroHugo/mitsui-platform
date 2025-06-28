using Mitsui.Sale.Domain.Model.Entities;
using Mitsui.Sale.Domain.Model.ValueObjects;
using Mitsui.Shared.Domain.Repositories;

namespace Mitsui.Sale.Domain.Repositories;

/// <summary>
/// Repository contract for bills.
/// </summary>
public interface IBillRepository : IBaseRepository<Bill>
{
    /// <summary>Find a bill by its invoice.</summary>
    /// <param name="invoice">Invoice value object</param>
    /// <returns>The bill if found.</returns>
    Task<Bill?> FindByInvoiceAsync(Invoice invoice);
}
