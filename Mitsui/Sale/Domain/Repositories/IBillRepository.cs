using CrewWeb.VehixPlatform.API.Sale.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Sale.Domain.Model.ValueObjects;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.Sale.Domain.Repositories;

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
